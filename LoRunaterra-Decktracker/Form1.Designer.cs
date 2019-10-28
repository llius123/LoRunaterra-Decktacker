namespace LoRunaterra_Decktracker
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
            this.panel_botones = new System.Windows.Forms.Panel();
            this.btn_historial = new System.Windows.Forms.Button();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.panel_contendor = new System.Windows.Forms.Panel();
            this.panel_status = new System.Windows.Forms.Panel();
            this.label_status = new System.Windows.Forms.Label();
            this.panel_botones.SuspendLayout();
            this.panel_status.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_botones
            // 
            this.panel_botones.Controls.Add(this.btn_historial);
            this.panel_botones.Controls.Add(this.btn_inicio);
            this.panel_botones.Location = new System.Drawing.Point(5, 0);
            this.panel_botones.Name = "panel_botones";
            this.panel_botones.Size = new System.Drawing.Size(184, 413);
            this.panel_botones.TabIndex = 0;
            // 
            // btn_historial
            // 
            this.btn_historial.Location = new System.Drawing.Point(13, 62);
            this.btn_historial.Name = "btn_historial";
            this.btn_historial.Size = new System.Drawing.Size(161, 43);
            this.btn_historial.TabIndex = 1;
            this.btn_historial.Text = "Historial";
            this.btn_historial.UseVisualStyleBackColor = true;
            this.btn_historial.Click += new System.EventHandler(this.btn_historial_Click);
            // 
            // btn_inicio
            // 
            this.btn_inicio.Location = new System.Drawing.Point(14, 13);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(161, 43);
            this.btn_inicio.TabIndex = 0;
            this.btn_inicio.Text = "Inicio";
            this.btn_inicio.UseVisualStyleBackColor = true;
            this.btn_inicio.Click += new System.EventHandler(this.btn_inicio_Click);
            // 
            // panel_contendor
            // 
            this.panel_contendor.Location = new System.Drawing.Point(196, 0);
            this.panel_contendor.Name = "panel_contendor";
            this.panel_contendor.Size = new System.Drawing.Size(592, 451);
            this.panel_contendor.TabIndex = 1;
            // 
            // panel_status
            // 
            this.panel_status.Controls.Add(this.label_status);
            this.panel_status.Location = new System.Drawing.Point(5, 420);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(184, 31);
            this.panel_status.TabIndex = 2;
            // 
            // label_status
            // 
            this.label_status.Location = new System.Drawing.Point(13, 3);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(170, 22);
            this.label_status.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.panel_status);
            this.Controls.Add(this.panel_contendor);
            this.Controls.Add(this.panel_botones);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_botones.ResumeLayout(false);
            this.panel_status.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_botones;
        private System.Windows.Forms.Button btn_historial;
        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.Panel panel_contendor;
        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Label label_status;
    }
}

