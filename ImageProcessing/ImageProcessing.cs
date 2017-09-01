using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        public ImageProcessing()
        {
            InitializeComponent();

            foreach (RotateFlipType type in Enum.GetValues(typeof(RotateFlipType)))
            {
                comboBoxTransf.Items.Add(new CheckboxItem(type.ToString(), (int)type));
            }

            pictureBoxImage2.MouseWheel += pictureBoxImage2_MouseWheel;

        }
       
        private void buttonOpenFileImg1_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "Image files (*.jpg, *.png, *.bmp, *.tiff, *gif) | *.jpg; *.png; *.bmp; *.tiff; *gif";
            fd.ShowDialog();
            try
            {
                pictureBoxImage1.Image = loadWithProgressBar(fd.FileName);
                textBoxImage1Props.Text = ReadImageData(fd.FileName);
                textBoxImage1Props.Text += "Color count: " + ImageProcessingServices.CountColors(pictureBoxImage1.Image);
                processedImage = null;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
        
        private Image loadWithProgressBar(String url)
        {
            BinaryReader reader = new BinaryReader(File.Open(url,FileMode.Open));
           
            FileInfo fi = new FileInfo(url);
            int size =Convert.ToInt32(fi.Length);
            int readed = 0;
            byte[] buff = new byte[size];
            do
            {
                buff[readed] = reader.ReadByte();
                readed++;
                progressBar.Value = Convert.ToInt32(Math.Ceiling(100d * readed / size));
            } while (readed < size);
            reader.Close();

            using (var ms = new MemoryStream(buff))
            {
                return Image.FromStream(ms);                
            }
            
        }

        private void buttonOpenFileImg2_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.Filter = "Image files (*.jpg, *.png, *.bmp, *.tiff, *gif) | *.jpg; *.png; *.bmp; *.tiff; *gif";
            fd.ShowDialog();
            try
            {
                pictureBoxImage2.Image = loadWithProgressBar(fd.FileName);
                textBoxImage2Props.Text = ReadImageData(fd.FileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }


        private String ReadImageData(String url)
        {
            StringBuilder imageData = new StringBuilder();
            FileInfo fi = new FileInfo(url);
            imageData.Append("File url: ");
            imageData.Append(url + Environment.NewLine);
            imageData.Append("Filename: " + fi.Name + Environment.NewLine);
            imageData.Append("File size: ");
            imageData.Append(fi.Length * 8 );
            imageData.Append(" bytes" + Environment.NewLine);
            imageData.Append("Extansion: ");
            imageData.Append(fi.Extension + Environment.NewLine);
            imageData.Append("Created: " + fi.CreationTime + Environment.NewLine);
            imageData.Append("Last modified: " + fi.LastWriteTime+ Environment.NewLine);
            imageData.Append("Attributes: " + fi.Attributes + Environment.NewLine);       
       
            return imageData.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Image files (*.jpg, *.png, *.bmp, *.tiff, *gif) | *.jpg; *.png; *.bmp; *.tiff; *gif";
            
            if (sf.ShowDialog() == DialogResult.OK && pictureBoxImage1.Image != null)
            {
                pictureBoxImage2.Image.Save(sf.FileName);
            }
        }

        WebAddressDialog urlDialog = new WebAddressDialog();

        private void buttonImg1FromUrl_Click(object sender, EventArgs e)
        {
            urlDialog.Show();
            if (urlDialog.result == DialogResult.OK)
            {
                String url = urlDialog.url;
                //download picture
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, "a.jpeg");
                }
            }
        }
        private class CheckboxItem
        {
            public string Name;
            public int Value;
            public CheckboxItem(string name, int value)
            {
                Name = name; Value = value;
            }

            public override string ToString()
            {
                return Name;
            }

            public RotateFlipType toRotateFlipType()
            {
                return (RotateFlipType) Value; 
            }
        }


        private void comboBoxTransf_SelectedIndexChanged(object sender, EventArgs e)
        {

            processedImage = pictureBoxImage1.Image;
            if (processedImage == null) return;
            processedImage.RotateFlip(((CheckboxItem)comboBoxTransf.SelectedItem).toRotateFlipType());
            pictureBoxImage2.Image = processedImage;
        }

        Image processedImage;
        int rotationAngle = 0;


        private Image zoom(double zoomFactor, Image srcImg)
        {
            Size newSize = new Size((int)(srcImg.Width * zoomFactor), (int)(srcImg.Height * zoomFactor));
            if (newSize.Height < 1) newSize.Height = 1;
            if (newSize.Width < 1) newSize.Width = 1;

            Bitmap bmp = (Bitmap) srcImg;
            try
            {
                bmp = new Bitmap(srcImg, newSize);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return bmp;
        }


        private void pictureBoxImage2_MouseWheel(object sender, MouseEventArgs e)
        {
            Image2ZoomFactor += 0.001 * e.Delta;
            if (processedImage == null) processedImage = pictureBoxImage1.Image;
            pictureBoxImage2.Image = zoom(Image2ZoomFactor, processedImage);
        }

        private void trackBarrotation_Scroll(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image == null) return;
            rotationAngle = trackBarrotation.Value;
            processedImage = ImageProcessingServices.Rotate(processedImage, rotationAngle);
            pictureBoxImage2.Image = processedImage;
        }

        double Image2ZoomFactor = 1;

        private void pictureBoxImage2_MouseHover(object sender, EventArgs e)
        {
            pictureBoxImage2.Focus();
        }

        private void buttonApplyCrop_Click(object sender, EventArgs e)
        {
            Rectangle cropRect = new Rectangle(Int32.Parse(maskedTextBoxCropX.Text), Int32.Parse(maskedTextBoxCropY.Text), Int32.Parse(maskedTextBoxCropWidth.Text), Int32.Parse(maskedTextBoxCropHeight.Text));
            Bitmap target = new Bitmap(Int32.Parse(maskedTextBoxCropWidth.Text), Int32.Parse(maskedTextBoxCropHeight.Text));
            Bitmap src = pictureBoxImage1.Image as Bitmap;

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0,0, target.Width, target.Height),cropRect,GraphicsUnit.Pixel);
            }

            processedImage = pictureBoxImage2.Image = target;
        }
		
		


        private void buttonGrayscaleApply_Click(object sender, EventArgs e)
        {
            float rFactor = (float) numericUpDownRFactor.Value;
            float gFactor = (float) numericUpDownGFactor.Value;
            float bFactor = (float) numericUpDownbFactor.Value;

            if ((rFactor + gFactor + bFactor) > 1.0)
            {
                MessageBox.Show("The sum of r, g and b factors must be smaller than 1");
                return;
            }
            if (pictureBoxImage1.Image == null) return;
            Bitmap desaturated = null;
            if (processedImage == null) desaturated = (Bitmap)pictureBoxImage1.Image.Clone();
            else desaturated = (Bitmap) processedImage.Clone();

            Bitmap outputImg = new Bitmap(desaturated);

            for (int i = 0; i < desaturated.Width; ++i)
                for (int k = 0; k < desaturated.Height; ++k)
                {
                    Color color = desaturated.GetPixel(i, k);
                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;
                    //outputImg.SetPixel(i, k, Color.FromArgb(a, Convert.ToInt32((float)r * rFactor), Convert.ToInt32((float)g * gFactor), Convert.ToInt32((float)b * bFactor)));
                    int avg = Convert.ToInt32((float)r * rFactor) + Convert.ToInt32((float)g * gFactor) + Convert.ToInt32((float)b * bFactor);
                    outputImg.SetPixel(i, k, Color.FromArgb(a, avg,avg,avg));
                }
           processedImage=  pictureBoxImage2.Image = outputImg;

        }

        private Image separateLayer(Image img)
        {
            Bitmap source = (Bitmap)img;
            Bitmap singleLayer = new Bitmap(source);

            for (int i = 0; i < source.Width; ++i)
                for (int k = 0; k < source.Height; ++k)
                {
                    Color color = source.GetPixel(i, k);
                    if (radioButtonLayerRed.Checked) singleLayer.SetPixel(i, k, Color.FromArgb(color.A, color.R, 0, 0));
                    else if (radioButtonLayerGreen.Checked) singleLayer.SetPixel(i, k, Color.FromArgb(color.A, 0, color.G, 0));
                    else if (radioButtonLayerBlue.Checked) singleLayer.SetPixel(i, k, Color.FromArgb(color.A, 0, 0, color.B));
                    else singleLayer.SetPixel(i, k, Color.FromArgb(color.A, color.R, color.G, color.B));
                }
            return singleLayer;
        }

        private void comboBoxPreDefGrayScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPreDefGrayScale.SelectedIndex)
            {
                case 0:
                    numericUpDownRFactor.Value = (decimal) 0.244f;
                    numericUpDownGFactor.Value = (decimal) 0.587f;
                    numericUpDownbFactor.Value = (decimal) 0.114f; 
                    break;
                case 1:
                    numericUpDownRFactor.Value = (decimal) 0.11f;
                    numericUpDownGFactor.Value = (decimal) 0.59f;
                    numericUpDownbFactor.Value = (decimal) 0.3f; 
                    break;
                case 2:
                    numericUpDownRFactor.Value = (decimal) 0.33f;
                    numericUpDownGFactor.Value = (decimal) 0.33f;
                    numericUpDownbFactor.Value = (decimal) 0.33f; 
                    break;
                default:
                    break;
            }
            buttonGrayscaleApply.PerformClick();
        }

        private void buttonToSepia_Click(object sender, EventArgs e)
        {
            if(pictureBoxImage1.Image == null) return;
          
            processedImage = ImageProcessingServices.ToSepia(pictureBoxImage1.Image);
            pictureBoxImage2.Image = processedImage;
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image == null) return;

            processedImage = ImageProcessingServices.Negate(pictureBoxImage1.Image);
            pictureBoxImage2.Image = processedImage;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Image files (*.jpg, *.png, *.bmp, *.tiff, *gif) | *.jpg; *.png; *.bmp; *.tiff; *gif";
            
            if (sf.ShowDialog() == DialogResult.OK && pictureBoxImage2.Image != null)
            {
                pictureBoxImage2.Image.Save(sf.FileName);
            }
        }

        private void openUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (urlDialog == null) urlDialog = new WebAddressDialog();
            urlDialog.Show();
            if (urlDialog.result == DialogResult.OK)
            {
                String url = urlDialog.url;
                //download picture
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, "a.jpeg");
                }
            }
        }

        private void yUVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxPreDefGrayScale.SelectedIndex = 0;
        }

        private void cIEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxPreDefGrayScale.SelectedIndex = 1;
        }

        private void aVGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBoxPreDefGrayScale.SelectedIndex = 2;
        }

        private void buttonBinaryze_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image == null) return;
            float treshold = (float)(trackBarBinTreshold.Value);
            processedImage = ImageProcessingServices.Binaryze(pictureBoxImage1.Image,treshold);
            pictureBoxImage2.Image = processedImage;
        }

        private void buttonTransformGamma_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image == null) return;
            processedImage = ImageProcessingServices.GammaTransform(pictureBoxImage1.Image, (float) numericUpDownGamma.Value);
            pictureBoxImage2.Image = processedImage;
        }

        private void trackBarBinTreshold_MouseUp(object sender, MouseEventArgs e)
        {
            buttonBinarize.PerformClick();
        }

        private void buttonSeparateLayer_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image == null) return;
            processedImage = separateLayer(pictureBoxImage1.Image);
            pictureBoxImage2.Image = processedImage;
        }

        private void buttonApplyCorrection_Click(object sender, EventArgs e)
        {
            float r = ((float)trackBarCorrectR.Value - 50) * (float) 0.01;
            float g = ((float)trackBarCorrectG.Value - 50) * (float) 0.01;
            float b = ((float)trackBarCorrectB.Value - 50) * (float) 0.01;

            if (pictureBoxImage1.Image == null) return;
            processedImage = ImageProcessingServices.bumpColors(pictureBoxImage1.Image,r,g,b);
            pictureBoxImage2.Image = processedImage;
        }
        
        private void buttonAddControl_Click(object sender, EventArgs e)
        {

            GraphicActionControl contr = new GraphicActionControl();
            if (panelFilters.Controls.Count > 0)
            {
                Control lastControl = panelFilters.Controls[panelFilters.Controls.Count - 1];
                contr.Location = new Point(lastControl.Location.X + lastControl.Width, lastControl.Location.Y);
            }
            else contr.Location = new Point(0, 0);
            contr.setTitle("Step " + (panelFilters.Controls.Count + 1));
            panelFilters.Controls.Add(contr);
        }

        private void buttonRemoveControl_Click(object sender, EventArgs e)
        {
            if(panelFilters.Controls.Count > 0) panelFilters.Controls.RemoveAt(panelFilters.Controls.Count - 1);
        }

        private void buttonRunChain_Click(object sender, EventArgs e)
        {
            if (panelFilters.Controls.Count == 0 || pictureBoxImage1.Image == null) return;
            GraphicActionControl first = (GraphicActionControl)panelFilters.Controls[0];
            first.applyEffect(pictureBoxImage1.Image);
            
            for (int i = 1; i< panelFilters.Controls.Count; ++i)
            {
                GraphicActionControl gac = (GraphicActionControl)panelFilters.Controls[i];
                gac.applyEffect((panelFilters.Controls[i - 1] as GraphicActionControl).result);
            }
            GraphicActionControl last = (GraphicActionControl)panelFilters.Controls[panelFilters.Controls.Count - 1];

            pictureBoxImage2.Image = processedImage =  last.result;
        }

        private void ShowHistogram(Image img)
        {


            //256 możliwych wartości każdego z kolorów składowych
            long[] red = new long[256];
            long[] green = new long[256];
            long[] blue = new long[256];
            
            //zliczanie ile razy wystąpiła na obrazku dana wartość każdego z kolorów
            for (int i = 0; i < img.Width; ++i)
            {
                for (int k = 0; k < img.Height; ++k)
                {
                    Color color = (img as Bitmap).GetPixel(i, k);
                    red[color.R] += 1;
                    green[color.G] += 1;
                    blue[color.B] += 1;
                }
            }
            //utowrzenie nowego wykresu
            Chart hist = new Chart()
            {
                Size = new Size(500, 500),
            };

            //utworzenie 3 zbiorów danych na wykresie
            Series redSeries = new Series
            {
                Name = "red",
                Color = Color.Red,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            Series greenSeries = new Series
            {
                Name = "green",
                Color = Color.Green,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };
            Series blueSeries = new Series
            {
                Name = "blue",
                Color = Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            hist.Series.Add(redSeries);
            hist.Series.Add(greenSeries);
            hist.Series.Add(blueSeries);
            
            //nowy obszar na krórym będą wykreślane dane
            ChartArea area = new ChartArea("Area");
            hist.ChartAreas.Add(area);

            //dodanie danych do wykresu
            for (int i = 0; i < 256; ++i)
            {
                hist.Series["red"].Points.AddXY(i,red[i]);
                hist.Series["green"].Points.AddXY(i, green[i]);
                hist.Series["blue"].Points.AddXY(i, blue[i]);
            }

            //nowe okienko z histogramem
            using (Form prevForm = new Form())
            {
                prevForm.Size = hist.Size;
                prevForm.Controls.Add(hist);
                hist.Dock = DockStyle.Fill;
                hist.Invalidate();
                prevForm.Text = "Histogram";
                prevForm.ShowDialog();
            }
            
        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            if (pictureBoxImage1.Image != null) ShowHistogram(pictureBoxImage1.Image);
        }

        private void załadujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (panelFilters.Controls.Count > 0) buttonRemoveControl.PerformClick();
            buttonAddControl.PerformClick();
            GraphicActionControl contr = (GraphicActionControl) panelFilters.Controls[0];
            ComboBox cbox = (ComboBox)contr.Controls["comboBoxEffect"];
            cbox.SelectedIndex = cbox.FindString("FFT Convolution");
            Panel pn = (Panel) contr.Controls["panelContainer"];
            FFTConvolutionControl fft = (FFTConvolutionControl)pn.Controls["FFTConvolutionControl"];
            //Przykładowa maska z http://michalbereta.pl/dydaktyka/KPO/wyklad_FFT.pdf str 22
            TextBox tb = (TextBox)fft.Controls["textBoxMask3x3X1"];
            tb.Text = "-1";
            tb = (TextBox)fft.Controls["textBoxMask3x3X2"];
            tb.Text = "-2";
            tb = (TextBox)fft.Controls["textBoxMask3x3X3"];
            tb.Text = "-1";
            tb = (TextBox)fft.Controls["textBoxMask3x3Y1"];
            tb.Text = "0";
            tb = (TextBox)fft.Controls["textBoxMask3x3Y2"];
            tb.Text = "0";
            tb = (TextBox)fft.Controls["textBoxMask3x3Y3"];
            tb.Text = "0";
            tb = (TextBox)fft.Controls["textBoxMask3x3Z1"];
            tb.Text = "1";
            tb = (TextBox)fft.Controls["textBoxMask3x3Z2"];
            tb.Text = "2";
            tb = (TextBox)fft.Controls["textBoxMask3x3Z3"];
            tb.Text = "1";
            buttonRunChain.PerformClick();
        }

        private void buttonShowHistogramImg2_Click(object sender, EventArgs e)
        {
            if(pictureBoxImage2.Image != null) ShowHistogram(pictureBoxImage2.Image);
        }
    }
}