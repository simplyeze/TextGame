using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace TextGame
{
    public class Stanza
    {
        public string nome;
        public string descrizione;
        public bool combatimento;
        public bool visitata;
        public bool chiave;
        public List<Personaggio> npc;
        public List<Oggetto> oggettiPresenti;

        public Stanza() { }
        public Stanza(string nome, string descrizione, bool combattimento, bool visitata, bool chiave)
        {
            //this.nome = nome;
            //this.descrizione = descrizione;
            //this.personaggiPresenti = personaggiPresenti;
            //this.oggettiPresenti = oggettiPresenti;
            //this.combattimento = combattimento;
            //this.visitata = visitata;
            //this.chiave = chiave;
        }

        public void AnalizzaStanza()
        {
            //Console.WriteLine("Nella stanza ci sono: ");
            //foreach (Oggetto oggetto in oggettiPresenti)
            //{
            //    Elenco(oggetto.nome);
            //}
            //Console.WriteLine("E son presenti: ");
            //foreach (Personaggio personaggio in personaggiPresenti)
            //{
            //    Elenco(personaggio.nome);
            //}
        }

        public void Elenco(string testo, int attesa = 12)// FUNZIONE CON IL TESTO DA SCRIVERE A SCHERMO
        {
            foreach (char c in testo)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(attesa);
            }
            Console.Write(" ");
        }
    }
}