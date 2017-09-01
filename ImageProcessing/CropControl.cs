using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class CropControl : UserControl, IGraphicEffect
    {
        public CropControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            Rectangle cropRect = new Rectangle(Int32.Parse(maskedTextBoxCropX.Text), Int32.Parse(maskedTextBoxCropY.Text), Int32.Parse(maskedTextBoxCropWidth.Text), Int32.Parse(maskedTextBoxCropHeight.Text));
            return ImageProcessingServices.Crop(source, cropRect);
        }
    }
}
