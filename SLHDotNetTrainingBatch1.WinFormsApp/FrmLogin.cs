using System.Data;
using Microsoft.Data.SqlClient;

namespace SLHDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmLogin : Form
    {
        private readonly SqlService _sqlService;
        public FrmLogin()
        {
            InitializeComponent();
            _sqlService = new SqlService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            string query = $"SELECT * FROM Tbl_User WHERE Username = @Username AND Password = @Password";
            DataTable dt = _sqlService.Query(query,
                 new SqlParameter("@Username", username),
                 new SqlParameter("@Password", password));

            //SqlParameter parameter1 = new SqlParameter("@Username", username);
            //SqlParameter parameter2 = new SqlParameter("@Password", password);

            //List<SqlParameter> parameters = new List<SqlParameter>
            //{
            //    parameter1,
            //    parameter2
            //};
            //List<SqlParameter> parameters = new List<SqlParameter>
            //{
            //    new SqlParameter("@Username", username),
            //    new SqlParameter("@Password", password)
            //};
            //parameters.Add(parameter1); 
            //parameters.Add(parameter2);

            //DataTable dt = _sqlService.Query(query, parameters);

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            //{
            //    DataSource = ".",
            //    InitialCatalog = "DotNetTrainingBatch1",
            //    UserID = "sa",
            //    Password = "sasa@123",
            //    TrustServerCertificate = true
            //};
            //SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@Username", username); 
            //cmd.Parameters.AddWithValue("@Password", password); 
            //DataTable dt = new DataTable();
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("User doesn't exist.");
                return;
            }

            MessageBox.Show("Login successful.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
