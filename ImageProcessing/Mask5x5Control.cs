using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Mask5x5Control : UserControl, IGraphicEffect
    {
        public Mask5x5Control()
        {
            InitializeComponent();
        }


        public Image applyEffect(Image source)
        {
            int[,] mask = new int[5, 5];
            mask[0, 0] = Convert.ToInt32(textBoxMask5x5A1.Text);
            mask[0, 1] = Convert.ToInt32(textBoxMask5x5A2.Text);
            mask[0, 2] = Convert.ToInt32(textBoxMask5x5A3.Text);
            mask[0, 3] = Convert.ToInt32(textBoxMask5x5A4.Text);
            mask[0, 4] = Convert.ToInt32(textBoxMask5x5A5.Text);

            mask[1, 0] = Convert.ToInt32(textBoxMask5x5B1.Text);
            mask[1, 1] = Convert.ToInt32(textBoxMask5x5B2.Text);
            mask[1, 2] = Convert.ToInt32(textBoxMask5x5B3.Text);
            mask[1, 3] = Convert.ToInt32(textBoxMask5x5B4.Text);
            mask[1, 4] = Convert.ToInt32(textBoxMask5x5B5.Text);

            mask[2, 0] = Convert.ToInt32(textBoxMask5x5C1.Text);
            mask[2, 1] = Convert.ToInt32(textBoxMask5x5C2.Text);
            mask[2, 2] = Convert.ToInt32(textBoxMask5x5C3.Text);
            mask[2, 3] = Convert.ToInt32(textBoxMask5x5C4.Text);
            mask[2, 4] = Convert.ToInt32(textBoxMask5x5C5.Text);

            mask[3, 0] = Convert.ToInt32(textBoxMask5x5D1.Text);
            mask[3, 1] = Convert.ToInt32(textBoxMask5x5D2.Text);
            mask[3, 2] = Convert.ToInt32(textBoxMask5x5D3.Text);
            mask[3, 3] = Convert.ToInt32(textBoxMask5x5D4.Text);
            mask[3, 4] = Convert.ToInt32(textBoxMask5x5D5.Text);

            mask[4, 0] = Convert.ToInt32(textBoxMask5x5E1.Text);
            mask[4, 1] = Convert.ToInt32(textBoxMask5x5E2.Text);
            mask[4, 2] = Convert.ToInt32(textBoxMask5x5E3.Text);
            mask[4, 3] = Convert.ToInt32(textBoxMask5x5E4.Text);
            mask[4, 4] = Convert.ToInt32(textBoxMask5x5E5.Text);

            return ImageProcessingServices.ApplyMask(source, mask, 5);
        }
    }
}
