using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_EDIIKM.Models;
using Lab1_EDIIKM.Utils;
using System.Text.Json;
using LibArbolB;
using System.Text;
using System.IO;
using Newtonsoft.Json;


namespace Lab1_EDIIKM.Controllers
	
{
	[Route("api/[controller]")]
	[ApiController]
	public class PeliculasController : Controller
	{
		[HttpGet]
		public List<Peliculas> GetMovies()
		{
			return new List<Peliculas>();
		}

		[HttpGet]
		[Route("{traversal}")]
		public List<Peliculas> Recorrido(string traversal)
		{
            try
            {
                return Storage.Instance.ArbolP.Ir(traversal);
            }
            catch (Exception)
            {
                //return StatusCode(500);
                throw;
            }
		}

        [HttpPost]
        [Route("populate")]        
        public ActionResult Post([FromBody] Peliculas Nuevo)
        {
            try
            {
                Storage.Instance.ArbolP.Agregar(Nuevo);
                return Created("", Nuevo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{delete}")]
        public ActionResult Delete(string delete)
        {

            try
            {
                if (delete == "delete")
                {
                    Storage.Instance.ArbolP = new ArbolB<Peliculas>(5);
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return StatusCode(500);
        }


        [HttpPost]
		public IActionResult Post([FromBody] propiedades grado)
		{
			try
            {
				int valor = grado.Grado;
				Storage.Instance.ArbolP = new ArbolB<Peliculas>(valor);
                return Created("", grado);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

		[HttpPost]
		[Route("import")]
		public IActionResult PostFileP([FromForm] IFormFile File)
		{
			using var content = new MemoryStream();
			try
			{
				File.CopyToAsync(content);
				var text = Encoding.ASCII.GetString(content.ToArray());
				var pelicula = JsonConvert.DeserializeObject<List<Peliculas>>(text);
				foreach (var item in pelicula)
				{
					Storage.Instance.ArbolP.Agregar(item);
				}
				return Ok();
			}
			catch
			{
				return StatusCode(500);
			}
		}

        //[Route("populate")]
        //[HttpDelete("{Title}")]
        //public ActionResult DeleteV(string Title)
        //{
        //    Peliculas eliminar = new Peliculas();
        //    eliminar.Title = Title;
        //    if (Storage.Instance.ArbolP.Eliminar(eliminar))
        //    {
        //        return Ok();
        //    }

        //    return NotFound();
        //}

    }

}
