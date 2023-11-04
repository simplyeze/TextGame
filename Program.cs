using System;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using System.Linq;
using System.Runtime.Serialization;

namespace TextGame
{
    public struct Posizione // coordinate e costruttore
        {
            public int X;
            public int Y;

            public Posizione(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

    class Gioco
    {
        static Stanza stanzaAttuale; // stanza in cui si trova il giocatore
        static Posizione posizioneAttuale = new Posizione(); // posizione del giocatore 
        static IDictionary<Posizione, Stanza> listaStanze = new Dictionary<Posizione, Stanza>(); // dizionario delle stanze, per coordinate
        public static Giocatore giocatore = new Giocatore();

        //SAVE AND LOAD
        /////<summary>
        /////leggere a run time quale è il metodo e la classe che hanno generato quell'evento
        ///// </summary>
        ////private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        //public class Salvataggio
        //{
        //    public Stanza ingressoCripta { get; set; }
        //    public Stanza ingressoOssuarioDemoni { get; set; }
        //    public Stanza OssuarioDemoni { get; set; }
        //    public Stanza ossuarioDemoniSud { get; set; }
        //    public Stanza stanzaNascosta { get; set; }
        //    public Stanza tombaOrnata { get; set; }
        //    public Stanza corridoioDissestato { get; set; }
        //    public Stanza corridoioDissestatoII { get; set; }
        //    public Stanza stanzaConMurale { get; set; }
        //    public Stanza passaggioRovinato { get; set; }
        //    public Stanza tombeDeiDiavoliIngresso { get; set; }
        //    public Stanza tombeDeiDiavoliOvest { get; set; }
        //    public Stanza tombeDeiDiavoliNord { get; set; }
        //    public Stanza Cappella { get; set; }
        //    public Stanza conLanterna { get; set; }
        //    public Stanza tombaDiNandareth { get; set; }
        //    public Stanza tombaDiNandarethNord { get; set; }
        //    public Stanza tombaDiNandarethCerimonia { get; set; }
        //    public Stanza tombaDiNandarethEst { get; set; }
        //    public Stanza criptaMisteriosa { get; set; }
        //    public Stanza criptaMisteriosaSud { get; set; }
        //    public Stanza criptaMisteriosaEst { get; set; }
        //    public Stanza criptaMisteriosaAtrioFinale { get; set; }
        //    public Stanza stanzaDelTesoro { get; set; }
        //    public Stanza stanzaDiNandareth { get; set; }
        //    public Poso PosizioneAttuale { get; set; }
        //    public List<Oggetto> Inventario { get; set; }
        //    public string NomeGiocatore { get; set; }
        //}
        //static string nomeGiocatore = null;
        //static bool Gioco = false;
        ///<summary>
        ///salvare i dati del gioco in un file json
        /// </summary>
        /// <param name ="number">passato il nome del file di salvataggio </param>
        //private static void SalvataggioGioco()
        //{
        //    Lettura("Inserisci il nome del file di salvataggio");
        //    string file = Console.ReadLine().ToLower();
        //    Salvataggio saveData = new Salvataggio
        //    {
        //        ingressoCripta = ingressoCripta,
        //        ingressoOssuarioDemoni = ingressoOssuarioDemoni,
        //        OssuarioDemoni = OssuarioDemoni,
        //        ossuarioDemoniSud = ossuarioDemoniSud,
        //        stanzaNascosta = stanzaNascosta,
        //        tombaOrnata = tombaOrnata,
        //        corridoioDissestato = corridoioDissestato,
        //        corridoioDissestatoII = corridoioDissestatoII,
        //        stanzaConMurale = stanzaConMurale,
        //        passaggioRovinato = passaggioRovinato,
        //        tombeDeiDiavoliIngresso = tombeDeiDiavoliIngresso,
        //        tombeDeiDiavoliOvest = tombeDeiDiavoliOvest,
        //        tombeDeiDiavoliNord = tombeDeiDiavoliNord,
        //        Cappella = Cappella,
        //        conLanterna = conLanterna,
        //        tombaDiNandareth = tombaDiNandareth,
        //        tombaDiNandarethNord = tombaDiNandarethNord,
        //        tombaDiNandarethCerimonia = tombaDiNandarethCerimonia,
        //        tombaDiNandarethEst = tombaDiNandarethEst,
        //        criptaMisteriosa = criptaMisteriosa,
        //        criptaMisteriosaSud = criptaMisteriosaSud,
        //        criptaMisteriosaEst = criptaMisteriosaEst,
        //        criptaMisteriosaAtrioFinale = criptaMisteriosaAtrioFinale,
        //        stanzaDelTesoro = stanzaDelTesoro,
        //        stanzaDiNandareth = stanzaDiNandareth,
        //        PosizioneAttuale = PosizioneAttuale,
        //        Inventario = Inventario,
        //        NomeGiocatore = NomeGiocatore,
        //    };
        //    string Json = JsonConvert.SerializeObject(saveData, Formatting.Indented); //passare dati al serializzatore
        //    File.WriteAllText(file, Json);
        //    Testo("Salvataggio Completato, Arriderci!");
        //    _log.Info("Salvatggio avvenuto correttamente");
        //    Gioco = false;
        //}

        /////<summary>
        /////carica i dati del salvataggio nel file json
        ///// </summary>
        //private static void CaricaSalvataggio()
        //{
        //    Testo("Inserisci il nome del file di salvatggio");
        //    string NomeSalvatagio = Console.ReadLine().ToLower();
        //    if (File.Exists(NomeSalvatagio))
        //    {
        //        string json = File.ReadAllText(NomeSalvatagio);
        //        Salvataggio saveData = JsonConvert.DeserializeObject<Salvataggio>(json);
        //        posizioneAttuale = saveData.PosizioneAttuale;
        //        inventario = saveData.Inventario;
        //        nomeGiocatore = saveData.NomeGiocatore;
        //        stanzaStart = saveData.StanzaStart;
        //        Saladeglispecchi = saveData.SalaDegliSpecchi;
        //        SaladeglispecchiEst = saveData.SalaDegliSpecchiEst;
        //        SaladeglispecchiOvest = saveData.SalaDegliSpecchiOvest;
        //        Criptadelsapere = saveData.CriptaDelSapere;
        //        CriptadelsapereEst = saveData.CriptaDelSapereEst;
        //        CriptadelsapereOvest = saveData.CriptaDelSapereOvest;
        //        Cameradelleombre = saveData.CameraDelleOmbre;
        //        CameradelleombreEst = saveData.CameraDelleOmbreEst;
        //        CameradelleombreOvest = saveData.CameraDelleOmbreOvest;
        //        Santuariodellemeraviglie = saveData.SantuarioDelleMeraviglie;
        //        stanzaFinale = saveData.StanzaFinale;

        //        stanze.Add(coordinatestanzaStart, stanzaStart);
        //        stanze.Add(coordinateSaladeglispecchi, Saladeglispecchi);
        //        stanze.Add(coordinateSaladeglispecchiEst, SaladeglispecchiEst);
        //        stanze.Add(coordinateSaladeglispecchiOvest, SaladeglispecchiOvest);
        //        stanze.Add(coordinateCriptadelsapere, Criptadelsapere);
        //        stanze.Add(coordinateCriptadelsapereEst, CriptadelsapereEst);
        //        stanze.Add(coordinateCriptadelsapereOvest, CriptadelsapereOvest);
        //        stanze.Add(coordinateCameradelleombre, Cameradelleombre);
        //        stanze.Add(coordinateCameradelleombreEst, CameradelleombreEst);
        //        stanze.Add(coordinateCameradelleombreOvest, CameradelleombreOvest);
        //        stanze.Add(coordinateSantuariodellemeraviglie, Santuariodellemeraviglie);
        //        stanze.Add(coordinatestanzaFinale, stanzaFinale);
        //        Gioco = true;
        //        _log.Debug("Stanze caricate dal salvataggio");
        //    }
        //    else
        //    {
        //        Lettura("File di salvataggio inesistente");

        //    }

        //}

        static void SavePlayer<T>(T serialObject, string filepath)  //Salvo gli oggetti di una classe serializzabile di tipo T
        {
            var serializer = new DataContractSerializer(typeof(T)); //Creo il serializer per salvare i dati
            var settings = new XmlWriterSettings()                  //Settings opzionali per il formato di salvataggio dei dati
            {
                Indent = true,
                IndentChars = "\t",
            };

            var writer = XmlWriter.Create(filepath, settings);      //Creo il writer per scrivere i dati su file sulla directory filepath e con le settings create prima
            serializer.WriteObject(writer, serialObject);           //Salvo i dati su file
            writer.Close();                                         //Chiudo il writer
        }

        static T LoadPlayer<T>(string filepath)                                                             //Carico gli oggetti dal file su filepath
        {
            var fileStream = new FileStream(filepath, FileMode.Open);                                       //Apro il file specificato
            var reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas()); //Leggo il file aperto tramite reader

            var serializer = new DataContractSerializer(typeof(T));

            T serialObject = (T)serializer.ReadObject(reader, true);                                        //Creo variabile di tipo T con i dati letti da file
            reader.Close();                                                                                 //Chiudo il reader e il file aperto all'inizio
            fileStream.Close();

            return serialObject;
        }

        public static void Inventario(int limiteInventario = 20) // metodo per controllo dell'inventario 
        {
            string inputInventario;

            // controllo se il giocatore ha oggetti nell'inventario, se non ha nulla torno al menu 
            if (giocatore.inventario.Count() >= 0)
            {
                Testo("Oggetti nell'inventario: ");
                foreach (Oggetto o in giocatore.inventario)
                {
                    Console.WriteLine($"{o.nome}: {o.descrizione}");
                }
            }
            else
            {
                Testo("Non hai oggetti nell'inventario");
                Console.ReadKey();
                return;
            }
            // azioni per l'inventario fino a che non vuole uscire il giocatore 
            do
            {
                Console.WriteLine("\nCosa vuoi fare? Svuota, Riordina, Esci");
                inputInventario = Console.ReadLine().ToLower();
                Oggetto oTrovato = new Oggetto();
                switch (inputInventario)
                {
                    case "svuota": // buto tutti gli oggetti dall'inventario
                        int nOggInv = giocatore.inventario.Count();
                        for (int i = 0; i < nOggInv; i++)
                        {
                            listaStanze[posizioneAttuale].AddOggetto(giocatore.inventario.Pop());
                        }
                        break;
                    case "riordina": // prendo un oggetto e lo metto al primo posto
                        Console.WriteLine("Quale oggetto vuoi per primo?"); // chiedo l'oggetto che devo cercare
                        string iOrdInv = Console.ReadLine().ToLower();
                        Stack<Oggetto> tempStack = new Stack<Oggetto>(); // creo uno stack temporaneo
                        while (giocatore.inventario.Count > 0) // svuoto l'inventario in uno stack temporaneo
                        {
                            Oggetto temp = giocatore.inventario.Pop() as Oggetto;
                            if (temp.nome.ToLower() == iOrdInv) // se l'oggetto è stato trovato lo estraggo
                            {
                                oTrovato = temp;
                                break;
                            }
                            tempStack.Push(temp); // altrimenti lo spingo nello stack temporaneo
                        }
                        while (tempStack.Count > 0)
                        {
                            giocatore.inventario.Push(tempStack.Pop()); // poi rimetto tutto nell'inventario nell'ordine in cui era
                        }
                        giocatore.inventario.Push(oTrovato); // l'oggetto trovato sarà messo per ultimo, quindi il primo in mano
                        Testo("\nOggetti riordinati : ");
                        foreach (Oggetto o in giocatore.inventario)
                        {
                            Console.Write($"{o.nome} \t");
                        }
                        break;
                    case "esci":
                        break;
                    default:
                        Testo("Non è un azione che puoi svolgere");
                        break;
                }

            } while (inputInventario != "esci");

        }
        
        public static void MovimentoPersonaggio() // metodo per il movimento del giocatore
        {
            Console.WriteLine("\nDove vuoi andare? [ NORD ] [ EST ] [ OVEST ] [ SUD ]");
            string inputMovimento = Console.ReadLine().ToLower();
            switch (inputMovimento)
            {
                case "nord":
                    Posizione nuovaNord = new Posizione(posizioneAttuale.X, posizioneAttuale.Y + 1); // posizione desiderata
                    // se è presente una stanza con quelle coordinate posso avanzare
                    if (listaStanze.ContainsKey(nuovaNord))  
                    {
                        listaStanze[nuovaNord].Nebbia(giocatore);
                        // controllo se è accessibile senza chiavi
                        if (listaStanze[nuovaNord].chiave)
                        {
                            // controllo se il giocatore ha la chiave
                            
                            Console.WriteLine("Non hai la chiave per entrare, mi spiace");
                            Console.ReadLine();
                        }
                        else
                        {
                            // controllo se il giocatore ha già visitato la stanza
                            if (listaStanze[nuovaNord].visitata)
                            {
                                stanzaAttuale = listaStanze[nuovaNord];
                                posizioneAttuale = nuovaNord;
                                Testo($"\nSei ritornato nel {stanzaAttuale.nome}");
                            }
                            else
                            {
                                stanzaAttuale = listaStanze[nuovaNord];
                                posizioneAttuale = nuovaNord;
                                Console.WriteLine("\n" + listaStanze[nuovaNord].descrizione);
                                listaStanze[nuovaNord].visitata = true;
                                giocatore.stanzeVisitate.Add(nuovaNord);
                                Testo($"\nSei entrato nel {stanzaAttuale.nome}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non puoi andare in questa direzione");
                    }
                    break;
                case "est":
                    Posizione nuovaEst = new Posizione(posizioneAttuale.X + 1, posizioneAttuale.Y);
                    if (listaStanze.ContainsKey(nuovaEst))
                    {
                        listaStanze[nuovaEst].Nebbia(giocatore);
                        // controllo se è accessibile
                        if (!listaStanze[nuovaEst].chiave)
                        {
                            //controllon se il giocatore ha l'oggetto
                            //if (giocatore.inventario.Contains(chiave))

                            if (listaStanze[nuovaEst].visitata)
                            {
                                stanzaAttuale = listaStanze[nuovaEst];
                                posizioneAttuale = nuovaEst;
                            }
                            else
                            {
                                stanzaAttuale = listaStanze[nuovaEst];
                                posizioneAttuale = nuovaEst;
                                Console.WriteLine(listaStanze[nuovaEst].descrizione);
                                giocatore.stanzeVisitate.Add(nuovaEst);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Non hai la chiave per entrare, mi spiace");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non puoi andare in questa direzione");
                    }
                    break;
                case "ovest":
                    Posizione nuovaOvest = new Posizione(posizioneAttuale.X - 1, posizioneAttuale.Y);
                    if (listaStanze.ContainsKey(nuovaOvest))
                    {
                        listaStanze[nuovaOvest].Nebbia(giocatore);
                        // controllo se è accessibile
                        if (!listaStanze[nuovaOvest].chiave)
                        {
                            //controllon se il giocatore ha l'oggetto
                            //if (giocatore.inventario.Contains(chiave))
                            if (listaStanze[nuovaOvest].visitata)
                            {
                                stanzaAttuale = listaStanze[nuovaOvest];
                                posizioneAttuale = nuovaOvest;
                            }
                            else
                            {
                                stanzaAttuale = listaStanze[nuovaOvest];
                                posizioneAttuale = nuovaOvest;
                                Console.WriteLine(listaStanze[nuovaOvest].descrizione);
                                giocatore.stanzeVisitate.Add(nuovaOvest);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Non hai la chiave per entrare, mi spiace");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non puoi andare in questa direzione");
                    }
                    break;
                case "sud":
                    Posizione nuovaSud = new Posizione(posizioneAttuale.X, posizioneAttuale.Y - 1);
                    if (listaStanze.ContainsKey(nuovaSud))
                    {
                        listaStanze[nuovaSud].Nebbia(giocatore);
                        // controllo se è accessibile
                        if (!listaStanze[nuovaSud].chiave)
                        {
                            //controllon se il giocatore ha l'oggetto
                            //if (giocatore.inventario.Contains(chiave))

                            if (listaStanze[nuovaSud].visitata)
                            {
                                stanzaAttuale = listaStanze[nuovaSud];
                                posizioneAttuale = nuovaSud;
                            }
                            else
                            {
                                stanzaAttuale = listaStanze[nuovaSud];
                                posizioneAttuale = nuovaSud;
                                Console.WriteLine(listaStanze[nuovaSud].descrizione);
                                giocatore.stanzeVisitate.Add(nuovaSud);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Non hai la chiave per entrare, mi spiace");
                            Console.ReadLine();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Non puoi andare in questa direzione");
                    }
                    break;
                default:
                    Console.WriteLine("Questa non è una valida direzione...");
                    break;
            }
            Console.ReadLine();
        }
        
        public static void Teletrasporto()// metodo per il teletrasporto casuale
        {
            // creo un random per scegliere una stanza tra quelle già visitate
            Random fuga = new Random();
            Posizione salto = giocatore.stanzeVisitate[fuga.Next(giocatore.stanzeVisitate.Count)];
            //Console.WriteLine($"{salto.X},{salto.Y}");
            // se la stanza è presente 
            if (listaStanze.ContainsKey(salto))
            {
                stanzaAttuale = listaStanze[salto];
                posizioneAttuale = salto;
                Testo($"\nSei saltato nel {stanzaAttuale.nome}");
            }
        }

        public static void Testo(string testo, int attesa = 4) // metodo per il testo più interessante
        {
            foreach (char c in testo)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(attesa);
            }
            Console.WriteLine();
        }

        public static void Esci() // metodo per chiudere il gioco
        {
            // scrive il testo e poi esce dal gioco
            Testo("Ci vediamo presto");
            Environment.Exit(0);
        }

        public static void SetupElementi() // funzione per la creazione delle stanze, dei personaggi e degli oggetti al loro interno 
        {
            // STANZE AREA 1 
            Stanza ingressoCripta = new Stanza("Ingresso della Cripta", "L'ingresso della leggendaria tomba di Nandareth; l'aria e' leggermente umida, e i numerosi strati di polvere accumulati in tutta la stanza sono segno di una sola cosa: nessuno e' entrato qui da tempo.", false, true, false);
            Stanza ingressoOssuarioDemoni = new Stanza("Ingresso all'Ossuario dei Demoni", "Zona principale dell'ossuario, la stanza si estende verticalmente per una decina di metri. Ogni parete contiene centinaia di nicchie e lapidi, sulle quali sono incise iscrizioni in una lingua che non riesci a comprendere.", false, false, false);
            Stanza OssuarioDemoni = new Stanza("Ossuario dei Demoni", "Zona principale dell'ossuario, la stanza si estende verticalmente per una decina di metri. Ogni parete contiene centinaia di nicchie e lapidi, sulle quali sono incise iscrizioni in una lingua che non riesci a comprendere.", false, false, false);
            Stanza stanzaNascosta = new Stanza("Stanza Nascosta", "Un muro abbattuto rivela un piccolo stanzino, originariamente celato da tutti. Al suo interno vi e' solo un piccolo altare, qualche scaffale abbattuto e poco altro.", false, false, false);
            Stanza ossuarioDemoniSud = new Stanza("Ossuario dei Demoni - Zona Sud", "Stanza periferica dell'ossuario. I muri contengono meno incavature delle stanze precedenti, ma l'ambiente e' decorato da alcune statue simili a gargoyle, che sono piazzate con la faccia contro i muri, come se li stessero graffiando per provare ad uscire.", false, false, false);
            Stanza tombaOrnata = new Stanza("Tomba Ornata", "Una singola stanza, contenente una tomba monumentale. La statua che era stata eretta a sua protezione e' crollata con il tempo, lasciando come unico elemento intatto la lapide sul pavimento. Vi sono alcune tracce di fiori scarlatti rinsecchiti vicino ad essa.", false, false, false);

            Posizione posizioneIngressoCripta = new Posizione(0, 0);
            Posizione posizioneIngressoOssuarioDemoni = new Posizione(0, -1);
            Posizione posizioneOssuarioDemoni = new Posizione(0, -2);
            Posizione posizioneStanzaNascosta = new Posizione(1, -2);
            Posizione posizioneOssuarioDemoniSud = new Posizione(0, -3);
            Posizione posizioneTombaOrnata = new Posizione(-1, -3);

            // STANZE AREA 2 
            Stanza corridoioDissestato = new Stanza("Corridoio Dissestato", "Un passaggio di medie dimensioni. Sui lati di questa stanza, sono presenti torce il cui legno e' ormai marcio.", false, false, false);
            Stanza corridoioDissestatoII = new Stanza("Corridoio Dissestato II", "Continuo del passaggio. In tempi passati, questa stanza avrebbe fatto da incrocio per altre sezioni della cripta, ma adesso tutte le uscite sono inaccessibili eccetto per una.", false, false, false);
            Stanza stanzaConMurale = new Stanza("Stanza con Murale", "Una piccola stanza di forma quadrata, che non contiene molto a parte per l'enorme Murale che ricopre la parete difronte all'ingresso. Rappresenta la terribile scena di un gruppo di diavoli che rade al suolo una citta' attraverso le loro poderose fiamme.", false, false, false);

            Posizione posizioneCorridoioDissestato = new Posizione(-1, 0);
            Posizione posizioneCorridoioDissestatoII = new Posizione(-2, 0);
            Posizione posizioneStanzaConMurale = new Posizione(-2, -1);

            // STANZE AREA 3 
            Stanza passaggioRovinato = new Stanza("Passaggio rovinato", "Un'insenatura nella parete che fa da transizione per una zona piu' grande. Parte delle sono crollate, rendendo il passaggio ostico ma possibile.", false, false, false);
            Stanza tombeDeiDiavoliIngresso = new Stanza("Tombe dei diavoli - Ingresso", "Un enorme cimitero, pieno di tombe di ogni forma e dimensione. Sulle lapidi sono incisi nomi in una lingua che non conosci, e non e' raro trovare alcune offerte poste su di esse.", false, false, false);
            Stanza tombeDeiDiavoliOvest = new Stanza("Tombe dei Diavoli - Zona Ovest", "Continuo del cimitero, questa volta vi sono alcune statue che sono poste a mo di sentinella, probabilmente per spaventare gli incursori che tentano di profanare le tombe del luogo.", false, false, false);
            Stanza tombeDeiDiavoliNord = new Stanza("Tombe dei Diavoli - Zona Nord", "Continuo del cimitero, in questa porzione di esso le tombe sono minori in numero, ma anche piu' ornate e curate. Le offerte votive poste su di esse sembrano essere piu' preziose.", false, false, false);
            Stanza Cappella = new Stanza("Cappella", "Una piccola cappella locata al margine del cdimitero. Al suo interno sono presenti alcune nicchie incise su i muri, mentre sull'altare si trovano una serie di unguenti e pozioni dall'aspetto strano - e' la prima volta che vedi qualcosa di simile.", false, false, false);

            Posizione posizionePassaggioRovinato = new Posizione(0, 1);
            Posizione posizioneTombeDeiDiavoliIngresso = new Posizione(0, 2);
            Posizione posizioneTombeDeiDiavoliOvest = new Posizione(-1, 2);
            Posizione posizioneTombeDeiDiavoliNord = new Posizione(0, 3);
            Posizione posizioneCappella = new Posizione(-1, 3);

            // STANZE AREA 4 
            Stanza Lanterna = new Stanza("???", "La stanza e' ricoperta da una fitta nebbia, che ti impedisce di vedere a un palmo dal tuo naso. Forse sarebbe meglio tornare indietro.", false, false, false);
            Stanza tombaDiNandareth = new Stanza("Tomba di Nandareth - Entrata", "L'ambiente tetro ti da un senso di angoscia che non riesci a spiegare. Tutte le pareti della stanza sono piene fino all'orlo di bassorilievi rappresentanti demoni, diavoli e persone sofferenti all'unisono.", false, false, false);
            Stanza tombaDiNandarethNord = new Stanza("Tomba di Nandareth - Zona Nord", "Continuo della tomba. Vicino i muri vi sono varie armature arruginite, come se fossero a guardia di qualcosa.", false, false, false);
            Stanza tombaDiNandarethCerimonia = new Stanza("Tomba di Nandareth - Zona Cerimoniale", "Una stanza semi-nascosta, con all'interno un piccolo altare. Sopra di esso vi sono alcuni rotoli di papiro con sopra iscritte alcune strane formule magiche.", false, false, false);
            Stanza tombaDiNandarethEst = new Stanza("Tomba di Nandareth - Zona Est", "Apparentemente la fine della tomba cerimoniale, vi è un piccolo cunicolo illuminato da delle torce che, nonostante l'età del luogo, sono ancora accese. Su un muro di questa stanza vi è un affresco rovinato, rappresentante il demone in tutto il suo orrore.", false, false, false);

            //Posizione posizioneSenzaLanterna = new Posizione(1, 0);
            Posizione posizioneConLanterna = new Posizione(1, 0);
            Posizione posizioneTombaDiNandareth = new Posizione(2, 0);
            Posizione posizioneTombaDiNandarethNord = new Posizione(2, 1);
            Posizione posizioneTombaDiNandarethCerimonia = new Posizione(3, 1);
            Posizione posizioneTombaDiNandarethEst = new Posizione(3, 0);

            // STANZE AREA 5 
            Stanza criptaMisteriosa = new Stanza("Cripta Misteriosa - Entrata", "Una stanza diruta, ma illuminata per bene da una numerosa serie di torce. L'atmosfera si è fatta più pesante: c'è qualcosa di potente alla fine di quest'area.", false, false, false);
            Stanza criptaMisteriosaSud = new Stanza("Cripta Misteriosa - Zona Sud", "La stanza è ripiena di alcuni tavoli, con sopra scheletri cosparsi di quelle che sembrano rune rituali. ", false, false, false);
            Stanza criptaMisteriosaEst = new Stanza("Cripta Misteriosa - Zona Est", "Una statua di Nandareth troneggia al centro di questa stanza, con sotto di essa un'iscrizione in più lingue: \"Stolto che profani questa tomba, l'ombra del demone non prende in favore chi invade il suo dominio\".", false, false, false);
            Stanza criptaMisteriosaAtrioFinale = new Stanza("Cripta Misteriosa - Atrio Finale", "Una stanza cosparsa di scheletri avvizziti. Una delle due porte che hai dinanzi emana un'aura sinistra, tanto da farti tremare le gambe.", false, false, false);
            Stanza stanzaDelTesoro = new Stanza("Stanza del tesoro", "Quante ricchezze! Oro, diamanti, gioielli, ed altri tesori ancora più preziosi!", false, false, false);
            Stanza stanzaDiNandareth = new Stanza("Stanza di Nandareth", "Appena entri nella stanza, un'ombra tetra come la notte invade il tuo campo visivo. Occhi rossi come il sangue appaiono nelle tenebre, tuonando a gran voce parole di morte.", false, false, false);

            Posizione posizioneCriptaMisteriosa = new Posizione(3, -1);
            Posizione posizioneCriptaMisteriosaSud = new Posizione(3, -2);
            Posizione posizioneCriptaMisteriosaEst = new Posizione(4, -1);
            Posizione posizioneCriptaMisteriosaAtrioFinale = new Posizione(4, -2);
            Posizione posizioneStanzaDelTesoro = new Posizione(4, -3);
            Posizione posizioneStanzaDiNandareth = new Posizione(5, -2);

            // OGGETTI 
            Oggetto oggettoChiaveFinale = new Oggetto("LIGHT", "serve per poter danneggiare il boss", 0, false);
            Oggetto sasso = new Oggetto("Sasso", "Un normalissimo sasso...? Forse puoi lanciarlo a qualcosa, non si sa mai.", 2, true);
            Oggetto lanterna = new Oggetto("Lanterna delle nebbie", "Una cinerea lanterna, al suo interno arde una piccola fiamma bianca. Sulla basse dell'oggetto vi è inciso 'Per squarciare il velo che protegge Nandareth', chissà cosa potrà mai significare.", 2, true);
            Oggetto pozione = new Oggetto("Pozione di cura", "Una piccola ampolla con all'interno un liquido rossastro, simile a quelle vendute nei Bazar della tua città natia. Berla accelera il potere curativo del tuo corpo, rimarginando ferite e curando le malattie del corpo.", 1, true);
            Oggetto unguento = new Oggetto("Unguento Scarlatto", "Un olio rosso scarlatto racchiuso in un'ornata ampolla. Usarlo sulla tua spada potrebbe potenziarne le proprietà offensive.", 1, true);
            Oggetto lapide = new Oggetto("Lapide Dissestata", "Una lapide non troppo grande, ma non per questo meno pesante. Potrebbe tornare utile, o forse no.", 8, true);
            Oggetto chiave = new Oggetto("Chiave", "Una chiave in ferro arruginito. Il labirinto che crea la tomba di Nandareth è molto intricato e cela molti segreti, questa chiave potrebbe essere l'accesso ad uno di essi.", 1, true);

            // SPAWN DEI PERSONAGGI: BUONO; CATTIVO; TIPI DI NEMICI 
            Nemico scheletro = new("Scheletro", "Uno scheletro risorto, armato con una spada arruginita. Dal suo teschio protrudono due affilate corna.", false, false, null, 5, 2);
            Nemico statuaAnimata = new("Statua Animata", "Una delle statue decorative della tomba ha preso vita. Che si tratti di una strana creatura o di un sortilegio volto a scacciare chi profana questo sepolcro?", false, false, null, 3, 5);
            Personaggio personaggioBuono = new Personaggio("Arcangelo Incatenato", "", true, true, oggettoChiaveFinale);
            Personaggio personaggioCattivo = new Personaggio("Belphagor", "descrizione", true, false, null);
            Nemico bossFinale = new Nemico("BOSS", "", true, false, null, 8, 20);

            // ASSEGNAZIONE OGGETTI E PERSONAGGI ALLE STANZE
            ingressoCripta.oggettiPresenti.Add(sasso);
            ingressoCripta.oggettiPresenti.Add(lanterna);
            //ingressoCripta.AddPersonaggio(scheletro);
            //ingressoCripta.AddPersonaggio(bossFinale);
            ingressoCripta.spell = 1;
            ingressoOssuarioDemoni.spell = 2;
            OssuarioDemoni.spell = 3;
            Lanterna.Nebbia(giocatore);

            // LISTA COORDINATE 
            giocatore.stanzeVisitate.Add(posizioneIngressoCripta);
            giocatore.stanzeVisitate.Add(posizioneIngressoOssuarioDemoni);
            giocatore.stanzeVisitate.Add(posizioneOssuarioDemoni);
            giocatore.stanzeVisitate.Add(posizioneOssuarioDemoniSud);
            giocatore.stanzeVisitate.Add(posizioneStanzaNascosta);
            giocatore.stanzeVisitate.Add(posizioneTombaOrnata);
            giocatore.stanzeVisitate.Add(posizioneCorridoioDissestato);
            giocatore.stanzeVisitate.Add(posizioneCorridoioDissestatoII);
            giocatore.stanzeVisitate.Add(posizioneStanzaConMurale);
            giocatore.stanzeVisitate.Add(posizionePassaggioRovinato);
            giocatore.stanzeVisitate.Add(posizioneTombeDeiDiavoliIngresso);
            giocatore.stanzeVisitate.Add(posizioneTombeDeiDiavoliOvest);
            giocatore.stanzeVisitate.Add(posizioneTombeDeiDiavoliNord);
            giocatore.stanzeVisitate.Add(posizioneCappella);
            giocatore.stanzeVisitate.Add(posizioneConLanterna);
            giocatore.stanzeVisitate.Add(posizioneTombaDiNandareth);
            giocatore.stanzeVisitate.Add(posizioneTombaDiNandarethNord);
            giocatore.stanzeVisitate.Add(posizioneTombaDiNandarethCerimonia);
            giocatore.stanzeVisitate.Add(posizioneTombaDiNandarethEst);
            giocatore.stanzeVisitate.Add(posizioneCriptaMisteriosa);
            giocatore.stanzeVisitate.Add(posizioneCriptaMisteriosaSud);
            giocatore.stanzeVisitate.Add(posizioneCriptaMisteriosaEst);
            giocatore.stanzeVisitate.Add(posizioneCriptaMisteriosaAtrioFinale);
            giocatore.stanzeVisitate.Add(posizioneStanzaDelTesoro);
            giocatore.stanzeVisitate.Add(posizioneStanzaDiNandareth);

            // ASSEGNAZIONE DELLE STANZE COMPLETE AL DIZIONARIO 
            listaStanze.Add(posizioneIngressoCripta, ingressoCripta);
            listaStanze.Add(posizioneIngressoOssuarioDemoni, ingressoOssuarioDemoni);
            listaStanze.Add(posizioneOssuarioDemoni, OssuarioDemoni);
            listaStanze.Add(posizioneOssuarioDemoniSud, ossuarioDemoniSud);
            listaStanze.Add(posizioneStanzaNascosta, stanzaNascosta);
            listaStanze.Add(posizioneTombaOrnata, tombaOrnata);
            listaStanze.Add(posizioneCorridoioDissestato, corridoioDissestato);
            listaStanze.Add(posizioneCorridoioDissestatoII, corridoioDissestatoII);
            listaStanze.Add(posizioneStanzaConMurale, stanzaConMurale);
            listaStanze.Add(posizionePassaggioRovinato, passaggioRovinato);
            listaStanze.Add(posizioneTombeDeiDiavoliIngresso, tombeDeiDiavoliIngresso);
            listaStanze.Add(posizioneTombeDeiDiavoliOvest, tombeDeiDiavoliOvest);
            listaStanze.Add(posizioneTombeDeiDiavoliNord, tombeDeiDiavoliNord);
            listaStanze.Add(posizioneCappella, Cappella);
            listaStanze.Add(posizioneConLanterna, Lanterna);
            listaStanze.Add(posizioneTombaDiNandareth, tombaDiNandareth);
            listaStanze.Add(posizioneTombaDiNandarethNord, tombaDiNandarethNord);
            listaStanze.Add(posizioneTombaDiNandarethCerimonia, tombaDiNandarethCerimonia);
            listaStanze.Add(posizioneTombaDiNandarethEst, tombaDiNandarethEst);
            listaStanze.Add(posizioneCriptaMisteriosa, criptaMisteriosa);
            listaStanze.Add(posizioneCriptaMisteriosaSud, criptaMisteriosaSud);
            listaStanze.Add(posizioneCriptaMisteriosaEst, criptaMisteriosaEst);
            listaStanze.Add(posizioneCriptaMisteriosaAtrioFinale, criptaMisteriosaAtrioFinale);
            listaStanze.Add(posizioneStanzaDelTesoro, stanzaDelTesoro);
            listaStanze.Add(posizioneStanzaDiNandareth, stanzaDiNandareth);

            // SPAWN PERSONAGGIO BUONO IN UNA STANZA RANDOM 
            Random spawn = new Random();
            Posizione temp = new Posizione();
            do
            {
                temp.X = spawn.Next(-1, 2);
                temp.Y = spawn.Next(-1, 2);
            } while (!giocatore.stanzeVisitate.Contains(temp));
            listaStanze[temp].AddPersonaggio(personaggioBuono);

            // SPAWN PERSONAGGIO CATTIVO RANDOM IN UNA STANZA DIVERSA DA QUELLA DEL PERSONAGGIO BUONO 
            do
            {
                temp.X = spawn.Next(-1, 4);
                temp.Y = spawn.Next(-2, 3);
                if (giocatore.stanzeVisitate.Contains(temp))
                {
                    if (!listaStanze[temp].npc.Contains(personaggioBuono))
                    {
                        listaStanze[temp].AddPersonaggio(personaggioCattivo);
                        break;
                    }
                }
            } while (true);
            
        }

        public static void SetupIniziale()
        {
            // OGGETTI INIZIALI GIOCATORE
            giocatore.vita = 15;
            giocatore.attacco = 1;

            // POSIZIONE INIZIALE 
            posizioneAttuale = new Posizione(0, 0);
            stanzaAttuale = listaStanze[posizioneAttuale];
        }

        public static void Partita(Giocatore giocatore)
        {
            giocatore.stanzeVisitate = giocatore.stanzeVisitate.Distinct().ToList();
            Console.Clear();
            Console.WriteLine("Cosa vuoi fare: [ Analizza ] la stanza, [ Inventario ], [ Muovi ], [ Parla ], [ Combatti ], [ Salta ], [ Dormi/Salva ] ");
            int indice = 0;
            string input = Console.ReadLine().ToLower();
            switch (input) // switch per la scelta delle azioni del giocatore ogni turno
            {
                case "analizza": case "a":
                    stanzaAttuale.AnalizzaStanza(giocatore);
                    Console.ReadLine();
                    break;
                case "inventario": case "i":
                    Inventario();
                    break;
                case "muovi": case "m":
                    MovimentoPersonaggio();
                    break;
                case "parla": case "p":
                    //Dialogo();
                    break;
                case "combatti": case "c":
                    if(stanzaAttuale.npc.Count > 0)
                    {
                        foreach(Personaggio p in stanzaAttuale.npc)
                        {
                            if (!p.buono)
                            {
                                Combattimento(giocatore, p);
                                break;
                            } else
                            {
                                continue;
                            }
                        }
                    }
                    
                    break;
                case "salta": case "s":
                    Teletrasporto();
                    break;
                case "dormi": case "d":
                    SavePlayer(giocatore, "Giocatore.xml");
                    Console.WriteLine("Gioco salvato con successo!");
                    Console.ReadLine();
                    break;
            }
        }
        
        static void Main(string[] args) // MANCANO I DETTAGLI
        {
            Console.Clear();

            // TESTO INTRODUTTIVO
            Testo("Era una notte buia e tempestosa, e un piccolo esploratore si faceva lentamente strada tra le insidie del Bosco del Non Ritorno. Il suo equipaggiamento era poco e malandato, ma l'obiettivo che si era imposto era più che grande: scoprire i segreti che uno dei tanti templi nascosti in quella selva celava, la tomba del demone Nandareth.");

            // FUNZIONE: CHIEDO IL NOME
            Console.Write("Inizia così l'avventura di : ");
            string input = Console.ReadLine();
            if (input == "" || input == null)
            {
                Console.WriteLine("Va bene, tieniti pure i tuoi segreti, STRANIERO \n");
                giocatore.nome = "STRANIERO";
            }

            Console.Clear();
            Console.WriteLine(" ======= Menu ======== ");
            Console.WriteLine(" + Nuova partita ");
            Console.WriteLine(" + Carica partita ");
            Console.WriteLine(" - Esci ");
            Console.WriteLine(" ===================== ");

            // menù del gioco si danno 3 scelte: NUOVA PARTITA, CARICA PARTITA, ESCI
            bool inputValido = false;
            while (!inputValido)
            {
                string scelta = Console.ReadLine().ToLower();
                switch (scelta)
                {
                    case "nuova": // setta tutti gli elementi del gioco e crea un nuovo file di salvataggio
                        //Console.WriteLine("carico gli elementi");
                        SetupElementi();
                        SetupIniziale();
                        inputValido = true;
                        break;
                    case "carica": // carica il personaggio salvato in quello attuale e continua la partita da quel punto
                        Console.WriteLine("Carico la partita...");
                        giocatore = LoadPlayer<Giocatore>("Giocatore.xml");
                        SetupElementi();
                        inputValido = true;
                        break;
                    case "esci": // chiude il gioco
                        Console.WriteLine("È stato bello per quello che è durato");
                        Esci();
                        break; //easter egg
                    default:
                        Console.WriteLine("Non penso sia una scelta possibile.... riprova");
                        break;
                }

            }
            giocatore.stanzeVisitate.Clear();
            while (giocatore.vita >= 0) Partita(giocatore);
        }
                
        public static void Combattimento(Giocatore pg, Personaggio en) // FUNZIONE PER IL COMBATTIMENTO
        {
            Personaggio nemico = en;
            Random random = new Random();
            string nomeNemico = nemico.nome;
            int attaccoNemico = nemico.attacco;
            int vitaNemico = nemico.vita;
            int difesa = 0;

            if (vitaNemico > 0)
            {
                Console.Clear();
                Console.WriteLine("Ti ha attaccato " + nomeNemico + "!");
                // fino a che il nemico è vivo il combattimento continua
                while (vitaNemico > 0)
                {
                    Console.WriteLine(" ===================== ");
                    Console.WriteLine("| (A)ttacco (D)ifendi |");
                    Console.WriteLine("| (S)pell   (O)ggetti |");
                    Console.WriteLine(" ===================== ");
                    Console.WriteLine("I tuoi PV: " + pg.vita);
                    Console.WriteLine("I PV del nemico: " + vitaNemico);
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "attacco":
                            if (nemico.CheckBoss())
                            {
                                pg.attacco = 0;
                                Console.WriteLine($"Il tuo attacco non ha effetto su {nemico.nome}");
                                break;
                            }
                            //Genera un numero casuale per determinare l'esito dell'attacco
                            int roll = random.Next(1, 21);
                            switch (roll)
                            {
                                case 1: //Miss
                                    Console.WriteLine("Lanci un attacco con tutta la tua forza, ma il nemico riesce a schivare all'ultimo secondo.");
                                    Console.ReadKey();
                                    break;
                                case 20: //Crit
                                    Console.WriteLine("UN COLPO DEVASTANTE! Il nemico trema difronte all'impeto del tuo colpo.");
                                    Console.ReadKey();
                                    vitaNemico -= pg.attacco * 2;    //calcolo dei danni raddoppiati al nemico
                                    break;
                                default: //Attacco va a segno con successo
                                    Console.WriteLine("Colpisci il nemico con la tua spada!");
                                    Console.ReadKey();
                                    vitaNemico -= pg.attacco;    //calcolo dei danni al nemico
                                    break;
                            }
                            break;
                        case "difesa":
                            //difesa = riduci i danni ricevuti dal prossimo attacco
                            Console.WriteLine("Alzi la spada in difesa.");
                            Console.ReadKey();
                            difesa = random.Next(1, 6); //Modifier randomico che sarà sottratto al prossimo attacco in arrivo
                            break;
                        case "spell":
                            Console.WriteLine("Recita l'incantamento a gran voce!");
                            string spell = Console.ReadLine();  //Inserimento dell'incantesimo: FRE, HLE, AGHISLOV sono opzioni accette, qualsiasi altro input sarà considerato un fallimento del casting
                            switch (spell.ToLower())
                            {
                                case "fre":
                                    Console.WriteLine("Hai evocato il potere del fuoco! Fiamme incandescenti avvolgono il nemico!");
                                    if (nemico.CheckBoss())
                                    {
                                        Console.WriteLine($"Il tuo attacco non ha effetto su {nemico.nome}");
                                        break;
                                    }
                                    vitaNemico -= random.Next(1, 11);
                                    Console.ReadKey();
                                    break;
                                case "hle":
                                    Console.WriteLine("Vieni circondato da un'aura verde, che lentamente lenisce le tue ferite.");
                                    pg.vita += random.Next(1, 8);
                                    Console.ReadKey();
                                    break;
                                case "aghislov":
                                    Console.WriteLine("AGHISLOV * fischi, il diavolo ora è scarso or smth");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("ARGH! L'incantesimo non era corretto, e fallisce!");
                                    Console.ReadKey();
                                    break;
                            }
                            break;
                        case "oggetto":
                            if (giocatore.inventario.Count > 0)
                            {
                                Oggetto oggetto = giocatore.inventario.Pop() as Oggetto;
                                switch (oggetto.nome)
                                {
                                    case "Sasso":
                                        Console.WriteLine("Lanci il sasso al nemico! Utile...?");
                                        stanzaAttuale.AddOggetto(oggetto);
                                        vitaNemico -= 2;
                                        break;
                                    case "Pozione":
                                        Console.WriteLine("Bevi la pozione e ti senti subito rinvigorito.");
                                        giocatore.vita += 5;
                                        break;
                                    default:
                                        Console.WriteLine("Non avrebbe alcun effetto!");
                                        giocatore.inventario.Push(oggetto);
                                        break;
                                }                     
                            }
                            else
                            {
                                Console.WriteLine("Non hai nessun oggetto!");
                                Console.ReadKey();
                            }
                            break;
                        default:
                            Console.WriteLine("Sprechi il turno a non fare niente, vista la tua indecisione.");
                            Console.ReadKey();
                            break;
                    }
                    Console.ReadLine();

                    ////FASE DI ATTACCO
                    //if (input.ToLower() == "a" || input.ToLower() == "attacco")
                    //{
                    //    //Genera un numero casuale per determinare l'esito dell'attacco
                    //    int roll = random.Next(1, 21);

                    //    switch (roll)
                    //    {
                    //        case 1: //Miss
                    //            Console.WriteLine("Lanci un attacco con tutta la tua forza, ma il nemico riesce a schivare all'ultimo secondo.");
                    //            Console.ReadKey();
                    //            break;
                    //        case 20: //Crit
                    //            Console.WriteLine("UN COLPO DEVASTANTE! Il nemico trema difronte all'impeto del tuo colpo.");
                    //            Console.ReadKey();
                    //            vitaNemico -= pg.attacco * 2;    //calcolo dei danni raddoppiati al nemico
                    //            break;
                    //        default: //Attacco va a segno con successo
                    //            Console.WriteLine("Colpisci il nemico con la tua spada!");
                    //            Console.ReadKey();
                    //            vitaNemico -= pg.attacco;    //calcolo dei danni al nemico
                    //            break;
                    //    }
                    //}
                    ////DIFESA
                    //else if (input.ToLower() == "d" || input.ToLower() == "difendi")
                    //{
                    //    //difesa = riduci i danni ricevuti dal prossimo attacco
                    //    Console.WriteLine("Alzi la spada in difesa.");
                    //    Console.ReadKey();
                    //    int defence = random.Next(1, 6); //Modifier randomico che sarà sottratto al prossimo attacco in arrivo
                    //}
                    ////SPELL
                    //else if (input.ToLower() == "s" || input.ToLower() == "spell")
                    //{
                    //    Console.WriteLine("Recita l'incantamento a gran voce!");
                    //    string spell = Console.ReadLine();  //Inserimento dell'incantesimo: FRE, HLE, AGHISLOV sono opzioni accette, qualsiasi altro input sarà considerato un fallimento del casting

                    //    switch (spell.ToLower())
                    //    {
                    //        case "FRE":
                    //            Console.WriteLine("Hai evocato il potere del fuoco! Fiamme incandescenti avvolgono il nemico!");
                    //            vitaNemico -= random.Next(1, 11);
                    //            Console.ReadKey();
                    //            break;
                    //        case "HLE":
                    //            Console.WriteLine("Vieni circondato da un'aura verde, che lentamente lenisce le tue ferite.");
                    //            pg.vita += random.Next(1, 8);
                    //            Console.ReadKey();
                    //            break;
                    //        case "AGHISLOV":
                    //            Console.WriteLine("AGHISLOV * fischi, il diavolo ora è scarso or smth");
                    //            Console.ReadKey();
                    //            break;
                    //        default:
                    //            Console.WriteLine("ARGH! L'incantesimo non era corretto, e fallisce!");
                    //            Console.ReadKey();
                    //            break;
                    //    }
                    //}
                    ////OGGETTI
                    //else if (input.ToLower() == "o" || input.ToLower() == "oggetti") //SEZIONE STRUMENTI WORK IN PROGRESS
                    //{
                    //    pg.ControlloPozione(pg);
                    //    Console.ReadKey();
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Sprechi il turno a non fare niente, vista la tua indecisione.");
                    //    Console.ReadKey();
                    //}

                    Console.WriteLine();

                    //TURNO DEL NEMICO
                    if (vitaNemico <= 0)
                    {
                        Console.WriteLine("Il " + nomeNemico + " è morto!");
                        stanzaAttuale.npc.Remove(nemico);
                        break; //nemico è morto, forzo uscita dal loop
                    }
                    else
                    {
                        //fase di attacco nemico
                        int enroll = random.Next(1, 21);

                        switch (enroll)
                        {
                            case 1: //Miss
                                Console.WriteLine(nomeNemico + " fa un passo falso, permettendoti di schivare l'attaco.");
                                break;
                            case 20: //Crit
                                Console.WriteLine("UN COLPO DEVASTANTE! L'attacco ti ha fatto molto male, lanciandoti via di qualche metro.");
                                pg.vita -= (attaccoNemico * 2) - difesa;    //calcolo dei danni raddoppiati al giocatore
                                difesa = 0;
                                break;
                            default: //Attacco va a segno con successo
                                Console.WriteLine(nomeNemico + " ti colpisce con successo.");
                                pg.vita -= attaccoNemico - difesa;    //calcolo dei danni al giocatore
                                difesa = 0;
                                break;
                        }
                    }
                    // MORTE DEL GIOCATORE
                    if (pg.vita <= 0)
                    {
                        Console.WriteLine("Sei morto lol.");
                        // mostrare le statistiche ?
                        System.Environment.Exit(0);
                    }
                    Console.ReadLine ();
                    Console.Clear();
                }
                Console.ReadKey();
            }
        }

    }
}