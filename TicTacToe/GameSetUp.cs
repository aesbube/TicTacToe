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
        }


        private void start_Click(object sender, EventArgs e)
        {
            Player1 = player1.Text;
            Player2 = player2.Text;
            MaxRounds = (int)numberOfRounds.Value;
            TicTacToe game = new TicTacToe();
            this.Hide();
            game.ShowDialog();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void player1_Validating(object sender, CancelEventArgs e)
        {
            if (player1.Text == "")
            {
                errorPlayer1.SetError(player1, "Must enter player name");
                e.Cancel = true;
            } else
            {
                errorPlayer1.SetError(player1, null);
                e.Cancel = false;
            }
        }

        private void player2_Validating(object sender, CancelEventArgs e)
        {
            if (player2.Text == "")
            {
                errorPlayer2.SetError(player2, "Must enter player name");
                e.Cancel = true;
            }
            else
            {
                errorPlayer2.SetError(player2, null);
                e.Cancel = false;
            }
        }

    }
}
