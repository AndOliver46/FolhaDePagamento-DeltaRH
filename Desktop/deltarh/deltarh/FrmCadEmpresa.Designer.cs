
namespace deltarh
{
    partial class FrmCadEmpresa
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
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.txtRazaoSocial = new System.Windows.Forms.TextBox();
            this.txtCodId = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pgEndereco = new System.Windows.Forms.TabPage();
            this.pgContato = new System.Windows.Forms.TabPage();
            this.gridEndereco = new System.Windows.Forms.DataGridView();
            this.txtInscEstadual = new System.Windows.Forms.TextBox();
            this.txtInscMunicipal = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditarEnd = new System.Windows.Forms.Button();
            this.btnEditarContato = new System.Windows.Forms.Button();
            this.btnEditarDp = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.pgEndereco.SuspendLayout();
            this.pgContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEndereco)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCnpj
            // 
            this.txtCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnpj.Location = new System.Drawing.Point(148, 32);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(232, 24);
            this.txtCnpj.TabIndex = 0;
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Enabled = false;
            this.txtRazaoSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazaoSocial.Location = new System.Drawing.Point(148, 70);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Size = new System.Drawing.Size(341, 24);
            this.txtRazaoSocial.TabIndex = 2;
            // 
            // txtCodId
            // 
            this.txtCodId.Enabled = false;
            this.txtCodId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodId.Location = new System.Drawing.Point(688, 70);
            this.txtCodId.Name = "txtCodId";
            this.txtCodId.Size = new System.Drawing.Size(100, 24);
            this.txtCodId.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.pgEndereco);
            this.tabControl1.Controls.Add(this.pgContato);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 159);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 409);
            this.tabControl1.TabIndex = 3;
            // 
            // pgEndereco
            // 
            this.pgEndereco.BackColor = System.Drawing.Color.White;
            this.pgEndereco.Controls.Add(this.btnEditarEnd);
            this.pgEndereco.Controls.Add(this.gridEndereco);
            this.pgEndereco.Location = new System.Drawing.Point(4, 25);
            this.pgEndereco.Name = "pgEndereco";
            this.pgEndereco.Padding = new System.Windows.Forms.Padding(3);
            this.pgEndereco.Size = new System.Drawing.Size(768, 380);
            this.pgEndereco.TabIndex = 0;
            this.pgEndereco.Text = "Endereço";
            // 
            // pgContato
            // 
            this.pgContato.Controls.Add(this.btnEditarContato);
            this.pgContato.Controls.Add(this.dataGridView1);
            this.pgContato.Location = new System.Drawing.Point(4, 25);
            this.pgContato.Name = "pgContato";
            this.pgContato.Padding = new System.Windows.Forms.Padding(3);
            this.pgContato.Size = new System.Drawing.Size(768, 380);
            this.pgContato.TabIndex = 1;
            this.pgContato.Text = "Contato";
            this.pgContato.UseVisualStyleBackColor = true;
            // 
            // gridEndereco
            // 
            this.gridEndereco.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.gridEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEndereco.Location = new System.Drawing.Point(6, 49);
            this.gridEndereco.Name = "gridEndereco";
            this.gridEndereco.Size = new System.Drawing.Size(759, 325);
            this.gridEndereco.TabIndex = 4;
            // 
            // txtInscEstadual
            // 
            this.txtInscEstadual.Enabled = false;
            this.txtInscEstadual.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInscEstadual.Location = new System.Drawing.Point(148, 111);
            this.txtInscEstadual.Name = "txtInscEstadual";
            this.txtInscEstadual.Size = new System.Drawing.Size(232, 24);
            this.txtInscEstadual.TabIndex = 4;
            // 
            // txtInscMunicipal
            // 
            this.txtInscMunicipal.Enabled = false;
            this.txtInscMunicipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInscMunicipal.Location = new System.Drawing.Point(556, 111);
            this.txtInscMunicipal.Name = "txtInscMunicipal";
            this.txtInscMunicipal.Size = new System.Drawing.Size(232, 24);
            this.txtInscMunicipal.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEditarDp);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 380);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Departamento Pessoal";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 49);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(759, 325);
            this.dataGridView1.TabIndex = 6;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 49);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(759, 325);
            this.dataGridView2.TabIndex = 6;
            // 
            // lblCnpj
            // 
            this.lblCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnpj.Location = new System.Drawing.Point(22, 35);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(61, 23);
            this.lblCnpj.TabIndex = 6;
            this.lblCnpj.Text = "CNPJ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Razão Social";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Insc. Estadual";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(585, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Código ID";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Insc. Municipal";
            // 
            // btnEditarEnd
            // 
            this.btnEditarEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarEnd.Location = new System.Drawing.Point(690, 6);
            this.btnEditarEnd.Name = "btnEditarEnd";
            this.btnEditarEnd.Size = new System.Drawing.Size(75, 37);
            this.btnEditarEnd.TabIndex = 11;
            this.btnEditarEnd.Text = "Editar";
            this.btnEditarEnd.UseVisualStyleBackColor = true;
            this.btnEditarEnd.Click += new System.EventHandler(this.btnEditarEnd_Click);
            // 
            // btnEditarContato
            // 
            this.btnEditarContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarContato.Location = new System.Drawing.Point(690, 6);
            this.btnEditarContato.Name = "btnEditarContato";
            this.btnEditarContato.Size = new System.Drawing.Size(75, 37);
            this.btnEditarContato.TabIndex = 12;
            this.btnEditarContato.Text = "Editar";
            this.btnEditarContato.UseVisualStyleBackColor = true;
            // 
            // btnEditarDp
            // 
            this.btnEditarDp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarDp.Location = new System.Drawing.Point(690, 6);
            this.btnEditarDp.Name = "btnEditarDp";
            this.btnEditarDp.Size = new System.Drawing.Size(75, 37);
            this.btnEditarDp.TabIndex = 12;
            this.btnEditarDp.Text = "Editar";
            this.btnEditarDp.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Location = new System.Drawing.Point(414, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 30);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // FrmCadEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCnpj);
            this.Controls.Add(this.txtInscMunicipal);
            this.Controls.Add(this.txtInscEstadual);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtCodId);
            this.Controls.Add(this.txtRazaoSocial);
            this.Controls.Add(this.txtCnpj);
            this.Name = "FrmCadEmpresa";
            this.Text = "Cadastrar Empresa";
            this.tabControl1.ResumeLayout(false);
            this.pgEndereco.ResumeLayout(false);
            this.pgContato.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEndereco)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.TextBox txtRazaoSocial;
        private System.Windows.Forms.TextBox txtCodId;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pgEndereco;
        private System.Windows.Forms.DataGridView gridEndereco;
        private System.Windows.Forms.TabPage pgContato;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtInscEstadual;
        private System.Windows.Forms.TextBox txtInscMunicipal;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditarEnd;
        private System.Windows.Forms.Button btnEditarContato;
        private System.Windows.Forms.Button btnEditarDp;
        private System.Windows.Forms.Button btnBuscar;
    }
}