using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGame
{
    public class Nemico : Personaggio
    {
        public Nemico(string nome, string descrizione, bool parla, bool buono, Oggetto oggetto, int attacco, int vita) : base(nome, descrizione, parla, buono, oggetto, attacco, vita)
        {
        }
    }

}