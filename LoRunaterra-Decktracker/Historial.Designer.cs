namespace LoRunaterra_Decktracker
{
    partial class Historial
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
            this.listView_historial_partidos = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView_historial_partidos
            // 
            this.listView_historial_partidos.HideSelection = false;
            this.listView_historial_partidos.Location = new System.Drawing.Point(0, 0);
            this.listView_historial_partidos.Name = "listView_historial_partidos";
            this.listView_historial_partidos.Size = new System.Drawing.Size(802, 451);
            this.listView_historial_partidos.TabIndex = 0;
            this.listView_historial_partidos.UseCompatibleStateImageBehavior = false;
            // 
            // Historial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView_historial_partidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Historial";
            this.Text = "Historial";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_historial_partidos;
    }
}