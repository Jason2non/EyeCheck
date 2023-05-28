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
using System.Runtime.InteropServices;

namespace EyeCheckUpSystem
{
    public partial class productdash : Form
    {
        public productdash()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (prodidTxt.Text == "" || produdesTxt.Text == "" || prodcostTxt.Text == "")
            {
                MessageBox.Show("Fill in the blank spaces");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Eyewear([ID],[ProDes],[ProductCost],[ProductName])values(@Id,@Pd,@Pc,@Pn)", con);
                    cmd.Parameters.AddWithValue("@Id", prodidTxt.Text);
                    cmd.Parameters.AddWithValue("@Pd", produdesTxt.Text);
                    cmd.Parameters.AddWithValue("@Pc", prodcostTxt.Text);
                    cmd.Parameters.AddWithValue("@Pn", pronameTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producted Added Successfully!");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}
