using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace LibrarySystem
{
    class ConnectWithDB
    {
        string ConnectionString = "server=localhost;user id=root;database=librarysystem";
        MySqlConnection con;
        bool isopen = false;

        public void OpenConection()
        {
            try
            {
                con = new MySqlConnection(ConnectionString);
                con.Open();
                isopen = true;
            }
            catch(Exception ex)
            {
                DialogResult ans = MessageBox.Show("Sever is not Connected.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if(ans == DialogResult.Retry)
                {
                    OpenConection();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
            public void CloseConnection()
            {
                con.Close();
            
            }


            public void ExecuteQueries(string Query_)
            {
                MySqlCommand cmd = new MySqlCommand(Query_, con);
                cmd.ExecuteNonQuery();
            }


        public MySqlDataReader DataReader(string Query_)
        {
            if (isopen)
            {
                MySqlCommand cmd = new MySqlCommand(Query_, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            else
            {
                return null;
            }
        }


            public object ShowDataInGridView(string Query_)
            {
                MySqlDataAdapter dr = new MySqlDataAdapter(Query_, ConnectionString);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                object dataum = ds.Tables[0];
                return dataum;
            }
        
    }
}

