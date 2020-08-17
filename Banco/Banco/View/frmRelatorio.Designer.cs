namespace Banco.View
{
    partial class frmRelatorio
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
            this.lstSaldos = new System.Windows.Forms.ListBox();
            this.btnMostrarSaldosMaior = new System.Windows.Forms.Button();
            this.btnAntigas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSaldos
            // 
            this.lstSaldos.FormattingEnabled = true;
            this.lstSaldos.Location = new System.Drawing.Point(12, 12);
            this.lstSaldos.Name = "lstSaldos";
            this.lstSaldos.Size = new System.Drawing.Size(203, 108);
            this.lstSaldos.TabIndex = 0;
            // 
            // btnMostrarSaldosMaior
            // 
            this.btnMostrarSaldosMaior.Location = new System.Drawing.Point(12, 126);
            this.btnMostrarSaldosMaior.Name = "btnMostrarSaldosMaior";
            this.btnMostrarSaldosMaior.Size = new System.Drawing.Size(203, 23);
            this.btnMostrarSaldosMaior.TabIndex = 1;
            this.btnMostrarSaldosMaior.Text = "Saldo Maior que 500";
            this.btnMostrarSaldosMaior.UseVisualStyleBackColor = true;
            this.btnMostrarSaldosMaior.Click += new System.EventHandler(this.btnMostrarSaldosMaior_Click);
            // 
            // btnAntigas
            // 
            this.btnAntigas.Location = new System.Drawing.Point(12, 155);
            this.btnAntigas.Name = "btnAntigas";
            this.btnAntigas.Size = new System.Drawing.Size(203, 23);
            this.btnAntigas.TabIndex = 2;
            this.btnAntigas.Text = "Contas Antigas";
            this.btnAntigas.UseVisualStyleBackColor = true;
            this.btnAntigas.Click += new System.EventHandler(this.btnAntigas_Click);
            // 
            // frmRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 186);
            this.Controls.Add(this.btnAntigas);
            this.Controls.Add(this.btnMostrarSaldosMaior);
            this.Controls.Add(this.lstSaldos);
            this.Name = "frmRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório";
            this.Load += new System.EventHandler(this.frmRelatorio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSaldos;
        private System.Windows.Forms.Button btnMostrarSaldosMaior;
        private System.Windows.Forms.Button btnAntigas;
    }
}