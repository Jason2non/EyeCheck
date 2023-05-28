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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EyeCheckUpSystem
{
    public partial class makeappointements : Form
    {
        public makeappointements()
        {
            InitializeComponent();
            showproduct();
            fillprice();
        }

        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showproduct()
        {
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT ProductName FROM Eyewear",con);
                OleDbDataAdapter dr = new OleDbDataAdapter(cmd);
        
                DataSet ds = new DataSet();
                dr.Fill(ds, "ProductName");
                buyproCb.DisplayMember = "ProductName";
                buyproCb.ValueMember = "ProducName";
                buyproCb.DataSource = ds.Tables["ProductName"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillprice()
        {/*
            try
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Select ProductCost FROM Eyewear WHERE ID IS NOT NULL", con);
                OleDbDataReader cap = cmd.ExecuteReader();
                while (cap.Read())
                {
                    string price = cap.GetInt64(0).ToString();
                    priceTxt.Text = price;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }*/
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(nameTxt.Text == "")
            {
                MessageBox.Show("Enter the username");
            }
            else
            {
                try
                {
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Appointments([Name],[AppointmentDate],[AppointmentDescription])values(@Na,@Ad,@As)", con);
                    cmd.Parameters.AddWithValue("@Na", nameTxt.Text);
                    cmd.Parameters.AddWithValue("@Ad", dateApp.Value.Date.ToString());
                    cmd.Parameters.AddWithValue("@As", adTxt.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Congratulations, Appointment made");


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bunameTxt.Text == "")
            {
                MessageBox.Show("Fill in the username");
            }
            else
            {
                MessageBox.Show("You have purchased medicine, thank you");
            }
        }

        private void buyproCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            fillprice();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
