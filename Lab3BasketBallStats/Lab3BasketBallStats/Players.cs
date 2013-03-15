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
    public partial class Players : Form
    {
        public Players()
        {
            InitializeComponent();
        }

        public DataClasses1DataContext db_ref = null;

        private void playerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            playerBindingSource.EndEdit();
            db_ref.SubmitChanges();
        }

        private void Players_Load(object sender, EventArgs e)
        {
            playerBindingSource.DataSource =
               from player in db_ref.Players
               orderby player.Id
               select player;
        }
    }
}
