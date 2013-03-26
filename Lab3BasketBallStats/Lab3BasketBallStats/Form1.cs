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
      private StatsDataContext database = new StatsDataContext();
        
       
        private DataGridView current_dg;
      
        public Form1()
        {
            InitializeComponent();
           
        }

        private void leagueBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            

            Validate();

            current_dg.EndEdit();
            //leagueBindingSource.EndEdit();
            Console.WriteLine(current_dg.Name);
            //teamBindingSource.EndEdit();

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

           statBindingSource.DataSource =
                from stat in database.Stats
                orderby stat.Id
                select stat;

           players_TeamBindingSource.DataSource =
               from playerTeam in database.Players_Teams
               orderby playerTeam.Id
               select playerTeam;
           
        }

        private void teamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.current_dg=(DataGridView)sender;
            switch(this.current_dg.Name)
            {
                case "leagueDataGridView":
                    leagueBindingNavigator.BindingSource = leagueBindingSource;
                    break;
                case "teamDataGridView":
                    leagueBindingNavigator.BindingSource = teamBindingSource;
                    break;
                case "statDataGridView":
                    leagueBindingNavigator.BindingSource = statBindingSource;
                    break;
                case "players_TeamDataGridView":
                    leagueBindingNavigator.BindingSource = statBindingSource;
                    break;
            }
            
        }





 
    }
}
