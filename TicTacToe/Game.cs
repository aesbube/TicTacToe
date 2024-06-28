using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        public Player Player1 {  get; set; }
        public Player Player2 { get; set; }
        public Player Winner {  get; set; }
        public Round currentRound {  get; set; }
        public char[,] matrix {  get; set; }
        public List<Button> buttons {  get; set; }
        public WholeGame game {  get; set; }
        public Image Sign {  get; set; }
        public bool Turn {  get; set; }
        public int TilesLeft { get; set; }
        public char SignChar { get; set; }

        public TicTacToe()
        {
            this.game = new WholeGame();
            this.Sign = Properties.Resources.X;
            this.SignChar = 'x';
            this.Turn = true;
            this.Player1 = game.Player1 as Player;
            this.Player2 = game.Player2 as Player;
            this.Winner = null;
            this.matrix = new char[3, 3];
            this.buttons = new List<Button>();
            this.TilesLeft = 9;
            this.currentRound = new Round(game.Player1, game.Player2);
            InitializeComponent();            
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            StartRound();
            updateLabels();
        }

        public void updateLabels()
        {
            RoundLabel.Text = this.TilesLeft.ToString();
            Player1_label.Text = game.Player1.Name;
            Player2_label.Text = game.Player2.Name;
            Round.Text = game.Rounds.Count.ToString();
            MaxRounds.Text = game.MaxRounds.ToString();
            Player1_wins.Text = game.Player1.NumberWins.ToString();
            Player2_wins.Text = game.Player2.NumberWins.ToString();
            if (this.Turn == true)
            {
                PlayerTurn.Text = Player1.Name;
            } else 
            {
                PlayerTurn.Text = Player2.Name;
            }
            
        }

        private void TicTacToe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to end the game?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Close();
                Environment.Exit(1);    
                e.Cancel = true;
            } else
            {
                e.Cancel = false;
            }
        }

        public void NewGame()
        {
            this.game = new WholeGame();
            this.Sign = Properties.Resources.X;
            this.SignChar = 'x';
            this.Turn = true;
            this.Player1 = game.Player1 as Player;
            this.Player2 = game.Player2 as Player;
            this.Winner = null;
            this.matrix = new char[3, 3];
            this.buttons = new List<Button>();
            this.TilesLeft = 9;
            this.currentRound = new Round(game.Player1, game.Player2);
            GameSetUp setUp = new GameSetUp();
            this.Hide();
            setUp.ShowDialog();
            this.Close();
        }

        public void StartRound()
        {
            this.currentRound = new Round(game.Player1, game.Player2);
            this.game.AddRound(this.currentRound);
            if (game.Rounds.Count % 2 == 0)
            {
                this.SignChar = 'o';
                this.Sign = Properties.Resources.O;
                this.Turn = false;
            }
            else
            {
                this.SignChar = 'x';
                this.Sign = Properties.Resources.X;
                this.Turn = true;
            }
            this.TilesLeft = 9; 
            this.Winner = null;
            this.buttons = new List<Button>();
            AddButtons();
            foreach (Button button in this.buttons)
            {
                button.BackgroundImage = null;
            }
            this.matrix = new char[3, 3];
            this.updateLabels();
        }

        private void Change_Next_Sign()
        {
            if (this.Turn == true)
            {
                this.Sign = Properties.Resources.O;
                this.Turn = false;
            } else
            {
                this.Sign = Properties.Resources.X;
                this.Turn = true;
            }
        }

        private void AddButtons()
        {
            buttons.Add(Tile1);
            buttons.Add(Tile2);
            buttons.Add(Tile3);
            buttons.Add(Tile4);
            buttons.Add(Tile5);
            buttons.Add(Tile6);
            buttons.Add(Tile7);
            buttons.Add(Tile8);
            buttons.Add(Tile9);

            for (int i = 0; i < 9; i++)
            {
                buttons[i].Click += new EventHandler(Tile_Click);
            }
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button Tile = sender as Button;
            Tile.BackgroundImage = this.Sign;
            char Sign = 'x';
            if (!this.Turn)
            {
                Sign = 'o';
            }

            switch (Tile.Name)
            {
                case "Tile1":
                    this.matrix[0, 0] = Sign;
                    this.buttons[0].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile2":
                    this.matrix[0, 1] = Sign;
                    this.buttons[1].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile3":
                    this.matrix[0, 2] = Sign;
                    this.buttons[2].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile4":
                    this.matrix[1, 0] = Sign;
                    this.buttons[3].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile5":
                    this.matrix[1, 1] = Sign;
                    this.buttons[4].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile6":
                    this.matrix[1, 2] = Sign;
                    this.buttons[5].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile7":
                    this.matrix[2, 0] = Sign;
                    this.buttons[6].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile8":
                    this.matrix[2, 1] = Sign;
                    this.buttons[7].Click -= new EventHandler(this.Tile_Click);
                    break;
                case "Tile9":
                    this.matrix[2, 2] = Sign;
                    this.buttons[8].Click -= new EventHandler(this.Tile_Click);
                    break;

            }
            this.TilesLeft -= 1;
            if (isWonGame())
            {
                this.updateLabels();
                this.currentRound.IsRoundOver = true;
                if (!isGameOver()){
                    MessageBox.Show($"The winner is: {Winner.Name}", "Round Winner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartRound();
                }
            }
            else if (isTieGame())
            {
                this.updateLabels();
                this.currentRound.IsRoundOver = true;
                if (!isGameOver())
                {
                    MessageBox.Show($"It's a tie!", "Round Tie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartRound();
                }
            } else { 
                this.Change_Next_Sign();
                this.updateLabels();
            }
        }

        
    }
}
