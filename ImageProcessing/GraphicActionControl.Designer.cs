namespace ImageProcessing
{
    partial class GraphicActionControl
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
            this.comboBoxEffect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRight = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.buttonShowResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxEffect
            // 
            this.comboBoxEffect.FormattingEnabled = true;
            this.comboBoxEffect.Location = new System.Drawing.Point(6, 23);
            this.comboBoxEffect.Name = "comboBoxEffect";
            this.comboBoxEffect.Size = new System.Drawing.Size(265, 21);
            this.comboBoxEffect.TabIndex = 0;
            this.comboBoxEffect.SelectedIndexChanged += new System.EventHandler(this.comboBoxEffect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = ">";
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(258, 116);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(13, 13);
            this.labelRight.TabIndex = 2;
            this.labelRight.Text = ">";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(124, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Title";
            // 
            // panelContainer
            // 
            this.panelContainer.Location = new System.Drawing.Point(22, 50);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(230, 208);
            this.panelContainer.TabIndex = 4;
            // 
            // buttonShowResult
            // 
            this.buttonShowResult.Location = new System.Drawing.Point(211, -1);
            this.buttonShowResult.Name = "buttonShowResult";
            this.buttonShowResult.Size = new System.Drawing.Size(75, 23);
            this.buttonShowResult.TabIndex = 5;
            this.buttonShowResult.Text = "Output";
            this.buttonShowResult.UseVisualStyleBackColor = true;
            this.buttonShowResult.Click += new System.EventHandler(this.buttonShowResult_Click);
            // 
            // GraphicActionControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonShowResult);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelRight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxEffect);
            this.Name = "GraphicActionControl";
            this.Size = new System.Drawing.Size(285, 261);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEffect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Button buttonShowResult;
    }
}
