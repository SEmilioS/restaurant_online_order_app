namespace RestUnedApp.Formularios.Registro
{
    partial class RegRestaurante
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelErrorReg = new System.Windows.Forms.Panel();
            this.labelFaltaInfo = new System.Windows.Forms.Label();
            this.panelErrorID = new System.Windows.Forms.Panel();
            this.labelErrorDB = new System.Windows.Forms.Label();
            this.labelcargando = new System.Windows.Forms.Label();
            this.labelidnounica = new System.Windows.Forms.Label();
            this.labelnointid = new System.Windows.Forms.Label();
            this.buttonReg = new System.Windows.Forms.Button();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDirec = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelErrorReg.SuspendLayout();
            this.panelErrorID.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.label1.Size = new System.Drawing.Size(485, 84);
            this.label1.TabIndex = 12;
            this.label1.Text = "Registro de Restaurante";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.panelErrorReg);
            this.panel1.Controls.Add(this.panelErrorID);
            this.panel1.Controls.Add(this.buttonReg);
            this.panel1.Controls.Add(this.comboBoxEstado);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxTelefono);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxDirec);
            this.panel1.Controls.Add(this.textBoxNombre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 477);
            this.panel1.TabIndex = 13;
            // 
            // panelErrorReg
            // 
            this.panelErrorReg.Controls.Add(this.labelFaltaInfo);
            this.panelErrorReg.Location = new System.Drawing.Point(33, 345);
            this.panelErrorReg.Name = "panelErrorReg";
            this.panelErrorReg.Size = new System.Drawing.Size(425, 32);
            this.panelErrorReg.TabIndex = 37;
            // 
            // labelFaltaInfo
            // 
            this.labelFaltaInfo.AutoSize = true;
            this.labelFaltaInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFaltaInfo.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltaInfo.ForeColor = System.Drawing.Color.Red;
            this.labelFaltaInfo.Location = new System.Drawing.Point(0, 0);
            this.labelFaltaInfo.Name = "labelFaltaInfo";
            this.labelFaltaInfo.Size = new System.Drawing.Size(322, 14);
            this.labelFaltaInfo.TabIndex = 0;
            this.labelFaltaInfo.Text = "X Debe llenar todos los apartados con el formato correcto!";
            // 
            // panelErrorID
            // 
            this.panelErrorID.Controls.Add(this.labelErrorDB);
            this.panelErrorID.Controls.Add(this.labelcargando);
            this.panelErrorID.Controls.Add(this.labelidnounica);
            this.panelErrorID.Controls.Add(this.labelnointid);
            this.panelErrorID.Location = new System.Drawing.Point(33, 79);
            this.panelErrorID.Name = "panelErrorID";
            this.panelErrorID.Size = new System.Drawing.Size(214, 47);
            this.panelErrorID.TabIndex = 36;
            // 
            // labelErrorDB
            // 
            this.labelErrorDB.AutoSize = true;
            this.labelErrorDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelErrorDB.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorDB.ForeColor = System.Drawing.Color.Red;
            this.labelErrorDB.Location = new System.Drawing.Point(0, 42);
            this.labelErrorDB.Name = "labelErrorDB";
            this.labelErrorDB.Size = new System.Drawing.Size(144, 14);
            this.labelErrorDB.TabIndex = 3;
            this.labelErrorDB.Text = "* Error de Base de datos *";
            // 
            // labelcargando
            // 
            this.labelcargando.AutoSize = true;
            this.labelcargando.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelcargando.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcargando.ForeColor = System.Drawing.Color.Red;
            this.labelcargando.Location = new System.Drawing.Point(0, 28);
            this.labelcargando.Name = "labelcargando";
            this.labelcargando.Size = new System.Drawing.Size(126, 14);
            this.labelcargando.TabIndex = 2;
            this.labelcargando.Text = "* Cargardo Recursos *";
            // 
            // labelidnounica
            // 
            this.labelidnounica.AutoSize = true;
            this.labelidnounica.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelidnounica.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelidnounica.ForeColor = System.Drawing.Color.Red;
            this.labelidnounica.Location = new System.Drawing.Point(0, 14);
            this.labelidnounica.Name = "labelidnounica";
            this.labelidnounica.Size = new System.Drawing.Size(145, 14);
            this.labelidnounica.TabIndex = 1;
            this.labelidnounica.Text = "X La ID digitada ya existe!";
            // 
            // labelnointid
            // 
            this.labelnointid.AutoSize = true;
            this.labelnointid.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelnointid.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnointid.ForeColor = System.Drawing.Color.Red;
            this.labelnointid.Location = new System.Drawing.Point(0, 0);
            this.labelnointid.Name = "labelnointid";
            this.labelnointid.Size = new System.Drawing.Size(216, 14);
            this.labelnointid.TabIndex = 0;
            this.labelnointid.Text = "X Debe ser un numero entero positivo!";
            // 
            // buttonReg
            // 
            this.buttonReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.buttonReg.FlatAppearance.BorderSize = 0;
            this.buttonReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReg.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReg.ForeColor = System.Drawing.Color.Black;
            this.buttonReg.Location = new System.Drawing.Point(33, 299);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(425, 40);
            this.buttonReg.TabIndex = 35;
            this.buttonReg.Text = "Registrar";
            this.buttonReg.UseVisualStyleBackColor = false;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstado.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.comboBoxEstado.Location = new System.Drawing.Point(262, 231);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(196, 22);
            this.comboBoxEstado.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(266, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "Estado del Restaurante:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTelefono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.textBoxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTelefono.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelefono.ForeColor = System.Drawing.Color.Black;
            this.textBoxTelefono.Location = new System.Drawing.Point(33, 231);
            this.textBoxTelefono.MaxLength = 50;
            this.textBoxTelefono.Multiline = true;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(196, 22);
            this.textBoxTelefono.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(35, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 12);
            this.label6.TabIndex = 31;
            this.label6.Text = "Telefono del Restaurante:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDirec
            // 
            this.textBoxDirec.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDirec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.textBoxDirec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDirec.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDirec.ForeColor = System.Drawing.Color.Black;
            this.textBoxDirec.Location = new System.Drawing.Point(33, 144);
            this.textBoxDirec.MaxLength = 255;
            this.textBoxDirec.Multiline = true;
            this.textBoxDirec.Name = "textBoxDirec";
            this.textBoxDirec.Size = new System.Drawing.Size(425, 40);
            this.textBoxDirec.TabIndex = 30;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.textBoxNombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNombre.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.ForeColor = System.Drawing.Color.Black;
            this.textBoxNombre.Location = new System.Drawing.Point(262, 62);
            this.textBoxNombre.MaxLength = 50;
            this.textBoxNombre.Multiline = true;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(196, 20);
            this.textBoxNombre.TabIndex = 29;
            this.textBoxNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Location = new System.Drawing.Point(35, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "Dirección del Restaurante:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.Location = new System.Drawing.Point(266, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nombre del Restaurante:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(35, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Identificación del Restaurante:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxID.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.ForeColor = System.Drawing.Color.Black;
            this.textBoxID.Location = new System.Drawing.Point(33, 62);
            this.textBoxID.Multiline = true;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(196, 20);
            this.textBoxID.TabIndex = 25;
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxID.TextChanged += new System.EventHandler(this.IdEsValida);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(485, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Llene todos los apartados para registrar un restaurante.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegRestaurante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(684, 561);
            this.Name = "RegRestaurante";
            this.Text = "RegRest";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelErrorReg.ResumeLayout(false);
            this.panelErrorReg.PerformLayout();
            this.panelErrorID.ResumeLayout(false);
            this.panelErrorID.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDirec;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Panel panelErrorID;
        private System.Windows.Forms.Label labelnointid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label labelidnounica;
        private System.Windows.Forms.Panel panelErrorReg;
        private System.Windows.Forms.Label labelFaltaInfo;
        private System.Windows.Forms.Label labelcargando;
        private System.Windows.Forms.Label labelErrorDB;
    }
}