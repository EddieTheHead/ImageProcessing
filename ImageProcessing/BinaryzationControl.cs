using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class BinaryzationControl : UserControl, IGraphicEffect
    {
        public BinaryzationControl()
        {
            InitializeComponent();
        }
        public Image applyEffect(Image img)
        {
            return ImageProcessingServices.Binaryze(img, trackBarBinTreshold.Value);
        }
    }
}
