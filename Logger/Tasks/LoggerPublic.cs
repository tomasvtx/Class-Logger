using Logger;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using netUtilities;
using System.Diagnostics;
using Logger.Model;
using MyApplication;
using System.Windows;

namespace Logger.Tasks
{
    public static class LoggerPublic
    {

        /// <summary>
        /// Zaznamenává logovací záznam a umožňuje snadnou výměnu logovacího nástroje v aplikaci.
        /// </summary>
        /// <param name="iLogger">Instance ILogger pro logování</param>
        /// <param name="zaznamLoggeru">Záznam k logování</param>
        /// <param name="resetTimer">Příznak resetování časovače</param>
        /// <param name="updateState">Příznak aktualizace stavu programu</param>
        public async static Task<Task> LoggerTitle(this IViewModel iLogger, IMyApp iMyApp, LoggerInputApp zaznamLoggeru, bool resetTimer = false, bool updateState = true)
        {
            return await iMyApp.LoggerTitleInternal(zaznamLoggeru?.Name, zaznamLoggeru?.MethodBase, zaznamLoggeru?.DisplayedProcessState, resetTimer, updateState);
        }

        /// <summary>
        /// Interní metoda pro logování titulu s detailními parametry.
        /// </summary>
        /// <param name="title">Název titulu</param>
        /// <param name="methodBase">MethodBase pro určení volající metody</param>
        /// <param name="processStateView">Stav procesu</param>
        /// <param name="resetTimer">Příznak resetování časovače</param>
        /// <param name="updateState">Příznak aktualizace stavu programu</param>
        public async static Task<Task> LoggerTitleInternal(this IMyApp myApp, string title, MethodBase methodBase, ProcessStateInput processStateView, bool resetTimer = false, bool updateState = true)
        {
            try
            {
                if (myApp?.Resources?.AppWindow == null)
                {
                    return Task.FromResult(0);
                }

                // Získání instance logovacího objektu
                var logger = await myApp?.Resources?.AppWindow?.Dispatcher?.InvokeAsync(() =>
                    LogContent.LoggerContent(myApp, title, processStateView, methodBase, resetTimer),
                    System.Windows.Threading.DispatcherPriority.Background
                );

                // Centralized logging and error handling
                await LogAndHandleErrors(myApp, logger, processStateView, updateState);
            }
            catch (Exception dd)
            {
                // Centralized error handling
                await HandleException(myApp, dd);
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Aktualizuje logovací záznamy, zpracovává chyby a udržuje omezený počet záznamů v logu.
        /// </summary>
        /// <param name="window">Hlavní okno aplikace</param>
        /// <param name="iLogger">Instance ILogger pro logování</param>
        /// <param name="logger">Logovací objekt</param>
        /// <param name="processStateView">Stav procesu</param>
        /// <param name="updateState">Příznak aktualizace stavu programu</param>
        /// <param name="cancellationToken">Token pro zrušení operace</param>
        private static async Task LogAndHandleErrors(IMyApp myApp, LogerOutputMVVM logger, ProcessStateInput processStateView, bool updateState)
        {
            await myApp?.Resources?.AppWindow?.Dispatcher?.InvokeAsync(() =>
            {
                // Nastaví šířku záznamu na 298
                logger.ZaznamProMVVM.Width = 298;

                // Aktualizuje titul hlavního okna
                myApp.Resources.AppViewModel.ApplicationTitle = logger?.ObsahOkna;

                // Aktualizuje stav programu, pokud není vyžádáno zrušení operace a ID procesu je 998
                if (updateState && myApp?.Resources?.CancellationTokenSource?.Token.IsCancellationRequested == false && processStateView?.ProcessID != 998 && processStateView?.ProcessID != 800)
                {
                    myApp.Resources.AppViewModel.LogManager.State = logger?.Stav;
                }

                if (processStateView?.ProcessID == 800)
                {
                    myApp.Resources.AppViewModel.LogManager.State = string.Empty;
                }
               
                // Přidá záznam do kolekce logu
                myApp.Resources.AppViewModel.LogManager.LogEntries.Add(logger?.ZaznamProMVVM);
          

                // Udržuje omezený počet záznamů v logu (maximálně 10)
                while (myApp.Resources.AppViewModel.LogManager?.LogEntries?.Count > 10)
                {
                    myApp.Resources.AppViewModel.LogManager.LogEntries.Remove(myApp?.Resources.AppViewModel.LogManager.LogEntries?.FirstOrDefault());
                }

                if (myApp?.Resources?.AppViewModel.LogManager?.LogEntries?.LastOrDefault() != null) 
                {
                    // Posune zobrazení logu na konec, aby byly viditelné nejnovější záznamy
                    myApp.Resources.AppViewModel.LogerViewer.ScrollIntoView(myApp?.Resources?.AppViewModel.LogManager?.LogEntries?.LastOrDefault());
                } 
            }, System.Windows.Threading.DispatcherPriority.Background);
        }

        /// <summary>
        /// Zpracovává výjimku a provádí zachycení vnitřní chyby, pokud dojde k výjimce.
        /// </summary>
        /// <param name="dispatcher">Správce dispečeru pro asynchronní operace</param>
        /// <param name="type">Typ, u kterého došlo k výjimce</param>
        /// <param name="exception">Výjimka, která byla zachycena</param>
        private static async Task HandleException(IMyApp myApp, Exception exception)
        {
            // Zachycení a zpráva o vnitřní chybě, pokud nastane výjimka
            LoggerHelper.SaveEventRecord(myApp, new ProcessStateInput(), exception.Message, MethodBase.GetCurrentMethod());
            await MethodBase.GetCurrentMethod()?.ReportInternalErrorAsync(myApp?.Resources?.AppWindow?.Dispatcher, exception, myApp);
        }
    }
}
