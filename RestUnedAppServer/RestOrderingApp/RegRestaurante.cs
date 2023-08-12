using RestOrderingClases;
using System;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegRestaurante : Form
    {
        int[] restauranteIDs;
        public RegRestaurante()
        {
            InitializeComponent();
            //esconde los paneles de error
            panelErrorID.Visible = false;
            labelidnounica.Visible = false;
            labelnointid.Visible = false;
            labelcargando.Visible = false;
            panelErrorReg.Visible = false;
            CargarIds();
        }

        /// <summary>
        /// Obtiene las Ids de Restaurantes registrados
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelcargando.Visible = true;
            restauranteIDs = Program.datosSQL.ObtenerIDs("Restaurante");
            if (restauranteIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de restaurante en Form RegRestaurante");
                Program.bitacora.Nuevolog = true;
                labelcargando.Visible = false;
                labelErrorDB.Visible = true;
                return;
            }
            panelErrorID.Visible = false;
            labelcargando.Visible = false;
            textBoxID.Enabled = true;
            buttonReg.Enabled = true;
        }

        /// <summary>
        /// Verifica si la id digitada es int y valida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdEsValida(object sender, EventArgs e)
        {
            panelErrorID.Visible = false;
            labelidnounica.Visible = false;
            labelnointid.Visible = false;
            int id;

            if (!int.TryParse(textBoxID.Text, out id)) //Verifica si es int
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = true;
                labelnointid.Visible = true;
            }
            else
            {
                bool noesvalida;
                noesvalida = ExisteID(id); //llama a funcion para verificar si es unico en DB
                if (noesvalida)
                {
                    buttonReg.Enabled = false;
                    panelErrorID.Visible = true;
                    labelidnounica.Visible = true;
                }
                else { buttonReg.Enabled = true; }
            }
        }

        /// <summary>
        /// Verifica si al id ya existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// boolean
        /// </returns>
        private bool ExisteID(int id)
        {
            for (int i = 0; i < restauranteIDs.Length; i++)
            {
                if (restauranteIDs[i] == id)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Verifica si los datos necesarios fueron digitados
        /// </summary>
        /// <returns></returns>
        private bool infocompleta()
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            { return false; }
            if (string.IsNullOrEmpty(textBoxDirec.Text))
            { return false; }
            if (string.IsNullOrEmpty(textBoxTelefono.Text))
            { return false; }
            if (comboBoxEstado.SelectedIndex == -1)//verifica si se selecciono un estado
            { return false; }
            return true;
        }

        /// <summary>
        /// Crea objeto Restaurante y lo envia para registrar en DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (infocompleta() == true) //verifica datos
            {
                //colaca el fomato correcto necesario
                int id = int.Parse(textBoxID.Text);
                string nombre = textBoxNombre.Text;
                string direccion = textBoxDirec.Text;
                string ItemSeleccionado = comboBoxEstado.SelectedItem.ToString();
                bool estado;
                switch (ItemSeleccionado)
                {
                    case "Activo":
                        estado = true;
                        break;
                    case "Inactivo":
                        estado = false;
                        break;
                    default:
                        estado = false;
                        break;
                }
                string telefono = textBoxTelefono.Text;
                Restaurante restaurante = new Restaurante(id, nombre, direccion, estado, telefono); //Crea un nuevo objeto Restaurante
                Program.datosSQL.agregarrestaurante(restaurante); //guarda el objeto en el array de restaurantes

                //limpia el formulario
                textBoxID.Text = "";
                textBoxNombre.Text = "";
                textBoxDirec.Text = "";
                textBoxTelefono.Text = "";
                comboBoxEstado.SelectedIndex = -1;
                panelErrorReg.Visible = false;
                panelErrorID.Visible = false;
                CargarIds();
            }
            else //muestra error si hacen falta datos
            { panelErrorReg.Visible = true; }
        }
    }
}
