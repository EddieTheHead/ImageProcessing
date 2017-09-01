using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class RotationControl : UserControl, IGraphicEffect
    {
        public RotationControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            return ImageProcessingServices.Rotate(source, trackBarAngle.Value);
        }
    }
}
