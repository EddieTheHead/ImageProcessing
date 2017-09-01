using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageProcessing
{
    public partial class FFTConvolutionControl : UserControl, IGraphicEffect
    {
        public FFTConvolutionControl()
        {
            InitializeComponent();
        }


        public Image applyEffect(Image source)
        {
            int[,] mask = new int[3, 3];
            mask[0, 0] = Convert.ToInt32(textBoxMask3x3X1.Text);
            mask[0, 1] = Convert.ToInt32(textBoxMask3x3X2.Text);
            mask[0, 2] = Convert.ToInt32(textBoxMask3x3X3.Text);
            mask[1, 0] = Convert.ToInt32(textBoxMask3x3Y1.Text);
            mask[1, 1] = Convert.ToInt32(textBoxMask3x3Y2.Text);
            mask[1, 2] = Convert.ToInt32(textBoxMask3x3Y3.Text);
            mask[2, 0] = Convert.ToInt32(textBoxMask3x3Z1.Text);
            mask[2, 1] = Convert.ToInt32(textBoxMask3x3Z2.Text);
            mask[2, 2] = Convert.ToInt32(textBoxMask3x3Z3.Text);

            return ImageProcessingServices.fftConvolution(source, mask);
        }
    }
}
