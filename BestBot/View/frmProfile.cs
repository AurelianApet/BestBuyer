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

namespace BestBot.View
{
    public partial class frmProfile : Form
    {
        public List<Profile> buyInfoList { get; set; }
        public frmProfile()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBuy frm = new frmBuy();
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Profile buyInfo = frm.buyInfo;
                addBuyInfo(buyInfo);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tblProfile.SelectedRows == null || tblProfile.SelectedRows.Count < 1)
            {
                Messagebox.show("Please select correct item!");
                return;
            }

            frmBuy frm = new frmBuy();
            int index = tblProfile.SelectedRows[0].Index;
            Profile buyInfoOld = tblProfile.SelectedRows[0].Tag as Profile;
            if (buyInfoOld == null)
            {
                Messagebox.show("Cannot select this item!");
                return;
            }

            frm.buyInfo = buyInfoOld;
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                updateBuyInfo(index, frm.buyInfo);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (tblProfile.SelectedRows == null || tblProfile.SelectedRows.Count < 1)
            {
                Messagebox.show("Please select correct item!");
                return;
            }

            delBuyInfo(tblProfile.SelectedRows[0].Index);
        }

        private void addBuyInfo(Profile buyInfo, bool bAdd = true)
        {
            int index = tblProfile.Rows.Add();
            if (index < 0)
                return;

            object[] values = new object[]{
                buyInfo.profileName
            };

            tblProfile.Rows[index].SetValues(values);
            tblProfile.Rows[index].Tag = buyInfo;

            if(bAdd)
                buyInfoList.Add(buyInfo);
        }

        private void updateBuyInfo(int index, Profile buyInfo)
        {
            if (index < 0)
            {
                Messagebox.show("Please select the item!");
                return;
            }

            Profile buyInfoOld = tblProfile.Rows[index].Tag as Profile;
            if (buyInfoOld == null)
            {
                Messagebox.show("Cannot delete the item!");
                return;
            }

            object[] values = new object[]{
                buyInfo.profileName
            };

            tblProfile.Rows[index].SetValues(values);
            tblProfile.Rows[index].Tag = buyInfo;

            buyInfoList.RemoveAt(index);
            buyInfoList.Insert(index, buyInfo);
        }

        private void delBuyInfo(int index)
        {
            if (index < 0)
            {
                Messagebox.show("Please select the item!");
                return;
            }

            Profile buyInfo = tblProfile.Rows[index].Tag as Profile;
            if (buyInfo == null)
            {
                Messagebox.show("Cannot delete this item!");
                return;
            }

            tblProfile.Rows.RemoveAt(index);
            buyInfoList.Remove(buyInfo);
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            if (buyInfoList == null)
                return;

            foreach (Profile buyInfo in buyInfoList)
                addBuyInfo(buyInfo, false);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
