using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prueba_sprites
{
    public partial class level2 : Form
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
        public level2()
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


            sonic_1.Image = sprites[0]; // hace que aparezca en su pocision natural
            sonic_1.Image = sprites[13]; 
        }

        private void level2_Load(object sender, EventArgs e)
        {

        }

        private void level2_KeyDown(object sender, KeyEventArgs e)
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
                    sonic_1.Image = sprites[13];
                    
                }
            }
        }

        private void movimiento()
        {
            sonic_1.Image = sprites[contadormovimiento];


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

        private void level2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                der = false;
                sonic_1.Image = sprites[0];
                contadormovimiento = 0;  // hace que se quede en su pocision natural
            }

            if (e.KeyCode == Keys.A)
            {
                izq = false;
                sonic_1.Image = sprites[0];
                contadormovimiento = 0;    // hace que se quede en su pocision natural
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
            
            if (der == true)
            {
                sonic_1.Left += 5;
                movimiento();
            }


            if (izq == true)
            {
                sonic_1.Left -= 5;
                movimiento();
            }

            if (jump == true)
            {
                sonic_1.Top -= gravedad; //sube
                gravedad -= 1;
            }

            if (sonic_1.Top + sonic_1.Height >= this.Height)
            {
                sonic_1.Top = (this.Height) - sonic_1.Height;
                jump = false;
            }
            else
            {
                sonic_1.Top += 5;
            }

            soniccorde = sonic_1.Location;

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

            if (sonic_1.Left + sonic_1.Width - 1 > piso_1.Left && sonic_1.Left + sonic_1.Width + 5 < piso_1.Left + piso_1.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_1.Top && sonic_1.Top < piso_1.Top)
            {
                sonic_1.Top = piso_1.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (suelo2.Bounds.IntersectsWith(sonic_1.Bounds))
            {
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("GAME OVER");
                button1.Visible = true;
            }


            if (sonic_1.Bounds.IntersectsWith(esmeraldas_1.Bounds))
            {
                button2.Visible = true;
                timer1.Stop();
                timer3.Start();


            }
         
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            label2.Text = score.ToString();
            //piso2
            if (sonic_1.Left + sonic_1.Width - 1 > piso_2.Left && sonic_1.Left + sonic_1.Width + 5 < piso_2.Left + piso_1.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_2.Top && sonic_1.Top < piso_2.Top)
            {
                sonic_1.Top = piso_2.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic_1.Bounds.IntersectsWith(piso_2.Bounds) && sonic_1.Right >= piso_2.Left && sonic_1.Left <= piso_2.Right)
            {
                score = 1;
                jump = false;
            }


            //piso3
            if (sonic_1.Left + sonic_1.Width - 1 > piso_3.Left && sonic_1.Left + sonic_1.Width + 5 < piso_3.Left + piso_3.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_3.Top && sonic_1.Top < piso_3.Top)
            {
                sonic_1.Top = piso_3.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic_1.Bounds.IntersectsWith(piso_1.Bounds) && sonic_1.Right >= piso_3.Left && sonic_1.Left <= piso_3.Right)
            {
               
                jump = false;
            }


            //piso4
            if (sonic_1.Left + sonic_1.Width - 1 > piso_4.Left && sonic_1.Left + sonic_1.Width + 5 < piso_4.Left + piso_4.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_4.Top && sonic_1.Top < piso_4.Top)
            {
                sonic_1.Top = piso_4.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic_1.Bounds.IntersectsWith(piso_4.Bounds) && sonic_1.Right >= piso_4.Left && sonic_1.Left <= piso_4.Right)
            {
                jump = false;
            }


            //piso5
            if (sonic_1.Left + sonic_1.Width - 1 > piso_5.Left && sonic_1.Left + sonic_1.Width + 5 < piso_5.Left + piso_5.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_5.Top && sonic_1.Top < piso_5.Top)
            {
                sonic_1.Top = piso_5.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic_1.Bounds.IntersectsWith(piso_5.Bounds) && sonic_1.Right >= piso_5.Left && sonic_1.Left <= piso_5.Right)
            {
                jump = false;
            }

            //piso6
            if (sonic_1.Left + sonic_1.Width - 1 > piso_6.Left && sonic_1.Left + sonic_1.Width + 5 < piso_6.Left + piso_6.Width + sonic_1.Width
                            && sonic_1.Top + sonic_1.Height >= piso_6.Top && sonic_1.Top < piso_6.Top)
            {
                sonic_1.Top = piso_6.Location.Y - sonic_1.Height;
                gravedad = 0;
                jump = false;
            }
            if (sonic_1.Bounds.IntersectsWith(piso_5.Bounds) && sonic_1.Right >= piso_6.Left && sonic_1.Left <= piso_6.Right)
            {
                jump = false;
            }




            piso_2.Top -= 4;
            if (piso_2.Top < -100)
            {
                piso_2.Top = 500;
            }

            piso_3.Left += 4;
            if (piso_3.Left > 800)
            {
                piso_3.Left = 100;
            }

            piso_4.Left -= 5;
            if (piso_4.Left < -100)
            {
                piso_4.Left = 900;
            }

            piso_5.Top -= 5;
            if (piso_5.Top < -100)
            {
                piso_5.Top = 500;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (u > 20)
            {
                timer3.Stop();
                MessageBox.Show("YOU WIN ");
                
            }
            else
            {

                sonic_1.Image = sprites[u];
                timer1.Stop();
            }
            u++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pantalla aa = new pantalla();
            aa.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
       
            end eeee = new end();
            eeee.Show();
            this.Hide();
        }
    }
}
