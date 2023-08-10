namespace RestUnedAppCliente.Formularios.MenuPrincipal
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.panelmenulateral = new System.Windows.Forms.Panel();
            this.panelConsultar = new System.Windows.Forms.Panel();
            this.ConPedidosTodos = new System.Windows.Forms.Button();
            this.ConPedidoUni = new System.Windows.Forms.Button();
            this.ConsultarPedidoBttn = new System.Windows.Forms.Button();
            this.panelPedido = new System.Windows.Forms.Panel();
            this.ProcesarPedidoBttn = new System.Windows.Forms.Button();
            this.ConstruirPedidoBttn = new System.Windows.Forms.Button();
            this.PedidoBttn = new System.Windows.Forms.Button();
            this.panelSesion = new System.Windows.Forms.Panel();
            this.CerrarSesion = new System.Windows.Forms.Button();
            this.buttonNombreUsu = new System.Windows.Forms.Button();
            this.ConeccionCheck = new System.Windows.Forms.Button();
            this.panellogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelmenulateral.SuspendLayout();
            this.panelConsultar.SuspendLayout();
            this.panelPedido.SuspendLayout();
            this.panelSesion.SuspendLayout();
            this.panellogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelmenulateral
            // 
            this.panelmenulateral.AutoScroll = true;
            this.panelmenulateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(62)))), ((int)(((byte)(82)))));
            this.panelmenulateral.Controls.Add(this.panelConsultar);
            this.panelmenulateral.Controls.Add(this.ConsultarPedidoBttn);
            this.panelmenulateral.Controls.Add(this.panelPedido);
            this.panelmenulateral.Controls.Add(this.PedidoBttn);
            this.panelmenulateral.Controls.Add(this.panelSesion);
            this.panelmenulateral.Controls.Add(this.buttonNombreUsu);
            this.panelmenulateral.Controls.Add(this.ConeccionCheck);
            this.panelmenulateral.Controls.Add(this.panellogo);
            this.panelmenulateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenulateral.Location = new System.Drawing.Point(0, 0);
            this.panelmenulateral.Name = "panelmenulateral";
            this.panelmenulateral.Size = new System.Drawing.Size(250, 661);
            this.panelmenulateral.TabIndex = 0;
            // 
            // panelConsultar
            // 
            this.panelConsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(120)))), ((int)(((byte)(158)))));
            this.panelConsultar.Controls.Add(this.ConPedidosTodos);
            this.panelConsultar.Controls.Add(this.ConPedidoUni);
            this.panelConsultar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConsultar.Location = new System.Drawing.Point(0, 358);
            this.panelConsultar.Name = "panelConsultar";
            this.panelConsultar.Size = new System.Drawing.Size(250, 82);
            this.panelConsultar.TabIndex = 12;
            // 
            // ConPedidosTodos
            // 
            this.ConPedidosTodos.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConPedidosTodos.FlatAppearance.BorderSize = 0;
            this.ConPedidosTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConPedidosTodos.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConPedidosTodos.ForeColor = System.Drawing.Color.White;
            this.ConPedidosTodos.Location = new System.Drawing.Point(0, 41);
            this.ConPedidosTodos.Name = "ConPedidosTodos";
            this.ConPedidosTodos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ConPedidosTodos.Size = new System.Drawing.Size(250, 41);
            this.ConPedidosTodos.TabIndex = 3;
            this.ConPedidosTodos.Text = "Todos los Pedidos";
            this.ConPedidosTodos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConPedidosTodos.UseVisualStyleBackColor = true;
            this.ConPedidosTodos.Click += new System.EventHandler(this.ConPedidosTodos_Click);
            // 
            // ConPedidoUni
            // 
            this.ConPedidoUni.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConPedidoUni.FlatAppearance.BorderSize = 0;
            this.ConPedidoUni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConPedidoUni.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConPedidoUni.ForeColor = System.Drawing.Color.White;
            this.ConPedidoUni.Location = new System.Drawing.Point(0, 0);
            this.ConPedidoUni.Name = "ConPedidoUni";
            this.ConPedidoUni.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ConPedidoUni.Size = new System.Drawing.Size(250, 41);
            this.ConPedidoUni.TabIndex = 2;
            this.ConPedidoUni.Text = "Pedido Unico";
            this.ConPedidoUni.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConPedidoUni.UseVisualStyleBackColor = true;
            this.ConPedidoUni.Click += new System.EventHandler(this.ConPedidoUni_Click);
            // 
            // ConsultarPedidoBttn
            // 
            this.ConsultarPedidoBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsultarPedidoBttn.FlatAppearance.BorderSize = 0;
            this.ConsultarPedidoBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsultarPedidoBttn.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsultarPedidoBttn.ForeColor = System.Drawing.Color.White;
            this.ConsultarPedidoBttn.Location = new System.Drawing.Point(0, 313);
            this.ConsultarPedidoBttn.Name = "ConsultarPedidoBttn";
            this.ConsultarPedidoBttn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ConsultarPedidoBttn.Size = new System.Drawing.Size(250, 45);
            this.ConsultarPedidoBttn.TabIndex = 11;
            this.ConsultarPedidoBttn.Text = "Consultar Pedidos";
            this.ConsultarPedidoBttn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConsultarPedidoBttn.UseVisualStyleBackColor = true;
            this.ConsultarPedidoBttn.Click += new System.EventHandler(this.ConsultarPedidoBttn_Click);
            // 
            // panelPedido
            // 
            this.panelPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(120)))), ((int)(((byte)(158)))));
            this.panelPedido.Controls.Add(this.ProcesarPedidoBttn);
            this.panelPedido.Controls.Add(this.ConstruirPedidoBttn);
            this.panelPedido.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPedido.Location = new System.Drawing.Point(0, 231);
            this.panelPedido.Name = "panelPedido";
            this.panelPedido.Size = new System.Drawing.Size(250, 82);
            this.panelPedido.TabIndex = 10;
            // 
            // ProcesarPedidoBttn
            // 
            this.ProcesarPedidoBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcesarPedidoBttn.FlatAppearance.BorderSize = 0;
            this.ProcesarPedidoBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcesarPedidoBttn.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcesarPedidoBttn.ForeColor = System.Drawing.Color.White;
            this.ProcesarPedidoBttn.Location = new System.Drawing.Point(0, 41);
            this.ProcesarPedidoBttn.Name = "ProcesarPedidoBttn";
            this.ProcesarPedidoBttn.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ProcesarPedidoBttn.Size = new System.Drawing.Size(250, 41);
            this.ProcesarPedidoBttn.TabIndex = 3;
            this.ProcesarPedidoBttn.Text = "Procesar Pedido";
            this.ProcesarPedidoBttn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ProcesarPedidoBttn.UseVisualStyleBackColor = true;
            this.ProcesarPedidoBttn.Click += new System.EventHandler(this.ProcesarPedidoBttn_Click);
            // 
            // ConstruirPedidoBttn
            // 
            this.ConstruirPedidoBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConstruirPedidoBttn.FlatAppearance.BorderSize = 0;
            this.ConstruirPedidoBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConstruirPedidoBttn.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConstruirPedidoBttn.ForeColor = System.Drawing.Color.White;
            this.ConstruirPedidoBttn.Location = new System.Drawing.Point(0, 0);
            this.ConstruirPedidoBttn.Name = "ConstruirPedidoBttn";
            this.ConstruirPedidoBttn.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ConstruirPedidoBttn.Size = new System.Drawing.Size(250, 41);
            this.ConstruirPedidoBttn.TabIndex = 2;
            this.ConstruirPedidoBttn.Text = "Crear Pedido";
            this.ConstruirPedidoBttn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConstruirPedidoBttn.UseVisualStyleBackColor = true;
            this.ConstruirPedidoBttn.Click += new System.EventHandler(this.ConstruirPedido_click);
            // 
            // PedidoBttn
            // 
            this.PedidoBttn.Dock = System.Windows.Forms.DockStyle.Top;
            this.PedidoBttn.FlatAppearance.BorderSize = 0;
            this.PedidoBttn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PedidoBttn.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PedidoBttn.ForeColor = System.Drawing.Color.White;
            this.PedidoBttn.Location = new System.Drawing.Point(0, 186);
            this.PedidoBttn.Name = "PedidoBttn";
            this.PedidoBttn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.PedidoBttn.Size = new System.Drawing.Size(250, 45);
            this.PedidoBttn.TabIndex = 9;
            this.PedidoBttn.Text = "Pedido";
            this.PedidoBttn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PedidoBttn.UseVisualStyleBackColor = true;
            this.PedidoBttn.Click += new System.EventHandler(this.PedidoBttn_Click);
            // 
            // panelSesion
            // 
            this.panelSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(120)))), ((int)(((byte)(158)))));
            this.panelSesion.Controls.Add(this.CerrarSesion);
            this.panelSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSesion.Location = new System.Drawing.Point(0, 145);
            this.panelSesion.Name = "panelSesion";
            this.panelSesion.Size = new System.Drawing.Size(250, 41);
            this.panelSesion.TabIndex = 8;
            // 
            // CerrarSesion
            // 
            this.CerrarSesion.Dock = System.Windows.Forms.DockStyle.Top;
            this.CerrarSesion.FlatAppearance.BorderSize = 0;
            this.CerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CerrarSesion.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CerrarSesion.ForeColor = System.Drawing.Color.White;
            this.CerrarSesion.Location = new System.Drawing.Point(0, 0);
            this.CerrarSesion.Name = "CerrarSesion";
            this.CerrarSesion.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.CerrarSesion.Size = new System.Drawing.Size(250, 41);
            this.CerrarSesion.TabIndex = 1;
            this.CerrarSesion.Text = "Cerrar Sesión";
            this.CerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CerrarSesion.UseVisualStyleBackColor = true;
            this.CerrarSesion.Click += new System.EventHandler(this.CerrarSesion_Click);
            // 
            // buttonNombreUsu
            // 
            this.buttonNombreUsu.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonNombreUsu.FlatAppearance.BorderSize = 0;
            this.buttonNombreUsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNombreUsu.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNombreUsu.ForeColor = System.Drawing.Color.White;
            this.buttonNombreUsu.Location = new System.Drawing.Point(0, 100);
            this.buttonNombreUsu.Name = "buttonNombreUsu";
            this.buttonNombreUsu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonNombreUsu.Size = new System.Drawing.Size(250, 45);
            this.buttonNombreUsu.TabIndex = 6;
            this.buttonNombreUsu.Text = "Usuario: ";
            this.buttonNombreUsu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNombreUsu.UseVisualStyleBackColor = true;
            this.buttonNombreUsu.Click += new System.EventHandler(this.buttonNombreUsu_Click);
            // 
            // ConeccionCheck
            // 
            this.ConeccionCheck.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ConeccionCheck.FlatAppearance.BorderSize = 0;
            this.ConeccionCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConeccionCheck.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConeccionCheck.ForeColor = System.Drawing.Color.White;
            this.ConeccionCheck.Location = new System.Drawing.Point(0, 616);
            this.ConeccionCheck.Name = "ConeccionCheck";
            this.ConeccionCheck.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ConeccionCheck.Size = new System.Drawing.Size(250, 45);
            this.ConeccionCheck.TabIndex = 5;
            this.ConeccionCheck.Text = "Conexión al servidor:";
            this.ConeccionCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConeccionCheck.UseVisualStyleBackColor = true;
            this.ConeccionCheck.Click += new System.EventHandler(this.ConeccionCheck_Click);
            // 
            // panellogo
            // 
            this.panellogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(62)))), ((int)(((byte)(82)))));
            this.panellogo.Controls.Add(this.pictureBox1);
            this.panellogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellogo.Location = new System.Drawing.Point(0, 0);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(250, 100);
            this.panellogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(81)))), ((int)(((byte)(107)))));
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(250, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(649, 661);
            this.panelContenido.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 661);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelmenulateral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(915, 700);
            this.MinimumSize = new System.Drawing.Size(915, 700);
            this.Name = "Dashboard";
            this.Text = "REST-UNED-CLIENTE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dashboard_FormClosing);
            this.panelmenulateral.ResumeLayout(false);
            this.panelConsultar.ResumeLayout(false);
            this.panelPedido.ResumeLayout(false);
            this.panelSesion.ResumeLayout(false);
            this.panellogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmenulateral;
        private System.Windows.Forms.Panel panellogo;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ConeccionCheck;
        private System.Windows.Forms.Panel panelPedido;
        private System.Windows.Forms.Button PedidoBttn;
        private System.Windows.Forms.Panel panelSesion;
        private System.Windows.Forms.Button CerrarSesion;
        private System.Windows.Forms.Button buttonNombreUsu;
        private System.Windows.Forms.Button ConstruirPedidoBttn;
        private System.Windows.Forms.Button ConsultarPedidoBttn;
        private System.Windows.Forms.Button ProcesarPedidoBttn;
        private System.Windows.Forms.Panel panelConsultar;
        private System.Windows.Forms.Button ConPedidosTodos;
        private System.Windows.Forms.Button ConPedidoUni;
    }
}