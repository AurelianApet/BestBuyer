using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BestBot.Model;
using BestBot.Constants;
using BestBot.Controller;

namespace BestBot
{
    public partial class frmBackdoor : Form
    {
        public string productId { get; set; }
        public frmBackdoor()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtProductId.Text))
            {
                Messagebox.show("Please enter the product id!");
                return;
            }

            productId = txtProductId.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(productId))
                txtProductId.Text = productId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
