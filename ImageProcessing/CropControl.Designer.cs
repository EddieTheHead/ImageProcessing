namespace ImageProcessing
{
    partial class CropControl
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
            this.labelCropY = new System.Windows.Forms.Label();
            this.labelCropX = new System.Windows.Forms.Label();
            this.maskedTextBoxCropY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCropX = new System.Windows.Forms.MaskedTextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.maskedTextBoxCropHeight = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCropWidth = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // labelCropY
            // 
            this.labelCropY.AutoSize = true;
            this.labelCropY.Location = new System.Drawing.Point(48, 75);
            this.labelCropY.Name = "labelCropY";
            this.labelCropY.Size = new System.Drawing.Size(14, 13);
            this.labelCropY.TabIndex = 10;
            this.labelCropY.Text = "Y";
            // 
            // labelCropX
            // 
            this.labelCropX.AutoSize = true;
            this.labelCropX.Location = new System.Drawing.Point(48, 49);
            this.labelCropX.Name = "labelCropX";
            this.labelCropX.Size = new System.Drawing.Size(14, 13);
            this.labelCropX.TabIndex = 9;
            this.labelCropX.Text = "X";
            // 
            // maskedTextBoxCropY
            // 
            this.maskedTextBoxCropY.Location = new System.Drawing.Point(94, 72);
            this.maskedTextBoxCropY.Mask = "99999999";
            this.maskedTextBoxCropY.Name = "maskedTextBoxCropY";
            this.maskedTextBoxCropY.Size = new System.Drawing.Size(55, 20);
            this.maskedTextBoxCropY.TabIndex = 8;
            // 
            // maskedTextBoxCropX
            // 
            this.maskedTextBoxCropX.Location = new System.Drawing.Point(94, 49);
            this.maskedTextBoxCropX.Mask = "99999999";
            this.maskedTextBoxCropX.Name = "maskedTextBoxCropX";
            this.maskedTextBoxCropX.Size = new System.Drawing.Size(55, 20);
            this.maskedTextBoxCropX.TabIndex = 7;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(48, 123);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 6;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(48, 97);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 5;
            this.labelWidth.Text = "Width";
            // 
            // maskedTextBoxCropHeight
            // 
            this.maskedTextBoxCropHeight.Location = new System.Drawing.Point(94, 120);
            this.maskedTextBoxCropHeight.Mask = "99999999";
            this.maskedTextBoxCropHeight.Name = "maskedTextBoxCropHeight";
            this.maskedTextBoxCropHeight.Size = new System.Drawing.Size(55, 20);
            this.maskedTextBoxCropHeight.TabIndex = 4;
            // 
            // maskedTextBoxCropWidth
            // 
            this.maskedTextBoxCropWidth.Location = new System.Drawing.Point(94, 97);
            this.maskedTextBoxCropWidth.Mask = "99999999";
            this.maskedTextBoxCropWidth.Name = "maskedTextBoxCropWidth";
            this.maskedTextBoxCropWidth.Size = new System.Drawing.Size(55, 20);
            this.maskedTextBoxCropWidth.TabIndex = 3;
            // 
            // CropControl
            // 
            this.Controls.Add(this.labelCropY);
            this.Controls.Add(this.labelCropX);
            this.Controls.Add(this.maskedTextBoxCropY);
            this.Controls.Add(this.maskedTextBoxCropWidth);
            this.Controls.Add(this.maskedTextBoxCropX);
            this.Controls.Add(this.maskedTextBoxCropHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Name = "CropControl";
            this.Size = new System.Drawing.Size(220, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCropY;
        private System.Windows.Forms.Label labelCropX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCropY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCropX;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCropHeight;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCropWidth;
    }
}
