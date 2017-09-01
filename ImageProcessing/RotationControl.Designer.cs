namespace ImageProcessing
{
    partial class RotationControl
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
            this.trackBarAngle = new System.Windows.Forms.TrackBar();
            this.labelRotation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.Location = new System.Drawing.Point(10, 86);
            this.trackBarAngle.Maximum = 360;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Size = new System.Drawing.Size(200, 45);
            this.trackBarAngle.TabIndex = 23;
            // 
            // labelRotation
            // 
            this.labelRotation.AutoSize = true;
            this.labelRotation.Location = new System.Drawing.Point(12, 70);
            this.labelRotation.Name = "labelRotation";
            this.labelRotation.Size = new System.Drawing.Size(34, 13);
            this.labelRotation.TabIndex = 22;
            this.labelRotation.Text = "Angle";
            // 
            // RotationControl
            // 
            this.Controls.Add(this.trackBarAngle);
            this.Controls.Add(this.labelRotation);
            this.Name = "RotationControl";
            this.Size = new System.Drawing.Size(220, 200);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarAngle;
        private System.Windows.Forms.Label labelRotation;
    }
}
