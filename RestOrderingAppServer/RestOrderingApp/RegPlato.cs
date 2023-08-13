using RestOrderingClases;
using System;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace RestOrderingApp.Formularios.Registro
{
    public partial class RegPlato : Form
    {
        int[] platoIDs;
        CategoriaPlato[] categorias;
        private ResourceManager manager = new ResourceManager(typeof(Program));
        public RegPlato()
        {
            InitializeComponent();
            SetLanguage();
            panelErrorID.Visible = false;
            panelErrorCat.Visible = false;
            panelErrorPrecio.Visible = false;
            panelErrorReg.Visible = false;
            ///Obtiene las Categorias Registradas
            CargarIds();
            if (categorias == null || categorias.Length == 0) //verifica que exista una categoria activa para usar
            {
                buttonReg.Enabled = false;
                panelErrorID.Visible = false;
                panelErrorCat.Visible = false;
                panelErrorPrecio.Visible = false;
                panelErrorReg.Visible = true;
                labelErrorBtn.Text = manager.GetString("regPlato_ErrorCat");
            }
        }

        private void SetLanguage()
        {
            SelectorLenguaje sl = new SelectorLenguaje();
            manager = sl.CargarLenguaje();
            label1.Text = manager.GetString("regPlato_titulo");
            label2.Text = manager.GetString("regPlato_instrucciones");
            label3.Text = manager.GetString("regPlato_id");
            label4.Text = manager.GetString("regPlato_nombre");
            label6.Text = manager.GetString("regPlato_precio");
            label7.Text = manager.GetString("regPlato_idCat");
            buttonReg.Text = manager.GetString("reg_boton");
        }

        /// <summary>
        /// Obtiene las ids de Platos existentes y las Categorias de la DB
        /// </summary>
        private void CargarIds()
        {
            textBoxID.Enabled = false;
            buttonReg.Enabled = false;
            panelErrorID.Visible = true;
            labelError.Text = manager.GetString("Reg_Cargando");
            platoIDs = Program.datosSQL.ObtenerIDs("Plato");
            categorias = Program.datosSQL.ObtenerCategorias();
            if (categorias == null || platoIDs == null)
            {
                MessageBox.Show("Hubo un error al obtener informacion de la base de datos.", "Error de información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Program.bitacora.Registros.Add($"{DateTime.Now} Sistema: Error al obtener IDs de categoria o platos en Form RegPlato");
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
        /// Verifica si la id ya existe o no existe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private bool ExisteID(int id, string tipo)
        {
            if (tipo == "Plato")
            {
                for (int i = 0; i < platoIDs.Length; i++)
                {
                    if (platoIDs[i] == id)
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
        /// Verifica la Id de Categoria digitada para int y validez
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
        /// Verifica si los datos necesarios fueron digitados
        /// </summary>
        /// <returns></returns>
        private bool infocompleta()
        {
            int id;
            if (string.IsNullOrEmpty(textBoxNombre.Text))
            { return false; }
            if (!int.TryParse(textBoxPrecio.Text, out id))
            { return false; }
            if (!int.TryParse(textBoxCategoriaID.Text, out id))
            { return false; }
            return true;
        }

        /// <summary>
        /// Crea el Plato y lo envia para registras en DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReg_Click(object sender, EventArgs e) //crea y registra un plato
        {
            if (infocompleta() == true) //Verifica los datos
            {
                //poene en formato la info necesaria
                int id = int.Parse(textBoxID.Text);
                string nombre = textBoxNombre.Text;
                int precio = int.Parse(textBoxPrecio.Text);
                int categoriaID = int.Parse(textBoxCategoriaID.Text);
                CategoriaPlato categoria = categorias.FirstOrDefault(c => c.ID == categoriaID);
                Plato plato = new Plato(id, nombre, precio, categoria); //crea objeto Plato
                Program.datosSQL.agregarplato(plato); //agrega el plato al array


                //limpia el form 
                textBoxID.Text = "";
                textBoxNombre.Text = "";
                textBoxPrecio.Text = "";
                textBoxCategoriaID.Text = "";
                panelErrorReg.Visible = false;
                panelErrorID.Visible = false;
                panelErrorCat.Visible = false;
                panelErrorPrecio.Visible = false;
                CargarIds();
            }
            else //muestra error si los datos no estan completos
            {
                panelErrorReg.Visible = true;
                labelErrorBtn.Text = manager.GetString("Reg_ErrorFaltaInfo");

            }
        }


        /// <summary>
        /// Verifica si el precio digitado es int
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
