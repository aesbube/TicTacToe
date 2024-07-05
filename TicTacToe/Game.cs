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
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player Winner { get; set; }
        public Round currentRound { get; set; }
        public char[,] matrix { get; set; }
        public List<Button> buttons { get; set; }
        public WholeGame game { get; set; }
        public Image Sign { get; set; }
        public bool Turn { get; set; }
        public int TilesLeft { get; set; }
        public char SignChar { get; set; }
        private bool isGameEnding = false;
        private bool isQuittingGame = false;
        private bool hasConfirmedQuit = false;
        public TicTacToe()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
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
            AddButtons();
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            StartRound();
            updateLabels();
        }

        public void updateLabels()
        {
            Player1_label.Text = game.Player1.Name;
            Player2_label.Text = game.Player2.Name;
            Round.Text = game.Rounds.Count.ToString();
            MaxRounds.Text = game.MaxRounds.ToString();
            Player1_wins.Text = game.Player1.NumberWins.ToString();
            Player2_wins.Text = game.Player2.NumberWins.ToString();
            if (this.Turn == true)
            {
                PlayerTurn.Text = Player1.Name;
            }
            else
            {
                PlayerTurn.Text = Player2.Name;
            }

        }

        private void TicTacToe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!hasConfirmedQuit)
            {
                if (!isQuittingGame && !isGameEnding)
                {
                    isGameEnding = true;
                    DialogResult result = MessageBox.Show("Are you sure you want to end the game?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                        isGameEnding = false;
                    }
                    else
                    {
                        hasConfirmedQuit = true;
                        isQuittingGame = true;
                        Environment.Exit(1);
                    }
                }
            }
            else if (hasConfirmedQuit)
            {
                Environment.Exit(0);
            }
        }

        public void NewGame()
        {
            hasConfirmedQuit = false;
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
                button.Enabled = true;
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
                this.SignChar = 'o';
            }
            else
            {
                this.Sign = Properties.Resources.X;
                this.Turn = true;
                this.SignChar = 'x';
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
                buttons[i].Click -= Tile_Click;
                buttons[i].Click += Tile_Click;
            }
        }

        private bool isWonGame()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (matrix[row, 0] != '\0' && matrix[row, 0] == matrix[row, 1] && matrix[row, 1] == matrix[row, 2])
                {
                    SetWinner(matrix[row, 0]);
                    return true;
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (matrix[0, col] != '\0' && matrix[0, col] == matrix[1, col] && matrix[1, col] == matrix[2, col])
                {
                    SetWinner(matrix[0, col]);
                    return true;
                }
            }

            // Check diagonals
            if (matrix[0, 0] != '\0' && matrix[0, 0] == matrix[1, 1] && matrix[1, 1] == matrix[2, 2])
            {
                SetWinner(matrix[0, 0]);
                return true;
            }

            if (matrix[0, 2] != '\0' && matrix[0, 2] == matrix[1, 1] && matrix[1, 1] == matrix[2, 0])
            {
                SetWinner(matrix[0, 2]);
                return true;
            }

            return false;
        }

        private void SetWinner(char winningSymbol)
        {
            if (winningSymbol == 'x')
            {
                this.Winner = Player1;
                Player1.IncreaseNumerWins();
            }
            else if (winningSymbol == 'o')
            {
                this.Winner = Player2;
                Player2.IncreaseNumerWins();
            }
        }

        private bool isGameOver()
        {
            if (this.game.Rounds.Count == this.game.MaxRounds)
            {
                String winner = Player1.Name;
                if (Player2.NumberWins > Player1.NumberWins)
                {
                    winner = Player2.Name;
                }
                if (Player2.NumberWins == Player1.NumberWins)
                {
                    if (MessageBox.Show($"It's a tie! Want to play another game?", "Game Tie", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        NewGame();
                        return true;
                    }
                    else
                    {
                        this.Close();
                        return true;
                    }
                }

                if (MessageBox.Show($"The winner of the game is: {winner}! Want to play another game?", "Game Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    NewGame();
                    return true;
                }
                else
                {
                    this.Close();
                    return true;
                }
            }
            return false;
        }


        private bool isTieGame()
        {
            return this.TilesLeft == 0;
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button Tile = sender as Button;

            if (Tile.BackgroundImage != null)
            {
                return;
            }

            Tile.BackgroundImage = this.Sign;
            char Sign = this.SignChar;

            switch (Tile.Name)
            {
                case "Tile1":
                    this.matrix[0, 0] = Sign;
                    break;
                case "Tile2":
                    this.matrix[0, 1] = Sign;
                    break;
                case "Tile3":
                    this.matrix[0, 2] = Sign;
                    break;
                case "Tile4":
                    this.matrix[1, 0] = Sign;
                    break;
                case "Tile5":
                    this.matrix[1, 1] = Sign;
                    break;
                case "Tile6":
                    this.matrix[1, 2] = Sign;
                    break;
                case "Tile7":
                    this.matrix[2, 0] = Sign;
                    break;
                case "Tile8":
                    this.matrix[2, 1] = Sign;
                    break;
                case "Tile9":
                    this.matrix[2, 2] = Sign;
                    break;
            }
            Tile.Enabled = false;

            this.TilesLeft -= 1;
            if (isWonGame())
            {
                this.updateLabels();
                this.currentRound.IsRoundOver = true;
                if (!isGameOver())
                {
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
            }
            else
            {
                this.Change_Next_Sign();
                this.updateLabels();
            }
        }

        private void QuitGame_Click(object sender, EventArgs e)
        {
            if (!hasConfirmedQuit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to end the game?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    hasConfirmedQuit = true;
                    isQuittingGame = true;
                    this.Close();
                }
            }
            else
            {
                isQuittingGame = true;
                this.Close();
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to start a new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                NewGame();
            }
        }
    }
}
