using System;
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
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
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
