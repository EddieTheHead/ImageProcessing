using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ColorCorrectionControl : UserControl, IGraphicEffect
    {
        public ColorCorrectionControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            float r = ((float)trackBarCorrectR.Value - 50) * (float)0.01;
            float g = ((float)trackBarCorrectG.Value - 50) * (float)0.01;
            float b = ((float)trackBarCorrectB.Value - 50) * (float)0.01;

            return ImageProcessingServices.bumpColors(source,r,g,b);
        }
    }
}
