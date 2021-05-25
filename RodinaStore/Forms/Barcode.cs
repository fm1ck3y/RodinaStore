using System;
using System.Drawing;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class Barcode : Form
    {
        private Image _img;

        public Image Img
        {
            get
            {
                return _img;
            }
        }

        private string _barcode;

        public Barcode(Image img = null, string barcode = null)
        {
            _img = img;
            _barcode = barcode;
            InitializeComponent();
            pictureBox1.Image = _img;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Img, 0, 0);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Graphics mg = Graphics.FromImage(Img);
            mg.DrawImage(Img, 0, 0);
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = $"{_barcode}.jpeg";
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Img.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    MessageBox.Show("Изображение удачно сохранено!", "Успешно",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
