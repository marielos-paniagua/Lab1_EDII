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
			return Storage.Instance.ArbolP.Ir(traversal);
		}



		[HttpPost]
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
			if (delete == "delete")
			{
				Storage.Instance.ArbolP = new ArbolB<Peliculas>(5);
				return Ok();
			}

			return NotFound();
		}

		
	}

}
