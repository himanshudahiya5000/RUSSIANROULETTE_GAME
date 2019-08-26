using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Media;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace RUSSIANROULETTE_GAME
{
    public partial class RUSSIANROULETTE_GAME : Form
    {
        GameLogic GAME = new GameLogic();// Defining the object (GAME) of the GameLogic Class


        public object PicBox_Main { get; private set; }
        public static object Properties { get; private set; }

        public RUSSIANROULETTE_GAME()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Spin.Enabled = false;
            btn_Shoot.Enabled = false;
            btn_Shootaway.Enabled = false;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.man.png");
            Bitmap bmp = new Bitmap(myStream);
            man.Image = bmp;

        }

        private void Load_button_Click(object sender, EventArgs e)
        {
            // GAME.Load(); //Calling Load function from GameLogic Class
            btn_Load.Enabled = false; // Disabling Load button
            btn_Spin.Enabled = true;
            btn_Shoot.Enabled = false;
            btn_Shootaway.Enabled = false;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.man.png");
            Bitmap bmp = new Bitmap(myStream);
            //Bitmap bmp = new Bitmap(@"C:\Users\jbmanukau\GAGAN\RUSSIANROULETTE_GAME\man.png");
            //Bitmap bmp = new Bitmap(@"C:\RUSSIANROULETTE_GAME.Properties.Resources.man1.png");
            gun.Image = bmp;

        }

        private void Spin_button_Click(object sender, EventArgs e)
        {
            // GAME.Spin(); //Calling Spin function from GameLogic Class
            btn_Load.Enabled = false;
            btn_Spin.Enabled = false;
            btn_Shoot.Enabled = true;
            btn_Shootaway.Enabled = true;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.gun01.jpg");
            Bitmap bmp = new Bitmap(myStream);

            gun.Image = bmp;
            SoundPlayer player = new SoundPlayer(Resource1.spinnn);
            player.Play();
            GAME.RNDNumber = GAME.RNDNumbergenerate();
        }

        private void Shoot_button_Click(object sender, EventArgs e)
        {
            //GAME.Shoot(); //Calling Shoot function from GameLogic Class
            btn_Load.Enabled = false;
            btn_Spin.Enabled = false;
            btn_Shoot.Enabled = true;
            btn_Shootaway.Enabled = true;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.gun011.jpg");
            Bitmap bmp = new Bitmap(myStream);
            gun.Image = bmp;
            SoundPlayer player = new SoundPlayer(Resource1.gun);
            player.Play();
            GAME.Shoot_button = GAME.Shoot();
            lblShots.Text = GAME.Shoot_button.ToString();
        }

        private void Shootaway_button_Click(object sender, EventArgs e)
        {
            //GAME.ShootAway_button(); //Calling Shoot Away function from GameLogic Class
            btn_Load.Enabled = false;
            btn_Spin.Enabled = false;
            btn_Shoot.Enabled = true;
            btn_Shootaway.Enabled = true;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.man.png");
            Bitmap bmp = new Bitmap(myStream);
            man.Image = bmp;

            SoundPlayer player = new SoundPlayer(Resource1.gun);
            player.Play();
            GAME.ShootAway_button = GAME.Shootaway(Shootaway);
            lbllives.Text = GAME.ShootAway_button.ToString();

        }

        private void Playagain_button_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            btn_Load.Enabled = true;
            btn_Spin.Enabled = false;
            btn_Shoot.Enabled = false;
            btn_Shootaway.Enabled = false;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("RUSSIANROULETTE_GAME.Resources.man.png");
            Bitmap bmp = new Bitmap(myStream);
            man.Image = bmp;

        }
        public void endgame_Check()
        {
            if (lblShots.Text == GAME.RNDNumber.ToString())

            {
                GAME.lose = GAME.losegame();
                lblwinlose.Text = GAME.lose;
                btn_Shoot.Enabled = false;
                btn_Load.Enabled = false;
                btn_Spin.Enabled = false;
                btn_Playagain.Enabled = false;
                GAME.losescore++;
                lblloses.Text = GAME.losescore.ToString();


            }

        }
        public void fireattempt()
        {
            if (lblShots.Text == GAME.RNDNumber.ToString())
            {
                GAME.losescore--;
                endgame_Check();
            }
        }
        public void Shootaway()
        {
            
            
                GAME.winscore++;
                lblwin.Text = GAME.winscore.ToString();
            

        }
    }
}

