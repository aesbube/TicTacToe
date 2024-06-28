namespace TicTacToe
{
    public class Round
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public bool IsGameOver { get; set; }
        public int TilesLeft { get; set; }
        public bool IsRoundOver { get; set; }
        public Round(Player Player1, Player Player2) { 
            this.Player1 = Player1;
            this.Player2 = Player2;
            this.IsGameOver = false;
            this.TilesLeft = 9;
            this.IsRoundOver = false;
            this.TilesLeft = TilesLeft;
        }


    }
}
