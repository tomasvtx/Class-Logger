using System;
using System.ComponentModel;
using System.Windows.Media;

namespace Logger.Model
{
        /// <summary>
        /// Reprezentuje záznam logu.
        /// </summary>
        public class LogRecordMVVM : LogEntries
        {
            /// <summary>
            /// Získá nebo nastaví datum záznamu.
            /// </summary>
            public DateTime Timestamp { get; set; }

            /// <summary>
            /// Získá nebo nastaví zprávu logu.
            /// </summary>
            public string DisplayedMessage { get; set; }

            /// <summary>
            /// Získá nebo nastaví stav procesu.
            /// </summary>
            public string ProcessStatus { get; set; }

            /// <summary>
            /// Získá nebo nastaví řetězec popisující stav procesu.
            /// </summary>
            public string ProcessStatusString { get; set; }

            /// <summary>
            /// Získá nebo nastaví čas logu.
            /// </summary>
            public string Time { get; set; }

            /// <summary>
            /// Získá nebo nastaví šířku záznamu.
            /// </summary>
            public int Width { get; set; }

            /// <summary>
            /// Získá nebo nastaví barvu logu.
            /// </summary>
            public SolidColorBrush Color { get; set; }

            public event PropertyChangedEventHandler PropertyChanged;
        }
}
