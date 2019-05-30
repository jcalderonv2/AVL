using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{

    class Avl
    {
        private NodoAvl raiz;

        public Avl()
        {

            raiz = null;

        }

        public NodoAvl obtenerRaiz()
        {
            return raiz;
        }

        public int obtenerFE(NodoAvl x)
        {
            if (x == null)
            {
                return -1;
            }
            else
            {
                return x.Fe;
            }
        }

        public NodoAvl rotacionIzquierda(NodoAvl c)
        {
            NodoAvl aux = c.Izquierda;
            c.Izquierda = aux.Derecha;
            aux.Derecha = c;
            c.Fe = Math.Max(obtenerFE(c.Izquierda), obtenerFE(c.Derecha)) + 1;
            aux.Fe = Math.Max(obtenerFE(aux.Izquierda), obtenerFE(aux.Derecha)) + 1;
            return aux;
        }

        public NodoAvl rotacionDerecha(NodoAvl c)
        {
            NodoAvl aux = c.Derecha;
            c.Derecha = aux.Izquierda;
            aux.Izquierda = c;
            c.Fe = Math.Max(obtenerFE(c.Izquierda), obtenerFE(c.Derecha)) + 1;
            aux.Fe = Math.Max(obtenerFE(aux.Izquierda), obtenerFE(aux.Derecha)) + 1;
            return aux;
        }

        public NodoAvl dobleIzquierda(NodoAvl c)
        {
            NodoAvl temp;
            c.Izquierda = rotacionDerecha(c.Izquierda);
            temp = rotacionIzquierda(c);
            return temp;
        }

        public NodoAvl dobleDerecha(NodoAvl c)
        {
            NodoAvl temp;
            c.Derecha = rotacionIzquierda(c.Derecha);
            temp = rotacionDerecha(c);
            return temp;
        }

        public NodoAvl insertarBalanceado(NodoAvl nuevo, NodoAvl subArbol)
        {

            NodoAvl nuevoPadre = subArbol;
            if (nuevo.Dato < subArbol.Dato)
            {
                if (subArbol.Izquierda == null)
                {
                    subArbol.Izquierda = nuevo;
                }
                else
                {
                    subArbol.Izquierda = insertarBalanceado(nuevo, subArbol.Izquierda);
                    if ((obtenerFE(subArbol.Izquierda) - obtenerFE(subArbol.Derecha)) == 2)
                    {
                        if (nuevo.Dato < subArbol.Izquierda.Dato)
                        {
                            nuevoPadre = rotacionIzquierda(subArbol);
                        }
                        else
                        {
                            nuevoPadre = dobleIzquierda(subArbol);
                        }
                    }
                }
            }
            else if (nuevo.Dato > subArbol.Dato)
            {
                if (subArbol.Derecha == null)
                {
                    subArbol.Derecha = nuevo;
                }
                else
                {
                    subArbol.Derecha = insertarBalanceado(nuevo, subArbol.Derecha);
                    if ((obtenerFE(subArbol.Derecha) - obtenerFE(subArbol.Izquierda) == 2))
                    {
                        if (nuevo.Dato > subArbol.Derecha.Dato)
                        {
                            nuevoPadre = rotacionDerecha(subArbol);
                        }
                        else
                        {
                            nuevoPadre = dobleDerecha(subArbol);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nodo duplicado.");
            }

            if (subArbol.Izquierda == null && (subArbol.Derecha != null))
            {
                subArbol.Fe = subArbol.Derecha.Fe + 1;
            }
            else if ((subArbol.Derecha == null && subArbol.Izquierda != null))
            {
                subArbol.Fe = subArbol.Izquierda.Fe + 1;
            }
            else
            {
                subArbol.Fe = Math.Max(obtenerFE(subArbol.Izquierda), obtenerFE(subArbol.Derecha)) + 1;
            }

            return nuevoPadre;
        }

        public void insertar(int dato)
        {
            NodoAvl nuevo = new NodoAvl();
            nuevo.Dato = dato;
            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                raiz = insertarBalanceado(nuevo, raiz);
            }
        }

        
        public void PreOrden(NodoAvl raiz)
        {

            Console.WriteLine(" - " + raiz.Dato);

            if (raiz.Izquierda != null)
            {
                PreOrden(raiz.Izquierda);
            }

            if (raiz.Derecha != null)
            {
                PreOrden(raiz.Derecha);
            }

        }

        public void InOrden(NodoAvl raiz)
        {
            if (raiz.Izquierda != null)
            {
                InOrden(raiz.Izquierda);
            }
            Console.WriteLine(" - " + raiz.Dato);
            if (raiz.Derecha != null)
            {
                InOrden(raiz.Derecha);
            }

        }

        public void PostOrden(NodoAvl raiz)
        {
            if (raiz.Izquierda != null)
            {
                PostOrden(raiz.Izquierda);
            }

            if (raiz.Derecha != null)
            {
                PostOrden(raiz.Derecha);
            }

            Console.WriteLine(" - " + raiz.Dato);
        }
    }
}
