using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private int szer = 0, wys = 0;
        Bitmap bitmap;

        int[] R = new int[256];
        int[] G = new int[256];
        int[] B = new int[256];

        int K = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                bitmap = (Bitmap)this.pictureBox1.Image;

                wys = pictureBox1.Image.Height;
                szer = pictureBox1.Image.Width;

                Array.Clear(R, 0, R.Length);
                Array.Clear(G, 0, G.Length);
                Array.Clear(B, 0, B.Length);

                histogram();

                K = 0;

                panel2.Invalidate();
                panel3.Invalidate();
                panel4.Invalidate();
            }
        }

        private void histogram()
        {
            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {
                    Color c = bitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    R[r]++;
                    G[g]++;
                    B[b]++;
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            if(K == 0)
            { 
                Graphics graphR = e.Graphics;

                for (int i = 0; i < 256; i++)
                {
                    float s = R[i];

                    s = s / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    s *= 6000;

                    graphR.DrawLine(new Pen(Color.Red), i, panel2.Height, i, panel2.Height - s);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            if (K == 0)
            {
                Graphics graphR = e.Graphics;

                for (int i = 0; i < 256; i++)
                {
                    float s = G[i];

                    s = s / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    s *= 6000;

                    graphR.DrawLine(new Pen(Color.Green), i, panel3.Height, i, panel3.Height - s);
                }
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            if (K == 0)
            {
                Graphics graphR = e.Graphics;

                for (int i = 0; i < 256; i++)
                {
                    float s = B[i];

                    s = s / (pictureBox1.Image.Height * pictureBox1.Image.Width);
                    s *= 6000;

                    graphR.DrawLine(new Pen(Color.Blue), i, panel4.Height, i, panel4.Height - s);
                }
            }
        }

        //1A
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmapEdited = (Bitmap)bitmap.Clone();

                for (int y = 0; y < wys; y++)
                {
                    for (int x = 0; x < szer; x++)
                    {

                        Color c = bitmap.GetPixel(x, y);

                        int r = c.R;
                        int g = c.G;
                        int b = c.B;

                        r = (127 / (127 - trackBar2.Value)) * (r - trackBar2.Value);
                        g = (127 / (127 - trackBar2.Value)) * (g - trackBar2.Value);
                        b = (127 / (127 - trackBar2.Value)) * (b - trackBar2.Value);

                        if (r < 0)
                        {
                            r = 0;
                        }
                        if (g < 0)
                        {
                            g = 0;
                        }
                        if (b < 0)
                        {
                            b = 0;
                        }
                        if (r > 255)
                        {
                            r = 255;
                        }
                        if (g > 255)
                        {
                            g = 255;
                        }
                        if (b > 255)
                        {
                            b = 255;
                        }

                        Color j = Color.FromArgb(r, g, b);
                        bitmapEdited.SetPixel(x, y, j);
                    }
                }
                pictureBox1.Image = bitmapEdited;
                pictureBox1.Invalidate();
            }
            catch
            {

            }
        }

        //1B
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();

            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {
                    Color c = bitmap.GetPixel(x, y);

                    double r = (double)c.R;
                    double g = (double)c.G;
                    double b = (double)c.B;

                    r = (127 + trackBar3.Value) * r / 127 - trackBar3.Value;

                    g = (127 + trackBar3.Value) * g / 127 - trackBar3.Value;

                    b = (127 + trackBar3.Value) * b / 127 - trackBar3.Value;

                    if (r < 0)
                    {
                        r = 0;
                    }
                    if (g < 0)
                    {
                        g = 0;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }
                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (g > 255)
                    {
                        g = 255;
                    }
                    if (b > 255)
                    {
                        b = 255;
                    }

                    Color j = Color.FromArgb((int)r, (int)g, (int)b);
                    bitmapEdited.SetPixel(x, y, j);
                }
            }
            pictureBox1.Image = bitmapEdited;
            pictureBox1.Invalidate();
        }

        //2A
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();

            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {

                    Color c = bitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (r < 127)
                    {
                        r = ((127 - trackBar4.Value) / 127) * r;
                    }
                    else
                    {
                        r = ((127 - trackBar4.Value) / 127) * r + 2 * trackBar4.Value;
                    }

                    if (g < 127)
                    {
                        g = ((127 - trackBar4.Value) / 127) * g;
                    }
                    else
                    {
                        g = ((127 - trackBar4.Value) / 127) * g + 2 * trackBar4.Value;
                    }

                    if (b < 127)
                    {
                        b = ((127 - trackBar4.Value) / 127) * b;
                    }
                    else
                    {
                        b = ((127 - trackBar4.Value) / 127) * b + 2 * trackBar4.Value;
                    }

                    if (r < 0)
                    {
                        r = 0;
                    }
                    if (g < 0)
                    {
                        g = 0;
                    }
                    if (b < 0)
                    {
                        b = 0;
                    }
                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (g > 255)
                    {
                        g = 255;
                    }
                    if (b > 255)
                    {
                        b = 255;
                    }

                    Color j = Color.FromArgb(r, g, b);
                    bitmapEdited.SetPixel(x, y, j);
                }
            }
            pictureBox1.Image = bitmapEdited;
            pictureBox1.Invalidate();
        }

        //2B
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap bitmapEdited = (Bitmap)bitmap.Clone();

            for (int y = 0; y < wys; y++)
            {
                for (int x = 0; x < szer; x++)
                {

                    Color c = bitmap.GetPixel(x, y);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    if (r < 127 + trackBar1.Value)
                    {
                        r = (127 / (127 + trackBar1.Value)) * r;
                    }
                    else if (r > 127 - trackBar1.Value)
                    {
                        r = (127 * r + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        r = 127;
                    }

                    if (g < 127 + trackBar1.Value)
                    {
                        g = (127 / (127 + trackBar1.Value)) * g;
                    }
                    else if (g > 127 - trackBar1.Value)
                    {
                        g = (127 * g + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        g = 127;
                    }

                    if (b < 127 + trackBar1.Value)
                    {
                        b = (127 / (127 + trackBar1.Value)) * b;
                    }
                    else if (b > 127 - trackBar1.Value)
                    {
                        b = (127 * b + 255 * trackBar1.Value) / (127 + trackBar1.Value);
                    }
                    else
                    {
                        b = 127;
                    }

                    Color j = Color.FromArgb(r, g, b);
                    bitmapEdited.SetPixel(x, y, j);
                }
            }
            pictureBox1.Image = bitmapEdited;
            pictureBox1.Invalidate();
        }
       
    }
}
