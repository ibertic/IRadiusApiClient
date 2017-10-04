namespace WindowsApiClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.lstHotspots = new System.Windows.Forms.ListBox();
            this.lstTypes = new System.Windows.Forms.ListBox();
            this.txtQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.Table = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(42, 406);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(113, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Cargar clientes";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(798, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(467, 154);
            this.textBox1.TabIndex = 1;
            // 
            // lstCustomers
            // 
            this.lstCustomers.DisplayMember = "Name";
            this.lstCustomers.FormattingEnabled = true;
            this.lstCustomers.Location = new System.Drawing.Point(35, 54);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(175, 251);
            this.lstCustomers.TabIndex = 2;
            this.lstCustomers.ValueMember = "Id";
            this.lstCustomers.SelectedValueChanged += new System.EventHandler(this.lstCustomers_SelectedValueChanged);
            // 
            // lstHotspots
            // 
            this.lstHotspots.DisplayMember = "Name";
            this.lstHotspots.FormattingEnabled = true;
            this.lstHotspots.Location = new System.Drawing.Point(216, 54);
            this.lstHotspots.Name = "lstHotspots";
            this.lstHotspots.Size = new System.Drawing.Size(175, 251);
            this.lstHotspots.TabIndex = 3;
            this.lstHotspots.ValueMember = "Id";
            // 
            // lstTypes
            // 
            this.lstTypes.DisplayMember = "Name";
            this.lstTypes.FormattingEnabled = true;
            this.lstTypes.Location = new System.Drawing.Point(406, 54);
            this.lstTypes.Name = "lstTypes";
            this.lstTypes.Size = new System.Drawing.Size(175, 251);
            this.lstTypes.TabIndex = 4;
            this.lstTypes.ValueMember = "Id";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(35, 323);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(120, 20);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(232, 319);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(349, 23);
            this.btnGenerate.TabIndex = 6;
            this.btnGenerate.Text = "Generar credenciales";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // Table
            // 
            this.Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table.Location = new System.Drawing.Point(662, 183);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(603, 413);
            this.Table.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 641);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lstTypes);
            this.Controls.Add(this.lstHotspots);
            this.Controls.Add(this.lstCustomers);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoad);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.ListBox lstHotspots;
        private System.Windows.Forms.ListBox lstTypes;
        private System.Windows.Forms.NumericUpDown txtQuantity;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DataGridView Table;
    }
}

