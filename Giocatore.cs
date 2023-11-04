using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static TextGame.Gioco;

namespace TextGame
{
    [DataContract]
    public class Giocatore : Personaggio
    {
        public int pesoLimiteInventario = 20;
        [DataMember]
        public Stack<Oggetto> inventario = new Stack<Oggetto>();

        [DataMember]
        public List<Posizione> stanzeVisitate = new List<Posizione>();

        [DataMember]
        public Stanza stanzaAttuale;

        public Giocatore() : base() { }

        public Giocatore(string nome, string descrizione, bool parla, bool buono, Oggetto oggetto, int attacco, int vita) : base(nome, descrizione, parla, buono, oggetto, attacco, vita)
        {
            this.vita = 15;
        }

        public void ControlloPozione(Giocatore pg)
        {
            int uso = 1;
            // se l'oggetto nell'inventario e' troppo indietro allora non riesce a prendere l'oggetto?
            foreach (Oggetto o in inventario)
            {
                if (o.nome == "pozione" && uso > 1)
                {
                    --uso;
                    inventario.Push(o);
                    pg.vita += 5;
                }
                else if (uso < 1)
                {
                    Console.WriteLine("Non puoi usare altre pozioni");
                }
                else
                {
                    Console.WriteLine("Non hai pozioni");
                }
            }
        }

        public void Prendi(Oggetto o)
        {
            if (inventario.Count <= pesoLimiteInventario)
            {
                inventario.Push(o);
            } else
            {
                Console.WriteLine("Non puoi prendere altri oggetti, liberati di qualche peso");
            }
        }

        public Oggetto Togli(Oggetto oggetto)
        {
            inventario.Pop();
            return oggetto;
        }

        public bool ControlloPeso(Oggetto oggetto)
        {
            int somma = 0;
            foreach(Oggetto o in inventario)
            {
                somma += o.peso;
            }
            if (somma < pesoLimiteInventario+1) return true;
            else return false;
        }
        
    }
}