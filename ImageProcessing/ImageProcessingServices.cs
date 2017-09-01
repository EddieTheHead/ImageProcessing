using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;

namespace ImageProcessing
{
    class ImageProcessingServices
    {
        public static Image ApplyMask(Image src, int[,] mask, int normalize = 1)
        {
            Bitmap input = (Bitmap)src;
            Bitmap result = new Bitmap(input);

            for (int i = 1; i < input.Width - 1; ++i)
                for (int k = 1; k < input.Height - 1; ++k)
                {
                    int color = 0;
                    int a = input.GetPixel(i, k).A;
                    color = input.GetPixel(i - 1, k - 1).R * mask[0, 0] + input.GetPixel(i - 1, k).R * mask[1, 0] + input.GetPixel(i - 1, k + 1).R * mask[2, 0] +
                            input.GetPixel(i, k - 1).R * mask[0, 1] + input.GetPixel(i, k).R * mask[1, 1] + input.GetPixel(i, k + 1).R * mask[2, 1] +
                            input.GetPixel(i + 1, k - 1).R * mask[0, 2] + input.GetPixel(i + 1, k).R * mask[1, 2] + input.GetPixel(i + 1, k + 1).R * mask[2, 2];
                    color /= normalize;
                    if (color < 0) color = 0;
                    if (color > 255) color = 255;
                    result.SetPixel(i, k, Color.FromArgb(a, color, color, color));
                }

            return result;
        }

        public static int CountColors(Image img)
        {
            HashSet<Color> colors = new HashSet<Color>();

            for (int i = 0; i < img.Width; ++i)
            {
                for (int k = 0; k < img.Height; ++k)
                {
                    colors.Add((img as Bitmap).GetPixel(i,k));
                }
            }
            return colors.Count;
        }
        /// <summary>
        /// Mnoży każdy element A[i] przez B[i] i przypisuje wynik do C[i]. Działanie odpowiad matlabowskiemu operatorowi " .* " 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>Wynik operacji A .* B </returns>
        private static Complex32[] multiplicateArrays(Complex32[] A, Complex32[] B)
        {
            if(A.Count() != B.Count()) throw new ArgumentException();
            Complex32[] result = new Complex32[A.Count()];
            for (int i = 0; i < A.Count(); ++i)
            {
                // (a+bi)(c+di) = (ac-bd)+(ad+bd)i
                //float re = A[i].Real *B [i].Imaginary - A[i].Imaginary*B[i].Imaginary;
                result[i] = A[i] * B[i]; 
            }
            return result;
        }
        /// <summary>
        /// Konwertuje bitmape na wektor liczb zespolonych. Części rzeczywistej wektora odpowiada wartość składnika czerwonego każdego pixela. 
        /// Wartości ustwiane są kolumnowo, tzn. pierwsze h wartości wektora wyjściowego odpowiada pierwszej kolumnie pixeli zdjęcia, gdzie h to jego wysokość. 
        /// </summary>
        /// <param name="img">Obraz do przekonwertowania</param>
        /// <returns>Wektor liczb zespolonych odpowiadający zdjęciu</returns>
        private static Complex32[] imgToComplex32(Image img)
        {
            Complex32[] result = new Complex32[img.Width * img.Height];
            for (int i = 0; i < img.Width; ++i)
            {
                for (int k = 0; k < img.Height; ++k)
                {
                    float val = (float) ((img as Bitmap).GetPixel(i, k).R);
                    result[i * img.Height + k] = new Complex32(val, 0);
                }
            }
            return result;
        }
        /// <summary>
        /// Konwertuje dwuwymiarową tablicę intów na wektor liczb zespolonych uzupełniony zerami do zadanej długości 
        /// </summary>
        /// <param name="mask">Maska do przekonwertowania</param>
        /// <param name="length">Długość wyjściowego wektora</param>
        /// <returns>Wektor liczb zespolonych odpowiadający masce</returns>
        private static Complex32[] maskToComplex32(int[,] mask, int length)
        {
            Complex32[] result = new Complex32[length];
            for (int i = 0; i < mask.GetLength(0); ++i)
            {
                for (int k = 0; k < mask.GetLength(1); ++k)
                {
                    result[i * mask.GetLength(1) + k] = new  Complex32( mask[i, k], 0) ;
                }
            }
            return result;
        }
        /// <summary>
        /// Konwertuje wektor liczb zespolonych Complex32[] na bitmapę o parmetrach odpowiadających wzorcowemu obrazowi
        /// </summary>
        /// <param name="source">Dane do przekonwertowania</param>
        /// <param name="pattern">Wzorcowa bitmapa</param>
        /// <returns>Zdjęcie odpowiadające danym z wektora source</returns>
        private static Image Complex32toImg(Complex32[] source, Image pattern)
        {
            Bitmap result = new Bitmap(pattern);
            for (int i = 0; i < pattern.Width; ++i)
            {
                for (int k = 0; k < pattern.Height; ++k)
                {
                    int c = (int) source[i * pattern.Height + k].Real;
                    if (c < 0) c = 0;
                    if (c > 255) c = 255;
                    Color color = Color.FromArgb(255,c,c,c);
                    result.SetPixel(i,k,color);
                }
            } return result;
        }
        /// <summary>
        /// Dokonuje filtracji zdjęcia filtrem zdefiniowanym jako dwuwymiarowa maska metodą splotu wektorów, przy pomocy szybkiej transformaty fouriera. 
        /// Procedura przebiega następująco:
        /// 1. Pozbaw zdjęcie kolorów.
        /// 2. Przekonwertuj zdjęcie na wektor liczb zespolonych, gdzie część rzeczywista odpowiada jasności danego pixela.
        /// 3. Przekonwertuj maskę na wektor liczb zespolonych uzupełniony zerami do długości wektora zdjęcia
        /// 3. Poddaj utworzone w poprzednich punktach wektory szybkiej transformacji Fouriera, bez skalowania 
        /// 4. Pomnóż odpowiadające sobie elementy wektorów częstotliwości (bitwise multiplication) dokonując działania odpowiadającego matlabowskiemu operatorowi " .* "   
        /// 5. Otrzymany wektor iloczynów poddaj odwrotnej szybkiej transformacie Fouriera ze skalowaniem 1/n, gdzie n to liczba elementów wektora (pixeli oryginalnego obrazu)
        /// 6. Przekonwertuj otrzymany wektor liczb zespolonych na zdjęcie, przypisując każdemu pixelowi część rzeczywistą odpowiadającej mu wartości w wektorze
        /// 7. Zwróć otrzymane zdjęcie
        /// 
        /// Do przeprowadzenia operacji fft i ifft wykożystano bibliotekę MathNet.Numerics
        /// fft  -> MathNet.Numerics.IntegralTransforms.Fourier.Forward
        /// ifft -> MathNet.Numerics.IntegralTransforms.Fourier.Inverse
        /// liczby zespolone -> MathNet.Numerics.Complex32
        /// </summary>
        /// <param name="img">Obraz wejściowy</param>
        /// <param name="mask">Maska filtra</param>
        /// <returns>Zdjęcie pozbawione kolorów i przefiltrowane filtrem zdefiniowanym w masce</returns>
        public static Image fftConvolution(Image img, int[,] mask)
        {
            Image gray = convertToGrayscale(img,0.24f,0.59f,0.11f);
            int size = gray.Width * gray.Height;
            Complex32[] imageSamples = imgToComplex32(img);
            Complex32[] maskSamples = maskToComplex32(mask,img.Width*img.Height);

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(imageSamples, MathNet.Numerics.IntegralTransforms.FourierOptions.AsymmetricScaling);
            MathNet.Numerics.IntegralTransforms.Fourier.Forward(maskSamples, MathNet.Numerics.IntegralTransforms.FourierOptions.AsymmetricScaling);

           Complex32[] conv = multiplicateArrays(imageSamples, maskSamples);
           MathNet.Numerics.IntegralTransforms.Fourier.Inverse(conv, MathNet.Numerics.IntegralTransforms.FourierOptions.AsymmetricScaling);
            
           Image result = Complex32toImg(conv, gray);
           return result;
        }
        public static Image Rotate(Image img, int angle)
        {
            PointF offset = new PointF((float)img.Width / 2, img.Height / 2);
            Bitmap rotated = new Bitmap(img.Width, img.Height);

            rotated.SetResolution(img.HorizontalResolution, img.VerticalResolution);

            Graphics grap = Graphics.FromImage(rotated);

            grap.TranslateTransform(offset.X, offset.Y);
            grap.RotateTransform(angle);
            grap.TranslateTransform(-offset.X, -offset.Y);

            grap.DrawImage(img, new PointF(0, 0));
            return rotated;

        }
        public Image Zoom(double zoomFactor, Image srcImg)
        {
            Size newSize = new Size((int)(srcImg.Width * zoomFactor), (int)(srcImg.Height * zoomFactor));
            if (newSize.Height < 1) newSize.Height = 1;
            if (newSize.Width < 1) newSize.Width = 1;

            Bitmap bmp = (Bitmap)srcImg;
            try
            {
                bmp = new Bitmap(srcImg, newSize);
            }
            catch (Exception e) { MessageBox.Show(e.Message); }

            return bmp;
        }

        public static Image Crop(Image source, Rectangle cropRect)
        {
           // Rectangle cropRect = new Rectangle(Int32.Parse(maskedTextBoxCropX.Text), Int32.Parse(maskedTextBoxCropY.Text), Int32.Parse(maskedTextBoxCropWidth.Text), Int32.Parse(maskedTextBoxCropHeight.Text));
            Bitmap target = new Bitmap(cropRect.Width,cropRect.Height);
            Bitmap src = source as Bitmap;

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
            }
            return target;
        }


        public static Image ToSepia(Image img)
        {
            Bitmap desaturated = (Bitmap)img;

            float[] rFactors = { 0.393f, 0.769f, 0.189f };
            float[] gFactors = { 0.349f, 0.686f, 0.168f };
            float[] bFactors = { 0.272f, 0.534f, 0.131f };

            Bitmap outputImg = new Bitmap(desaturated);

            for (int i = 0; i < desaturated.Width; ++i)
                for (int k = 0; k < desaturated.Height; ++k)
                {
                    Color color = desaturated.GetPixel(i, k);
                    int a = color.A;
                    int r = color.R;
                    int g = color.G;
                    int b = color.B;

                    int newR = Convert.ToInt32(r * rFactors[0] + g * rFactors[1] + b * rFactors[2]);
                    int newG = Convert.ToInt32(r * gFactors[0] + g * gFactors[1] + b * gFactors[2]);
                    int newB = Convert.ToInt32(r * bFactors[0] + g * bFactors[1] + b * bFactors[2]);

                    if (newR > 255) newR = 255;
                    if (newG > 255) newG = 255;
                    if (newB > 255) newB = 255;

                    outputImg.SetPixel(i, k, Color.FromArgb(a, newR, newG, newB));
                }
            return outputImg;
        }

        public static Image Negate(Image img)
        {
            Bitmap desaturated = (Bitmap)img;

            Bitmap outputImg = new Bitmap(desaturated);

            for (int i = 0; i < desaturated.Width; ++i)
                for (int k = 0; k < desaturated.Height; ++k)
                {
                    Color color = desaturated.GetPixel(i, k);
                    int a = color.A;
                    int r = 255 - color.R;
                    int g = 255 - color.G;
                    int b = 255 - color.B;

                    outputImg.SetPixel(i, k, Color.FromArgb(a, r, g, b));
                }
            return outputImg;

        }
        public static Image GammaTransform(Image img, float gamma)
        {
            Bitmap bmp = (Bitmap)img;
            Bitmap outputImg = new Bitmap(bmp);
            //float gamma = (float)(numericUpDownGamma.Value);

            for (int i = 0; i < bmp.Width; ++i)
                for (int k = 0; k < bmp.Height; ++k)
                {
                    Color color = bmp.GetPixel(i, k);
                    int a = color.A;
                    int r = (Int32)(255.0 * Math.Pow((float)color.R / 255.0, 1.0 / gamma));
                    int g = (Int32)(255.0 * Math.Pow((float)color.R / 255.0, 1.0 / gamma));
                    int b = (Int32)(255.0 * Math.Pow((float)color.R / 255.0, 1.0 / gamma));

                    outputImg.SetPixel(i, k, Color.FromArgb(a, r, g, b));
                }
            return outputImg;
        }
        public static Image Binaryze(Image img, float treshold)
        {
            Bitmap binary = (Bitmap)img;
            Bitmap outputImg = new Bitmap(binary);
            //float treshold = (float)(trackBarBinTreshold.Value);

            for (int i = 0; i < binary.Width; ++i)
                for (int k = 0; k < binary.Height; ++k)
                {
                    Color color = binary.GetPixel(i, k);
                    int a = color.A;
                    if (color.R + color.B + color.G > treshold) outputImg.SetPixel(i, k, Color.FromArgb(a, 255, 255, 255));
                    else outputImg.SetPixel(i, k, Color.FromArgb(a, 0, 0, 0));
                }
            return outputImg;
        }

        public enum ColorLayerType {Red, Green, Blue };

        public static Image SeparateLayer(Image img, ColorLayerType layer)
        {
            Bitmap source = (Bitmap)img;
            Bitmap singleLayer = new Bitmap(source);

            for (int i = 0; i < source.Width; ++i)
                for (int k = 0; k < source.Height; ++k)
                {
                    Color color = source.GetPixel(i, k);
                    switch (layer)
                    {
                        case ColorLayerType.Red:
                            singleLayer.SetPixel(i, k, Color.FromArgb(color.A, color.R, 0, 0));
                            break;
                        case ColorLayerType.Green:
                            singleLayer.SetPixel(i, k, Color.FromArgb(color.A, 0, color.G, 0));
                            break;
                        case ColorLayerType.Blue:
                            singleLayer.SetPixel(i, k, Color.FromArgb(color.A, color.R, color.G, color.B));
                            break;
                        default:
                            break;
                    }
                }
            return singleLayer;
        }

        public static Image bumpColors(Image img, float rFactor, float gFactor, float bFactor)
        {
            Bitmap source = (Bitmap)img;
            Bitmap singleLayer = new Bitmap(source);

            for (int i = 0; i < source.Width; ++i)
                for (int k = 0; k < source.Height; ++k)
                {
                    Color color = source.GetPixel(i, k);
                    singleLayer.SetPixel(i, k, Color.FromArgb(color.A, Math.Abs((int)(color.R * rFactor)), Math.Abs((int)(color.G * gFactor)), Math.Abs((int)(color.B * bFactor))));//////
                }
            return singleLayer;
        }


        //public void buttonGrayscaleApply_Click(object sender, EventArgs e);
        public static Image convertToGrayscale(Image img, float rFactor, float gFactor, float bFactor)
        {

            if (((rFactor + gFactor + bFactor) > 1.0))
            {
                MessageBox.Show("The sum of r, g and b factors must be smaller than 1");
                return img;
            }
            Bitmap desaturated = (Bitmap) img.Clone();
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
                    outputImg.SetPixel(i, k, Color.FromArgb(a, avg, avg, avg));
                }
            return outputImg;
        }
    }
}
