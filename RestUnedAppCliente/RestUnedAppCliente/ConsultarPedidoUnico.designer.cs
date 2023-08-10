namespace RestUnedAppCliente.Formularios.Cosultar
{
    partial class ConsultarPedidoUnico
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelErrorReg = new System.Windows.Forms.Panel();
            this.labelerrorDB = new System.Windows.Forms.Label();
            this.labelFaltaInfo = new System.Windows.Forms.Label();
            this.dataGridViewPlatos = new System.Windows.Forms.DataGridView();
            this.comboBoxPlatos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxPedidos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewCostos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewExtras = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelErrorReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).BeginInit();
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
            this.label1.Text = "Consultar Pedido Unico";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.label2.Text = "Consulte sus pedidos anteriores.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Platos seleccionados:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelErrorReg
            // 
            this.panelErrorReg.Controls.Add(this.labelerrorDB);
            this.panelErrorReg.Controls.Add(this.labelFaltaInfo);
            this.panelErrorReg.Location = new System.Drawing.Point(33, 447);
            this.panelErrorReg.Name = "panelErrorReg";
            this.panelErrorReg.Size = new System.Drawing.Size(425, 35);
            this.panelErrorReg.TabIndex = 37;
            // 
            // labelerrorDB
            // 
            this.labelerrorDB.AutoSize = true;
            this.labelerrorDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelerrorDB.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelerrorDB.ForeColor = System.Drawing.Color.Red;
            this.labelerrorDB.Location = new System.Drawing.Point(0, 14);
            this.labelerrorDB.Name = "labelerrorDB";
            this.labelerrorDB.Size = new System.Drawing.Size(154, 14);
            this.labelerrorDB.TabIndex = 1;
            this.labelerrorDB.Text = "X Error al obtener registros.";
            // 
            // labelFaltaInfo
            // 
            this.labelFaltaInfo.AutoSize = true;
            this.labelFaltaInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFaltaInfo.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFaltaInfo.ForeColor = System.Drawing.Color.Red;
            this.labelFaltaInfo.Location = new System.Drawing.Point(0, 0);
            this.labelFaltaInfo.Name = "labelFaltaInfo";
            this.labelFaltaInfo.Size = new System.Drawing.Size(214, 14);
            this.labelFaltaInfo.TabIndex = 0;
            this.labelFaltaInfo.Text = "X Usted no tiene pedidos procesados.";
            // 
            // dataGridViewPlatos
            // 
            this.dataGridViewPlatos.AllowUserToAddRows = false;
            this.dataGridViewPlatos.AllowUserToDeleteRows = false;
            this.dataGridViewPlatos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPlatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlatos.Location = new System.Drawing.Point(33, 99);
            this.dataGridViewPlatos.Name = "dataGridViewPlatos";
            this.dataGridViewPlatos.Size = new System.Drawing.Size(425, 126);
            this.dataGridViewPlatos.TabIndex = 38;
            // 
            // comboBoxPlatos
            // 
            this.comboBoxPlatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPlatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxPlatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPlatos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlatos.FormattingEnabled = true;
            this.comboBoxPlatos.Location = new System.Drawing.Point(33, 243);
            this.comboBoxPlatos.MaxDropDownItems = 20;
            this.comboBoxPlatos.Name = "comboBoxPlatos";
            this.comboBoxPlatos.Size = new System.Drawing.Size(425, 22);
            this.comboBoxPlatos.TabIndex = 42;
            this.comboBoxPlatos.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatos_seleccionado);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.comboBoxPedidos);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridViewCostos);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxPlatos);
            this.panel1.Controls.Add(this.dataGridViewExtras);
            this.panel1.Controls.Add(this.dataGridViewPlatos);
            this.panel1.Controls.Add(this.panelErrorReg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 591);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(31, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "Seleccione un pedido para consultar:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPedidos
            // 
            this.comboBoxPedidos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPedidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPedidos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPedidos.FormattingEnabled = true;
            this.comboBoxPedidos.Location = new System.Drawing.Point(33, 55);
            this.comboBoxPedidos.MaxDropDownItems = 20;
            this.comboBoxPedidos.Name = "comboBoxPedidos";
            this.comboBoxPedidos.Size = new System.Drawing.Size(425, 22);
            this.comboBoxPedidos.TabIndex = 48;
            this.comboBoxPedidos.SelectedIndexChanged += new System.EventHandler(this.comboBoxPedidos_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 12);
            this.label4.TabIndex = 47;
            this.label4.Text = "Costos:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewCostos
            // 
            this.dataGridViewCostos.AllowUserToAddRows = false;
            this.dataGridViewCostos.AllowUserToDeleteRows = false;
            this.dataGridViewCostos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCostos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCostos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewCostos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCostos.Location = new System.Drawing.Point(33, 371);
            this.dataGridViewCostos.Name = "dataGridViewCostos";
            this.dataGridViewCostos.ReadOnly = true;
            this.dataGridViewCostos.Size = new System.Drawing.Size(425, 70);
            this.dataGridViewCostos.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "Seleccione un plato para consultar extras seleccionadas:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewExtras
            // 
            this.dataGridViewExtras.AllowUserToAddRows = false;
            this.dataGridViewExtras.AllowUserToDeleteRows = false;
            this.dataGridViewExtras.AllowUserToResizeColumns = false;
            this.dataGridViewExtras.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewExtras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtras.Location = new System.Drawing.Point(33, 271);
            this.dataGridViewExtras.Name = "dataGridViewExtras";
            this.dataGridViewExtras.Size = new System.Drawing.Size(425, 80);
            this.dataGridViewExtras.TabIndex = 40;
            // 
            // ConsultarPedidoUnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(915, 650);
            this.Name = "ConsultarPedidoUnico";
            this.Text = "RegPedido";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelErrorReg.ResumeLayout(false);
            this.panelErrorReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelErrorReg;
        private System.Windows.Forms.Label labelFaltaInfo;
        private System.Windows.Forms.DataGridView dataGridViewPlatos;
        private System.Windows.Forms.ComboBox comboBoxPlatos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCostos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxPedidos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridViewExtras;
        private System.Windows.Forms.Label labelerrorDB;
    }
}