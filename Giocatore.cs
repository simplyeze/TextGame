using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGame
{
    public class Giocatore : Personaggio
    {
        public int pesoLimiteInventario;
        public List<Oggetto> inventario;

        public Giocatore()
        {

        }
    }
}