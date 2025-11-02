namespace CapaPresentacion
{
    partial class FormVentaDetalle
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
            this.lbltitulo = new System.Windows.Forms.Label();
            this.lblFech4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtCodigoDeVentaDetalle = new System.Windows.Forms.Label();
            this.txtCodigoVentad = new System.Windows.Forms.Label();
            this.txtCodigoAnimalcc = new System.Windows.Forms.Label();
            this.txtCodigoCultivoccc = new System.Windows.Forms.Label();
            this.txtCodigoProductovvv = new System.Windows.Forms.Label();
            this.txtCodigoRol = new System.Windows.Forms.TextBox();
            this.txtCodiVent = new System.Windows.Forms.TextBox();
            this.txtCodigoAnimal = new System.Windows.Forms.TextBox();
            this.txtCodigoCultivo = new System.Windows.Forms.TextBox();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.txtCanti = new System.Windows.Forms.Label();
            this.txtPreUniccc = new System.Windows.Forms.Label();
            this.txtTot = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.Label();
            this.txtImp = new System.Windows.Forms.Label();
            this.txtTotVentcc = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboxEstado = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtPrecioUni = new System.Windows.Forms.TextBox();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.txtDescu = new System.Windows.Forms.TextBox();
            this.txtImpd = new System.Windows.Forms.TextBox();
            this.txtTotVent = new System.Windows.Forms.TextBox();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Calisto MT", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(185, 57);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(467, 32);
            this.lbltitulo.TabIndex = 86;
            this.lbltitulo.Text = "DETALLE VENTA GRANJA \"S.A\"";
            // 
            // lblFech4
            // 
            this.lblFech4.AutoSize = true;
            this.lblFech4.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFech4.Location = new System.Drawing.Point(789, 69);
            this.lblFech4.Name = "lblFech4";
            this.lblFech4.Size = new System.Drawing.Size(121, 20);
            this.lblFech4.TabIndex = 85;
            this.lblFech4.Text = "Imprimir fecha:";
            this.lblFech4.Click += new System.EventHandler(this.lblFecha_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(658, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 20);
            this.label8.TabIndex = 84;
            this.label8.Text = "Fecha actual:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnCancelar.IconColor = System.Drawing.Color.Black;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 25;
            this.btnCancelar.Location = new System.Drawing.Point(889, 217);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(112, 39);
            this.btnCancelar.TabIndex = 83;
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
            this.btnEditar.Location = new System.Drawing.Point(889, 172);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(112, 39);
            this.btnEditar.TabIndex = 82;
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
            this.btnGuardar.Location = new System.Drawing.Point(889, 128);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(112, 39);
            this.btnGuardar.TabIndex = 81;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCodigoDeVentaDetalle
            // 
            this.txtCodigoDeVentaDetalle.AllowDrop = true;
            this.txtCodigoDeVentaDetalle.AutoSize = true;
            this.txtCodigoDeVentaDetalle.Location = new System.Drawing.Point(41, 128);
            this.txtCodigoDeVentaDetalle.Name = "txtCodigoDeVentaDetalle";
            this.txtCodigoDeVentaDetalle.Size = new System.Drawing.Size(152, 16);
            this.txtCodigoDeVentaDetalle.TabIndex = 87;
            this.txtCodigoDeVentaDetalle.Text = "Codigo Detalle de venta";
            this.txtCodigoDeVentaDetalle.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCodigoVentad
            // 
            this.txtCodigoVentad.AllowDrop = true;
            this.txtCodigoVentad.AutoSize = true;
            this.txtCodigoVentad.Location = new System.Drawing.Point(41, 159);
            this.txtCodigoVentad.Name = "txtCodigoVentad";
            this.txtCodigoVentad.Size = new System.Drawing.Size(89, 16);
            this.txtCodigoVentad.TabIndex = 89;
            this.txtCodigoVentad.Text = "Codigo Venta";
            this.txtCodigoVentad.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // txtCodigoAnimalcc
            // 
            this.txtCodigoAnimalcc.AllowDrop = true;
            this.txtCodigoAnimalcc.AutoSize = true;
            this.txtCodigoAnimalcc.Location = new System.Drawing.Point(41, 186);
            this.txtCodigoAnimalcc.Name = "txtCodigoAnimalcc";
            this.txtCodigoAnimalcc.Size = new System.Drawing.Size(95, 16);
            this.txtCodigoAnimalcc.TabIndex = 90;
            this.txtCodigoAnimalcc.Text = "Codigo Animal\r\n";
            // 
            // txtCodigoCultivoccc
            // 
            this.txtCodigoCultivoccc.AllowDrop = true;
            this.txtCodigoCultivoccc.AutoSize = true;
            this.txtCodigoCultivoccc.Location = new System.Drawing.Point(42, 209);
            this.txtCodigoCultivoccc.Name = "txtCodigoCultivoccc";
            this.txtCodigoCultivoccc.Size = new System.Drawing.Size(94, 16);
            this.txtCodigoCultivoccc.TabIndex = 92;
            this.txtCodigoCultivoccc.Text = "Codigo Cultivo";
            // 
            // txtCodigoProductovvv
            // 
            this.txtCodigoProductovvv.AllowDrop = true;
            this.txtCodigoProductovvv.AutoSize = true;
            this.txtCodigoProductovvv.Location = new System.Drawing.Point(42, 236);
            this.txtCodigoProductovvv.Name = "txtCodigoProductovvv";
            this.txtCodigoProductovvv.Size = new System.Drawing.Size(108, 16);
            this.txtCodigoProductovvv.TabIndex = 93;
            this.txtCodigoProductovvv.Text = "Codigo Producto";
            // 
            // txtCodigoRol
            // 
            this.txtCodigoRol.Location = new System.Drawing.Point(235, 125);
            this.txtCodigoRol.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoRol.Name = "txtCodigoRol";
            this.txtCodigoRol.ReadOnly = true;
            this.txtCodigoRol.Size = new System.Drawing.Size(177, 22);
            this.txtCodigoRol.TabIndex = 94;
            // 
            // txtCodiVent
            // 
            this.txtCodiVent.Location = new System.Drawing.Point(235, 159);
            this.txtCodiVent.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodiVent.Name = "txtCodiVent";
            this.txtCodiVent.Size = new System.Drawing.Size(177, 22);
            this.txtCodiVent.TabIndex = 100;
            // 
            // txtCodigoAnimal
            // 
            this.txtCodigoAnimal.Location = new System.Drawing.Point(235, 186);
            this.txtCodigoAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoAnimal.Name = "txtCodigoAnimal";
            this.txtCodigoAnimal.Size = new System.Drawing.Size(177, 22);
            this.txtCodigoAnimal.TabIndex = 101;
            // 
            // txtCodigoCultivo
            // 
            this.txtCodigoCultivo.Location = new System.Drawing.Point(235, 209);
            this.txtCodigoCultivo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoCultivo.Name = "txtCodigoCultivo";
            this.txtCodigoCultivo.Size = new System.Drawing.Size(177, 22);
            this.txtCodigoCultivo.TabIndex = 103;
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(235, 236);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(177, 22);
            this.txtCodigoProducto.TabIndex = 104;
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(45, 308);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.RowHeadersWidth = 51;
            this.dgvDetalleVenta.RowTemplate.Height = 24;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(956, 167);
            this.dgvDetalleVenta.TabIndex = 105;
            this.dgvDetalleVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleVenta_CellContentClick);
            // 
            // txtCanti
            // 
            this.txtCanti.AllowDrop = true;
            this.txtCanti.AutoSize = true;
            this.txtCanti.Location = new System.Drawing.Point(433, 131);
            this.txtCanti.Name = "txtCanti";
            this.txtCanti.Size = new System.Drawing.Size(61, 16);
            this.txtCanti.TabIndex = 106;
            this.txtCanti.Text = "Cantidad";
            this.txtCanti.Click += new System.EventHandler(this.txt_Click);
            // 
            // txtPreUniccc
            // 
            this.txtPreUniccc.AllowDrop = true;
            this.txtPreUniccc.AutoSize = true;
            this.txtPreUniccc.Location = new System.Drawing.Point(433, 159);
            this.txtPreUniccc.Name = "txtPreUniccc";
            this.txtPreUniccc.Size = new System.Drawing.Size(95, 16);
            this.txtPreUniccc.TabIndex = 107;
            this.txtPreUniccc.Text = "Precio Unitario";
            this.txtPreUniccc.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtTot
            // 
            this.txtTot.AllowDrop = true;
            this.txtTot.AutoSize = true;
            this.txtTot.Location = new System.Drawing.Point(433, 186);
            this.txtTot.Name = "txtTot";
            this.txtTot.Size = new System.Drawing.Size(38, 16);
            this.txtTot.TabIndex = 108;
            this.txtTot.Text = "Total";
            // 
            // txtDesc
            // 
            this.txtDesc.AllowDrop = true;
            this.txtDesc.AutoSize = true;
            this.txtDesc.Location = new System.Drawing.Point(433, 211);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(72, 16);
            this.txtDesc.TabIndex = 109;
            this.txtDesc.Text = "Descuento";
            // 
            // txtImp
            // 
            this.txtImp.AllowDrop = true;
            this.txtImp.AutoSize = true;
            this.txtImp.Location = new System.Drawing.Point(433, 236);
            this.txtImp.Name = "txtImp";
            this.txtImp.Size = new System.Drawing.Size(62, 16);
            this.txtImp.TabIndex = 110;
            this.txtImp.Text = "Impuesto";
            // 
            // txtTotVentcc
            // 
            this.txtTotVentcc.AllowDrop = true;
            this.txtTotVentcc.AutoSize = true;
            this.txtTotVentcc.Location = new System.Drawing.Point(432, 263);
            this.txtTotVentcc.Name = "txtTotVentcc";
            this.txtTotVentcc.Size = new System.Drawing.Size(73, 16);
            this.txtTotVentcc.TabIndex = 111;
            this.txtTotVentcc.Text = "TotalVenta";
            // 
            // label14
            // 
            this.label14.AllowDrop = true;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(690, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 16);
            this.label14.TabIndex = 112;
            this.label14.Text = "Estado";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // cboxEstado
            // 
            this.cboxEstado.FormattingEnabled = true;
            this.cboxEstado.Items.AddRange(new object[] {
            "Pendiente",
            "Completado"});
            this.cboxEstado.Location = new System.Drawing.Point(756, 125);
            this.cboxEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cboxEstado.Name = "cboxEstado";
            this.cboxEstado.Size = new System.Drawing.Size(114, 24);
            this.cboxEstado.TabIndex = 113;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(550, 125);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(134, 22);
            this.txtCantidad.TabIndex = 114;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtPrecioUni
            // 
            this.txtPrecioUni.Location = new System.Drawing.Point(550, 153);
            this.txtPrecioUni.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecioUni.Name = "txtPrecioUni";
            this.txtPrecioUni.Size = new System.Drawing.Size(134, 22);
            this.txtPrecioUni.TabIndex = 115;
            this.txtPrecioUni.TextChanged += new System.EventHandler(this.txtPrecioUni_TextChanged);
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(550, 186);
            this.textTotal.Margin = new System.Windows.Forms.Padding(4);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(134, 22);
            this.textTotal.TabIndex = 119;
            this.textTotal.TextChanged += new System.EventHandler(this.textTotal_TextChanged);
            // 
            // txtDescu
            // 
            this.txtDescu.Location = new System.Drawing.Point(550, 211);
            this.txtDescu.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescu.Name = "txtDescu";
            this.txtDescu.ReadOnly = true;
            this.txtDescu.Size = new System.Drawing.Size(134, 22);
            this.txtDescu.TabIndex = 120;
            // 
            // txtImpd
            // 
            this.txtImpd.Location = new System.Drawing.Point(550, 236);
            this.txtImpd.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpd.Name = "txtImpd";
            this.txtImpd.ReadOnly = true;
            this.txtImpd.Size = new System.Drawing.Size(134, 22);
            this.txtImpd.TabIndex = 121;
            this.txtImpd.TextChanged += new System.EventHandler(this.txtImpd_TextChanged);
            // 
            // txtTotVent
            // 
            this.txtTotVent.Location = new System.Drawing.Point(550, 263);
            this.txtTotVent.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotVent.Name = "txtTotVent";
            this.txtTotVent.ReadOnly = true;
            this.txtTotVent.Size = new System.Drawing.Size(134, 22);
            this.txtTotVent.TabIndex = 122;
            this.txtTotVent.TextChanged += new System.EventHandler(this.txtTotVent_TextChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnSalir.IconColor = System.Drawing.Color.Black;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 25;
            this.btnSalir.Location = new System.Drawing.Point(889, 497);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 38);
            this.btnSalir.TabIndex = 124;
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
            this.btnEliminar.Location = new System.Drawing.Point(771, 497);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(112, 38);
            this.btnEliminar.TabIndex = 123;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // FormVentaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 578);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.txtCanti);
            this.Controls.Add(this.txtTotVent);
            this.Controls.Add(this.txtImpd);
            this.Controls.Add(this.txtDescu);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.txtPrecioUni);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cboxEstado);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTotVentcc);
            this.Controls.Add(this.txtImp);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtTot);
            this.Controls.Add(this.txtPreUniccc);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Controls.Add(this.txtCodigoProducto);
            this.Controls.Add(this.txtCodigoCultivo);
            this.Controls.Add(this.txtCodigoAnimal);
            this.Controls.Add(this.txtCodiVent);
            this.Controls.Add(this.txtCodigoRol);
            this.Controls.Add(this.txtCodigoProductovvv);
            this.Controls.Add(this.txtCodigoCultivoccc);
            this.Controls.Add(this.txtCodigoAnimalcc);
            this.Controls.Add(this.txtCodigoVentad);
            this.Controls.Add(this.txtCodigoDeVentaDetalle);
            this.Controls.Add(this.lbltitulo);
            this.Controls.Add(this.lblFech4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "FormVentaDetalle";
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormVentaDetalle_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitulo;
        private System.Windows.Forms.Label lblFech4;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Label txtCodigoDeVentaDetalle;
        private System.Windows.Forms.Label txtCodigoVentad;
        private System.Windows.Forms.Label txtCodigoAnimalcc;
        private System.Windows.Forms.Label txtCodigoCultivoccc;
        private System.Windows.Forms.Label txtCodigoProductovvv;
        private System.Windows.Forms.TextBox txtCodigoRol;
        private System.Windows.Forms.TextBox txtCodiVent;
        private System.Windows.Forms.TextBox txtCodigoAnimal;
        private System.Windows.Forms.TextBox txtCodigoCultivo;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Label txtCanti;
        private System.Windows.Forms.Label txtPreUniccc;
        private System.Windows.Forms.Label txtTot;
        private System.Windows.Forms.Label txtDesc;
        private System.Windows.Forms.Label txtImp;
        private System.Windows.Forms.Label txtTotVentcc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboxEstado;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtPrecioUni;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.TextBox txtDescu;
        private System.Windows.Forms.TextBox txtImpd;
        private System.Windows.Forms.TextBox txtTotVent;
        private FontAwesome.Sharp.IconButton btnSalir;
        private FontAwesome.Sharp.IconButton btnEliminar;
    }
}