using TextGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime.Serialization;
using System.Reflection.PortableExecutable;

namespace TextGame
{
    [DataContract]
    public class Personaggio
    {
        [DataMember]
        public string nome;
        public string descrizione;
        public bool parla;
        public bool discorso;
        [DataMember]
        public int attacco;
        [DataMember]
        public int vita;
        public bool buono;
        public Oggetto oggettoPersonaggio;

        public Personaggio() { }

        public Personaggio(string nome, string descrizione, bool parla, bool buono, Oggetto oggettoPersonaggio, int attacco, int vita)
        {
            this.nome = nome;
            this.descrizione = descrizione;
            this.parla = parla; 
            this.buono = buono;
            this.oggettoPersonaggio = oggettoPersonaggio;
            this.attacco = attacco;
            this.vita = vita;
        }

        public Personaggio(string nome, string descrizione, bool parla, bool buono, Oggetto oggettoPersonaggio)
        {
            this.nome = nome;
            this.descrizione = descrizione;
            this.parla = parla;
            this.buono = buono;
            this.oggettoPersonaggio = oggettoPersonaggio;
        }

        public bool CheckBoss()
        {
            if (this.nome == "BOSS") return true;
            else return false;
        }
    }
}


        