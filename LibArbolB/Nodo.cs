using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;

namespace LibArbolB
{
    class Nodo<T> where T : IComparable 
    {
        public T[] Valor;
        public Nodo<T>[] Hijos;
        private List<T> Lista = new List<T>();

        public bool espacio()
        {
            foreach (var item in Valor)
            {
                if (EqualityComparer<T>.Default.Equals(item, default(T)))
                {
                    return true;
                }
            }
            return false;
        }

        public Nodo(T val, int grado)
        {
            Valor = new T[grado - 1];
            Hijos = new Nodo<T>[grado];
            Valor[0] = val;
        }

        public void Agregar(T val)
        {
            for (int i = 0; i < Valor.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(Valor[i], default(T)))
                {
                    Valor[i] = val;
                    i = Valor.Length;
         
                }
            }
            NodoGrado();
        }

        public void NodoGrado()
        {
            T temp;
            for (int i = 0; i < Valor.Length - 1; i++)
            {
                for (int j = i+1; j < Valor.Length; j++)
                {
                    if (Valor[j] == null)
                    {
                        i = Valor.Length - 1;
                        j = Valor.Length;
                    }
                    else
                    {
                        if (Valor[i].CompareTo(Valor[j]) > 0)
                        {
                            temp = Valor[i];
                            Valor[i] = Valor[j];
                            Valor[j] = temp;
                        }                    
                    }
                }
            }
        }
    }
}
