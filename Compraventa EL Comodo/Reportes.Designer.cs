namespace Compraventa_EL_Comodo
{
    partial class Reportes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empeñadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eMpeñosPorClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empeñosPorDiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirosPorClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirosPorDiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empeñadosToolStripMenuItem,
            this.retirosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empeñadosToolStripMenuItem
            // 
            this.empeñadosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eMpeñosPorClientesToolStripMenuItem,
            this.empeñosPorDiasToolStripMenuItem});
            this.empeñadosToolStripMenuItem.Name = "empeñadosToolStripMenuItem";
            this.empeñadosToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.empeñadosToolStripMenuItem.Text = "Empeñados";
            // 
            // eMpeñosPorClientesToolStripMenuItem
            // 
            this.eMpeñosPorClientesToolStripMenuItem.Name = "eMpeñosPorClientesToolStripMenuItem";
            this.eMpeñosPorClientesToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.eMpeñosPorClientesToolStripMenuItem.Text = "EMpeños por Clientes ";
            this.eMpeñosPorClientesToolStripMenuItem.Click += new System.EventHandler(this.eMpeñosPorClientesToolStripMenuItem_Click);
            // 
            // empeñosPorDiasToolStripMenuItem
            // 
            this.empeñosPorDiasToolStripMenuItem.Name = "empeñosPorDiasToolStripMenuItem";
            this.empeñosPorDiasToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.empeñosPorDiasToolStripMenuItem.Text = "Empeños por dias ";
            // 
            // retirosToolStripMenuItem
            // 
            this.retirosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retirosPorClientesToolStripMenuItem,
            this.retirosPorDiasToolStripMenuItem});
            this.retirosToolStripMenuItem.Name = "retirosToolStripMenuItem";
            this.retirosToolStripMenuItem.Size = new System.Drawing.Size(88, 30);
            this.retirosToolStripMenuItem.Text = "Retiro";
            // 
            // retirosPorClientesToolStripMenuItem
            // 
            this.retirosPorClientesToolStripMenuItem.Name = "retirosPorClientesToolStripMenuItem";
            this.retirosPorClientesToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.retirosPorClientesToolStripMenuItem.Text = "Retiros por clientes";
            // 
            // retirosPorDiasToolStripMenuItem
            // 
            this.retirosPorDiasToolStripMenuItem.Name = "retirosPorDiasToolStripMenuItem";
            this.retirosPorDiasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.retirosPorDiasToolStripMenuItem.Text = "Retiros por dias ";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empeñadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eMpeñosPorClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem empeñosPorDiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirosPorClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirosPorDiasToolStripMenuItem;
    }
}