namespace ImageProcessing
{
    partial class SepiaControl
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
            this.labelSepia = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSepia
            // 
            this.labelSepia.AutoSize = true;
            this.labelSepia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSepia.Location = new System.Drawing.Point(77, 92);
            this.labelSepia.Name = "labelSepia";
            this.labelSepia.Size = new System.Drawing.Size(86, 24);
            this.labelSepia.TabIndex = 1;
            this.labelSepia.Text = "To Sepia";
            // 
            // SepiaControl
            // 
            this.Controls.Add(this.labelSepia);
            this.Name = "SepiaControl";
            this.Size = new System.Drawing.Size(245, 225);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSepia;
    }
}
