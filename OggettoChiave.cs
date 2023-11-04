using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGame
{
    public class OggettoChiave : Oggetto
    {
        public OggettoChiave(string nome, string descrizione, int peso, bool pickup) : base(nome, descrizione, peso, pickup)
        {
        }
    }
}