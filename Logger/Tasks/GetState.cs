using Logger.Model;
using System.Collections.Generic;
using System;

namespace Logger.Tasks
{
    /// <summary>
    /// Tato třída obsahuje metody pro získávání a popis stavu procesů z různých kategorií na základě vstupního výčtového typu.
    /// </summary>
    public class GetState : DictionaryStates
    {
        /// <summary>
        /// Získá nebo nastaví název procesu.
        /// </summary>
        public static ProcessStateInput Get<T>(T stav) where T : Enum
        {
            var popisProcesu = GetProcessDescription(stav);
            var idProcesu = stav.GetHashCode();
            return new ProcessStateInput { ProcessID = idProcesu, ProcessName = stav.ToString(), Description = popisProcesu };
        }

        /// <summary>
        /// Získá textový popis a informaci o chybě pro stav procesu na základě vstupního zobrazeného stavu.
        /// </summary>
        /// <param name="processStateView">Zobrazený stav procesu.</param>
        /// <returns>Krotka obsahující textový popis a indikaci, zda se jedná o chybu stavu.</returns>
        public static (string Text, bool IsError) GetFromState(ProcessStateInput processStateView)
        {
            try
            {
                var popisProcesu = processStateView?.Description;
                return GetStateDescription(popisProcesu, processStateView.ProcessID);
            }
            catch
            {
                // Pokud dojde k vyjímce, vracíme výchozí hodnotu pro chybějící stav.
                return ("Zazn. chybí", true);
            }
        }

        /// <summary>
        /// Získá textový popis pro stav procesu na základě vstupního enumu.
        /// </summary>
        /// <typeparam name="T">Vstupní enum reprezentující stav procesu.</typeparam>
        /// <param name="stav">Stav procesu reprezentovaný vstupním enumem.</param>
        /// <returns>Textový popis stavu procesu.</returns>
        private static string GetProcessDescription<T>(T stav) where T : Enum
        {
            if (stav is Enums.StavDopravniku)
                return "DOPRAV";
            else if (stav is Enums.StavDatabaze)
                return "DB";
            else if (stav is Enums.StavBCS)
                return "BCS";
            else if (stav is Enums.StavSenzoru)
                return "SENSOR";
            else if (stav is Enums.StavTiskarny)
                return "PRINTER";
            else if (stav is Enums.StavObrazu)
                return "IMG";
            else if (stav is Enums.ProcessState)
                return "PRG";
            else if (stav is Enums.StavyPrihlaseni)
                return "LOGIN";
            else
                return "Unknown"; // Defaultní popis, měli byste doplnit další enumy podle potřeby.
        }


        /// <summary>
        /// Získá popis stavu procesu z odpovídajícího slovníku na základě popisu procesu a ID procesu.
        /// </summary>
        /// <param name="popisProcesu">Textový popis procesu (např. "DOPRAV", "DB", atd.).</param>
        /// <param name="idProcesu">ID procesu.</param>
        /// <returns>Korpus obsahující textový popis stavu a zda se jedná o chyby.</returns>
        private static (string Text, bool IsError) GetStateDescription(string popisProcesu, int idProcesu)
        {
            var slovnik = GetDictionary(popisProcesu);
            return slovnik?[idProcesu] ?? ("Zazn. chybí", true);
        }


        /// <summary>
        /// Získá slovník stavů procesu na základě textového popisu procesu.
        /// </summary>
        /// <param name="popisProcesu">Textový popis procesu (např. "DOPRAV", "DB", atd.).</param>
        /// <returns>Slovník stavů procesu nebo null, pokud není slovník nalezen pro daný popis.</returns>
        private static Dictionary<int, (string Text, bool IsError)> GetDictionary(string popisProcesu)
        {
            switch (popisProcesu)
            {
                case "DOPRAV":
                    return StavyDopravniku;
                case "DB":
                    return StavyDatabaze;
                case "BCS":
                    return StavyBCS;
                case "SENSOR":
                    return StavySenzoru;
                case "PRINTER":
                    return StavyTiskarny;
                case "IMG":
                    return StavyObrazku;
                case "PRG":
                    return StavyProgramu;
                case "LOGIN":
                    return StavyPrihlaseni;
                default:
                    return null;
            }
        }
    }
}
