using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class SepiaControl : UserControl, IGraphicEffect
    {
        public SepiaControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            return ImageProcessingServices.ToSepia(source);
        }
    }
}
