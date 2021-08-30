using System;
using System.Collections.Generic;
using LibArbolB;

namespace ArbolB_Consola
{
    class Program
    {
        private static List<int> lista;

        static void Main(string[] args)
        {
            Arbol:
            Console.WriteLine("Ingrese grado del Árbol");
            try
            {
                int grado = Convert.ToInt32(Console.ReadLine());
                ArbolB<int> ArbolB = new ArbolB<int>(grado);

                bool valores = true;
                do
                {
                Insertar:
                    Console.WriteLine($"{Environment.NewLine}Ingrese un valor entero");
                    try
                    {
                        ArbolB.Agregar(Convert.ToInt32(Console.ReadLine()));
                         Console.WriteLine("Para insertar otro valor, escriba 'ok'. De lo contrario, presione enter ");
                        if (Console.ReadLine() != "ok")
                        {
                            valores = false;
                        }


                    
                    }
                    catch
                    {
                        Console.WriteLine("Ingrese un valor válido");
                        Console.ReadLine();
                        goto Insertar;
                    }
                } while (valores);
                bool recorrido = true;
				do
				{
                recorrido:
                    Console.WriteLine("Escriba el tipo de recorrido que quiere realizar (preorder, postorder, inorder)");
                    string ruta = Console.ReadLine();
					if (ruta == "preorder" || ruta == "inorder" || ruta == "postorder")
					{
                        lista = ArbolB.Ir(ruta);
					}
					else
					{
                        Console.WriteLine("Ingrese un recorrido válido");
                        Console.ReadLine();
                        goto recorrido;
					}
					if (lista != null)
					{
						foreach (var item in lista)
						{
                            Console.WriteLine(item.ToString());
						}
					}

                    Console.WriteLine("Para realizar otro recorrido, escriba 'ok'. De lo contrario, presione enter");
                    if (Console.ReadLine() != "ok")
                    {
                        recorrido = false;
                    }
                } while (recorrido);
            }
            catch (Exception)
            {
                Console.WriteLine("Ingrese valor válido");
                Console.ReadLine();
                goto Arbol;

                throw;
            }
            
        }
    }
}
