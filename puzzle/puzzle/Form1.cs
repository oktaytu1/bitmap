using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace puzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Bitmap kes(int x, int y, int w, int h)
        {
            Bitmap resim = pictureBox1.Image as Bitmap;
            Rectangle dikdörtgenalan = new Rectangle(x, y, w, h);
            Bitmap kesilenresim = resim.Clone(dikdörtgenalan, resim.PixelFormat);
            return kesilenresim;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int x = 0, y = 0, xx = 0, yy = 0;
        public void btnoluştur()
        {    
            Image resim=Image.FromFile(dia.FileName);
            int tex1 = Convert.ToInt32(textBox1.Text);
            int tex2 = Convert.ToInt32(textBox2.Text);
            int w = resim.Width / tex1;
            int h = resim.Height / tex2;
            
            for (int i = 1; i <= tex1*tex2; i++)
            {
                PictureBox ptb = new PictureBox();
                ptb.Name = "ptb"+i;
                ptb.Text = i.ToString();
                ptb.Location = new Point(x, y);                
                ptb.Image = kes(xx,yy,w,h);                
                ptb.SizeMode = PictureBoxSizeMode.StretchImage;
                ptb.Size = new Size((groupBox1.Width / tex1), (groupBox1.Height / tex2));
                x += groupBox1.Width / tex1;
                xx += resim.Width / tex1;
                if (x == (groupBox1.Width / tex1) * tex1)
                {
                    y += groupBox1.Height / tex1;
                    x = 0;
                    yy += resim.Height / tex2;
                    xx = 0;
                }
                this.groupBox1.Controls.Add(ptb);            
               
            }
           

        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBox1.Controls.Clear();
            //((Image)this.Controls["resim"]).Dispose();
            x = 0;
            y = 0;
            btnoluştur();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            int w = groupBox1.Width / Convert.ToInt32(textBox1.Text);
            int h = groupBox1.Height / Convert.ToInt32(textBox2.Text);
            for (int i = 1; i <= Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox2.Text); i++)
            {

                ((PictureBox)this.groupBox1.Controls["ptb"+i]).Size = new Size(w, h);
                ((PictureBox)this.groupBox1.Controls["ptb" + i]).Location = new Point(x, y);
                x += groupBox1.Width / Convert.ToInt32(textBox1.Text);
                if (x == (groupBox1.Width / Convert.ToInt32(textBox1.Text) * Convert.ToInt32(textBox1.Text)))
                {
                    y += groupBox1.Height / Convert.ToInt32(textBox2.Text);
                    x = 0;
                }
            }
        }
        OpenFileDialog dia = new OpenFileDialog();
        private void button2_Click(object sender, EventArgs e)
        {
            
            dia.ShowDialog();
            pictureBox1.Image =new Bitmap(dia.FileName);
        }

        
    }
}
