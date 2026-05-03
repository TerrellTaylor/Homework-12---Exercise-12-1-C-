using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }

        private void frmAddCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private Customer customer = null!;

        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return customer;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                customer = new(txtFirstName.Text, txtLastName.Text, txtEmail.Text)
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text
                };
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidData()
        {
            bool success = true; string errorMessage = "";
            errorMessage += Validator.IsPresent(txtFirstName.Text, nameof(Customer.FirstName));
            errorMessage += Validator.IsPresent(txtLastName.Text, nameof(Customer.LastName));
            errorMessage += Validator.IsValidEmail(txtEmail.Text, nameof(Customer.Email));
            if (errorMessage != "")
            {
                success = false; MessageBox.Show(errorMessage, "Entry Error");
            }
            return success;
        }
    }
}
