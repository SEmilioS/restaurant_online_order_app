using System;
using System.Configuration;
using System.Reflection.Emit;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Log
{
    public partial class Bitacora : Form
    {
        private Timer TimerBitacora;
        private ResourceManager manager = new ResourceManager(typeof(Program));

        public Bitacora()
        {
            InitializeComponent();
            SetLanguage();
            Program.bitacora.Nuevolog = true;
            cargarbitacora(null, EventArgs.Empty);
            TimerBitacora = new Timer();
            TimerBitacora.Interval = 1000;
            TimerBitacora.Tick += cargarbitacora;
            TimerBitacora.Start();
        }

        private void SetLanguage()
        {
            string selectedLanguage = ConfigurationManager.AppSettings["Language"]; // Get language setting from configuration

            if (selectedLanguage == "es")
            {
                manager = new ResourceManager($"RestOrderingApp.esCR",
                                                        typeof(Program).Assembly);
            }
            else if (selectedLanguage == "eng")
            {
                manager = new ResourceManager($"RestOrderingApp.engUS",
                                            typeof(Program).Assembly);
            }
            label1.Text = manager.GetString("Bitacora_titulo");
            label2.Text = manager.GetString("Bitacora_instrucciones");
        }

        /// <summary>
        /// Actualiza los contenidos de la bitacora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargarbitacora(object sender, EventArgs e)
        {
            if (Program.bitacora.Nuevolog == true)
            {
                richTextBox.Clear();
                StringBuilder sb = new StringBuilder();
                foreach (string log in Program.bitacora.Registros)
                {
                    sb.AppendLine(log);
                }
                richTextBox.Text = sb.ToString();
                Program.bitacora.Nuevolog = false;
            }
        }
    }
}
