using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class NegativeControl : UserControl, IGraphicEffect
    {
        public NegativeControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            return ImageProcessingServices.Negate(source);
        }
    }
}
