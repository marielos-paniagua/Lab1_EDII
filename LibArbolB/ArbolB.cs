using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LibArbolB
{
    public class ArbolB<T> where T : IComparable
    {
        private int Grado;
        private Nodo<T> ruta;
        private List<T> List = new List<T>();

        public ArbolB(int grado)
        {
            Grado = grado;
        }

        public void Agregar(T valor)
        {
            Insertar(valor, ruta);
        }

        private void Insertar(T valor, Nodo<T> nodo)
        {
            if (nodo != null)
            {
                if (nodo.espacio())
                {
                    nodo.Agregar(valor);
                }
                else
                {
                    for (int i = 0; i < Grado - 1; i++)
                    {
                        if (valor.CompareTo(nodo.Valor[i]) < 0)
                        {
                            if (i - 1 > -1)
                            {
                                if (valor.CompareTo(nodo.Valor[i-1]) > 0)
                                {
                                    if (nodo.Hijos[i] == null)
                                    {
                                        nodo.Hijos[i] = new Nodo<T>(valor, Grado);
                                    }
                                    else
                                    {
                                        Insertar(valor, nodo.Hijos[i]);
                                    }
                                    i = Grado;
                                }
                            }
                            else
                            {
                                if (nodo.Hijos[i] == null)
                                {
                                    nodo.Hijos[i] = new Nodo<T>(valor, Grado);
                                }
                                else
                                {
                                    Insertar(valor, nodo.Hijos[i]);
                                }
                                i = Grado;
                            }
                        }
                        else if (valor.CompareTo(nodo.Valor[i]) > 0)
                        {
                            if (i + 1 < nodo.Valor.Length)
                            {
                                if (valor.CompareTo(nodo.Valor[i + 1]) < 0)
                                {
                                    if (nodo.Hijos[i + 1] == null)
                                    {
                                        nodo.Hijos[i + 1] = new Nodo<T>(valor, Grado);
                                    }
                                    else
                                    {
                                        Insertar(valor, nodo.Hijos[i + 1]);
                                    }
                                    i = Grado;
                                }
                            }
                            else
                            {
                                if (nodo.Hijos[i + 1] == null)
                                {
                                    nodo.Hijos[i + 1] = new Nodo<T>(valor, Grado);
                                }
                                else
                                {
                                    Insertar(valor, nodo.Hijos[i + 1]);
                                }
                                i = Grado;
                            }
                        }
                        else
                        {
                            i = (Grado - 1);
                        }
                    }
                }
            }
            else if (nodo == ruta)
            {
                ruta = new Nodo<T>(valor, Grado);
            }
        }


    }
}
