using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class TransformControl : UserControl, IGraphicEffect
    {
        public TransformControl()
        {
            InitializeComponent();
            foreach (RotateFlipType type in Enum.GetValues(typeof(RotateFlipType)))
            {
                comboBoxTransf.Items.Add(new CheckboxItem(type.ToString(), (int)type));
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
                return (RotateFlipType)Value;
            }
        }

        public Image applyEffect(Image source)
        {
            Image img = source;
            img.RotateFlip(((CheckboxItem)comboBoxTransf.SelectedItem).toRotateFlipType());
            return img;
        }
    }

}
