using RestOrderingClases;
using System;
using System.Resources;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegCatPlato : Form
    {
        int[] categoriaIDs;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public RegCatPlato()
        {
            InitializeComponent();
            SetLanguage();
            //esconder todos los paneles de error
            panelErrorID.Visible = false;
            panelErrorReg.Visible = false;
            CargarIds();
        }

        private void SetLanguage()
        {
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
            label1.Text = manager.GetString("regCat_titulo");
            label2.Text = manager.GetString("regCat_instrucciones");
            label3.Text = manager.GetString("regCat_id");
            label5.Text = manager.GetString("regCat_descripcion");
            label7.Text = manager.GetString("regCat_estado");
            buttonReg.Text = manager.GetString("reg_boton");
            comboBoxEstado.Items.AddRange(new object[] { manager.GetString("Estado1"), manager.GetString("Estado2") });
        }

        /// <summary>
        /// Obtiene las Ids de las Categorias registradas
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelError.Text = manager.GetString("Reg_Cargando");
            categoriaIDs = Program.datosSQL.ObtenerIDs("Categoria_SinEstado");
            if (categoriaIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de categoria en Form RegCatPlato");
                Program.bitacora.Nuevolog = true;
                labelError.Text = manager.GetString("Reg_ErrorDataBase");
                return;
            }
            panelErrorID.Visible = false;
            textBoxID.Enabled = true;
            buttonReg.Enabled = true;
        }

        /// <summary>
        /// Verifica si la id digitada es int y valida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void idesvalida(object sender, EventArgs e) 
        {
            panelErrorID.Visible = false;
            int id;

            if (!int.TryParse(textBoxID.Text, out id)) //intenta convertir la string a int, si no funciona muestra error
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = true;
                labelError.Text = manager.GetString("Reg_ErrorNoInt");
            }
            else //si funciona, verifica si es unica
            {
                bool noesvalida;
                noesvalida = ExisteID(id); //llama a funcion para verificar si es unico en DB
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
        /// Verifica si la id existe en la DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ExisteID(int id)
        {
            for (int i = 0; i < categoriaIDs.Length; i++)
            {
                if (categoriaIDs[i] == id)
                { return true; }
            }
            return false;
        }

        /// <summary>
        /// Veifica que todos los datos necesarios fueron introducidos
        /// </summary>
        /// <returns></returns>
        private bool infocompleta()
        {
            if (string.IsNullOrEmpty(textBoxDescrip.Text)) //Verifica que haya una descripcion
            { return false; }
            if (comboBoxEstado.SelectedIndex == -1) //verifica que se haya escogido un estado
            { return false; }
            return true;
        }

        /// <summary>
        /// Crea una CategoriaPlato y la envia para agregar a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e)
        {
            if (infocompleta() == true) //verifica que tenga toda la info antes de continuar
            {
                int id = int.Parse(textBoxID.Text); //establece toda la info el formato correcto
                string descripcion = textBoxDescrip.Text;
                string itemSeleccionado = comboBoxEstado.SelectedItem.ToString();
                bool estado;
                switch (itemSeleccionado)
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
                        break;
                }
                CategoriaPlato categoria = new CategoriaPlato(id, descripcion, estado); //crea nuevo objeto Categoria de Plato
                Program.datosSQL.agregarcategoriaplato(categoria);//agrega eel objeto al array de categorias de platos
                //limpia los paneles de errro y los textboxes
                textBoxID.Text = "";
                textBoxDescrip.Text = "";
                comboBoxEstado.SelectedIndex = -1;
                panelErrorReg.Visible = false;
                panelErrorID.Visible = false;
                CargarIds();
            }
            else //de lo contrario muestra un error
            { 
                panelErrorReg.Visible = true;
                labelErrorBtn.Text = manager.GetString("Reg_ErrorFaltaInfo");
            }
        }
    }
}
