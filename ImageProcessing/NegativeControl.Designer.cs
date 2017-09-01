namespace ImageProcessing
{
    partial class NegativeControl
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
            this.labelNeg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNeg
            // 
            this.labelNeg.AutoSize = true;
            this.labelNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelNeg.Location = new System.Drawing.Point(51, 82);
            this.labelNeg.Name = "labelNeg";
            this.labelNeg.Size = new System.Drawing.Size(112, 24);
            this.labelNeg.TabIndex = 0;
            this.labelNeg.Text = "To Negative";
            // 
            // NegativeControl
            // 
            this.Controls.Add(this.labelNeg);
            this.Name = "NegativeControl";
            this.Size = new System.Drawing.Size(220, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNeg;
    }
}
