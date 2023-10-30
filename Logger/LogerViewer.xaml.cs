using MyApplication;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace Logger
{
    /// <summary>
    /// Částečná třída LogerViewer sloužící k implementaci uživatelského rozhraní pro zobrazení logu.
    /// </summary>
    public partial class LogerViewer : UserControl
    {
        private ListView listview;

        public LogerViewer()
        {
            InitializeComponent();

            ListView = LogListView;
        }

        /// <summary>
        /// Získá nebo nastaví ListView, který slouží k zobrazení logu v uživatelském rozhraní.
        /// </summary>
        public ListView ListView { get => listview; set => listview = value; }
    }
}
