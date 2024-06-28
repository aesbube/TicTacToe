namespace TicTacToe
{
    partial class GameSetUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSetUp));
            this.numberOfRounds_label = new System.Windows.Forms.Label();
            this.player2_label = new System.Windows.Forms.Label();
            this.player1_label = new System.Windows.Forms.Label();
            this.numberOfRounds = new System.Windows.Forms.NumericUpDown();
            this.player2 = new System.Windows.Forms.TextBox();
            this.player1 = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.errorPlayer1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPlayer2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // numberOfRounds_label
            // 
            this.numberOfRounds_label.AutoSize = true;
            this.numberOfRounds_label.BackColor = System.Drawing.Color.Transparent;
            this.numberOfRounds_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.numberOfRounds_label.Location = new System.Drawing.Point(162, 176);
            this.numberOfRounds_label.Name = "numberOfRounds_label";
            this.numberOfRounds_label.Size = new System.Drawing.Size(119, 16);
            this.numberOfRounds_label.TabIndex = 9;
            this.numberOfRounds_label.Text = "Number of Rounds";
            // 
            // player2_label
            // 
            this.player2_label.AutoSize = true;
            this.player2_label.BackColor = System.Drawing.Color.Transparent;
            this.player2_label.Location = new System.Drawing.Point(162, 114);
            this.player2_label.Name = "player2_label";
            this.player2_label.Size = new System.Drawing.Size(56, 16);
            this.player2_label.TabIndex = 10;
            this.player2_label.Text = "Player 2";
            // 
            // player1_label
            // 
            this.player1_label.AutoSize = true;
            this.player1_label.BackColor = System.Drawing.Color.Transparent;
            this.player1_label.Location = new System.Drawing.Point(162, 53);
            this.player1_label.Name = "player1_label";
            this.player1_label.Size = new System.Drawing.Size(56, 16);
            this.player1_label.TabIndex = 11;
            this.player1_label.Text = "Player 1";
            // 
            // numberOfRounds
            // 
            this.numberOfRounds.Location = new System.Drawing.Point(165, 151);
            this.numberOfRounds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfRounds.Name = "numberOfRounds";
            this.numberOfRounds.Size = new System.Drawing.Size(132, 22);
            this.numberOfRounds.TabIndex = 8;
            this.numberOfRounds.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // player2
            // 
            this.player2.Location = new System.Drawing.Point(165, 89);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(132, 22);
            this.player2.TabIndex = 6;
            this.player2.Validating += new System.ComponentModel.CancelEventHandler(this.player2_Validating);
            // 
            // player1
            // 
            this.player1.Location = new System.Drawing.Point(165, 28);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(132, 22);
            this.player1.TabIndex = 7;
            this.player1.Validating += new System.ComponentModel.CancelEventHandler(this.player1_Validating);
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(32, 216);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(153, 40);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel Game";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // start
            // 
            this.start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.start.Location = new System.Drawing.Point(295, 215);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(150, 41);
            this.start.TabIndex = 5;
            this.start.Text = "Start Game";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // errorPlayer1
            // 
            this.errorPlayer1.ContainerControl = this;
            // 
            // errorPlayer2
            // 
            this.errorPlayer2.ContainerControl = this;
            // 
            // GameSetUp
            // 
            this.AcceptButton = this.start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(477, 277);
            this.Controls.Add(this.numberOfRounds_label);
            this.Controls.Add(this.player2_label);
            this.Controls.Add(this.player1_label);
            this.Controls.Add(this.numberOfRounds);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.start);
            this.Name = "GameSetUp";
            this.Text = "Game Set Up";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfRounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label numberOfRounds_label;
        private System.Windows.Forms.Label player2_label;
        private System.Windows.Forms.Label player1_label;
        private System.Windows.Forms.NumericUpDown numberOfRounds;
        private System.Windows.Forms.TextBox player2;
        private System.Windows.Forms.TextBox player1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ErrorProvider errorPlayer1;
        private System.Windows.Forms.ErrorProvider errorPlayer2;
    }
}

