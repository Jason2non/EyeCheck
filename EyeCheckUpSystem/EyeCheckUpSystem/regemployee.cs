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
    public partial class regemployee : Form
    {
        public regemployee()
        {
            InitializeComponent();
            
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(empidTxt.Text == "" || empnameTxt.Text == "" || empmailTxt.Text == "" || emoaddTxt.Text == "")
            {
                MessageBox.Show("Fill all the blank pages");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Employee([ID],[Name],[email],[Address])values(@Id,@Na,@Em,@Ad)", con);
                    cmd.Parameters.AddWithValue("@Id", empidTxt.Text);
                    cmd.Parameters.AddWithValue("@Na", empnameTxt.Text);
                    cmd.Parameters.AddWithValue("@Em", empmailTxt.Text);
                    cmd.Parameters.AddWithValue("@Ad", emoaddTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added Successfully");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
