using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class GammaControl : UserControl, IGraphicEffect
    {
        public GammaControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            float gamma = (float)(numericUpDownGamma.Value);
            return ImageProcessingServices.GammaTransform(source,gamma);
        }
    }
}
