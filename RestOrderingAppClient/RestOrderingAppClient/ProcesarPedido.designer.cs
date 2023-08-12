namespace RestOrderingAppClient.Formularios.Registrar
{
    partial class ProcesarPedido
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
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.panelErrorReg = new System.Windows.Forms.Panel();
            this.labelFaltaInfo = new System.Windows.Forms.Label();
            this.dataGridViewPlatos = new System.Windows.Forms.DataGridView();
            this.dataGridViewExtras = new System.Windows.Forms.DataGridView();
            this.comboBoxPlatos = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewCostos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panelErrorReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostos)).BeginInit();
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
            this.label1.Text = "Procesar Pedido";
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
            this.label2.Text = "Revise su pedido. Seleccione confirmar para procesar su pedido.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Platos seleccionados:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.buttonConfirmar.FlatAppearance.BorderSize = 0;
            this.buttonConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmar.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmar.ForeColor = System.Drawing.Color.Black;
            this.buttonConfirmar.Location = new System.Drawing.Point(33, 422);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(425, 28);
            this.buttonConfirmar.TabIndex = 35;
            this.buttonConfirmar.Text = "Confirmar Pedido";
            this.buttonConfirmar.UseVisualStyleBackColor = false;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // panelErrorReg
            // 
            this.panelErrorReg.Controls.Add(this.labelFaltaInfo);
            this.panelErrorReg.Location = new System.Drawing.Point(33, 456);
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
            this.labelFaltaInfo.Size = new System.Drawing.Size(289, 14);
            this.labelFaltaInfo.TabIndex = 0;
            this.labelFaltaInfo.Text = "X Usted no tiene pedidos pendientes para procesar.";
            // 
            // dataGridViewPlatos
            // 
            this.dataGridViewPlatos.AllowUserToAddRows = false;
            this.dataGridViewPlatos.AllowUserToDeleteRows = false;
            this.dataGridViewPlatos.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewPlatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlatos.Location = new System.Drawing.Point(33, 51);
            this.dataGridViewPlatos.Name = "dataGridViewPlatos";
            this.dataGridViewPlatos.Size = new System.Drawing.Size(425, 126);
            this.dataGridViewPlatos.TabIndex = 38;
            // 
            // dataGridViewExtras
            // 
            this.dataGridViewExtras.AllowUserToAddRows = false;
            this.dataGridViewExtras.AllowUserToDeleteRows = false;
            this.dataGridViewExtras.AllowUserToResizeColumns = false;
            this.dataGridViewExtras.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewExtras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExtras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtras.Location = new System.Drawing.Point(33, 234);
            this.dataGridViewExtras.Name = "dataGridViewExtras";
            this.dataGridViewExtras.Size = new System.Drawing.Size(425, 80);
            this.dataGridViewExtras.TabIndex = 40;
            // 
            // comboBoxPlatos
            // 
            this.comboBoxPlatos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPlatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.comboBoxPlatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPlatos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPlatos.FormattingEnabled = true;
            this.comboBoxPlatos.Location = new System.Drawing.Point(33, 206);
            this.comboBoxPlatos.MaxDropDownItems = 20;
            this.comboBoxPlatos.Name = "comboBoxPlatos";
            this.comboBoxPlatos.Size = new System.Drawing.Size(425, 22);
            this.comboBoxPlatos.TabIndex = 42;
            this.comboBoxPlatos.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlatos_seleccionado);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "Seleccione un plato para consultar extras seleccionadas:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridViewCostos);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBoxPlatos);
            this.panel1.Controls.Add(this.dataGridViewExtras);
            this.panel1.Controls.Add(this.dataGridViewPlatos);
            this.panel1.Controls.Add(this.panelErrorReg);
            this.panel1.Controls.Add(this.buttonConfirmar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 591);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 322);
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
            this.dataGridViewCostos.Location = new System.Drawing.Point(33, 337);
            this.dataGridViewCostos.Name = "dataGridViewCostos";
            this.dataGridViewCostos.ReadOnly = true;
            this.dataGridViewCostos.Size = new System.Drawing.Size(425, 70);
            this.dataGridViewCostos.TabIndex = 46;
            // 
            // ProcesarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(915, 650);
            this.Name = "ProcesarPedido";
            this.Text = "RegPedido";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panelErrorReg.ResumeLayout(false);
            this.panelErrorReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtras)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCostos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.Panel panelErrorReg;
        private System.Windows.Forms.Label labelFaltaInfo;
        private System.Windows.Forms.DataGridView dataGridViewPlatos;
        private System.Windows.Forms.DataGridView dataGridViewExtras;
        private System.Windows.Forms.ComboBox comboBoxPlatos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewCostos;
        private System.Windows.Forms.Label label4;
    }
}