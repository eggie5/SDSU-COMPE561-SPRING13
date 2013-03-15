using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3BasketBallStats
{
    public partial class Form1 : Form
    {
        private DataClasses1DataContext database = new DataClasses1DataContext();
      
        public Form1()
        {
            InitializeComponent();
           
        }

        private void leagueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            leagueBindingSource.EndEdit();
            database.SubmitChanges();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            leagueBindingSource.DataSource =
                from league in database.Leagues
                orderby league.Id
                select league;

            teamBindingSource.DataSource =
                from team in database.Teams
                orderby team.Id
                select team;

            playerBindingSource.DataSource =
                from player in database.Players
                orderby player.Id
                select player;

            gameBindingSource.DataSource =
                from game in database.Games
                orderby game.Id
                select game;

            statisticBindingSource.DataSource =
                from stat in database.Statistics
                orderby stat.Id
                select stat;
           
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Validate();
            teamBindingSource.EndEdit();
            database.SubmitChanges();
        }

       
        private void saveToolStripButton2_Click(object sender, EventArgs e)
        {
            Validate();
            statisticBindingSource.EndEdit();
            database.SubmitChanges();
        }

        private void saveToolStripButton3_Click(object sender, EventArgs e)
        {
            Validate();
            gameBindingSource.EndEdit();
            database.SubmitChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Players p = new Players();
            p.db_ref = database;
            p.Show();
        }

        private void saveToolStripButton1_Click_1(object sender, EventArgs e)
        {
            Validate();
            playerBindingSource.EndEdit();
            database.SubmitChanges();
        }

 
    }
}
