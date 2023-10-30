using System.Windows.Controls;

namespace Logger
{
    /// <summary>
    /// Částečná třída LogerViewerBasic sloužící k implementaci uživatelského rozhraní pro zobrazení logu.
    /// </summary>
    public partial class LogerViewerBasic : UserControl
    {
        private ListView listview;

        /// <summary>
        /// Inicializuje instanci třídy LogerViewerBasic a nastavuje ListView pro zobrazení logu.
        /// </summary>
        public LogerViewerBasic()
        {
            InitializeComponent();

            listview = LogListView;
        }

        /// <summary>
        /// Získá nebo nastaví ListView, který slouží k zobrazení logu v uživatelském rozhraní.
        /// </summary>
        public ListView ListView { get => listview; set => listview = value; }
    }
}
