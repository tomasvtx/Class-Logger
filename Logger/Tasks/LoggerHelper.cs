using Logger.Model;
using MyApplication;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Media;

namespace Logger.Tasks
{
    internal class LoggerHelper
    {
        /// <summary>
        /// Formátovací řetězec pro logování času v milisekundách s třemi desetinnými místy.
        /// </summary>
        private const string formatTimeLogMilliseconds = "D3";

        /// <summary>
        /// Formátovací řetězec pro logování času v sekundách s třemi desetinnými místy.
        /// </summary>
        private const string formatTimeLogSeconds = "D3";

        private const string statusCodeFormat = "D3";

        /// <summary>
        /// Získá čas provádění ve formátu pro záznam události.
        /// </summary>
        /// <param name="stopwatch">Stopky pro měření času</param>
        /// <returns>Čas provádění ve vhodném formátu pro záznam</returns>
        protected static string GetFormattedElapsedTime(Stopwatch stopwatch)
        {
            return $"    {((int)stopwatch?.Elapsed.TotalSeconds).ToString(formatTimeLogSeconds)}.{stopwatch?.Elapsed.Milliseconds.ToString(formatTimeLogMilliseconds)}";
        }

        /// <summary>
        /// Vytvoří kompletní zprávu pro uložení do souboru TXT.
        /// </summary>
        /// <param name="title">Název zprávy</param>
        /// <param name="time">Čas zprávy</param>
        /// <param name="code">Kód stavu</param>
        /// <returns>Kompletní zpráva pro uložení</returns>
        protected static string GetCompleteStatusMessage(string title, string time, int code)
        {
            return $"{time} {code.ToString(statusCodeFormat)} {title}";
        }

        /// <summary>
        /// Vrátí titulek hlavního okna na základě konfigurace aplikace a stavového kódu.
        /// </summary>
        /// <param name="myApp">Instance rozhraní IMyApp, obsahující konfiguraci a prostředky aplikace</param>
        /// <param name="code">Stavový kód, který bude začleněn do titulku</param>
        /// <returns>Titulek hlavního okna aplikace</returns>
        protected static string GetMainWindowTitle(IMyApp myApp, int code)
        {
            // Sestavení titulku hlavního okna obsahující název aplikace, verzi, stavový kód a verzi .NET Frameworku
            return $"{myApp?.AppConfig?.AppConfiguration?.AppName} {myApp?.Resources?.AppType?.Assembly?.GetName()?.Version} [{code.ToString(statusCodeFormat)}] {myApp?.Resources?.DotNetVersion}";
        }


        /// <summary>
        /// Vytváří a vrací objekt LogEntries reprezentující záznam pro zobrazení na obrazovce pomocí vzoru MVVM.
        /// </summary>
        /// <param name="processState">Stav procesu</param>
        /// <param name="title">Název zprávy</param>
        /// <param name="code">Kód zprávy</param>
        /// <param name="time">Čas zprávy</param>
        /// <returns>Objekt LogEntries reprezentující záznam</returns>
        protected static LogEntries CreateLogEntry(ProcessStateInput processState, string title, int code, string time)
        {
            // Získá stav pro záznam
            var output = Tasks.GetState.GetFromState(processState);

            // Získá barvu pro záznam na základě stavu procesu a informace o chybě
            SolidColorBrush barva = GetLogEntryColor(processState, output.IsError);

            // Vytvoří objekt LogEntries s potřebnými údaji pro zobrazení v uživatelském rozhraní
            return new LogRecordMVVM
            {
                Timestamp = DateTime.Now,
                DisplayedMessage = title,
                ProcessStatusString = processState?.ProcessName,
                Color = barva,
                ProcessStatus = $"[{code.ToString(statusCodeFormat)}]",
                Time = time,
                Width = 365
            };
        }

        /// <summary>
        /// Získá barvu pro záznam na základě stavu procesu a informace o chybě.
        /// </summary>
        /// <param name="processState">Stav procesu</param>
        /// <param name="isError">Indikuje, zda se jedná o chybu</param>
        /// <returns>Barva pro záznam</returns>
        protected static SolidColorBrush GetLogEntryColor(ProcessStateInput processState, bool isError)
        {
            SolidColorBrush barva;

            // Nastaví barvu na základě popisu procesu
            switch (processState.Description)
            {
                case "DOPRAV":
                    barva = new SolidColorBrush(Colors.LightSkyBlue);
                    break;
                case "DB":
                    barva = new SolidColorBrush(Colors.LightGreen);
                    break;
                case "BCS":
                    barva = new SolidColorBrush(Colors.LightPink);
                    break;
                case "SENSOR":
                    barva = new SolidColorBrush(Colors.LightYellow);
                    break;
                case "PRINTER":
                    barva = new SolidColorBrush(Colors.LightPink);
                    break;
                case "IMG":
                    barva = new SolidColorBrush(Colors.MediumPurple);
                    break;
                case "PRG":
                    barva = new SolidColorBrush(Colors.SandyBrown);
                    break;
                case "LOGIN":
                    barva = new SolidColorBrush(Colors.LightCyan);
                    break;
                default:
                    // Výchozí barva pro ostatní případy
                    barva = new SolidColorBrush(Colors.Gray); // Můžete zvolit jinou výchozí barvu
                    break;
            }

            // Pokud je záznam označen jako chyba, změní barvu na výraznější odstín
            if (isError)
            {
                barva = new SolidColorBrush(Colors.PaleVioletRed);
            }

            return barva;
        }

        /// <summary>
        /// Uloží záznam o události do souboru v určeném umístění.
        /// </summary>
        /// <param name="myApp">Instance rozhraní IMyApp, obsahující konfiguraci a prostředky aplikace</param>
        /// <param name="stavProcesu">Stav procesu, který je součástí události</param>
        /// <param name="zprava">Textová zpráva popisující událost</param>
        /// <param name="metoda">Metoda, která vytvořila záznam o události</param>
        public static void SaveEventRecord(IMyApp myApp, ProcessStateInput stavProcesu, string zprava, MethodBase metoda)
        {
            try
            {
                // Získání výchozího umístění pro uložení záznamu
                string umisteniZaznamu = myApp?.AppConfig?.AppConfiguration?.Logger?.RecordLocation ?? @"C:\PE_OUTPUT";

                // Vytvoření názvu souboru pro záznam s aktuálním datem
                string nazevSouboruZaznamu = $"{DateTime.Now:yyyyMMdd}-" + (myApp?.AppConfig?.AppConfiguration?.Logger?.RecordFileName ?? "LOG") + ".txt";

                // Sestavení obsahu záznamu
                string obsahZaznamu = $"\n\n\n{DateTime.Now}\n{zprava}\nVe: {metoda?.DeclaringType?.FullName}.{metoda?.Name}";

                // Sestavení složky pro záznam
                string slozka = Path.Combine(umisteniZaznamu, $"{myApp?.Resources?.AppType?.Assembly?.GetName()?.Name}");

                // Názvy složek pro různé typy záznamů
                string[] slozky = { myApp?.AppConfig?.AppConfiguration?.Logger?.AppLogErorPath ?? "_ErrLog", myApp?.AppConfig?.AppConfiguration?.Logger?.AppLogErrorInternal ?? "_InternalErrorLog", myApp?.AppConfig?.AppConfiguration?.Logger?.AppLogPathName ?? "_Applog" };
                string chybovaSlozka = null;

                // Získání výstupu pro stav procesu
                var output = Tasks.GetState.GetFromState(stavProcesu);

                // Rozhodnutí, do které složky záznam uložit na základě stavu procesu a obsahu zprávy
                if ((stavProcesu?.ProcessName?.Contains("ERROR") != false) || zprava?.Contains("ERROR") != false || output.IsError)
                {
                    chybovaSlozka = slozka + slozky[0];
                }
                else if (stavProcesu?.ProcessName == null)
                {
                    chybovaSlozka = slozka + slozky[1];
                }

                // Pokud složka pro chybové záznamy neexistuje, vytvoří ji
                if (chybovaSlozka != null && !Directory.Exists(chybovaSlozka))
                {
                    Directory.CreateDirectory(chybovaSlozka);
                }

                // Základní složka pro záznamy
                string zakladniSlozkaZaznamu = slozka + slozky[2];

                // Pokud složka pro záznamy neexistuje, vytvoří ji
                if (!Directory.Exists(zakladniSlozkaZaznamu))
                {
                    Directory.CreateDirectory(zakladniSlozkaZaznamu);
                }

                // Určení konečné cesty pro záznam
                string cestaKZaznamu = chybovaSlozka ?? zakladniSlozkaZaznamu;

                // Zápis záznamu do souboru
                File.AppendAllText(Path.Combine(cestaKZaznamu, nazevSouboruZaznamu), obsahZaznamu);
            }
            catch
            {
                // Chyby při zápisu jsou ignorovány
            }
        }

    }
}
