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
    public partial class pantalla : Form
    {
        Image[] sprites = new Image[21]; //numero de sprites
        bool izq, der, jump;
        string direccion = "derecha";
        int contadormovimiento;
        int contadortimer = 0;
        int alto = 25, gravedad;
        bool volteaunasolavez = false;
        Point soniccorde;
        int u = 14;
        int score = 0;
        public pantalla()
        {
            InitializeComponent();

            // se inicializan las imagenes 
            sprites[0] = prueba_sprites.Properties.Resources.Sonic_1;
            sprites[1] = prueba_sprites.Properties.Resources.Correr1;
            sprites[2] = prueba_sprites.Properties.Resources.Correr2;
            sprites[3] = prueba_sprites.Properties.Resources.Correr3;
            sprites[4] = prueba_sprites.Properties.Resources.Correr4;
            sprites[5] = prueba_sprites.Properties.Resources.Correr5;
            sprites[6] = prueba_sprites.Properties.Resources.Correr6;
            sprites[7] = prueba_sprites.Properties.Resources.Correr7;
            sprites[8] = prueba_sprites.Properties.Resources.Correr8;
            sprites[9] = prueba_sprites.Properties.Resources.Correr9;
            sprites[10] = prueba_sprites.Properties.Resources.Correr10;
            sprites[11] = prueba_sprites.Properties.Resources.Correr11;
            sprites[12] = prueba_sprites.Properties.Resources.Correr12;
            sprites[13] = prueba_sprites.Properties.Resources.Salto;

            sprites[14] = prueba_sprites.Properties.Resources.super1;
            sprites[15] = prueba_sprites.Properties.Resources.super2;
            sprites[16] = prueba_sprites.Properties.Resources.super3;
            sprites[17] = prueba_sprites.Properties.Resources.super4;
            sprites[18] = prueba_sprites.Properties.Resources.super5;
            sprites[19] = prueba_sprites.Properties.Resources.super6;
            sprites[20] = prueba_sprites.Properties.Resources.super7;


            sonic.Image = sprites[0]; // hace que aparezca en su pocision natural
            sonic.Image = sprites[13]; ;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                if (direccion == "izquierda")
                {
                    direccion = "derecha";

                    if (volteaunasolavez == false)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            sprites[i].RotateFlip(RotateFlipType.Rotate180FlipY);
                        }
                    }
                }

                der = true;


            }


            if (e.KeyCode == Keys.A)
            {
                if (direccion == "derecha")
                {
                    direccion = "izquierda";


                    if (volteaunasolavez == false)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            sprites[i].RotateFlip(RotateFlipType.Rotate180FlipY);
                        }



                    }
                }

                izq = true;

            }

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    label2.Text = score.ToString();
                    score++;
                    jump = true;
                    gravedad = alto;
                    sonic.Image = sprites[13];
                }
            }
        }

        private void movimiento()
        {
            sonic.Image = sprites[contadormovimiento];


            if (contadortimer % 6 == 0) // rapidez del movimiento
            {
                contadormovimiento++;
            }


            if (contadormovimiento == 13) //vuelve a iniciar el contador del movimiento
            {
                contadormovimiento = 10;
            }
            contadortimer++;
        }
    
        

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D)
            {
                der = false;
                sonic.Image = sprites[0];
                contadormovimiento = 0;  // hace que se quede en su pocision natural
            }

            if(e.KeyCode == Keys.A)
            {
                izq = false;
                sonic.Image = sprites[0];
                contadormovimiento = 0;    // hace que se quede en su pocision natural
            }

        }

        private void timer1_Tick(object sender, EventArgs e) //el intervalo del timer tiene que estar en 1
        {

           
            if (der == true)
            {
                sonic.Left += 5;
                movimiento();
            }


            if (izq == true)
            {
                sonic.Left -= 5;
                movimiento();
            }

            if (jump == true)
            {
                sonic.Top -= gravedad; //sube
                gravedad -= 1;
            }

            if (sonic.Top + sonic.Height >= this.Height)
            {
                sonic.Top = (this.Height) - sonic.Height;
                jump = false;
            }
            else
            {
                sonic.Top += 5;
            }

            soniccorde = sonic.Location;

            /*if (sonic.Location.X + sonic.Width >= this.Height)
            {
                soniccorde.X = this.Height - sonic.Width;
            }
            else if (sonic.Location.X <= 0)
            {
                soniccorde.X = 0;
            }
            if (sonic.Location != soniccorde)
            
                sonic.Location = soniccorde;
            }
             */

            if (sonic.Left + sonic.Width - 1 > piso1.Left && sonic.Left + sonic.Width + 5 < piso1.Left + piso1.Width + sonic.Width
                            && sonic.Top + sonic.Height >= piso1.Top && sonic.Top < piso1.Top)
            {
                sonic.Top = piso1.Location.Y - sonic.Height;
                gravedad = 0;
                jump = false;
            }
            if (suelo.Bounds.IntersectsWith(sonic.Bounds))
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("GAME OVER");
                button1.Visible = true;
            }


            if (sonic.Bounds.IntersectsWith(esmeraldas.Bounds))
            {
                timer1.Stop();
                timer3.Start();


            }
         
            


            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer cancion = new SoundPlayer(Application.StartupPath + @"\son\green.wav");
            cancion.Play();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //piso2
            if (sonic.Left + sonic.Width - 1 > piso2.Left && sonic.Left + sonic.Width + 5 < piso2.Left + piso1.Width + sonic.Width
                            && sonic.Top + sonic.Height >= piso2.Top && sonic.Top < piso2.Top)
            {
                sonic.Top = piso2.Location.Y - sonic.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic.Bounds.IntersectsWith(piso2.Bounds) && sonic.Right >= piso2.Left && sonic.Left <= piso2.Right)
            {
                
                jump = false;
            }


            //piso3
            if (sonic.Left + sonic.Width - 1 > piso3.Left && sonic.Left + sonic.Width + 5 < piso3.Left + piso3.Width + sonic.Width
                            && sonic.Top + sonic.Height >= piso3.Top && sonic.Top < piso3.Top)
            {
                sonic.Top = piso3.Location.Y - sonic.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic.Bounds.IntersectsWith(piso1.Bounds) && sonic.Right >= piso3.Left && sonic.Left <= piso3.Right)
            {
               
                jump = false;
            }


            //piso4
            if (sonic.Left + sonic.Width - 1 > piso4.Left && sonic.Left + sonic.Width + 5 < piso4.Left + piso4.Width + sonic.Width
                            && sonic.Top + sonic.Height >= piso4.Top && sonic.Top < piso4.Top)
            {
                sonic.Top = piso4.Location.Y - sonic.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic.Bounds.IntersectsWith(piso4.Bounds) && sonic.Right >= piso4.Left && sonic.Left <= piso4.Right)
            {
                jump = false;
            }


            //piso5
            if (sonic.Left + sonic.Width - 1 > piso5.Left && sonic.Left + sonic.Width + 5 < piso5.Left + piso5.Width + sonic.Width
                            && sonic.Top + sonic.Height >= piso5.Top && sonic.Top < piso5.Top)
            {
                sonic.Top = piso5.Location.Y - sonic.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic.Bounds.IntersectsWith(piso5.Bounds) && sonic.Right >= piso5.Left && sonic.Left <= piso5.Right)
            {
                jump = false;
            }





            piso2.Left -= 4;
            if (piso2.Left < -100)
            {
                piso2.Left =  800;
            }

            piso3.Left += 4;
            if (piso3.Left > 800)
            {
                piso3.Left = 100;
            }

            piso4.Left -= 5;
            if (piso4.Left < -100)
            {
                piso4.Left = 800;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pantalla aa = new pantalla();
            aa.Show();
            this.Hide();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (u > 20)
            {
                timer3.Stop();
                MessageBox.Show("YOU WIN! SIIUUUU");
                button2.Visible = true;
            }
            else
            {

                sonic.Image = sprites[u];
                timer1.Stop();
            }
            u++;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            sonic.Image = sprites[0];

            level2 ee = new level2();
            ee.Show();
            this.Hide();
            timer3.Stop();

        }
    }
}
