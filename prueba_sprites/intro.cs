using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace prueba_sprites
{
    public partial class intro : Form
    {
        public intro()
        {
            InitializeComponent();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pantalla qwer = new pantalla();
            qwer.Show();
            this.Hide();
        }

        private void intro_Load(object sender, EventArgs e)
        {
            SoundPlayer cancion = new SoundPlayer(Application.StartupPath + @"\son\intro.wav");
            cancion.Play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
