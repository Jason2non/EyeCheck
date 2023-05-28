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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            login form = new login();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(cidTxt.Text == "" || nameTxt.Text == "" || phoneTxt.Text == "" || emailTxt.Text == "" || passwordTxt.Text == "")
            {
                MessageBox.Show("Fill in the empty spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Customer([ID],[Name],[Email],[Phone],[Password])values(@Id,@Na,@Em,@Ph,@Pa)", con);
                    cmd.Parameters.AddWithValue("@Id", cidTxt.Text);
                    cmd.Parameters.AddWithValue("@Na", nameTxt.Text);
                    cmd.Parameters.AddWithValue("@Em", emailTxt.Text);
                    cmd.Parameters.AddWithValue("@Ph", phoneTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passwordTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uploaded successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
