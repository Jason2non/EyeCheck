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
    public partial class appointmentsmade : Form
    {
        public appointmentsmade()
        {
            InitializeComponent();
            datgrid();
        }
        OleDbConnection con = new OleDbConnection(Global.connectionString);
        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel form = new AdminPanel();
            this.Hide();
            form.Show();
            
        }
        private void datgrid()
        {
            con.Open();
            string query = "Select * from Appointments";
            OleDbDataAdapter sda = new OleDbDataAdapter(query, con);
            OleDbCommandBuilder Builder = new OleDbCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            apartDVG.DataSource = ds.Tables[0];
            con.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
