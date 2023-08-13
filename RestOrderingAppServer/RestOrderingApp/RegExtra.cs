using RestOrderingClases;
using System;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegExtra : Form
    {
        int[] extraIDs;
        CategoriaPlato[] categorias;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public RegExtra()
        {
            InitializeComponent();
            SetLanguage();
            panelErrorID.Visible = false;
            panelErrorCat.Visible = false;
            panelErrorPrecio.Visible = false;
            panelErrorReg.Visible = false;
            CargarIds();
            if (categorias.Length == 0) //verifica que exista una categoria activa para usar
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = false;
                panelErrorCat.Visible = false;
                panelErrorPrecio.Visible = false;
                panelErrorReg.Visible = true;
                labelErrorBtn.Visible = false;
                labelErrorBtn.Text = manager.GetString("regPlato_ErrorCat");
            }
        }

        private void SetLanguage()
        {
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
            label1.Text = manager.GetString("regExtra_titulo");
            label2.Text = manager.GetString("regExtra_instrucciones");
            label3.Text = manager.GetString("regExtra_id");
            label4.Text = manager.GetString("regExtra_descripcion");
            label6.Text = manager.GetString("regExtra_precio");
            label7.Text = manager.GetString("regExtra_idCat");
            label11.Text = manager.GetString("regExtra_estado");
            buttonReg.Text = manager.GetString("reg_boton");
            comboBoxEstado.Items.AddRange(new object[] { manager.GetString("Estado1"), manager.GetString("Estado2") });
        }

        /// <summary>
        /// Obtiene las Categorias e Ids de Extras de la DB
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelError.Text = manager.GetString("Reg_Cargando");
            extraIDs = Program.datosSQL.ObtenerIDs("Extra");
            categorias = Program.datosSQL.ObtenerCategorias();
            if (categorias == null || extraIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de categoria o extras en Form RegExtra");
                Program.bitacora.Nuevolog = true;
                labelError.Text = manager.GetString("Reg_ErrorDataBase");
                return;
            }
            panelErrorID.Visible = false;
            textBoxID.Enabled = true;
            buttonReg.Enabled = true;
        }

        /// <summary>
        /// Verifica si la id es int y valida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IdEsValida(object sender, EventArgs e)
        {
            panelErrorID.Visible = false;
            int id;

            if (!int.TryParse(textBoxID.Text, out id))
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = true;
                labelError.Text = manager.GetString("Reg_ErrorNoInt");
            }
            else
            {
                bool noesvalida;
                noesvalida = ExisteID(id, "Plato"); //llama a funcion para verificar si es unico en DB
                if (noesvalida)
                {
                    buttonReg.Enabled = false;
                    panelErrorID.Visible = true;
                    labelError.Text = manager.GetString("Reg_IdYaExiste");
                }
                else { buttonReg.Enabled = true; }
            }
        }

        /// <summary>
        /// Verifica si la id ya existe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private bool ExisteID(int id, string tipo)
        {
            if (tipo == "Plato")
            {
                for (int i = 0; i < extraIDs.Length; i++)
                {
                    if (extraIDs[i] == id)
                    { return true; }
                }
            }
            else
            {
                for (int i = 0; i < categorias.Length; i++)
                {
                    if (categorias[i].ID == id)
                    { return true; }
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica si la Id de categoria es valida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void catvalida(object sender, EventArgs e) 
        {
            panelErrorCat.Visible = false;
            int id;

            if (!int.TryParse(textBoxCategoriaID.Text, out id))
            {
                buttonReg.Enabled = false;
                panelErrorCat.Visible = true;
                labelErrorCat.Text = manager.GetString("Reg_ErrorNoInt");
            }
            else
            {
                bool esvalida;
                esvalida = ExisteID(id, "categoria"); //llama a funcion para verificar si existe
                if (!esvalida)
                {
                    buttonReg.Enabled = false;
                    panelErrorCat.Visible = true;
                    labelErrorCat.Text = manager.GetString("Reg_IdNoExiste");
                }
                else { buttonReg.Enabled = true; }
            }
        }

        /// <summary>
        /// Verifica que todos los datos necesarios fueron digitados
        /// </summary>
        /// <returns>
        /// boolean
        /// </returns>
        private bool infocompleta()
        {
            if (string.IsNullOrEmpty(textBoxDescripcion.Text))
            { return false; }
            if (!int.TryParse(textBoxPrecio.Text, out _))
            { return false; }
            if (comboBoxEstado.SelectedIndex == -1)
            { return false; }
            return true;
        }

        /// <summary>
        /// Crea un Extra y lo envia para agregar a la DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (infocompleta() == true) //revisa que esten todos los datos y correctos
            {
                //preparando los datos necesarios
                int id = int.Parse(textBoxID.Text);
                string descripcion = textBoxDescripcion.Text;
                int precio = int.Parse(textBoxPrecio.Text);
                int categoriaID = int.Parse(textBoxCategoriaID.Text);
                bool estado;
                string ItemSeleccionado = comboBoxEstado.SelectedItem.ToString();
                switch (ItemSeleccionado)
                {
                    case "Activo":
                        estado = true;
                        break;
                    case "Inactivo":
                        estado = false;
                        break;
                    case "Active":
                        estado = true;
                        break;
                    case "Inactive":
                        estado = false;
                        break;
                    default:
                        estado = false;
                        break; ;
                }
                CategoriaPlato categoria = categorias.FirstOrDefault(c => c.ID == categoriaID);
                if (categoria == null)
                {
                    MessageBox.Show("Operacion abortada. Categoria no exite en la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener categoría");
                    Program.bitacora.Nuevolog = true;
                    return;
                }
                Extra ex = new Extra(id, descripcion, categoria, estado, precio); //crea objeto extra
                Program.datosSQL.agregarextra(ex); //agrega el extra al array

                //limpia el form
                textBoxID.Text = "";
                textBoxDescripcion.Text = "";
                textBoxPrecio.Text = "";
                textBoxCategoriaID.Text = "";
                panelErrorReg.Visible = false;
                panelErrorID.Visible = false;
                panelErrorCat.Visible = false;
                panelErrorPrecio.Visible = false;
                comboBoxEstado.SelectedIndex = -1;
                CargarIds();
            }
            else //muestra error de falta de datos
            {
                panelErrorReg.Visible = true;
                labelErrorBtn.Text = manager.GetString("Reg_ErrorFaltaInfo");
            }
        }

        /// <summary>
        /// Verifica si el precio es un int
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void esintprecio(object sender, EventArgs e)
        {
            panelErrorPrecio.Visible = false;

            if (!int.TryParse(textBoxPrecio.Text, out _))
            {
                panelErrorPrecio.Visible = true;
                labelErrorPrecio.Text = manager.GetString("Reg_ErrorNoInt");
            }
        }
    }
}
