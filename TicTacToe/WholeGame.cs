using System.Collections.Generic;

namespace TicTacToe
{
    public class WholeGame
    {
        public List<Round> Rounds { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int MaxRounds { get; set; }
        public WholeGame() {
            this.Player1 = new Player(GameSetUp.Player1); 
            this.Player2 = new Player(GameSetUp.Player2);
            this.MaxRounds = GameSetUp.MaxRounds;
            this.Rounds = new List<Round>();
        }

        public void AddRound(Round round)
        {
            this.Rounds.Add(round);
        }
        
        

    }
}
