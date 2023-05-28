using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EyeCheckUpSystem
{
    public partial class AddOpt : Form
    {
        public AddOpt()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void AddOpt_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(optidTxt.Text == "" || optnameTxt.Text == "" || optemailTxt.Text == "" || optaddTxt.Text == "")
            {
                MessageBox.Show("Fill in the blank spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Optometrist([ID],[Name],[Email],[Address])values(@Id,@Na,@Em,@Ad)", con);
                    cmd.Parameters.AddWithValue("@Id", optidTxt.Text);
                    cmd.Parameters.AddWithValue("@Na", optnameTxt.Text);
                    cmd.Parameters.AddWithValue("@Em", optemailTxt.Text);
                    cmd.Parameters.AddWithValue("@Ad", optaddTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Optometrist Added successfully");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    
            }
        }
    }
}
