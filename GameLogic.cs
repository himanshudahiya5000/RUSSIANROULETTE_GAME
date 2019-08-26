using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RUSSIANROULETTE_GAME
{
    public class GameLogic
    {
        public int RNDNumber { get; set; }
        public string win { get; set; }
        public string lose { get; set; }
        public int Shoot_button { get; set; }
        public int ShootAway_button { get; set; } = 2;
        public int winscore { get; set; } = 0;
        public int losescore { get; set; } = 0;
        public string Messagebox { get; set; }

        public int RNDNumbergenerate()
        {
            Random myrandom = new Random();
            return myrandom.Next(1, 6);
        }
        public string wingame()
        {
            win = "you won";
            return win;

        }
        public string losegame()
        {
            lose = "you lose";
            return lose;

        }
        public string Messageboxgame()
        {
            MessageBox.Show("you won");
            
            return Messagebox;
        }
        public int Shoot()
        {
            Shoot_button++;
            if (Shoot_button > 6)
            {
                MessageBox.Show("no more shots");
                Shoot_button = 0;
            }
                    
            return Shoot_button; 
            

        }
       
       public int Shootaway(int shootaway)
        {
            ShootAway_button--;
            if (ShootAway_button <0)
            {
                MessageBox.Show("no more shots");
                ShootAway_button = 2;
            }
            return ShootAway_button;
        }

        internal int Shootaway(Action shootaway)
        {
            throw new NotImplementedException();
        }
    }
}
