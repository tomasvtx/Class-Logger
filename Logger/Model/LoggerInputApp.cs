using System.Reflection;

namespace Logger.Model
{
    /// <summary>
    /// Reprezentuje záznam loggeru.
    /// </summary>
    public class LoggerInputApp
    {
        /// <summary>
        /// Získá nebo nastaví název záznamu.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Získá nebo nastaví metodu, která vytvořila záznam.
        /// </summary>
        public MethodBase MethodBase { get; set; }

        /// <summary>
        /// Získá nebo nastaví zobrazený stav procesu.
        /// </summary>
        public ProcessStateInput DisplayedProcessState { get; set; }
    }

    /// <summary>
    /// Třída ProcessStateView pro logger a titulek hlavního okna.
    /// </summary>
    public sealed class ProcessStateInput
    {
        /// <summary>
        /// Získá nebo nastaví název procesu.
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// Získá nebo nastaví jedinečný identifikátor procesu.
        /// </summary>
        public int ProcessID { get; set; }

        /// <summary>
        /// Získá nebo nastaví popis procesu.
        /// </summary>
        public string Description { get; set; }
    }
}
