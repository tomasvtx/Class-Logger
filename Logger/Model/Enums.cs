namespace Logger.Model
{
    /// <summary>
    /// Třída obsahující výčtové typy (Enums)
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Stavy procesu přihlášení
        /// </summary>
        public enum StavyPrihlaseni
        {
            /// <summary>
            /// Přihlášeno
            /// </summary>
            Logged = 101,

            /// <summary>
            /// Neautorizováno
            /// </summary>
            Unauthorized = 102,

            /// <summary>
            /// Uživatel neexistuje
            /// </summary>
            NotExist = 103,

            /// <summary>
            /// Chyba v databázi
            /// </summary>
            DBError = 994
        }

        /// <summary>
        /// Stavy procesu databáze
        /// </summary>
        public enum StavDatabaze
        {
            /// <summary>
            /// Databáze běží
            /// </summary>
            Running = 1,

            /// <summary>
            /// Inicializace databáze
            /// </summary>
            InitDb = 2,

            /// <summary>
            /// Aktualizace DDS v databázi
            /// </summary>
            DbUpdateDds = 20,

            /// <summary>
            /// Čtení DDS z databáze
            /// </summary>
            DbReadDds = 21,

            /// <summary>
            /// Aktualizace dat v databázi
            /// </summary>
            DbUpdateData = 22,

            /// <summary>
            /// Čtení dat z databáze
            /// </summary>
            DbReadData = 23,

            /// <summary>
            /// Chyba databáze
            /// </summary>
            DbError = 994
        }

        /// <summary>
        /// Stavy procesu čtečky čárových kódů (Barcode Reader)
        /// </summary>
        public enum StavBCS
        {
            /// <summary>
            /// BCS běží
            /// </summary>
            Running = 1,

            /// <summary>
            /// Inicializace BCS
            /// </summary>
            InitBcs = 3,

            /// <summary>
            /// Otevření BCS
            /// </summary>
            OpenBcs = 4,

            /// <summary>
            /// Čtení čárového kódu (BC)
            /// </summary>
            BcRead = 10,

            /// <summary>
            /// Čárový kód přečten
            /// </summary>
            BarcoreReaded = 12,

            /// <summary>
            /// Chyba BCR (Barcode Reader)
            /// </summary>
            BcrError = 990,

            /// <summary>
            /// Chyba čárového kódu
            /// </summary>
            BarcodeError = 997
        }


        /// <summary>
        /// Stavy procesu Tiskárny
        /// </summary>
        public enum StavTiskarny
        {
            /// <summary>
            /// Inicializace tiskárny
            /// </summary>
            InitPrinter = 3,

            /// <summary>
            /// Otevření tiskárny
            /// </summary>
            OpenPrinter = 4,

            /// <summary>
            /// Tisk na tiskárně
            /// </summary>
            PrinterWrite = 10,

            /// <summary>
            /// Uzavření tiskárny
            /// </summary>
            PrinterClose = 55,

            /// <summary>
            /// Odeslání ZPL
            /// </summary>
            ZplSend = 700,

            /// <summary>
            /// Chyba tiskárny
            /// </summary>
            PrinterError = 990,

            /// <summary>
            /// Chyba ZPL
            /// </summary>
            ZplError = 997
        }

        /// <summary>
        /// Stavy procesu dopravníku
        /// </summary>
        public enum StavDopravniku
        {
            /// <summary>
            /// Čekání na paletu
            /// </summary>
            WaitPalete = 30,

            /// <summary>
            /// Čekání na shodující se paletu
            /// </summary>
            PaleteWaitMatching = 31,

            /// <summary>
            /// Čekání na paletu u stroje
            /// </summary>
            PaleteWaitMachine = 32,

            /// <summary>
            /// Čekání na paletu u operátora
            /// </summary>
            PaleteWaitOperator = 33,

            /// <summary>
            /// Čtení palety
            /// </summary>
            PaleteRead = 34,

            /// <summary>
            /// Zápis palety
            /// </summary>
            PaleteWrite = 35
        }

        /// <summary>
        /// Stavy procesu senzorů
        /// </summary>
        public enum StavSenzoru
        {
            /// <summary>
            /// Inicializace senzorů
            /// </summary>
            InitSensor = 3,

            /// <summary>
            /// Čtení senzorů
            /// </summary>
            SensorRead = 10,

            /// <summary>
            /// Chyba senzorů
            /// </summary>
            SensorError = 990
        }

        /// <summary>
        /// Stavy procesu práce s obrazem
        /// </summary>
        public enum StavObrazu
        {
            /// <summary>
            /// Inicializace obrázku
            /// </summary>
            InitImage = 1,

            /// <summary>
            /// Inicializace FTP
            /// </summary>
            InitFtp = 5,

            /// <summary>
            /// Seznam FTP
            /// </summary>
            FtpList = 24,

            /// <summary>
            /// Chyba FTP
            /// </summary>
            FtpError = 889,

            /// <summary>
            /// Načítání obrázku
            /// </summary>
            LoadImage = 6,

            /// <summary>
            /// Chyba obrázku
            /// </summary>
            ErrorImage = 990
        }

        /// <summary>
        /// Klasické stavy procesu
        /// </summary>
        public enum ProcessState
        {
            /// <summary>
            /// Inicializace
            /// </summary>
            Init = 0,

            /// <summary>
            /// Inicializace DIO
            /// </summary>
            InitDio = 1,

            /// <summary>
            /// Inicializace dokončena
            /// </summary>
            InitDone = 8,

            /// <summary>
            /// Start
            /// </summary>
            Start = 9,

            /// <summary>
            /// Čekání na uživatele
            /// </summary>
            WaitUser = 4,

            /// <summary>
            /// Linq
            /// </summary>
            Linq = 15,

            /// <summary>
            /// Dokončení
            /// </summary>
            Done = 800,

            /// <summary>
            /// Software chyba
            /// </summary>
            SwError = 900,

            /// <summary>
            /// Zobrazení dialogu
            /// </summary>
            ShowDialog = 910,

            /// <summary>
            /// Chyba v SIO
            /// </summary>
            SioError = 991,

            /// <summary>
            /// Chyba v DIO
            /// </summary>
            DioError = 996,

            /// <summary>
            /// Příprava k ukončení
            /// </summary>
            PrepareToExit = 998,

            /// <summary>
            /// Připraven k ukončení
            /// </summary>
            ReadyToExit = 999
        }
    }
}
