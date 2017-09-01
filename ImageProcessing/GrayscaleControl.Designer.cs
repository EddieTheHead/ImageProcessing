namespace ImageProcessing
{
    partial class GrayscaleControl
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
            this.comboBoxPreDefGrayScale = new System.Windows.Forms.ComboBox();
            this.labelBFactor = new System.Windows.Forms.Label();
            this.labelGFactor = new System.Windows.Forms.Label();
            this.labelRFactor = new System.Windows.Forms.Label();
            this.numericUpDownbFactor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGFactor = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRFactor = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownbFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRFactor)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPreDefGrayScale
            // 
            this.comboBoxPreDefGrayScale.FormattingEnabled = true;
            this.comboBoxPreDefGrayScale.Items.AddRange(new object[] {
            "YUV",
            "CIE",
            "AVG"});
            this.comboBoxPreDefGrayScale.Location = new System.Drawing.Point(40, 37);
            this.comboBoxPreDefGrayScale.Name = "comboBoxPreDefGrayScale";
            this.comboBoxPreDefGrayScale.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPreDefGrayScale.TabIndex = 29;
            this.comboBoxPreDefGrayScale.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreDefGrayScale_SelectedIndexChanged);
            // 
            // labelBFactor
            // 
            this.labelBFactor.AutoSize = true;
            this.labelBFactor.Location = new System.Drawing.Point(68, 129);
            this.labelBFactor.Name = "labelBFactor";
            this.labelBFactor.Size = new System.Drawing.Size(17, 13);
            this.labelBFactor.TabIndex = 28;
            this.labelBFactor.Text = "B:";
            // 
            // labelGFactor
            // 
            this.labelGFactor.AutoSize = true;
            this.labelGFactor.Location = new System.Drawing.Point(68, 102);
            this.labelGFactor.Name = "labelGFactor";
            this.labelGFactor.Size = new System.Drawing.Size(18, 13);
            this.labelGFactor.TabIndex = 27;
            this.labelGFactor.Text = "G:";
            // 
            // labelRFactor
            // 
            this.labelRFactor.AutoSize = true;
            this.labelRFactor.Location = new System.Drawing.Point(69, 74);
            this.labelRFactor.Name = "labelRFactor";
            this.labelRFactor.Size = new System.Drawing.Size(18, 13);
            this.labelRFactor.TabIndex = 26;
            this.labelRFactor.Text = "R:";
            // 
            // numericUpDownbFactor
            // 
            this.numericUpDownbFactor.DecimalPlaces = 2;
            this.numericUpDownbFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownbFactor.Location = new System.Drawing.Point(108, 127);
            this.numericUpDownbFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownbFactor.Name = "numericUpDownbFactor";
            this.numericUpDownbFactor.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownbFactor.TabIndex = 25;
            // 
            // numericUpDownGFactor
            // 
            this.numericUpDownGFactor.DecimalPlaces = 2;
            this.numericUpDownGFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownGFactor.Location = new System.Drawing.Point(108, 100);
            this.numericUpDownGFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGFactor.Name = "numericUpDownGFactor";
            this.numericUpDownGFactor.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownGFactor.TabIndex = 24;
            // 
            // numericUpDownRFactor
            // 
            this.numericUpDownRFactor.DecimalPlaces = 2;
            this.numericUpDownRFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownRFactor.Location = new System.Drawing.Point(108, 74);
            this.numericUpDownRFactor.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRFactor.Name = "numericUpDownRFactor";
            this.numericUpDownRFactor.Size = new System.Drawing.Size(53, 20);
            this.numericUpDownRFactor.TabIndex = 23;
            // 
            // GrayscaleControl
            // 
            this.Controls.Add(this.comboBoxPreDefGrayScale);
            this.Controls.Add(this.labelBFactor);
            this.Controls.Add(this.labelGFactor);
            this.Controls.Add(this.labelRFactor);
            this.Controls.Add(this.numericUpDownbFactor);
            this.Controls.Add(this.numericUpDownGFactor);
            this.Controls.Add(this.numericUpDownRFactor);
            this.Name = "GrayscaleControl";
            this.Size = new System.Drawing.Size(220, 200);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownbFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRFactor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPreDefGrayScale;
        private System.Windows.Forms.Label labelBFactor;
        private System.Windows.Forms.Label labelGFactor;
        private System.Windows.Forms.Label labelRFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownbFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownGFactor;
        private System.Windows.Forms.NumericUpDown numericUpDownRFactor;
    }
}
