using AppConfigure;
using Logger.Model;
using MyApplication;
using System;
using System.Diagnostics;
using System.Reflection;
using static AppConfigure.BaseModel;

namespace Logger.Tasks
{
    /// <summary>
    /// Třída pro záznamy do logu s podporou různých procesních stavů.
    /// </summary>
    internal partial class LogContent : LoggerHelper
    {
        /// <summary>
        /// Stopek pro měření celkové doby běhu aplikace.
        /// </summary>
        public static readonly Stopwatch CelkovaUlohaStopky = new Stopwatch();

        /// <summary>
        /// Zaznamenávání a ukládání logu.
        /// </summary>
        /// <param name="myApp">Instance rozhraní IMyApp</param>
        /// <param name="Zprava">Název zprávy</param>
        /// <param name="stavProcesu">Stav procesu</param>
        /// <param name="metodaBase">Metoda, která vytvořila záznam</param>
        /// <param name="ResetovatCasovac">Nastavit časovač zpět na nulu (volitelný)</param>
        /// <returns>Výstup logu</returns>
        public static LogerOutputMVVM LoggerContent(IMyApp myApp, string Zprava, ProcessStateInput stavProcesu, MethodBase metodaBase, bool ResetovatCasovac = false)
        {
            CelkovaUlohaStopky.Start();
            int kodStavu = stavProcesu.ProcessID;
            string cas = GetFormattedElapsedTime(CelkovaUlohaStopky);
            string zprava = GetCompleteStatusMessage(Zprava, cas, kodStavu);
            string titulek = GetMainWindowTitle(myApp, kodStavu);
            LogEntries novyZaznam = CreateLogEntry(stavProcesu, Zprava, kodStavu, cas);
            novyZaznam.Width = 255;

            // Extrahovaná metoda pro ukládání záznamu a resetování časovače
            SaveEventRecordAndResetTimer(myApp, stavProcesu, zprava, metodaBase, ResetovatCasovac);

            var Output = Tasks.GetState.GetFromState(stavProcesu);
            return new LogerOutputMVVM
            {
                ObsahOkna = titulek,
                ZaznamProMVVM = novyZaznam,
                Stav = Output.Text,
                IsError = Output.IsError,
            };
        }


        /// <summary>
        /// Extrahovaná metoda pro ukládání záznamu a případné resetování časovače.
        /// </summary>
        /// <param name="myApp">Instance rozhraní IMyApp</param>
        /// <param name="stavProcesu">Stav procesu</param>
        /// <param name="zprava">Zpráva k uložení do logu</param>
        /// <param name="metodaBase">Metoda, která vytvořila záznam</param>
        /// <param name="resetTimer">Nastavit časovač zpět na nulu, pokud je true (volitelný)</param>
        private static void SaveEventRecordAndResetTimer(IMyApp myApp, ProcessStateInput stavProcesu, string zprava, MethodBase metodaBase, bool resetTimer)
        {
            // Uložení záznamu do logu
            SaveEventRecord(myApp, stavProcesu, zprava, metodaBase);

            // Resetování časovače, pokud resetTimer je true
            if (resetTimer)
            {
                CelkovaUlohaStopky?.Reset();
            }
        }
    }
}
