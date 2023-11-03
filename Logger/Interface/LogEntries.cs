using System; // Importujeme System pro DateTime
using System.ComponentModel; // Importujeme INotifyPropertyChanged pro notifikaci o změnách
using System.Windows.Media; // Importujeme System.Windows.Media pro SolidColorBrush

namespace Logger
{
    /// <summary>
    /// Reprezentuje záznam logu.
    /// </summary>
    public interface LogEntries
    {
        /// <summary>
        /// Získá nebo nastaví datum záznamu.
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// Získá nebo nastaví zobrazenou zprávu logu.
        /// </summary>
        string DisplayedMessage { get; set; }

        /// <summary>
        /// Získá nebo nastaví stav procesu.
        /// </summary>
        string ProcessStatus { get; set; }

        /// <summary>
        /// Získá nebo nastaví řetězec popisující stav procesu.
        /// </summary>
        string ProcessStatusString { get; set; }

        /// <summary>
        /// Získá nebo nastaví čas logu.
        /// </summary>
        string Time { get; set; }

        /// <summary>
        /// Získá nebo nastaví šířku záznamu.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        /// Získá nebo nastaví barvu logu.
        /// </summary>
        SolidColorBrush Color { get; set; }
    }
}
