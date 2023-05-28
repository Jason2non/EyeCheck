using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EyeCheckUpSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void button2_Click(object sender, EventArgs e)
        {
            register form = new register();
            this.Hide();
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (userTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Fill the blank spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Admin,Password FROM Admin WHERE Admin=@Ad and Password=@Pa", con);
                    cmd.Parameters.AddWithValue("@Ad", userTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passTxt.Text);
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int i = cmd.ExecuteNonQuery();
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Successfully logged in");
                        AdminPanel form = new AdminPanel();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please enter Correct Username or Password");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (userTxt.Text == "" || passTxt.Text == "")
            {
                MessageBox.Show("Fill the blank spaces");
            }
            else
            {
                try
                { 
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT Email,Password FROM Customer WHERE Email=@Em and Password=@Pa",con);
                    cmd.Parameters.AddWithValue("@Ad", userTxt.Text);
                    cmd.Parameters.AddWithValue("@Pa", passTxt.Text);
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    int i = cmd.ExecuteNonQuery();
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Successfully logged in");
                        makeappointements form = new makeappointements();
                        this.Hide();
                        form.Show();

                    }
                    else
                    {
                        MessageBox.Show("Please enter Correct Password");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
