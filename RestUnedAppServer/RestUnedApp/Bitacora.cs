using System;
using System.Text;
using System.Windows.Forms;

namespace RestUnedApp.Formularios.Log
{
    public partial class Bitacora : Form
    {
        private Timer TimerBitacora;

        public Bitacora()
        {
            InitializeComponent();
            Program.bitacora.Nuevolog = true;
            cargarbitacora(null, EventArgs.Empty);
            TimerBitacora = new Timer();
            TimerBitacora.Interval = 1000;
            TimerBitacora.Tick += cargarbitacora;
            TimerBitacora.Start();
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
