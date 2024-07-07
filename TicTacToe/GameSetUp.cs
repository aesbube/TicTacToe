using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class GameSetUp : Form
    {
        public static String Player1;
        public static String Player2;
        public static int MaxRounds;

        public GameSetUp()
        {
            InitializeComponent();
            player1.TextChanged += new EventHandler(player1_TextChanged);
            player2.TextChanged += new EventHandler(player2_TextChanged);
        }

        private void GameSetUp_Load(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(player1.Text) || string.IsNullOrEmpty(player2.Text))
            {
                start.Enabled = false;
            }
            else
            {
                start.Enabled = true;
                Player1 = player1.Text;
                Player2 = player2.Text;
                MaxRounds = (int)numberOfRounds.Value;
                TicTacToe game = new TicTacToe();
                this.Hide();
                game.ShowDialog();
                this.Close();
            }
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void player1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(player1.Text))
            {
                errorPlayer1.SetError(player1, "Must enter player name");
                e.Cancel = true;
            }
            else
            {
                errorPlayer1.SetError(player1, null);
                e.Cancel = false;
            }
            ValidateInput();
        }

        private void player2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(player2.Text))
            {
                errorPlayer2.SetError(player2, "Must enter player name");
                e.Cancel = true;
            }
            else
            {
                errorPlayer2.SetError(player2, null);
                e.Cancel = false;
            }
            ValidateInput();
        }

        private void ValidateInput()
        {
            bool player1Valid = !string.IsNullOrEmpty(player1.Text);
            bool player2Valid = !string.IsNullOrEmpty(player2.Text);

            start.Enabled = player1Valid && player2Valid;
        }

        private void player1_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }

        private void player2_TextChanged(object sender, EventArgs e)
        {
            ValidateInput();
        }
    }
}