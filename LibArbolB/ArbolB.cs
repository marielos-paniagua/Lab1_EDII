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
        private bool SeparaR = false;
        private int contH = 0;

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
                if (nodo.espacio() && nodo.Hijos[0] == null)
                {
                    nodo.Agregar(valor);
                    if (!nodo.espacio())
                    {
                        if (!SeparaR)
                        {
                            SepararR(valor, nodo);
                        }
                        else
                        {
                            Separar(valor, nodo);
                        }
                        
                    }
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
                                if (valor.CompareTo(nodo.Valor[i + 1]) > 0) 
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

        private void SepararR(T valor, Nodo<T> nodo)
        {
            Nodo<T> temp = new Nodo<T>(valor, Grado);
            for (int i = 0; i < nodo.Valor.Length; i++)
            {
                temp.Valor[i] = nodo.Valor[i];
            }

            nodo = new Nodo<T>(temp.Valor[0], Grado);
            nodo.Valor[0] = temp.Valor[temp.Valor.Length / 2];

            nodo.Hijos[0] = new Nodo<T>(valor, Grado);
            for (int i = 0; i < (nodo.Valor.Length / 2); i++)
            {
                nodo.Hijos[0].Valor[i] = temp.Valor[i];
            }
            int cont = 0;

            nodo.Hijos[1] = new Nodo<T>(valor, Grado);
            for (int i = (nodo.Valor.Length / 2) + 1; i < nodo.Valor.Length; i++)
            {
                nodo.Hijos[1].Valor[cont] = temp.Valor[i];
                cont++;
            }
            ruta = nodo;
            SeparaR = true;
            contH++;
        }

        private void Separar(T valor, Nodo<T> nodo)
        {
            Nodo<T> temp = new Nodo<T>(valor, Grado);
            for (int i = 0; i < nodo.Valor.Length; i++)
            {
                temp.Valor[i] = nodo.Valor[i];
            }

            int cont = 0;
            for (int i = (nodo.Valor.Length / 2); i < nodo.Valor.Length; i++)
            {
                nodo.Valor[i] = default(T);
            }

            Nodo<T> drc = new Nodo<T>(valor, Grado);
            cont = 0;
            for (int i = (nodo.Valor.Length / 2) + 1; i < nodo.Valor.Length; i++)
            {
                drc.Valor[cont] = temp.Valor[i];
                cont++;
            }

            cont = 0;
            ruta.Agregar(temp.Valor[temp.Valor.Length / 2]);
            for (int i = ruta.Valor.Length - 1; i > 0; i--)
            {
                int j;
                if (drc.Valor[0].CompareTo(ruta.Valor[i]) < 0)
                {
                    for (j = contH; j > 0; j--)
                    {
                        if (nodo.Valor[0].CompareTo(ruta.Hijos[j].Valor[0]) == 0)
                        {                            
                            break;
                        }
                        ruta.Hijos[j + 1] = ruta.Hijos[j];
                    }
                    ruta.Hijos[j + 1] = drc;
                    contH++;
                    i = 0;
                }
            }
        }

        public T buscar(T valor)
		{
            return Get(valor, ruta);
		}

        private T Get(T valor, Nodo<T> nodo)
		{
			for (int i = 0; i < nodo.Valor.Length; i++)
			{
				if (valor.CompareTo(nodo.Valor[i])<0)
				{
                    return Get(valor, nodo.Hijos[i]);
				}
                else if (valor.CompareTo(nodo.Valor[i]) > 0)
                {
                    return Get(valor, nodo.Hijos[i + 1]);
                }
                else if (valor.CompareTo(nodo.Valor[i]) == 0)
                {
                    return nodo.Valor[i];
                }
            }
            return default;
		}

        public List<T> Ir(string recorrido)
		{
            List.Clear();
			if (recorrido == "preorder")
			{
                PreOrder(ruta);
			}
			else if (recorrido == "inorder")
			{
                InOrder(ruta);
			
            }else if(recorrido == "postorder")
			{
                PostOrder(ruta);
			}
            return List;
		}

        private void PreOrder(Nodo<T> nodo)
        {
            for (int i = 0; i < nodo.Valor.Length; i++)
            {
                if (!(EqualityComparer<T>.Default.Equals(nodo.Valor[i], default(T))))
                {
                    List.Add(nodo.Valor[i]);
                }
            }
            for (int j = 0; j < nodo.Valor.Length + 1; j++)
            {
                if (nodo.Hijos[j] != null)
                {
                    PreOrder(nodo.Hijos[j]);
                }
            }
        }

        private void InOrder(Nodo<T> nodo)
        {
            for (int i = 0; i < nodo.Valor.Length; i++)
            {
                if (i == 0)
                {
                    if (nodo.Hijos[i] != null)
                    {
                        InOrder(nodo.Hijos[i]);
                    }
                }
                if (!(EqualityComparer<T>.Default.Equals(nodo.Valor[i], default(T))))
                {
                    List.Add(nodo.Valor[i]);
                    if (nodo.Hijos[i + 1] != null)
                    {
                        InOrder(nodo.Hijos[i + 1]);
                    }
                }
            }
        }

        private void PostOrder(Nodo<T> nodo)
        {
            for (int j = 0; j < nodo.Valor.Length + 1; j++)
            {
                if (nodo.Hijos[j] != null)
                {
                    PostOrder(nodo.Hijos[j]);
                }
            }
            for (int i = 0; i < nodo.Valor.Length; i++)
            {
                if (!(EqualityComparer<T>.Default.Equals(nodo.Valor[i], default(T))))
                {
                    List.Add(nodo.Valor[i]);
                }
            }
        }

    }
}
