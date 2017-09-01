namespace ImageProcessing
{
    partial class BinaryzationControl
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
            this.labelBinarization = new System.Windows.Forms.Label();
            this.trackBarBinTreshold = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinTreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBinarization
            // 
            this.labelBinarization.AutoSize = true;
            this.labelBinarization.Location = new System.Drawing.Point(78, 50);
            this.labelBinarization.Name = "labelBinarization";
            this.labelBinarization.Size = new System.Drawing.Size(48, 13);
            this.labelBinarization.TabIndex = 31;
            this.labelBinarization.Text = "Treshold";
            // 
            // trackBarBinTreshold
            // 
            this.trackBarBinTreshold.Location = new System.Drawing.Point(3, 77);
            this.trackBarBinTreshold.Maximum = 768;
            this.trackBarBinTreshold.Name = "trackBarBinTreshold";
            this.trackBarBinTreshold.Size = new System.Drawing.Size(197, 45);
            this.trackBarBinTreshold.TabIndex = 30;
            // 
            // BinaryzationControl
            // 
            this.Controls.Add(this.labelBinarization);
            this.Controls.Add(this.trackBarBinTreshold);
            this.Name = "BinaryzationControl";
            this.Size = new System.Drawing.Size(220, 200);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBinTreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBinarization;
        private System.Windows.Forms.TrackBar trackBarBinTreshold;
    }
}
