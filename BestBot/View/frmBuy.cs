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
    public partial class frmBuy : Form
    {
        public Profile buyInfo { get; set; }
        public frmBuy()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!canSetting())
                return;

            setSetting();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private bool canSetting()
        {
            if(string.IsNullOrEmpty(txtProfileName.Text))
            {
                Messagebox.show("Please enter the profile name!");
                txtProfileName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                Messagebox.show("Please enter the card number!");
                txtCardNo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtExpires.Text))
            {
                Messagebox.show("Please enter the expires!");
                txtExpires.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSecurity.Text))
            {
                Messagebox.show("Please enter the security!");
                txtSecurity.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                Messagebox.show("Please enter the first name!");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                Messagebox.show("Please enter the last name!");
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                Messagebox.show("Please enter the address!");
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCity.Text))
            {
                Messagebox.show("Please enter the city/town!");
                txtCity.Focus();
                return false;
            }

            if (cbState.SelectedIndex < 0)
            {
                Messagebox.show("Please select the correct state!");
                cbState.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtZipCode.Text))
            {
                Messagebox.show("Please enter the zipcode!");
                txtZipCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                Messagebox.show("Please enter the phone number!");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                Messagebox.show("Please enter the email!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtBirthday.Text))
            {
                Messagebox.show("Please enter the birthday!");
                txtBirthday.Focus();
                return false;
            }

            return true;
        }

        private void setSetting()
        {
            try
            {
                buyInfo = new Profile();

                buyInfo.profileName = txtProfileName.Text;

                CardInfo cardInfo = new CardInfo();
                cardInfo.cardNo = txtCardNo.Text;
                cardInfo.expires = txtExpires.Text;
                cardInfo.security = txtSecurity.Text;
                buyInfo.cardInfo = cardInfo;

                DeliveryInfo deliveryInfo = new DeliveryInfo();
                deliveryInfo.address = txtAddress.Text;
                deliveryInfo.birthday = txtBirthday.Text;
                deliveryInfo.city = txtCity.Text;
                deliveryInfo.email = txtEmail.Text;
                deliveryInfo.firstName = txtFirstName.Text;
                deliveryInfo.lastName = txtLastName.Text;
                deliveryInfo.phone = txtPhone.Text;
                deliveryInfo.state = cbState.SelectedIndex;
                deliveryInfo.zipCode = txtZipCode.Text;
                buyInfo.deliveryInfo = deliveryInfo;
            }
            catch(Exception e)
            {

            }
        }

        private void initValues()
        {
            try
            {
                if (buyInfo == null)
                    return;

                txtProfileName.Text = buyInfo.profileName;

                cbCardType.SelectedIndex = 0;
                txtCardNo.Text = buyInfo.cardInfo.cardNo;
                txtExpires.Text = buyInfo.cardInfo.expires;
                txtSecurity.Text = buyInfo.cardInfo.security;

                txtAddress.Text = buyInfo.deliveryInfo.address;
                txtBirthday.Text = buyInfo.deliveryInfo.birthday;
                txtCity.Text = buyInfo.deliveryInfo.city;
                txtEmail.Text = buyInfo.deliveryInfo.email;
                txtFirstName.Text = buyInfo.deliveryInfo.firstName;
                txtLastName.Text = buyInfo.deliveryInfo.lastName;
                txtPhone.Text = buyInfo.deliveryInfo.phone;
                cbState.SelectedIndex = buyInfo.deliveryInfo.state;
                txtZipCode.Text = buyInfo.deliveryInfo.zipCode;
            }
            catch(Exception)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmBuy_Load(object sender, EventArgs e)
        {
            //initControls();

            if (buyInfo == null)
                return;

            initValues();
        }
    }
}
