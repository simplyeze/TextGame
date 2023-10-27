using System;

namespace TextGame
{
    /// <summary>
    /// LE FUNZIONI CHE SONO GIÀ PRONTE LE METTO DOPO IL MAIN PERCHÈ OLTRE A QUELLO NON C'È NULLA DI IMPORTANTE
    /// </summary>



    class Gioco
    {
        static IDictionary<Posizione, Stanza> ListaStanze = new Dictionary<Posizione, Stanza>();
        static Stack<Oggetto> Inventario = new Stack<Oggetto>();
        static List<Oggetto> OggettiGioco = new List<Oggetto>();
        static Stanza stanzaAttuale = new Stanza();
        static List<Posizione> stanzeVisitate = new List<Posizione>();
        static Posizione posizioneAttuale = new Posizione();

        public struct Posizione // COORDINATE DELLA POSIZIONE E COSTRUTTORE
        {
            public int X;
            public int Y;

            public Posizione(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        public static void SetupElementi() // FUNZIONE PER LA CREAZIONE DELLE STANZE, DEI PERSONAGGI E DEGLI OGGETTI AL LORO INTERNO
        {
            // Area 1
            Stanza ingressoCripta = new Stanza("Ingresso della Cripta", "L'ingresso della leggendaria tomba di Nandareth; l'aria e' leggermente umida, e i numerosi strati di polvere accumulati in tutta la stanza sono segno di una sola cosa: nessuno e' entrato qui da tempo.", false, true, false);
            Posizione posizioneIngressoCripta = new Posizione(0, 0);

            Stanza ingressoOssuarioDemoni = new Stanza("Ingresso all'Ossuario dei Demoni", "Zona principale dell'ossuario, la stanza si estende verticalmente per una decina di metri. Ogni parete contiene centinaia di nicchie e lapidi, sulle quali sono incise iscrizioni in una lingua che non riesci a comprendere.", false, false, false);
            Posizione posizioneOssuarioDemoni = new Posizione(0, -2);

            Stanza stanzaNascosta = new Stanza("Stanza Nascosta", "Un muro abbattuto rivela un piccolo stanzino, originariamente celato da tutti. Al suo interno vi e' solo un piccolo altare, qualche scaffale abbattuto e poco altro.", false, false, false);
            Posizione posizioneStanzaNascosta = new Posizione(1, -2);

            Stanza ossuarioDemoniSud = new Stanza("Ossuario dei Demoni - Zona Sud", "Stanza periferica dell'ossuario. I muri contengono meno incavature delle stanze precedenti, ma l'ambiente e' decorato da alcune statue simili a gargoyle, che sono piazzate con la faccia contro i muri, come se li stessero graffiando per provare ad uscire.", false, false, false);
            Posizione posizioneOssuarioDemoniSud = new Posizione(0, -3);

            Stanza tombaOrnata = new Stanza("Tomba Ornata", "Una singola stanza, contenente una tomba monumentale. La statua che era stata eretta a sua protezione e' crollata con il tempo, lasciando come unico elemento intatto la lapide sul pavimento. Vi sono alcune tracce di fiori scarlatti rinsecchiti vicino ad essa.", false, false, false);
            Posizione posizioneTombaOrnata = new Posizione(-1, -3);

            // STANZE AREA 2
            Stanza corridoioDissestato = new Stanza("Corridoio Dissestato", "Un passaggio di medie dimensioni. Sui lati di questa stanza, sono presenti torce il cui legno e' ormai marcio.", false, false, false);
            Posizione posizioneCorridoioDissestato = new Posizione(-1, 0);

            Stanza corridoioDissestatoII = new Stanza("Corridoio Dissestato II", "Continuo del passaggio. In tempi passati, questa stanza avrebbe fatto da incrocio per altre sezioni della cripta, ma adesso tutte le uscite sono inaccessibili eccetto per una.", false, false, false);
            Posizione posizioneCorridoioDissestatoII = new Posizione(-2, 0);

            Stanza stanzaConMurale = new Stanza("Stanza con Murale", "Una piccola stanza di forma quadrata, che non contiene molto a parte per l'enorme Murale che ricopre la parete difronte all'ingresso. Rappresenta la terribile scena di un gruppo di diavoli che rade al suolo una citta' attraverso le loro poderose fiamme.", false, false, false);
            Posizione posizioneStanzaConMurale = new Posizione(-2, -1);

            // STANZE AREA 3
            Stanza passaggioRovinato = new Stanza("Passaggio rovinato", "Un'insenatura nella parete che fa da transizione per una zona piu' grande. Parte delle sono crollate, rendendo il passaggio ostico ma possibile.", false, false, false);
            Posizione posizionePassaggioRovinato = new Posizione(0, 1);

            Stanza tombeDeiDiavoliIngresso = new Stanza("Tombe dei diavoli - Ingresso", "Un enorme cimitero, pieno di tombe di ogni forma e dimensione. Sulle lapidi sono incisi nomi in una lingua che non conosci, e non e' raro trovare alcune offerte poste su di esse.", false, false, false);
            Posizione posizioneTombeDeiDiavoliIngresso = new Posizione(0, 2);

            Stanza tombeDeiDiavoliOvest = new Stanza("Tombe dei Diavoli - Zona Ovest", "Continuo del cimitero, questa volta vi sono alcune statue che sono poste a mo di sentinella, probabilmente per spaventare gli incursori che tentano di profanare le tombe del luogo.", false, false, false);
            Posizione posizioneTombeDeiDiavoliOvest = new Posizione(-1, 2);

            Stanza tombeDeiDiavoliNord = new Stanza("Tombe dei Diavoli - Zona Nord", "Continuo del cimitero, in questa porzione di esso le tombe sono minori in numero, ma anche piu' ornate e curate. Le offerte votive poste su di esse sembrano essere piu' preziose.", false, false, false);
            Posizione posizioneTombeDeiDiavoliNord = new Posizione(0, 3);

            Stanza Cappella = new Stanza("Cappella", "Una piccola cappella locata al margine del cdimitero. Al suo interno sono presenti alcune nicchie incise su i muri, mentre sull'altare si trovano una serie di unguenti e pozioni dall'aspetto strano - e' la prima volta che vedi qualcosa di simile.", false, false, false);
            Posizione posizioneCappella = new Posizione(-1, 3);

            // STANZE AREA 4
            Stanza senzaLanterna = new Stanza("???", "La stanza e' ricoperta da una fitta nebbia, che ti impedisce di vedere a un palmo dal tuo naso. Forse sarebbe meglio tornare indietro.", false, false, false);
            Posizione posizioneSenzaLanterna = new Posizione(1, 0);

            Stanza conLanterna = new Stanza("Ingresso alla tomba di Nandareth", "Non appena entri nella stanza, la nebbia si dirada istantaneamente, mostrandone le fattezze. Riconosci gli altorilievi incisi su i muri e capisci esattamente dove ti stai recando: e' l'ingresso della tomba di Nandareth.", false, false, false);
            Posizione posizioneConLanterna = new Posizione(1, 0);

            Stanza tombaDiNandareth = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneTombaDiNandareth = new Posizione(2, 0);

            Stanza tombaDiNandarethNord = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneTombaDiNandarethNord = new Posizione(2, 1);

            Stanza tombaDiNandarethCerimonia = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneTombaDiNandarethCerimonia = new Posizione(3, 1);

            Stanza tombaDiNandarethEst = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneTombaDiNandarethEst = new Posizione(3, 0);


            // AREA 5
            Stanza criptaMisteriosa = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizionecriptaMisteriosa = new Posizione(3, -1);

            Stanza criptaMisteriosaSud = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizionecriptaMisteriosaSud = new Posizione(3, -2);

            Stanza criptaMisteriosaEst = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizionecriptaMisteriosaEst = new Posizione(4, -1);

            Stanza criptaMisteriosaAtrioFinale = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizionecriptaMisteriosaAtrioFinale = new Posizione(4, -2);

            Stanza stanzaDelTesoro = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneStanzaDelTesoro = new Posizione(4, -3);

            Stanza stanzaDiNandareth = new Stanza("nome", "descrizione", false, false, false);
            Posizione posizioneStanzaDiNandareth = new Posizione(5, -2);

            Oggetto oggettoChiaveFinale = new Oggetto("LIGHT", "serve per poter danneggiare il boss", 0, false);

            // SPAWN DEI PERSONAGGI: BUONO; CATTIVO; TIPI DI NEMICI
            Personaggio personaggioBuono = new Personaggio("Arcangelo Incatenato", "", true, true, oggettoChiaveFinale);
            Random spawn = new Random();
            posizioneAttuale.X = spawn.Next(-1, 4);
            posizioneAttuale.Y = spawn.Next(-2, 3);
            if (ListaStanze.ContainsKey(posizioneAttuale))
            {
                ListaStanze[posizioneAttuale].npc.Add(personaggioBuono);
            }
            else
            {
                ListaStanze[posizioneTombaOrnata].npc.Add(personaggioBuono);
            }

            Personaggio personaggioCattivo = new Personaggio("Belphagor", "descrizione", true, false, null);
            Nemico scheletro = new("Scheletro", "Uno scheletro risorto, armato con una spada arruginita. Dal suo teschio protrudono due affilate corna.", false, false, null, 5, 2);
            Nemico statuaAnimata = new("Statua Animata", "Una delle statue decorative della tomba ha preso vita. Che si tratti di una strana creatura o di un sortilegio volto a scacciare chi profana questo sepolcro?", false, false, null, 3, 5);


            posizioneAttuale = posizioneIngressoCripta;
        }
        public static void MostraInventario(int limiteInventario = 20) // FUNZIONE PER ANALIZZARE L'INVENTARIO
        {
            bool trovato = false;
            // Array per rendere il metodo più semplice
            Oggetto[] stack = Inventario.ToArray();
            Console.WriteLine("Nell'inventario sono presenti: ");
            foreach (Oggetto oggetto in Inventario)
            {
                Console.WriteLine(oggetto.nome);
            }
            Console.WriteLine("Al momento hai in mano ");
            Console.Write(stack[0]);
            Console.WriteLine("Cosa vuoi fare? ");
            string input = Console.ReadLine().ToLower();
            Oggetto oggettoTemp = new Oggetto();
            switch (input)
            {
                case "svuota":
                    foreach (Oggetto oggetto in Inventario)
                    {
                        stanzaAttuale.oggettiPresenti.Add(Inventario.Pop());
                    }
                    break;
                case "prendi":
                    Console.WriteLine("Quale oggetto vuoi prendere? ");
                    string inputOggetto = Console.ReadLine().ToLower();
                    //Oggetto oggettoTrovato = Inventario.Find(o =>  o.nome == inputOggetto);

                    // PEZZO PRESO DA CHATGPT
                    // Crea una pila temporanea per invertire l'ordine degli oggetti
                    Stack<Oggetto> temp = new Stack<Oggetto>();
                    // Rimuovi gli oggetti dalla pila originale e mettili nella pila temporanea finché non trovi quello da rimuovere
                    while (temp.Count > 0)
                    {
                        oggettoTemp = Inventario.Pop();

                        if (oggettoTemp.nome == inputOggetto)
                        {
                            // Se trovi l'oggetto da rimuovere, esci dal ciclo
                            break;
                        }

                        temp.Push(oggettoTemp);
                    }

                    // Rimetti gli oggetti nella pila originale, ripristinando l'ordine LIFO
                    while (temp.Count > 0)
                    {
                        Inventario.Push(temp.Pop());
                    }
                    break;

                default:
                    Console.WriteLine("Non puoi svolgere questa azione ");
                    break;
            }
        }
        public static void MovimentoPersonaggio(string direzione) // FUNZIONE PER SPOSTARSI
        {
            Console.WriteLine("Dove vuoi andare?");
            string inputMovimento = Console.ReadLine().ToLower();
            switch (inputMovimento)
            {
                case "nord":
                    // CONTROLLA IL DIZIONARIO IN BASE ALLE COORDINATE SE È PRESENTE UNA STANZA IN QUESTA DIREZIONE, POI CONTROLLA SE È POSSIBILE ENTRARCI
                    Posizione nuovaPozizioneNord = new Posizione(posizioneAttuale.X, posizioneAttuale.Y + 1);

                    //controllo se è presente una stanza
                    if (ListaStanze.ContainsKey(nuovaPozizioneNord))
                    {
                        // controllo se è accessibile
                        if (ListaStanze[nuovaPozizioneNord].chiave)
                        {
                            //controllon se il giocatore ha l'oggetto
                            // if (Inventario.Contains(chiave))
                            if (!ListaStanze[nuovaPozizioneNord].visitata)
                            {
                                Console.WriteLine(ListaStanze[nuovaPozizioneNord].descrizione);
                            }
                        }
                    }

                    stanzaAttuale = ListaStanze[nuovaPozizioneNord];
                    posizioneAttuale = nuovaPozizioneNord;
                    //confronta le coordinate della stanza attuale
                    //e vede se aggiungendo + 1 a una delle due coordinate ci sta una stanza
                    //vero: controlla i parametri per entrare
                    //falso: questa direzione è chiusa da... (un muro, la porta è sbarrata, ce la nebbia e torni indietro)



                    break;
                case "est":
                    break;
                case "ovest":
                    break;
                case "sud":
                    break;
                default:
                    Console.WriteLine("Questa non è una valida direzione...");
                    break;
            }
        }
        public static void Menu(string comandi) // FUNZIONE PER LE VARIE FRASI DI DIALOGO
        {
            // controlla quantio comandi ci sono, li divide in 3 e crea righe se sono >3
            Console.WriteLine(" ----------------------------------------- ");
            Console.WriteLine("| (A)nalizza (I)nventario    (M)uovi      |");
            Console.WriteLine("| (P)arla    (C)ombatti      (S)alta      |");
            Console.WriteLine(" ----------------------------------------- ");
        }
        public static void Combattimento(Personaggio pg, Personaggio nemico) // FUNZIONE PER IL COMBATTIMENTO
        {
            Random random = new Random();
            string nameEnc = nemico.nome;
            int powerEnc = nemico.attacco;
            int healthEnc = nemico.vita;

            while (healthEnc > 0)
            {
                Console.Clear();
                Console.WriteLine("Ti ha attaccato " + nameEnc + "!");
                Console.WriteLine(" ===================== ");
                Console.WriteLine("| (A)ttacco (D)ifendi |");
                Console.WriteLine("| (S)pell   (O)ggetti |");
                Console.WriteLine(" ===================== ");
                Console.WriteLine("I tuoi PV: " + pg.vita);
                string input = Console.ReadLine();

                //FASE DI ATTACCO
                if (input.ToLower() == "a" || input.ToLower() == "attacco")
                {
                    //Genera un numero casuale per determinare l'esito dell'attacco
                    int roll = random.Next(1, 21);

                    switch (roll)
                    {
                        case 1: //Miss
                            Console.WriteLine("Lanci un attacco con tutta la tua forza, ma il nemico riesce a schivare all'ultimo secondo.");
                            break;
                        case 20: //Crit
                            Console.WriteLine("UN COLPO DEVASTANTE! Il nemico trema difronte all'impeto del tuo colpo.");
                            healthEnc -= pg.attacco * 2;    //calcolo dei danni raddoppiati al nemico
                            break;
                        default: //Attacco va a segno con successo
                            Console.WriteLine("Colpisci il nemico con la tua spada!");
                            healthEnc -= pg.attacco;    //calcolo dei danni al nemico
                            break;
                    }
                }
                //DIFESA
                if (input.ToLower() == "d" || input.ToLower() == "difendi")
                {
                    //difesa = riduci i danni ricevuti dal prossimo attacco
                    Console.WriteLine("Alzi la spada in difesa.");
                    int defence = random.Next(1, 6); //Modifier randomico che sarà sottratto al prossimo attacco in arrivo
                }
                //SPELL
                if (input.ToLower() == "s" || input.ToLower() == "spell")
                {
                    Console.WriteLine("Recita l'incantamento a gran voce!");
                    string spell = Console.ReadLine();  //Inserimento dell'incantesimo: FRE, HLE, AGHISLOV sono opzioni accette, qualsiasi altro input sarà considerato un fallimento del casting

                    switch (spell.ToLower())
                    {
                        case "FRE":
                            Console.WriteLine("Hai evocato il potere del fuoco! Fiamme incandescenti avvolgono il nemico!");
                            healthEnc -= random.Next(1, 11);
                            break;
                        case "HLE":
                            Console.WriteLine("Vieni circondato da un'aura verde, che lentamente lenisce le tue ferite.");
                            pg.vita += random.Next(1, 8);
                            break;
                        case "AGHISLOV":
                            Console.WriteLine("AGHISLOV * fischi, il diavolo ora è scarso or smth");
                            break;
                        default:
                            Console.WriteLine("ARGH! L'incantesimo non era corretto, e fallisce!");
                            break;
                    }
                }
                //OGGETTI
                if (input.ToLower() == "h" || input.ToLower() == "heal") //SEZIONE STRUMENTI WORK IN PROGRESS
                {
                    Console.ReadKey();
                }
                //TURNO DEL NEMICO
                if (healthEnc <= 0)
                {
                    Console.WriteLine("Il " + nameEnc + " è morto!");
                    break; //nemico è morto, forzo uscita dal loop
                }
                else
                {
                    //fase di attacco nemico
                    int enroll = random.Next(1, 21);

                    switch (enroll)
                    {
                        case 1: //Miss
                            Console.WriteLine(nameEnc + " fa un passo falso, permettendoti di schivare l'attaco.");
                            break;
                        case 20: //Crit
                            Console.WriteLine("UN COLPO DEVASTANTE! L'attacco ti ha fatto molto male, lanciandoti via di qualche metro.");
                            pg.vita -= powerEnc * 2;    //calcolo dei danni raddoppiati al giocatore
                            break;
                        default: //Attacco va a segno con successo
                            Console.WriteLine(nameEnc + " ti colpisce con successo.");
                            pg.vita -= powerEnc;    //calcolo dei danni al giocatore
                            break;
                    }
                }
                // MORTE DEL GIOCATORE
                if (pg.vita <= 0)
                {
                    Console.WriteLine("Sei morto lol.");
                    System.Environment.Exit(0);
                }

            }
            Console.ReadKey();
        }
        public static void Teletrasporto()// FUNZIONE PER IL TELETRASPORTO Nella lista di stanze già visitate ne scelgo una random
        {
            Random fuga = new Random();
            posizioneAttuale = stanzeVisitate[fuga.Next(stanzeVisitate.Count)];
            // SPOSTARE IL GIOCATORE
        }
        public static void Salvataggio(Giocatore giocatore) // FUNZIONE PER IL SALVATAGGIO
        {
            //SaveSystem.SavePlayer(giocatore);
        }
        //public static Giocatore Carica() // FUNZIONE PER IL CARICAMENTO DELLE PARTITE SALVATE
        //{
        //    Giocatore data = SaveSystem.LoadPlayer(); //Chiama la funzione di load dallo script per il salvataggio

        //    //assegna le variabili salvate in precedenza a quelle del giocatore appena creato
        //    data.nome = data.nome;
        //    data.hp = data.vita;
        //    data.attacco = data.attacco;
        //    data.inventario = data.inventario;

        //    return data;
        //}
        public static void Esci() // FUNZIONE PER CHIUDERE IL GIOCO
        {
            // scrive il testo e poi esce dal gioco
            Environment.Exit(0);
        }

        public static void Partita()
        {
            //Testo();
            string input = Console.ReadLine().ToLower();
            switch (input) //SWITCH PER LA SCELTA DELLE AZIONI DEL GIOCATORE OGNI TURNO
            {
                case "analizza":
                    // chiama funzione della stanza per mostrare cosa è presente nella stanza
                    break;
                case "inventario":
                    MostraInventario();
                    break;
                case "muovi":
                    string inputMovimento = Console.ReadLine().ToLower();
                    MovimentoPersonaggio(inputMovimento);
                    break;
                case "parla":
                    //Dialogo();
                    break;
                case "combatti":
                    //Combattimento();
                    break;
                case "salta":
                    Teletrasporto();
                    break;
            }
        }
        static void Main(string[] args) // BISOGNA SISTEMARE IL SetupElementi()
        {
            // Crea il giocatore attuale
            Console.Clear();
            //bool nuovaPartita = false;
            Giocatore giocatore = new Giocatore();
            //stanzaAttuale = ListaStanze[posizioneIngressoCripta];

            // TESTO INTRODUTTIVO
            Console.WriteLine("TESTO INTRODUTTIVO ------------------------------------------------------------------------------\n");

            // FUNZIONE: CHIEDO IL NOME
            Console.WriteLine("chiedo il nome ------------------------------------------------------------------------------\n");
            Console.WriteLine("Nome: ");
            string input = Console.ReadLine();
            if (input == "" || input == null)
            {
                Console.WriteLine("Va bene, tieniti pure i tuoi segreti, STRANIERO \n");
                giocatore.nome = "STRANIERO";
            }

            Console.WriteLine("Menù della partita");
            // menù del gioco si danno 3 scelte: NUOVA PARTITA, CARICA PARTITA, ESCI
            bool inputValido = false;
            while (!inputValido)
            {
                string scelta = Console.ReadLine().ToLower();
                switch (scelta)
                {
                    case "nuova": // setta tutti gli elementi del gioco e crea un nuovo file di salvataggio
                        Console.WriteLine("carico gli elementi");
                        SetupElementi();
                        //nuovaPartita = true;
                        inputValido = true;
                        break;
                    case "carica": // carica il personaggio salvato in quello attuale e continua la partita da quel punto
                        Console.WriteLine("carico la partita");
                        //giocatore = Carica();
                        inputValido = true;
                        break;
                    case "esci": // chiude il gioco
                        Console.WriteLine("levate dal cazzo");
                        Esci();
                        break; //easter egg
                    default:
                        Console.WriteLine("Che cazzo hai scritto?.... Damme na risposta giusta");
                        break;
                }
            }

            while (giocatore.vita > 0) Partita();
        }

        public static void Testo(string testo, int attesa = 12) // FUNZIONE CON IL TESTO DA SCRIVERE A SCHERMO
        {
            foreach (char c in testo)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(attesa);
            }
            Console.WriteLine();
        }












    }
}