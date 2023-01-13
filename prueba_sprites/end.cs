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
    public partial class end : Form
    {
        public end()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            intro yyy = new intro();
            yyy.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void end_Load(object sender, EventArgs e)
        {
            SoundPlayer cancion = new SoundPlayer(Application.StartupPath + @"\son\end.wav");
            cancion.Play();
        }
    }
}
