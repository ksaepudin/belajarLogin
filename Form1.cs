using Connection_DB;
using MySql.Data.MySqlClient;

namespace belajarLogin
{
    public partial class Form1 : Form
    {
        // Add connection
        connection con = new connection();
        string username, password, nama, user_id;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                // Open Connetion
                con.Open();
  
                string query = "select Nama, username, password, user_id from tbl_users WHERE username ='" + txtUsername.Text + "' AND password ='" + txtPassword.Text + "'";

                MySqlDataReader row;
                row = con.ExecuteReader(query);
                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        nama = row["Nama"].ToString();
                        username = row["username"].ToString();
                        password = row["password"].ToString();
                        user_id = row["user_id"].ToString();
                        MessageBox.Show("login berhasil " + username + password + nama + user_id);
                    }

                   MessageBox.Show("Data not found "+ username + password + nama + user_id);
                }
                else
                {
                    MessageBox.Show("Data not found", "Information");
                }


            }
            else
            {

            }
        }
    }
}