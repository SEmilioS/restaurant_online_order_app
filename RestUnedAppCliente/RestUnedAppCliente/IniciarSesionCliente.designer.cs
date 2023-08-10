namespace RestUnedAppCliente.Formularios.Sesion
{
    partial class IniciarSesionCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IniciarSesionCliente));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelErrorReg = new System.Windows.Forms.Panel();
            this.labelDenegado = new System.Windows.Forms.Label();
            this.labelFaltaInfo = new System.Windows.Forms.Label();
            this.buttonReg = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelErrorReg.SuspendLayout();
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
            this.label1.Text = "Iniciar Sesión";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.panelErrorReg);
            this.panel1.Controls.Add(this.buttonReg);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 438);
            this.panel1.TabIndex = 13;
            // 
            // panelErrorReg
            // 
            this.panelErrorReg.Controls.Add(this.labelDenegado);
            this.panelErrorReg.Controls.Add(this.labelFaltaInfo);
            this.panelErrorReg.Location = new System.Drawing.Point(37, 167);
            this.panelErrorReg.Name = "panelErrorReg";
            this.panelErrorReg.Size = new System.Drawing.Size(425, 32);
            this.panelErrorReg.TabIndex = 37;
            // 
            // labelDenegado
            // 
            this.labelDenegado.AutoSize = true;
            this.labelDenegado.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDenegado.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDenegado.ForeColor = System.Drawing.Color.Red;
            this.labelDenegado.Location = new System.Drawing.Point(0, 14);
            this.labelDenegado.Name = "labelDenegado";
            this.labelDenegado.Size = new System.Drawing.Size(293, 14);
            this.labelDenegado.TabIndex = 1;
            this.labelDenegado.Text = "X Acceso denegado, Digite una Identificación valida.";
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
            // buttonReg
            // 
            this.buttonReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.buttonReg.FlatAppearance.BorderSize = 0;
            this.buttonReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReg.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReg.ForeColor = System.Drawing.Color.Black;
            this.buttonReg.Location = new System.Drawing.Point(37, 121);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(425, 40);
            this.buttonReg.TabIndex = 35;
            this.buttonReg.Text = "Iniciar Sesión";
            this.buttonReg.UseVisualStyleBackColor = false;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(166, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 12);
            this.label3.TabIndex = 26;
            this.label3.Text = "Identificación del Cliente:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxID.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.ForeColor = System.Drawing.Color.Black;
            this.textBoxID.Location = new System.Drawing.Point(145, 62);
            this.textBoxID.MaxLength = 10;
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(196, 16);
            this.textBoxID.TabIndex = 25;
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label2.Text = "Llene todos los apartados para iniciar sesión.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IniciarSesionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 522);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(684, 561);
            this.Name = "IniciarSesionCliente";
            this.Text = "REST-UNED-CLIENTE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IniciarSesionCliente_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelErrorReg.ResumeLayout(false);
            this.panelErrorReg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Panel panelErrorReg;
        private System.Windows.Forms.Label labelFaltaInfo;
        private System.Windows.Forms.Label labelDenegado;
    }
}