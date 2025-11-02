namespace CapaPresentacion {
    partial class frmInsumos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservacion = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtCostoUnitario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombreInsumo = new System.Windows.Forms.TextBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.txtCodigoVenta = new System.Windows.Forms.TextBox();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.cboTipoInsumo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDatos.Location = new System.Drawing.Point(11, 206);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(778, 199);
            this.dgvDatos.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtObservacion);
            this.groupBox1.Controls.Add(this.txtPeso);
            this.groupBox1.Controls.Add(this.cboUnidadMedida);
            this.groupBox1.Controls.Add(this.txtCostoUnitario);
            this.groupBox1.Controls.Add(this.cboTipoInsumo);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNombreInsumo);
            this.groupBox1.Controls.Add(this.lblTotalVenta);
            this.groupBox1.Controls.Add(this.txtCodigoVenta);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnEditar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.cboProveedor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(11, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(779, 162);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(346, 108);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 48;
            this.label11.Text = "Observacion:";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboEstado.Location = new System.Drawing.Point(459, 132);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(2);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(134, 23);
            this.cboEstado.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(346, 137);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 16);
            this.label10.TabIndex = 46;
            this.label10.Text = "Estado:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(458, 104);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(134, 20);
            this.txtObservacion.TabIndex = 45;
            // 
            // txtPeso
            // 
            this.txtPeso.Location = new System.Drawing.Point(458, 76);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(134, 20);
            this.txtPeso.TabIndex = 44;
            // 
            // txtCostoUnitario
            // 
            this.txtCostoUnitario.Location = new System.Drawing.Point(458, 17);
            this.txtCostoUnitario.Name = "txtCostoUnitario";
            this.txtCostoUnitario.Size = new System.Drawing.Size(134, 20);
            this.txtCostoUnitario.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Tipo Insumo:";
            // 
            // txtNombreInsumo
            // 
            this.txtNombreInsumo.Location = new System.Drawing.Point(142, 75);
            this.txtNombreInsumo.Name = "txtNombreInsumo";
            this.txtNombreInsumo.Size = new System.Drawing.Size(134, 20);
            this.txtNombreInsumo.TabIndex = 39;
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.Location = new System.Drawing.Point(451, 57);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(0, 16);
            this.lblTotalVenta.TabIndex = 37;
            // 
            // txtCodigoVenta
            // 
            this.txtCodigoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoVenta.Location = new System.Drawing.Point(142, 15);
            this.txtCodigoVenta.Name = "txtCodigoVenta";
            this.txtCodigoVenta.ReadOnly = true;
            this.txtCodigoVenta.Size = new System.Drawing.Size(134, 21);
            this.txtCodigoVenta.TabIndex = 26;
            // 
            // btnCancelar
            // 
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 25;
            this.btnCancelar.Location = new System.Drawing.Point(627, 89);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 31);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.SquarePen;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 25;
            this.btnEditar.Location = new System.Drawing.Point(627, 53);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(84, 31);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnGuardar.IconColor = System.Drawing.Color.Black;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 25;
            this.btnGuardar.Location = new System.Drawing.Point(627, 17);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(84, 31);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboProveedor
            // 
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboProveedor.Location = new System.Drawing.Point(142, 44);
            this.cboProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(134, 23);
            this.cboProveedor.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(346, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Peso:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(346, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Unidad Medida:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(346, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Costo Unitario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Insumo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Codigo Insumo:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(616, 10);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 16);
            this.lblFecha.TabIndex = 46;
            this.lblFecha.Text = "Imprimir fecha:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(518, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "Fecha actual:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 44;
            this.label1.Text = "INSUMOS";
            // 
            // btnSalir
            // 
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnSalir.IconColor = System.Drawing.Color.Black;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 25;
            this.btnSalir.Location = new System.Drawing.Point(640, 410);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 31);
            this.btnSalir.TabIndex = 49;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 25;
            this.btnEliminar.Location = new System.Drawing.Point(551, 410);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(84, 31);
            this.btnEliminar.TabIndex = 48;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboUnidadMedida.Location = new System.Drawing.Point(458, 45);
            this.cboUnidadMedida.Margin = new System.Windows.Forms.Padding(2);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(134, 23);
            this.cboUnidadMedida.TabIndex = 43;
            // 
            // cboTipoInsumo
            // 
            this.cboTipoInsumo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoInsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoInsumo.FormattingEnabled = true;
            this.cboTipoInsumo.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboTipoInsumo.Location = new System.Drawing.Point(142, 103);
            this.cboTipoInsumo.Margin = new System.Windows.Forms.Padding(2);
            this.cboTipoInsumo.Name = "cboTipoInsumo";
            this.cboTipoInsumo.Size = new System.Drawing.Size(134, 23);
            this.cboTipoInsumo.TabIndex = 41;
            // 
            // frmInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 455);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Name = "frmInsumos";
            this.Text = "frmInsumos";
            this.Load += new System.EventHandler(this.frmInsumos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.TextBox txtCodigoVenta;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombreInsumo;
        private System.Windows.Forms.TextBox txtObservacion;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtCostoUnitario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.ComboBox cboTipoInsumo;
    }
}