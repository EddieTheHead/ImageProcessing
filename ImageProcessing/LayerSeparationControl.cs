using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class LayerSeparationControl : UserControl, IGraphicEffect
    {
        public LayerSeparationControl()
        {
            InitializeComponent();
        }

        public Image applyEffect(Image source)
        {
            ImageProcessingServices.ColorLayerType layerType;
            if (radioButtonLayerRed.Checked) layerType = ImageProcessingServices.ColorLayerType.Red;
            else if (radioButtonLayerGreen.Checked) layerType = ImageProcessingServices.ColorLayerType.Green;
            else layerType = ImageProcessingServices.ColorLayerType.Blue;

            return ImageProcessingServices.SeparateLayer(source, layerType);
        }
    }
}
