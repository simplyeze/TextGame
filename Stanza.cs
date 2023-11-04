using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using TextGame;

namespace TextGame
{
    [System.Serializable]
    public class Stanza
    {
        public string nome;
        public string descrizione;
        public bool combattimento;
        public bool visitata;
        public bool chiave;
        public Oggetto lanternina = new Oggetto("Lanterna delle nebbie", "", 2, true);
        public int spell;
        public List<Personaggio> npc = new List<Personaggio>();
        public List<Oggetto> oggettiPresenti = new List<Oggetto>();

        public Stanza(string nome, string descrizione, bool combattimento, bool visitata, bool chiave)
        {
            this.nome = nome;
            this.descrizione = descrizione;
            this.combattimento = combattimento;
            this.visitata = visitata;
            this.chiave = chiave;
            this.spell = 0;
        }
        public void AnalizzaStanza(Giocatore pg)
        {
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------");
            ToStringStanza();
            if (this.oggettiPresenti.Count > 0)
            {
                if (this.oggettiPresenti.Count == 1)
                {
                    Console.WriteLine($"Nella stanza c'è: {oggettiPresenti[0].nome}");
                }
                else
                {
                    Console.WriteLine("Nella stanza ci sono: ");
                    foreach (Oggetto oggetto in oggettiPresenti)
                    {
                        if (oggetto != oggettiPresenti[oggettiPresenti.Count - 1])
                        {
                            Console.WriteLine($"{oggetto.nome}, ");
                        }
                        else
                        {
                            Console.WriteLine($"{oggetto.nome}.");
                        }
                    }
                }

                List<Oggetto> obtained = new List<Oggetto>();

                foreach (Oggetto o in this.oggettiPresenti)
                {
                    if (o.pickup)
                    {
                        Console.WriteLine($"Vuoi raccogliere {o.nome}? (Y/N)");
                        string choice = Console.ReadLine().ToLower();

                        if (choice == "yes" || choice == "y")
                        {
                            bool afferrabile = pg.ControlloPeso(o);
                            if (afferrabile)
                            {
                                Console.WriteLine($"Hai raccolto {o.nome}!");
                                pg.inventario.Push(o);
                                obtained.Add(o);
                            }
                            else
                            {
                                Console.WriteLine($"Hai raggiunto il peso limite dell'inventario!");
                            }
                        }
                        else if (choice == "no" || choice == "n")
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (obtained.Count > 0)
                {
                    foreach (Oggetto o in obtained)
                    {
                        oggettiPresenti.Remove(o);
                    }
                }

                obtained.Clear();
            }
            else
            {
                Console.WriteLine("\nNon ci sono oggetti nella stanza.");
            }
            Console.WriteLine("\n");


            if (npc.Count > 0)
            {
                if (npc.Count == 1)
                {
                    Console.WriteLine($"Nella stanza c'è: {npc[0].nome}");
                }
                else
                {
                    Console.WriteLine("Nella stanza ci sono: ");
                    foreach (Personaggio p in npc)
                    {
                        if (p != npc[npc.Count - 1])
                        {
                            Console.WriteLine($"{p.nome}, ");
                        }
                        else
                        {
                            Console.WriteLine($"{p.nome}.");
                        }
                    }
                }
            }

            if (spell != 0) this.ImparaSpell();
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
        public void AddPersonaggio(Personaggio personaggio)
        {
            npc.Add(personaggio);
        }
        public void AddOggetto(Oggetto oggetto)
        {
            oggettiPresenti.Add(oggetto);
        }
        public void ToStringPersonaggio()
        {
            foreach (Personaggio personaggio in npc)
            {
                Console.WriteLine($"{personaggio.nome}");
            }

        }
        public void ToStringStanza()
        {
            Console.WriteLine($"Ti trovi nella {this.nome}. \n{this.descrizione}");
        }
        public void ImparaSpell()
        {
            Console.Write("Nella stanza è presente una scritta che non riesci a decifrare, vuoi provare a leggerla? [ Si / No ]");
            string input = Console.ReadLine().ToLower();
            switch (spell)
            {
                case 1:
                    if (input == "si") Console.WriteLine("Leggi la scritta a voce alta e le lettere si illuminano, formando la parola 'FRE', mormorandola compare una fiammela davanti a te "
                        + "\nCOMPLIMENTI!! Hai imparato l'incantesimo 'HLE'");
                    else Console.WriteLine("Non ti interessa la lettura e lasci perdere");
                    break;
                case 2:
                    if (input == "si") Console.WriteLine("Leggi la scritta a voce alta e le lettere si illuminano, formando la parola 'FRE', mormorandola compare una fiammela davanti a te "
                        + "\nCOMPLIMENTI!! Hai imparato l'incantesimo 'fre'");
                    else Console.WriteLine("Non ti interessa la lettura e lasci perdere");
                    break;
                case 3:
                    if (input == "si") Console.WriteLine("Leggi la scritta a voce alta e le lettere si illuminano, formando la parola 'FRE', mormorandola compare una fiammela davanti a te "
                        + "\nCOMPLIMENTI!! Hai imparato l'incantesimo 'aghislov'");
                    else Console.WriteLine("Non ti interessa la lettura e lasci perdere");
                    break;
                default:
                    break;
            }
        }

        public void Nebbia(Giocatore p)
        {
            if (p.inventario.Count() >= 0)
            {
                foreach (Oggetto o in p.inventario)
                {
                    Oggetto temp = o;
                    if (o.nome == lanternina.nome)
                    {
                        this.nome = "Ingresso alla tomba di Nandareth";
                        this.descrizione = "Non appena entri nella stanza, la nebbia si dirada istantaneamente, mostrandone le fattezze. Riconosci gli altorilievi incisi su i muri e capisci esattamente dove ti stai recando: e' l'ingresso della tomba di Nandareth.";
                        this.combattimento = false;
                        this.visitata = false;
                        this.chiave = false;
                        this.spell = 0;
                    }
                }
            }
        }

    }
}
