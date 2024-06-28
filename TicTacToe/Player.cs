using System;

namespace TicTacToe
{
    public class Player
    {
        public String Name { get; set; }
        public int NumberWins { get; set; }
        public String Sign {  get; set; }

        public Player(String name)
        {
            this.Name = name;
            this.Sign = "X";
            this.NumberWins = 0;
        }

        public void IncreaseNumerWins()
        {
            this.NumberWins += 1;
        }

        public void ChangeSign()
        {
            this.Sign = "O";
        }




    }
}
