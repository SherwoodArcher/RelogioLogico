namespace RelogioLogico
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.iniciarControle = new System.Windows.Forms.Button();
            this.pausarMovimento = new System.Windows.Forms.Button();
            this.reiniciarMovimento = new System.Windows.Forms.Button();
            this.liberarMovimento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iniciarControle
            // 
            this.iniciarControle.Location = new System.Drawing.Point(3, 4);
            this.iniciarControle.Name = "iniciarControle";
            this.iniciarControle.Size = new System.Drawing.Size(296, 23);
            this.iniciarControle.TabIndex = 0;
            this.iniciarControle.Text = "Iniciar Controle";
            this.iniciarControle.UseVisualStyleBackColor = true;
            this.iniciarControle.Click += new System.EventHandler(this.button1_Click);
            // 
            // pausarMovimento
            // 
            this.pausarMovimento.Location = new System.Drawing.Point(3, 33);
            this.pausarMovimento.Name = "pausarMovimento";
            this.pausarMovimento.Size = new System.Drawing.Size(296, 23);
            this.pausarMovimento.TabIndex = 1;
            this.pausarMovimento.Text = "Pausar Movimento";
            this.pausarMovimento.UseVisualStyleBackColor = true;
            this.pausarMovimento.Click += new System.EventHandler(this.pausarMovimento_Click);
            // 
            // reiniciarMovimento
            // 
            this.reiniciarMovimento.Location = new System.Drawing.Point(3, 62);
            this.reiniciarMovimento.Name = "reiniciarMovimento";
            this.reiniciarMovimento.Size = new System.Drawing.Size(296, 23);
            this.reiniciarMovimento.TabIndex = 2;
            this.reiniciarMovimento.Text = "Reiniciar Movimento";
            this.reiniciarMovimento.UseVisualStyleBackColor = true;
            this.reiniciarMovimento.Click += new System.EventHandler(this.reiniciarMovimento_Click);
            // 
            // liberarMovimento
            // 
            this.liberarMovimento.Location = new System.Drawing.Point(3, 91);
            this.liberarMovimento.Name = "liberarMovimento";
            this.liberarMovimento.Size = new System.Drawing.Size(296, 23);
            this.liberarMovimento.TabIndex = 3;
            this.liberarMovimento.Text = "Liberar Controle";
            this.liberarMovimento.UseVisualStyleBackColor = true;
            this.liberarMovimento.Click += new System.EventHandler(this.liberarMovimento_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 119);
            this.Controls.Add(this.liberarMovimento);
            this.Controls.Add(this.reiniciarMovimento);
            this.Controls.Add(this.pausarMovimento);
            this.Controls.Add(this.iniciarControle);
            this.Name = "Form1";
            this.Text = "Relógio Lógico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button iniciarControle;
        private System.Windows.Forms.Button pausarMovimento;
        private System.Windows.Forms.Button reiniciarMovimento;
        private System.Windows.Forms.Button liberarMovimento;
    }
}

