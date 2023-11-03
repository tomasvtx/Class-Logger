using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Logger
{
    public interface ILogManager
    {
        /// <summary>
        /// Zpráva o stavu programu nebo kód procesu, který může být užitečný pro sledování aktuálního stavu aplikace.
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// Kolekce určená k uchování záznamů v logovacím systému. Tato kolekce může být propojena s ViewModel pro zobrazování záznamů v uživatelském rozhraní.
        /// </summary>
        ObservableCollection<LogEntries> LogEntries { get; set; }
    }
}
