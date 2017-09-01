namespace ImageProcessing
{
    partial class ColorCorrectionControl
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackBarCorrectR = new System.Windows.Forms.TrackBar();
            this.labelCorrectR = new System.Windows.Forms.Label();
            this.trackBarCorrectG = new System.Windows.Forms.TrackBar();
            this.labelCorrectG = new System.Windows.Forms.Label();
            this.trackBarCorrectB = new System.Windows.Forms.TrackBar();
            this.labelCorrectB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectB)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarCorrectR
            // 
            this.trackBarCorrectR.Location = new System.Drawing.Point(78, 20);
            this.trackBarCorrectR.Maximum = 100;
            this.trackBarCorrectR.Name = "trackBarCorrectR";
            this.trackBarCorrectR.Size = new System.Drawing.Size(104, 45);
            this.trackBarCorrectR.TabIndex = 0;
            // 
            // labelCorrectR
            // 
            this.labelCorrectR.AutoSize = true;
            this.labelCorrectR.Location = new System.Drawing.Point(26, 20);
            this.labelCorrectR.Name = "labelCorrectR";
            this.labelCorrectR.Size = new System.Drawing.Size(18, 13);
            this.labelCorrectR.TabIndex = 23;
            this.labelCorrectR.Text = "R:";
            // 
            // trackBarCorrectG
            // 
            this.trackBarCorrectG.Location = new System.Drawing.Point(78, 64);
            this.trackBarCorrectG.Maximum = 100;
            this.trackBarCorrectG.Name = "trackBarCorrectG";
            this.trackBarCorrectG.Size = new System.Drawing.Size(104, 45);
            this.trackBarCorrectG.TabIndex = 1;
            // 
            // labelCorrectG
            // 
            this.labelCorrectG.AutoSize = true;
            this.labelCorrectG.Location = new System.Drawing.Point(26, 64);
            this.labelCorrectG.Name = "labelCorrectG";
            this.labelCorrectG.Size = new System.Drawing.Size(18, 13);
            this.labelCorrectG.TabIndex = 24;
            this.labelCorrectG.Text = "G:";
            // 
            // trackBarCorrectB
            // 
            this.trackBarCorrectB.Location = new System.Drawing.Point(78, 115);
            this.trackBarCorrectB.Maximum = 100;
            this.trackBarCorrectB.Name = "trackBarCorrectB";
            this.trackBarCorrectB.Size = new System.Drawing.Size(104, 45);
            this.trackBarCorrectB.TabIndex = 2;
            // 
            // labelCorrectB
            // 
            this.labelCorrectB.AutoSize = true;
            this.labelCorrectB.Location = new System.Drawing.Point(26, 115);
            this.labelCorrectB.Name = "labelCorrectB";
            this.labelCorrectB.Size = new System.Drawing.Size(17, 13);
            this.labelCorrectB.TabIndex = 25;
            this.labelCorrectB.Text = "B:";
            // 
            // ColorCorrectionControl
            // 
            this.Controls.Add(this.labelCorrectB);
            this.Controls.Add(this.trackBarCorrectG);
            this.Controls.Add(this.trackBarCorrectB);
            this.Controls.Add(this.trackBarCorrectR);
            this.Controls.Add(this.labelCorrectG);
            this.Controls.Add(this.labelCorrectR);
            this.Name = "ColorCorrectionControl";
            this.Size = new System.Drawing.Size(220, 200);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCorrectB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarCorrectR;
        private System.Windows.Forms.Label labelCorrectR;
        private System.Windows.Forms.TrackBar trackBarCorrectG;
        private System.Windows.Forms.Label labelCorrectG;
        private System.Windows.Forms.TrackBar trackBarCorrectB;
        private System.Windows.Forms.Label labelCorrectB;
    }
}
