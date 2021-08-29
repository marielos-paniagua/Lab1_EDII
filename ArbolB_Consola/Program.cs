using System;
using System.Collections.Generic;

namespace ArbolB_Consola
{
    class Program
    {
        private static List<int> lista;

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese grado del Árbol");
            try
            {
                int grado = Convert.ToInt32(Console.ReadLine());
                ArbolB<int> ArbolB = new ArbolB<int>();

                bool valores = true;
                do
                {
                Insertar:
                    Console.WriteLine($"{Environment.NewLine}Ingrese un valor entero");
                    try
                    {

                    }
                    catch
                    {
                        Console.WriteLine("Ingrese un valor válido");
                        Console.ReadLine();
                        goto Insertar;
                    }
                } while (valores);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
