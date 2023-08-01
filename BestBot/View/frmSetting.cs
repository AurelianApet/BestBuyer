using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using BestBot.Model;
using BestBot.Constants;
using BestBot.Controller;

namespace BestBot
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!canSetting())
                return;

            setSetting();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void setSetting()
        {
            Setting.instance.captchaKey = txtCaptcha.Text;
            Setting.instance.interval = (int)numInterval.Value;
        }

        private void initSetting()
        {
            txtCaptcha.Text = Setting.instance.captchaKey;
            numInterval.Value = Setting.instance.interval;
        }

        private bool canSetting()
        {
            if(string.IsNullOrEmpty(txtCaptcha.Text))
            {
                Messagebox.show("Please enter the 2captcha key!");
                txtCaptcha.Focus();
                return false;
            }

            return true;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            initSetting();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
