﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextGame
{
    public class Oggetto
    {
        public string descrizione;
        public string nome;
        public int peso;
        public int pickup;

        public Oggetto()
        {

        }

        public Oggetto(string nome, string descrizione, int peso, bool pickup)
        {
            //this.nome = nome;
            //this.descrizione = descrizione;
            //this.peso = peso;
            //this.pickup = pickup;
        }

        public Personaggio Personaggio
        {
            get => default;
            set
            {
            }
        }

        public Stanza Stanza
        {
            get => default;
            set
            {
            }
        }
    }
}