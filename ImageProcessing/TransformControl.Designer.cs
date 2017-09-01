namespace ImageProcessing
{
    partial class TransformControl
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
            this.labelTransformations = new System.Windows.Forms.Label();
            this.comboBoxTransf = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelTransformations
            // 
            this.labelTransformations.AutoSize = true;
            this.labelTransformations.Location = new System.Drawing.Point(72, 64);
            this.labelTransformations.Name = "labelTransformations";
            this.labelTransformations.Size = new System.Drawing.Size(82, 13);
            this.labelTransformations.TabIndex = 19;
            this.labelTransformations.Text = "Transformations";
            // 
            // comboBoxTransf
            // 
            this.comboBoxTransf.FormattingEnabled = true;
            this.comboBoxTransf.Location = new System.Drawing.Point(50, 80);
            this.comboBoxTransf.Name = "comboBoxTransf";
            this.comboBoxTransf.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTransf.TabIndex = 18;
            // 
            // TransformControl
            // 
            this.Controls.Add(this.labelTransformations);
            this.Controls.Add(this.comboBoxTransf);
            this.Name = "TransformControl";
            this.Size = new System.Drawing.Size(220, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTransformations;
        private System.Windows.Forms.ComboBox comboBoxTransf;
    }
}
