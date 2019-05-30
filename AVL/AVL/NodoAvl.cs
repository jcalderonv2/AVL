using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class NodoAvl
    {
        private int dato;
        private int fe;
        private NodoAvl izquierda;
        private NodoAvl derecha;

        public int Dato
        {
            get { return dato; }
            set { dato = value; }
        }

        public int Fe
        {
            get { return fe; }
            set { fe = value; }
        }

        public NodoAvl Izquierda
        {
            get { return izquierda; }
            set { izquierda = value; }
        }

        public NodoAvl Derecha
        {
            get { return derecha; }
            set { derecha = value; }
        }
    }
}
