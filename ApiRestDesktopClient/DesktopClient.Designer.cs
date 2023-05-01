namespace ApiRestDesktopClient
{
    partial class frmApiRest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvEmpleados = new DataGridView();
            lblFiltro = new Label();
            txtFiltro = new TextBox();
            btnFiltrar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtDni = new TextBox();
            lblDNI = new Label();
            txtEdad = new TextBox();
            lblEdad = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtCorreo = new TextBox();
            lblCorreo = new Label();
            txtBasico = new TextBox();
            lblBasico = new Label();
            txtIngreso = new TextBox();
            lblIngreso = new Label();
            txtActivo = new TextBox();
            lblActivo = new Label();
            btnNuevo = new Button();
            btnElimnar = new Button();
            btnGuardar = new Button();
            txtId = new TextBox();
            lblId = new Label();
            dtpIngreso = new DateTimePicker();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            SuspendLayout();
            // 
            // dgvEmpleados
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.InfoText;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmpleados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.DimGray;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.AppWorkspace;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmpleados.GridColor = SystemColors.WindowFrame;
            dgvEmpleados.Location = new Point(12, 65);
            dgvEmpleados.Name = "dgvEmpleados";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEmpleados.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.DimGray;
            dataGridViewCellStyle4.ForeColor = Color.White;
            dgvEmpleados.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvEmpleados.RowTemplate.Height = 25;
            dgvEmpleados.Size = new Size(693, 354);
            dgvEmpleados.TabIndex = 15;
            dgvEmpleados.RowEnter += dgvEmpleados_RowEnter;
            // 
            // lblFiltro
            // 
            lblFiltro.AutoSize = true;
            lblFiltro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblFiltro.Location = new Point(23, 25);
            lblFiltro.Name = "lblFiltro";
            lblFiltro.Size = new Size(41, 17);
            lblFiltro.TabIndex = 1;
            lblFiltro.Text = "Filtro";
            // 
            // txtFiltro
            // 
            txtFiltro.BackColor = Color.FromArgb(64, 64, 64);
            txtFiltro.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            txtFiltro.ForeColor = SystemColors.Control;
            txtFiltro.Location = new Point(79, 21);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(100, 25);
            txtFiltro.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.DarkOrange;
            btnFiltrar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFiltrar.ForeColor = SystemColors.Control;
            btnFiltrar.Location = new Point(209, 17);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(105, 33);
            btnFiltrar.TabIndex = 11;
            btnFiltrar.Text = "Listar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(64, 64, 64);
            txtNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.ForeColor = SystemColors.Control;
            txtNombre.Location = new Point(802, 65);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 25);
            txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombre.Location = new Point(735, 68);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(58, 17);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // txtDni
            // 
            txtDni.BackColor = Color.FromArgb(64, 64, 64);
            txtDni.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtDni.ForeColor = SystemColors.Control;
            txtDni.Location = new Point(802, 96);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(151, 25);
            txtDni.TabIndex = 4;
            // 
            // lblDNI
            // 
            lblDNI.AutoSize = true;
            lblDNI.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblDNI.Location = new Point(735, 99);
            lblDNI.Name = "lblDNI";
            lblDNI.Size = new Size(32, 17);
            lblDNI.TabIndex = 6;
            lblDNI.Text = "DNI";
            // 
            // txtEdad
            // 
            txtEdad.BackColor = Color.FromArgb(64, 64, 64);
            txtEdad.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtEdad.ForeColor = SystemColors.Control;
            txtEdad.Location = new Point(802, 127);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(151, 25);
            txtEdad.TabIndex = 5;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblEdad.Location = new Point(735, 130);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(38, 17);
            lblEdad.TabIndex = 8;
            lblEdad.Text = "Edad";
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(64, 64, 64);
            txtTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtTelefono.ForeColor = SystemColors.Control;
            txtTelefono.Location = new Point(802, 158);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(151, 25);
            txtTelefono.TabIndex = 6;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblTelefono.Location = new Point(735, 161);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(62, 17);
            lblTelefono.TabIndex = 10;
            lblTelefono.Text = "Telefono";
            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = Color.FromArgb(64, 64, 64);
            txtCorreo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.ForeColor = SystemColors.Control;
            txtCorreo.Location = new Point(802, 189);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(151, 25);
            txtCorreo.TabIndex = 7;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblCorreo.Location = new Point(735, 192);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(49, 17);
            lblCorreo.TabIndex = 12;
            lblCorreo.Text = "Correo";
            // 
            // txtBasico
            // 
            txtBasico.BackColor = Color.FromArgb(64, 64, 64);
            txtBasico.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBasico.ForeColor = SystemColors.Control;
            txtBasico.Location = new Point(802, 220);
            txtBasico.Name = "txtBasico";
            txtBasico.Size = new Size(151, 25);
            txtBasico.TabIndex = 8;
            // 
            // lblBasico
            // 
            lblBasico.AutoSize = true;
            lblBasico.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblBasico.Location = new Point(735, 223);
            lblBasico.Name = "lblBasico";
            lblBasico.Size = new Size(47, 17);
            lblBasico.TabIndex = 14;
            lblBasico.Text = "Basico";
            // 
            // txtIngreso
            // 
            txtIngreso.BackColor = Color.FromArgb(64, 64, 64);
            txtIngreso.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtIngreso.ForeColor = SystemColors.Control;
            txtIngreso.Location = new Point(802, 251);
            txtIngreso.Name = "txtIngreso";
            txtIngreso.Size = new Size(126, 25);
            txtIngreso.TabIndex = 9;
            // 
            // lblIngreso
            // 
            lblIngreso.AutoSize = true;
            lblIngreso.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblIngreso.Location = new Point(735, 254);
            lblIngreso.Name = "lblIngreso";
            lblIngreso.Size = new Size(54, 17);
            lblIngreso.TabIndex = 16;
            lblIngreso.Text = "Ingreso";
            // 
            // txtActivo
            // 
            txtActivo.BackColor = Color.FromArgb(64, 64, 64);
            txtActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtActivo.ForeColor = SystemColors.Control;
            txtActivo.Location = new Point(837, 282);
            txtActivo.Name = "txtActivo";
            txtActivo.ReadOnly = true;
            txtActivo.Size = new Size(116, 25);
            txtActivo.TabIndex = 10;
            txtActivo.Visible = false;
            // 
            // lblActivo
            // 
            lblActivo.AutoSize = true;
            lblActivo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblActivo.Location = new Point(735, 285);
            lblActivo.Name = "lblActivo";
            lblActivo.Size = new Size(47, 17);
            lblActivo.TabIndex = 18;
            lblActivo.Text = "Activo";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnNuevo.ForeColor = SystemColors.Control;
            btnNuevo.Location = new Point(320, 17);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(102, 33);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Crear";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnElimnar
            // 
            btnElimnar.BackColor = Color.Firebrick;
            btnElimnar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnElimnar.ForeColor = SystemColors.Control;
            btnElimnar.Location = new Point(849, 326);
            btnElimnar.Name = "btnElimnar";
            btnElimnar.Size = new Size(102, 33);
            btnElimnar.TabIndex = 14;
            btnElimnar.Text = "Eliminar";
            btnElimnar.UseVisualStyleBackColor = false;
            btnElimnar.Click += btnElimnar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.MenuHighlight;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.ForeColor = SystemColors.Control;
            btnGuardar.Location = new Point(738, 326);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 33);
            btnGuardar.TabIndex = 13;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(64, 64, 64);
            txtId.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.ForeColor = SystemColors.Control;
            txtId.Location = new Point(802, 34);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(151, 25);
            txtId.TabIndex = 2;
            txtId.Visible = false;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblId.Location = new Point(735, 37);
            lblId.Name = "lblId";
            lblId.Size = new Size(20, 17);
            lblId.TabIndex = 23;
            lblId.Text = "Id";
            lblId.Visible = false;
            // 
            // dtpIngreso
            // 
            dtpIngreso.CalendarMonthBackground = Color.FromArgb(64, 64, 64);
            dtpIngreso.CustomFormat = "dd/MM/yyyy hh:mm";
            dtpIngreso.Format = DateTimePickerFormat.Custom;
            dtpIngreso.Location = new Point(934, 253);
            dtpIngreso.Name = "dtpIngreso";
            dtpIngreso.Size = new Size(19, 23);
            dtpIngreso.TabIndex = 24;
            dtpIngreso.ValueChanged += dtpIngreso_ValueChanged;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(802, 288);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(15, 14);
            chkActivo.TabIndex = 25;
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.CheckedChanged += chkActivo_CheckedChanged;
            // 
            // frmApiRest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(977, 431);
            Controls.Add(chkActivo);
            Controls.Add(dtpIngreso);
            Controls.Add(txtId);
            Controls.Add(lblId);
            Controls.Add(btnElimnar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtActivo);
            Controls.Add(lblActivo);
            Controls.Add(txtIngreso);
            Controls.Add(lblIngreso);
            Controls.Add(txtBasico);
            Controls.Add(lblBasico);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtEdad);
            Controls.Add(lblEdad);
            Controls.Add(txtDni);
            Controls.Add(lblDNI);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(btnFiltrar);
            Controls.Add(txtFiltro);
            Controls.Add(lblFiltro);
            Controls.Add(dgvEmpleados);
            ForeColor = SystemColors.AppWorkspace;
            Name = "frmApiRest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "API Rest Desktop Client";
            Load += frm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvEmpleados;
        private Label lblFiltro;
        private TextBox txtFiltro;
        private Button btnFiltrar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtDni;
        private Label lblDNI;
        private TextBox txtEdad;
        private Label lblEdad;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtCorreo;
        private Label lblCorreo;
        private TextBox txtBasico;
        private Label lblBasico;
        private TextBox txtIngreso;
        private Label lblIngreso;
        private TextBox txtActivo;
        private Label lblActivo;
        private Button btnNuevo;
        private Button btnElimnar;
        private Button btnGuardar;
        private TextBox txtId;
        private Label lblId;
        private DateTimePicker dtpIngreso;
        private CheckBox chkActivo;
    }
}