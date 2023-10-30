using System.Collections.Generic;

namespace Logger.Model
{
    /// <summary>
    /// Třída obsahující slovníky pro různé stavy procesů.
    /// </summary>
    public class DictionaryStates
    {
        protected static Dictionary<int, (string Text, bool IsError)> StavyDopravniku = new Dictionary<int, (string Text, bool IsError)>
    {
        {30, ("Čekám na paletu", false)},
        {31, ("Čekám na shodu", false)},
        {32, ("Čekám na data PLC", false)},
        {33, ("Čekám na operátora", false)},
        {34, ("PLC Čtení", false)},
        {35, ("PLC Zápis", false)}
    };

        protected static Dictionary<int, (string Text, bool IsError)> StavyPrihlaseni = new Dictionary<int, (string Text, bool IsError)>
    {
        {101, ("Přihlášeno", false)},
        {102, ("Nedostatečná oprávnění", true)},
        {103, ("Neexistuje", true)},
        {994, ("Chyba databáze", true)}
    };

        /// <summary>
        /// Instrukce procesu
        /// </summary>
        protected static Dictionary<int, (string Text, bool IsError)> StavyDatabaze = new Dictionary<int, (string Text, bool IsError)>
    {
        {1, ("Spuštění DB úkolu", false)},
        {2, ("Inicializace DB", false)},
        {20, ("Aktualizace DDS", false)},
        {21, ("Čtení DDS", false)},
        {22, ("Aktualizace dat v DB", false)},
        {23, ("Čtení dat z DB", false)},
        {994, ("Chyba databáze", true)}
    };

        /// <summary>
        /// Instrukce procesu
        /// </summary>
        protected static Dictionary<int, (string Text, bool IsError)> StavyBCS = new Dictionary<int, (string Text, bool IsError)>
    {
        {1, ("Inicializace BCS", false)},
        {3, ("Inicializace BCS", false)},
        {4, ("BCS je otevřeno", false)},
        {10, ("Načtěte kód", false)},
        {12, ("Čtení BCR", false)},
        {990, ("Chyba čtečky", true)},
        {997, ("Chybný kód", true)}
    };

        protected static Dictionary<int, (string Text, bool IsError)> StavyTiskarny = new Dictionary<int, (string Text, bool IsError)>
    {
        {3, ("Inicializace tiskárny", false)},
        {4, ("Otevřeno PRN", false)},
        {10, ("Tisk", false)},
        {55, ("Zavírání PRN", false)},
        {700, ("Odesláno na tiskárnu", false)},
        {990, ("Chyba tiskárny", true)},
        {997, ("Chyba ZPL", true)}
    };

        /// <summary>
        /// Instrukce procesu
        /// </summary>
        protected static Dictionary<int, (string Text, bool IsError)> StavySenzoru = new Dictionary<int, (string Text, bool IsError)>
    {
        {3, ("Inicializace senzoru", false)},
        {10, ("Čtení dat ze senzoru", false)},
        {990, ("Chyba čtení ze senzoru", true)},
    };

        /// <summary>
        /// Instrukce procesu
        /// </summary>
        protected static Dictionary<int, (string Text, bool IsError)> StavyObrazku = new Dictionary<int, (string Text, bool IsError)>
    {
        {1, ("Inicializace obrazu", false)},
        {5, ("Inicializace FTP", false)},
        {24, ("FTP seznam hotov", false)},
        {889, ("Načtěte kód", false)},
        {12, ("FTP chyba", true)},
        {6, ("Načítání obrazu", false)},
        {990, ("Chyba obrázku", true)}
    };

        /// <summary>
        /// Instrukce procesu
        /// </summary>
        protected static Dictionary<int, (string Text, bool IsError)> StavyProgramu = new Dictionary<int, (string Text, bool IsError)>
    {
        {4, ("Zadat data", false)},
        {15, ("Seznam LINQ", false)},
        {800, ("Dokončen úkol", false)},
        {900, ("Interní chyba", true)},
        {910, ("Zobrazit dialog", false)},
        {998, ("Ukončování", false)},
        {999, ("Připraveno k ukončení", false)}
    };
    }
}
