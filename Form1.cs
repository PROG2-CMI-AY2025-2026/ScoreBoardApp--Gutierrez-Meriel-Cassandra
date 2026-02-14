using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> players = new Dictionary<string, int>();
        public Form1()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Leaderboard App\nVersion 1.0\nDeveloped by Merry Christmas",
                "About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int score = int.Parse(txtScore.Text.Trim());

                if (name == "")
                {
                    MessageBox.Show("Enter player name.");
                    return;
                }

                if (players.ContainsKey(name))
                {
                    players[name] = score;
                }
                else
                {
                    players.Add(name, score);
                }

                UpdateLeaderboard();
                UpdateHighest();

                txtName.Clear();
                txtScore.Clear();
            }
            catch
            {
                MessageBox.Show("Invalid score.");
            }
        }

            private void UpdateLeaderboard()
        {
            lblLeaderboard.Text = "Leaderboard:\n";

            foreach (var player in players)
            {
                lblLeaderboard.Text += player.Key + "-" + player.Value + "\n";
            }
        }

        private void UpdateHighest()
        {
            if (players.Count == 0)
            {
                lblHighest.Text = "Highest Score:";
                return;
            }
            var highest = players.OrderByDescending(p => p.Value).First();

            lblHighest.Text = "Highest Score: " + highest.Key + " (" + highest.Value + ")";
        }

        private void tsbStart_Click(object sender, EventArgs e)
        {
            players.Clear();
            lblLeaderboard.Text = "Leaderboard: ";
            lblHighest.Text = "Highest Score: ";
        }

        private void tsbReset_Click(object sender, EventArgs e)
        {
            players.Clear();
            lblLeaderboard.Text = "Leaderboard reset.";
            lblHighest.Text = "Highest Score:";
        }
    }
}
