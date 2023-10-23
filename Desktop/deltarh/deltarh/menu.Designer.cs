
namespace deltarh
{
    partial class frmMenu
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCnpjStatus = new System.Windows.Forms.TextBox();
            this.btnStatus = new System.Windows.Forms.Button();
            this.gridPendentes = new System.Windows.Forms.DataGridView();
            this.btnAtualiza = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCpf = new System.Windows.Forms.Button();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.btnCnpj = new System.Windows.Forms.Button();
            this.lblCadCnpj = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnJustificar = new System.Windows.Forms.Button();
            this.gridPonto = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxColaborador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.tblempresaBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.tblempresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tblempresaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendentes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(526, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.gridPendentes);
            this.tabPage1.Controls.Add(this.btnAtualiza);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(518, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtCnpjStatus);
            this.groupBox3.Controls.Add(this.btnStatus);
            this.groupBox3.Location = new System.Drawing.Point(9, 394);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(503, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Atualizar Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "CNPJ";
            // 
            // txtCnpjStatus
            // 
            this.txtCnpjStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpjStatus.Location = new System.Drawing.Point(132, 47);
            this.txtCnpjStatus.Name = "txtCnpjStatus";
            this.txtCnpjStatus.Size = new System.Drawing.Size(196, 22);
            this.txtCnpjStatus.TabIndex = 4;
            // 
            // btnStatus
            // 
            this.btnStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.Location = new System.Drawing.Point(349, 45);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 5;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.button1_Click);
            // 
            // gridPendentes
            // 
            this.gridPendentes.AllowUserToAddRows = false;
            this.gridPendentes.AllowUserToDeleteRows = false;
            this.gridPendentes.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gridPendentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPendentes.Location = new System.Drawing.Point(0, 0);
            this.gridPendentes.Name = "gridPendentes";
            this.gridPendentes.ReadOnly = true;
            this.gridPendentes.Size = new System.Drawing.Size(515, 339);
            this.gridPendentes.TabIndex = 2;
            // 
            // btnAtualiza
            // 
            this.btnAtualiza.Location = new System.Drawing.Point(437, 345);
            this.btnAtualiza.Name = "btnAtualiza";
            this.btnAtualiza.Size = new System.Drawing.Size(75, 23);
            this.btnAtualiza.TabIndex = 1;
            this.btnAtualiza.Text = "Atualizar";
            this.btnAtualiza.UseVisualStyleBackColor = true;
            this.btnAtualiza.Click += new System.EventHandler(this.btnAtualiza_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(518, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consulta";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCpf);
            this.groupBox2.Controls.Add(this.txtCpf);
            this.groupBox2.Controls.Add(this.lblCpf);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(499, 107);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta Colaborador";
            // 
            // btnCpf
            // 
            this.btnCpf.Location = new System.Drawing.Point(373, 34);
            this.btnCpf.Name = "btnCpf";
            this.btnCpf.Size = new System.Drawing.Size(89, 23);
            this.btnCpf.TabIndex = 8;
            this.btnCpf.Text = "Buscar";
            this.btnCpf.UseVisualStyleBackColor = true;
            this.btnCpf.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(116, 36);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(228, 22);
            this.txtCpf.TabIndex = 1;
            this.txtCpf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCpf_KeyPress);
            // 
            // lblCpf
            // 
            this.lblCpf.Location = new System.Drawing.Point(32, 39);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(62, 23);
            this.lblCpf.TabIndex = 4;
            this.lblCpf.Text = "CPF";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCnpj);
            this.groupBox1.Controls.Add(this.btnCnpj);
            this.groupBox1.Controls.Add(this.lblCadCnpj);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(499, 92);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consulta Empresa";
            // 
            // txtCnpj
            // 
            this.txtCnpj.Location = new System.Drawing.Point(116, 31);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(228, 22);
            this.txtCnpj.TabIndex = 0;
            this.txtCnpj.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCnpj_KeyPress);
            // 
            // btnCnpj
            // 
            this.btnCnpj.Location = new System.Drawing.Point(373, 29);
            this.btnCnpj.Name = "btnCnpj";
            this.btnCnpj.Size = new System.Drawing.Size(89, 23);
            this.btnCnpj.TabIndex = 6;
            this.btnCnpj.Text = "Buscar";
            this.btnCnpj.UseVisualStyleBackColor = true;
            this.btnCnpj.Click += new System.EventHandler(this.btnCnpj_Click);
            // 
            // lblCadCnpj
            // 
            this.lblCadCnpj.Location = new System.Drawing.Point(32, 34);
            this.lblCadCnpj.Name = "lblCadCnpj";
            this.lblCadCnpj.Size = new System.Drawing.Size(62, 23);
            this.lblCadCnpj.TabIndex = 3;
            this.lblCadCnpj.Text = "CNPJ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnFiltrar);
            this.tabPage3.Controls.Add(this.btnProcessar);
            this.tabPage3.Controls.Add(this.btnCancelar);
            this.tabPage3.Controls.Add(this.btnJustificar);
            this.tabPage3.Controls.Add(this.gridPonto);
            this.tabPage3.Controls.Add(this.dateTimePicker2);
            this.tabPage3.Controls.Add(this.dateTimePicker1);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cBoxColaborador);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.cBoxEmpresa);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(518, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Fechar Folha";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnProcessar
            // 
            this.btnProcessar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessar.Location = new System.Drawing.Point(423, 472);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(85, 30);
            this.btnProcessar.TabIndex = 2;
            this.btnProcessar.Text = "Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(314, 472);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnJustificar
            // 
            this.btnJustificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJustificar.Location = new System.Drawing.Point(9, 472);
            this.btnJustificar.Name = "btnJustificar";
            this.btnJustificar.Size = new System.Drawing.Size(85, 30);
            this.btnJustificar.TabIndex = 1;
            this.btnJustificar.Text = "Justificar";
            this.btnJustificar.UseVisualStyleBackColor = true;
            // 
            // gridPonto
            // 
            this.gridPonto.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gridPonto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPonto.Location = new System.Drawing.Point(9, 161);
            this.gridPonto.Name = "gridPonto";
            this.gridPonto.ReadOnly = true;
            this.gridPonto.Size = new System.Drawing.Size(499, 305);
            this.gridPonto.TabIndex = 8;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(269, 131);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(59, 131);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(148, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(242, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "À:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "De:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Colaborador";
            // 
            // cBoxColaborador
            // 
            this.cBoxColaborador.FormattingEnabled = true;
            this.cBoxColaborador.Location = new System.Drawing.Point(135, 88);
            this.cBoxColaborador.Name = "cBoxColaborador";
            this.cBoxColaborador.Size = new System.Drawing.Size(282, 21);
            this.cBoxColaborador.TabIndex = 2;
            this.cBoxColaborador.SelectedIndexChanged += new System.EventHandler(this.cBoxColaborador_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empresa";
            // 
            // cBoxEmpresa
            // 
            this.cBoxEmpresa.FormattingEnabled = true;
            this.cBoxEmpresa.Location = new System.Drawing.Point(131, 43);
            this.cBoxEmpresa.Name = "cBoxEmpresa";
            this.cBoxEmpresa.Size = new System.Drawing.Size(377, 21);
            this.cBoxEmpresa.TabIndex = 0;
            this.cBoxEmpresa.SelectedIndexChanged += new System.EventHandler(this.cBoxEmpresa_SelectedIndexChanged);
            // 
            // tblempresaBindingSource2
            // 
            this.tblempresaBindingSource2.DataMember = "tbl_empresa";
            // 
            // tblempresaBindingSource
            // 
            this.tblempresaBindingSource.DataMember = "tbl_empresa";
            // 
            // tblempresaBindingSource1
            // 
            this.tblempresaBindingSource1.DataMember = "tbl_empresa";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.Location = new System.Drawing.Point(433, 130);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 9;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 543);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPendentes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblempresaBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridPonto;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxColaborador;
        private System.Windows.Forms.Button btnJustificar;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCnpj;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblCadCnpj;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCpf;
        public System.Windows.Forms.TextBox txtCpf;
        public System.Windows.Forms.ComboBox cBoxEmpresa;
        private System.Windows.Forms.BindingSource tblempresaBindingSource;
        private System.Windows.Forms.BindingSource tblempresaBindingSource1;
        private System.Windows.Forms.Button btnAtualiza;
        private System.Windows.Forms.DataGridView gridPendentes;
        private System.Windows.Forms.BindingSource tblempresaBindingSource2;
        public System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtCnpjStatus;
        private System.Windows.Forms.Button btnFiltrar;
    }
}