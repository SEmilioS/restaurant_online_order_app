using System.Resources;
using System.Configuration;

namespace RestOrderingApp
{
    internal class SelectorLenguaje
    {
        public SelectorLenguaje() { }

        public ResourceManager CargarLenguaje()
        {
            string selectedLanguage = ConfigurationManager.AppSettings["Language"]; // Get language setting from configuration

            if (selectedLanguage == "es")
            {
                return new ResourceManager($"RestOrderingApp.esCR",
                                                        typeof(Program).Assembly);
            }
            else if (selectedLanguage == "eng")
            {
                return new ResourceManager($"RestOrderingApp.engUS",
                                            typeof(Program).Assembly);
            }
            return null;
        }
    }
}
