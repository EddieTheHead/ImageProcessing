namespace ImageProcessing
{
    partial class LayerSeparationControl
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
            this.radioButtonLayerBlue = new System.Windows.Forms.RadioButton();
            this.radioButtonLayerGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonLayerRed = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonLayerBlue
            // 
            this.radioButtonLayerBlue.AutoSize = true;
            this.radioButtonLayerBlue.Location = new System.Drawing.Point(73, 103);
            this.radioButtonLayerBlue.Name = "radioButtonLayerBlue";
            this.radioButtonLayerBlue.Size = new System.Drawing.Size(46, 17);
            this.radioButtonLayerBlue.TabIndex = 7;
            this.radioButtonLayerBlue.TabStop = true;
            this.radioButtonLayerBlue.Text = "Blue";
            this.radioButtonLayerBlue.UseVisualStyleBackColor = true;
            // 
            // radioButtonLayerGreen
            // 
            this.radioButtonLayerGreen.AutoSize = true;
            this.radioButtonLayerGreen.Location = new System.Drawing.Point(73, 80);
            this.radioButtonLayerGreen.Name = "radioButtonLayerGreen";
            this.radioButtonLayerGreen.Size = new System.Drawing.Size(54, 17);
            this.radioButtonLayerGreen.TabIndex = 6;
            this.radioButtonLayerGreen.TabStop = true;
            this.radioButtonLayerGreen.Text = "Green";
            this.radioButtonLayerGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonLayerRed
            // 
            this.radioButtonLayerRed.AutoSize = true;
            this.radioButtonLayerRed.Location = new System.Drawing.Point(73, 57);
            this.radioButtonLayerRed.Name = "radioButtonLayerRed";
            this.radioButtonLayerRed.Size = new System.Drawing.Size(45, 17);
            this.radioButtonLayerRed.TabIndex = 5;
            this.radioButtonLayerRed.TabStop = true;
            this.radioButtonLayerRed.Text = "Red";
            this.radioButtonLayerRed.UseVisualStyleBackColor = true;
            // 
            // LayerSeparationControl
            // 
            this.Controls.Add(this.radioButtonLayerBlue);
            this.Controls.Add(this.radioButtonLayerGreen);
            this.Controls.Add(this.radioButtonLayerRed);
            this.Name = "LayerSeparationControl";
            this.Size = new System.Drawing.Size(220, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLayerBlue;
        private System.Windows.Forms.RadioButton radioButtonLayerGreen;
        private System.Windows.Forms.RadioButton radioButtonLayerRed;
    }
}
