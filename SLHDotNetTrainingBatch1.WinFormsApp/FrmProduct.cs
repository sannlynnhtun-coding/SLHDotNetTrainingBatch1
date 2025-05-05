using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using SLHDotNetTrainingBatch1.WinFormsApp.Queries;

namespace SLHDotNetTrainingBatch1.WinFormsApp
{
    public partial class FrmProduct : Form
    {
        private readonly SqlService _sqlService;
        private string _productId = string.Empty;

        public FrmProduct()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _sqlService = new SqlService();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataTable dt = _sqlService.Query(ProductQuery.GetAllProducts);
            dgvData.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = textBox1.Text.Trim();
            string name = textBox2.Text.Trim();
            decimal price = Convert.ToDecimal(textBox3.Text.Trim());
            int quantity = Convert.ToInt32(textBox4.Text.Trim());

            int result = _sqlService.Execute(ProductQuery.InsertProduct,
                 new SqlParameter("@Code", code),
                 new SqlParameter("@Name", name),
                 new SqlParameter("@Price", price),
                 new SqlParameter("@Quantity", quantity),
                 new SqlParameter("@CreatedDate", DateTime.Now),
                 new SqlParameter("@CreatedBy", AppSetting.CurrentUser)
                 );

            //int a = 0;
            //bool isZero = a == 0 ? true : false;
            //if(isZero == 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            string message = result > 0 ? "Insert successful." : "Insert failed.";
            MessageBox.Show(message,
                "Inventory Control System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            ClearControls();
            BindData();
        }

        private void ClearControls()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(e.RowIndex);
            Console.WriteLine(e.ColumnIndex);

            if (e.ColumnIndex == 0) // Edit
            {
                string id = dgvData.Rows[e.RowIndex].Cells["colProductId"].Value.ToString()!;

                DataTable dt = _sqlService.Query("select * from tbl_product where ProductId = @ProductId;",
                     new SqlParameter("@ProductId", id));
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Product not found.",
                        "Inventory Control System",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                textBox1.Text = dt.Rows[0]["ProductCode"].ToString()!;
                textBox2.Text = dt.Rows[0]["ProductName"].ToString()!;
                textBox3.Text = dt.Rows[0]["Price"].ToString()!;
                textBox4.Text = dt.Rows[0]["Quantity"].ToString()!;

                _productId = id;

                btnUpdate.Visible = true;
                btnSave.Visible = false;
            }
            else if (e.ColumnIndex == 1) // Delete
            {
                var result = MessageBox.Show("Are your sure to delete?",
                     "Inventory Control System",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Delete Process
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validation
            // Get Data From Textbox
            // Update Process

            _productId = string.Empty;

            BindData();
        }
    }
}
