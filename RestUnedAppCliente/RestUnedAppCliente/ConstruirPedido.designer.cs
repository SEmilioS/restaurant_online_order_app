namespace RestUnedAppCliente.Formularios.Registrar
{
    partial class ConstruirPedido
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPlatos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewExtras = new System.Windows.Forms.DataGridView();
            this.panelerrorplato = new System.Windows.Forms.Panel();
            this.labelnoplatos = new System.Windows.Forms.Label();
            this.dataGridViewPlatos = new System.Windows.Forms.DataGridView();
            this.panelErrorReg = new System.Windows.Forms.Panel();
            this.labelFaltaInfo = new System.Windows.Forms.Label();
            this.panelErrorRest = new System.Windows.Forms.Panel();
            this.labelcargando = new System.Windows.Forms.Label();
            this.labelnoseleccion = new System.Windows.Forms.Label();
            this.buttonAso = new System.Windows.Forms.Button();
            this.comboBoxRest = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).BeginInit();
            this.panelerrorplato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).BeginInit();
            this.panelErrorReg.SuspendLayout();
            this.panelErrorRest.SuspendLayout();
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
            this.label1.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.label1.Size = new System.Drawing.Size(485, 59);
            this.label1.TabIndex = 12;
            this.label1.Text = "Construir Pedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxPlatos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridViewExtras);
            this.panel1.Controls.Add(this.panelerrorplato);
            this.panel1.Controls.Add(this.dataGridViewPlatos);
            this.panel1.Controls.Add(this.panelErrorReg);
            this.panel1.Controls.Add(this.panelErrorRest);
            this.panel1.Controls.Add(this.buttonAso);
            this.panel1.Controls.Add(this.comboBoxRest);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 591);
            this.panel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(253, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "Seleccione un plato para agregar extras:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPlatos
            // 
            this.comboBoxPlatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPlatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxPlatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPlatos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlatos.FormattingEnabled = true;
            this.comboBoxPlatos.Location = new System.Drawing.Point(33, 293);
            this.comboBoxPlatos.MaxDropDownItems = 20;
            this.comboBoxPlatos.Name = "comboBoxPlatos";
            this.comboBoxPlatos.Size = new System.Drawing.Size(425, 22);
            this.comboBoxPlatos.TabIndex = 42;
            this.comboBoxPlatos.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatos_seleccionado);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 12);
            this.label4.TabIndex = 41;
            this.label4.Text = "Extras disponibles";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewExtras
            // 
            this.dataGridViewExtras.AllowUserToAddRows = false;
            this.dataGridViewExtras.AllowUserToDeleteRows = false;
            this.dataGridViewExtras.AllowUserToResizeColumns = false;
            this.dataGridViewExtras.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewExtras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtras.Location = new System.Drawing.Point(33, 333);
            this.dataGridViewExtras.Name = "dataGridViewExtras";
            this.dataGridViewExtras.Size = new System.Drawing.Size(425, 80);
            this.dataGridViewExtras.TabIndex = 40;
            this.dataGridViewExtras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExtras_CellContentClick);
            this.dataGridViewExtras.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewExtras_CurrentCellDirtyStateChanged);
            // 
            // panelerrorplato
            // 
            this.panelerrorplato.Controls.Add(this.labelnoplatos);
            this.panelerrorplato.Location = new System.Drawing.Point(33, 244);
            this.panelerrorplato.Name = "panelerrorplato";
            this.panelerrorplato.Size = new System.Drawing.Size(223, 16);
            this.panelerrorplato.TabIndex = 39;
            // 
            // labelnoplatos
            // 
            this.labelnoplatos.AutoSize = true;
            this.labelnoplatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelnoplatos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnoplatos.ForeColor = System.Drawing.Color.Red;
            this.labelnoplatos.Location = new System.Drawing.Point(0, 0);
            this.labelnoplatos.Name = "labelnoplatos";
            this.labelnoplatos.Size = new System.Drawing.Size(207, 14);
            this.labelnoplatos.TabIndex = 1;
            this.labelnoplatos.Text = "X Debe seleccionar al menos 1 plato!";
            // 
            // dataGridViewPlatos
            // 
            this.dataGridViewPlatos.AllowUserToAddRows = false;
            this.dataGridViewPlatos.AllowUserToDeleteRows = false;
            this.dataGridViewPlatos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPlatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlatos.Location = new System.Drawing.Point(33, 123);
            this.dataGridViewPlatos.Name = "dataGridViewPlatos";
            this.dataGridViewPlatos.Size = new System.Drawing.Size(425, 115);
            this.dataGridViewPlatos.TabIndex = 38;
            this.dataGridViewPlatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPlatos_CellContentClick);
            this.dataGridViewPlatos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewPlatos_CurrentCellDirtyStateChanged);
            // 
            // panelErrorReg
            // 
            this.panelErrorReg.Controls.Add(this.labelFaltaInfo);
            this.panelErrorReg.Location = new System.Drawing.Point(33, 450);
            this.panelErrorReg.Name = "panelErrorReg";
            this.panelErrorReg.Size = new System.Drawing.Size(425, 21);
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
            this.labelFaltaInfo.Size = new System.Drawing.Size(380, 14);
            this.labelFaltaInfo.TabIndex = 0;
            this.labelFaltaInfo.Text = "X Debe seleccionar un restaurante y al menos un plato para registrar!";
            // 
            // panelErrorRest
            // 
            this.panelErrorRest.Controls.Add(this.labelcargando);
            this.panelErrorRest.Controls.Add(this.labelnoseleccion);
            this.panelErrorRest.Location = new System.Drawing.Point(33, 73);
            this.panelErrorRest.Name = "panelErrorRest";
            this.panelErrorRest.Size = new System.Drawing.Size(223, 32);
            this.panelErrorRest.TabIndex = 36;
            // 
            // labelcargando
            // 
            this.labelcargando.AutoSize = true;
            this.labelcargando.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelcargando.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelcargando.ForeColor = System.Drawing.Color.Red;
            this.labelcargando.Location = new System.Drawing.Point(0, 14);
            this.labelcargando.Name = "labelcargando";
            this.labelcargando.Size = new System.Drawing.Size(148, 14);
            this.labelcargando.TabIndex = 3;
            this.labelcargando.Text = "* Error al cargar recursos *";
            // 
            // labelnoseleccion
            // 
            this.labelnoseleccion.AutoSize = true;
            this.labelnoseleccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelnoseleccion.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnoseleccion.ForeColor = System.Drawing.Color.Red;
            this.labelnoseleccion.Location = new System.Drawing.Point(0, 0);
            this.labelnoseleccion.Name = "labelnoseleccion";
            this.labelnoseleccion.Size = new System.Drawing.Size(198, 14);
            this.labelnoseleccion.TabIndex = 0;
            this.labelnoseleccion.Text = "X Debe seleccionar un restaurante!";
            // 
            // buttonAso
            // 
            this.buttonAso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.buttonAso.FlatAppearance.BorderSize = 0;
            this.buttonAso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAso.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAso.ForeColor = System.Drawing.Color.Black;
            this.buttonAso.Location = new System.Drawing.Point(33, 419);
            this.buttonAso.Name = "buttonAso";
            this.buttonAso.Size = new System.Drawing.Size(425, 28);
            this.buttonAso.TabIndex = 35;
            this.buttonAso.Text = "Confirmar Selección";
            this.buttonAso.UseVisualStyleBackColor = false;
            this.buttonAso.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // comboBoxRest
            // 
            this.comboBoxRest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxRest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxRest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRest.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxRest.FormattingEnabled = true;
            this.comboBoxRest.Location = new System.Drawing.Point(33, 47);
            this.comboBoxRest.MaxDropDownItems = 20;
            this.comboBoxRest.Name = "comboBoxRest";
            this.comboBoxRest.Size = new System.Drawing.Size(425, 22);
            this.comboBoxRest.TabIndex = 34;
            this.comboBoxRest.SelectedIndexChanged += new System.EventHandler(this.comboBoxRestaurante_seleccionado);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(34, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "Seleccione un restaurante disponible:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(263, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Seleccione los platos a agregar al pedido:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(485, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "Seleccione un restaurante, un plato y/o extras";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConstruirPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(915, 650);
            this.Name = "ConstruirPedido";
            this.Text = "RegPedido";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).EndInit();
            this.panelerrorplato.ResumeLayout(false);
            this.panelerrorplato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).EndInit();
            this.panelErrorReg.ResumeLayout(false);
            this.panelErrorReg.PerformLayout();
            this.panelErrorRest.ResumeLayout(false);
            this.panelErrorRest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxRest;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAso;
        private System.Windows.Forms.Panel panelErrorRest;
        private System.Windows.Forms.Label labelnoseleccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelErrorReg;
        private System.Windows.Forms.Label labelFaltaInfo;
        private System.Windows.Forms.DataGridView dataGridViewPlatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewExtras;
        private System.Windows.Forms.Label labelcargando;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxPlatos;
        private System.Windows.Forms.Panel panelerrorplato;
        private System.Windows.Forms.Label labelnoplatos;
    }
}