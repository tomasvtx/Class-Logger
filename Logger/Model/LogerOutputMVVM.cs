namespace Logger.Model
{
        /// <summary>
        /// Reprezentuje výstup záznamu pro Logger.
        /// </summary>
        public sealed class LogerOutputMVVM
        {
            /// <summary>
            /// Získá nebo nastaví ObsahOkna výstupu.
            /// </summary>
            public string ObsahOkna { get; set; }

            /// <summary>
            /// Získá nebo nastaví záznam pro MVVM.
            /// </summary>
            public LogEntries ZaznamProMVVM { get; set; }

            /// <summary>
            /// Získá nebo nastaví stav výstupu.
            /// </summary>
            public string Stav { get; set; }

            /// <summary>
            /// Získá nebo nastaví, zda-li se jedná o chybu.
            /// </summary>
            public bool IsError { get; set; } = true;
        }
}
