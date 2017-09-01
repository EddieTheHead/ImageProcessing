using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class GraphicActionControl : UserControl
    {

        public Image result;
        
        public void showResult()
        {
            if (result == null) return;
            using (Form prevForm = new Form())
            {
                prevForm.Size = result.Size;
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                prevForm.Controls.Add(pb);
                pb.Image = result;
                prevForm.Text = "Output of " + labelTitle.Text + ": " + comboBoxEffect.Text;
                prevForm.ShowDialog();
            }
        }

        public GraphicActionControl()
        {
            InitializeComponent();
            //MaskControl mk = new MaskControl();
            //panelContainer.Controls.Add(mk);
            comboBoxEffect.Items.Add("Color Correction");
            comboBoxEffect.Items.Add("Transformations");
            comboBoxEffect.Items.Add("Mask 3x3");
            comboBoxEffect.Items.Add("Mask 5x5");
            comboBoxEffect.Items.Add("Color Layer Separation");
            comboBoxEffect.Items.Add("Binaryzation");
            comboBoxEffect.Items.Add("Crop");
            comboBoxEffect.Items.Add("Gamma transform");
            comboBoxEffect.Items.Add("Convert to Grayscale");
            comboBoxEffect.Items.Add("Negative");
            comboBoxEffect.Items.Add("Sepia");
            comboBoxEffect.Items.Add("FFT Convolution");
        }

        public void setTitle(String title)
        {
            labelTitle.Text = title;
        }

        private void comboBoxEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selected = comboBoxEffect.Text;
            panelContainer.Controls.Clear();
            if(selected == "Mask 3x3")
            {
                Mask3x3Control mk = new Mask3x3Control();
                panelContainer.Controls.Add(mk);
            }
            else if (selected == "Color Correction")
            {
                ColorCorrectionControl ccc = new ColorCorrectionControl();
                panelContainer.Controls.Add(ccc);
            }
            else if (selected == "Transformations")
            {
                TransformControl tc = new TransformControl();
                panelContainer.Controls.Add(tc);
            }
            else if(selected == "Color Layer Separation")
            {
                LayerSeparationControl lsc = new LayerSeparationControl();
                panelContainer.Controls.Add(lsc);
            }
            else if (selected == "Mask 5x5")
            {
                Mask5x5Control mk = new Mask5x5Control();
                panelContainer.Controls.Add(mk);
            }
            else if (selected == "Binaryzation")
            {
                BinaryzationControl bin = new BinaryzationControl();
                panelContainer.Controls.Add(bin);
            }
            else if (selected == "Crop")
            {
                CropControl cr = new CropControl();
                panelContainer.Controls.Add(cr);
            }
            else if (selected == "Gamma transform")
            {
                GammaControl gc = new GammaControl();
                panelContainer.Controls.Add(gc);
            }
            else if (selected == "Sepia")
            {
                SepiaControl s = new SepiaControl();
                panelContainer.Controls.Add(s);
            }
            else if (selected == "Convert to Grayscale")
            {
                GrayscaleControl gc = new GrayscaleControl();
                panelContainer.Controls.Add(gc);
            }
            else if (selected == "Negative")
            {
                NegativeControl ng = new NegativeControl();
                panelContainer.Controls.Add(ng);
            }
            else if (selected == "FFT Convolution")
            {
                FFTConvolutionControl fft = new FFTConvolutionControl();
                panelContainer.Controls.Add(fft);
            }
        }

        private void buttonShowResult_Click(object sender, EventArgs e)
        {
            showResult();
            //if (panelContainer.Controls.Count == 0) return;
            //GraphicEffectUserControl gc = (GraphicEffectUserControl)panelContainer.Controls[0];
        }
        public void applyEffect(Image img)
        {
            if (panelContainer.Controls.Count == 0) return;
            IGraphicEffect gc = (IGraphicEffect)panelContainer.Controls[0];
            result = gc.applyEffect(img);
        }
    }
}
