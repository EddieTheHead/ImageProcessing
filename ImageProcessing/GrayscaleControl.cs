using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class GrayscaleControl : UserControl, IGraphicEffect
    {
        public GrayscaleControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            float rFactor = (float)numericUpDownRFactor.Value;
            float gFactor = (float)numericUpDownGFactor.Value;
            float bFactor = (float)numericUpDownbFactor.Value;

            return ImageProcessingServices.convertToGrayscale(source, rFactor,gFactor,bFactor);
        }

        private void comboBoxPreDefGrayScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPreDefGrayScale.SelectedIndex)
            {
                case 0:
                    numericUpDownRFactor.Value = (decimal)0.244f;
                    numericUpDownGFactor.Value = (decimal)0.587f;
                    numericUpDownbFactor.Value = (decimal)0.114f;
                    break;
                case 1:
                    numericUpDownRFactor.Value = (decimal)0.11f;
                    numericUpDownGFactor.Value = (decimal)0.59f;
                    numericUpDownbFactor.Value = (decimal)0.3f;
                    break;
                case 2:
                    numericUpDownRFactor.Value = (decimal)0.33f;
                    numericUpDownGFactor.Value = (decimal)0.33f;
                    numericUpDownbFactor.Value = (decimal)0.33f;
                    break;
                default:
                    break;
            }
        }
    }
}
