using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EyeCheckUpSystem
{
    class Global
    {
        private static int role = 0;
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\adm\3D Objects\Eyecare and Eyeglasses Business Database Management Project(Thomas).mdb""";
        public static int Role
        {
            get { return role; }
            set { role = value; }
        }

    }
    
}
