using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Diagnostics;

using Selenium;
using Selenium.Internal.SeleniumEmulation;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

using BestBot.Model;
using BestBot.Constants;
using BestBot.Controller;
using BestBot.View;

namespace BestBot
{
    public delegate void onWriteStatusEvent(string status);
    public partial class frmMain : Form
    {
        public event onWriteStatusEvent onWriteStatus;
        private List<TaskInfo> taskInfoList = new List<TaskInfo>();
        private List<HttpsProxy> proxyList = new List<HttpsProxy>();
        private List<Profile> profileList = new List<Profile>();
        private List<ProductInfo> productInfoList = new List<ProductInfo>();

        private Point _ptPrevPoint = new Point(0, 0);

        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        private string ReadRegistry(string KeyName)
        {
            return Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("BestBot").GetValue(KeyName, (object)"").ToString();
        }

        private void WriteRegistry(string KeyName, string KeyValue)
        {
            Registry.CurrentUser.CreateSubKey("SoftWare").CreateSubKey("BestBot").SetValue(KeyName, (object)KeyValue);
        }

        private void saveSettingInfo()
        {
            try
            {
                WriteRegistry("captcha", Setting.instance.captchaKey);
                WriteRegistry("interval", Setting.instance.interval.ToString());

                WriteRegistry("taskNumber", (tblProductInfo.Rows.Count - 1).ToString());
                for (int i = 0; i < tblProductInfo.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = tblProductInfo.Rows[i];
                    object url = row.Cells["colUrl"].Value;
                    WriteRegistry("productUrl" + i.ToString(), url == null ? "" : url.ToString());

                    object size = row.Cells["colSize"].Value;
                    WriteRegistry("productSize" + i.ToString(), size == null ? "" : size.ToString());

                    object profile = row.Cells["colProfile"].Value;
                    WriteRegistry("profile" + i.ToString(), profile == null ? "" : profile.ToString());

                    DataGridViewCheckBoxCell cellCheckout = row.Cells["colAutoCheckout"] as DataGridViewCheckBoxCell;
                    if (cellCheckout != null)
                        WriteRegistry("autoCheckout" + i.ToString(), (bool)cellCheckout.Value == true ? "True" : "False");

                    DataGridViewCheckBoxCell cellBackdoor = row.Cells["colBackdoor"] as DataGridViewCheckBoxCell;
                    if (cellBackdoor != null)
                        WriteRegistry("backdoor" + i.ToString(), (bool)cellBackdoor.Value == true ? "True" : "False");

                    string backdoorInfo = row.Cells["colBackdoorInfo"].Tag == null ? "" : row.Cells["colBackdoorInfo"].Tag as string;
                    WriteRegistry("backdoorInfo" + i.ToString(), backdoorInfo);
                }

                WriteRegistry("buyInfoNumber", profileList.Count.ToString());
                for (int i = 0; i < profileList.Count; i++)
                {
                    WriteRegistry("profileName" + i.ToString(), profileList[i].profileName);

                    WriteRegistry("cardNo" + i.ToString(), profileList[i].cardInfo.cardNo);
                    WriteRegistry("security" + i.ToString(), profileList[i].cardInfo.security);
                    WriteRegistry("expires" + i.ToString(), profileList[i].cardInfo.expires);

                    WriteRegistry("firstName" + i.ToString(), profileList[i].deliveryInfo.firstName);
                    WriteRegistry("lastName" + i.ToString(), profileList[i].deliveryInfo.lastName);
                    WriteRegistry("address" + i.ToString(), profileList[i].deliveryInfo.address);
                    WriteRegistry("city" + i.ToString(), profileList[i].deliveryInfo.city);
                    WriteRegistry("state" + i.ToString(), profileList[i].deliveryInfo.state.ToString());
                    WriteRegistry("zipCode" + i.ToString(), profileList[i].deliveryInfo.zipCode);
                    WriteRegistry("phone" + i.ToString(), profileList[i].deliveryInfo.phone);
                    WriteRegistry("email" + i.ToString(), profileList[i].deliveryInfo.email);
                    WriteRegistry("birthday" + i.ToString(), profileList[i].deliveryInfo.birthday);
                }
            }
            catch(Exception e)
            {

            }
        }

        private void loadSettingInfo()
        {
            Setting.instance.captchaKey = ReadRegistry("captcha");

            int interval = 0;
            if (int.TryParse(ReadRegistry("interval"), out interval))
                Setting.instance.interval = interval;
            else
                Setting.instance.interval = 1000;

            if (Setting.instance.interval < 1000)
                Setting.instance.interval = 1000;

            int buyInfoNumber = 0;
            if (int.TryParse(ReadRegistry("buyInfoNumber"), out buyInfoNumber))
            {
                colProfile.Items.Clear();

                for (int i = 0; i < buyInfoNumber; i++)
                {
                    Profile buyInfo = new Profile();

                    buyInfo.profileName = ReadRegistry("profileName" + i.ToString());

                    CardInfo cardInfo = new CardInfo();
                    cardInfo.cardNo = ReadRegistry("cardNo" + i.ToString());
                    cardInfo.security = ReadRegistry("security" + i.ToString());
                    cardInfo.expires = ReadRegistry("expires" + i.ToString());
                    buyInfo.cardInfo = cardInfo;

                    DeliveryInfo deliveryInfo = new DeliveryInfo();
                    deliveryInfo.firstName = ReadRegistry("firstName" + i.ToString());
                    deliveryInfo.lastName = ReadRegistry("lastName" + i.ToString());
                    deliveryInfo.address = ReadRegistry("address" + i.ToString());
                    deliveryInfo.city = ReadRegistry("city" + i.ToString());
                    int state = -1;
                    if (int.TryParse(ReadRegistry("state" + i.ToString()), out state))
                        deliveryInfo.state = state;

                    deliveryInfo.zipCode = ReadRegistry("zipCode" + i.ToString());
                    deliveryInfo.phone = ReadRegistry("phone" + i.ToString());
                    deliveryInfo.email = ReadRegistry("email" + i.ToString());
                    deliveryInfo.birthday = ReadRegistry("birthday" + i.ToString());
                    buyInfo.deliveryInfo = deliveryInfo;

                    profileList.Add(buyInfo);
                    colProfile.Items.Add(buyInfo.profileName);
                }
            }

            int taskNumber = 0;
            if (int.TryParse(ReadRegistry("taskNumber"), out taskNumber))
            {
                for (int i = 0; i < taskNumber; i++)
                {
                    string productUrl = ReadRegistry("productUrl" + i.ToString());
                    string productSize = ReadRegistry("productSize" + i.ToString());
                    string profile = ReadRegistry("profile" + i.ToString());
                    string autoCheckout = ReadRegistry("autoCheckout" + i.ToString());
                    string backdoor = ReadRegistry("backdoor" + i.ToString());
                    string backdoorInfo = ReadRegistry("backdoorInfo" + i.ToString());

                    if (string.IsNullOrEmpty(productUrl) && string.IsNullOrEmpty(backdoorInfo))
                        continue;

                    int nIndex = tblProductInfo.Rows.Add();
                    if (nIndex >= 0)
                    {
                        object[] values = new object[]{
                            productUrl, productSize, profile, autoCheckout == "True" ? true : false, backdoor == "True" ? true : false, backdoorInfo
                        };
                        tblProductInfo.Rows[nIndex].SetValues(values);
                        tblProductInfo.Rows[nIndex].Cells["colBackdoorInfo"].Tag = backdoorInfo;
                    }
                }
            }
        }

        private bool canStart()
        {
            if(Constant.bRun)
            {
                Messagebox.show("Already started!");
                return false;
            }

            taskInfoList.Clear();

            if(string.IsNullOrEmpty(Setting.instance.captchaKey))
            {
                Messagebox.show("Please enter the captcha key!");
                return false;
            }

            if (tblProductInfo.Rows.Count < 1 || profileList.Count < 1)
            {
                Messagebox.show("Please add product or buy info!");
                return false;
            }

            for (int i = 0; i < tblProductInfo.Rows.Count - 1; i ++)
            {
                DataGridViewRow row = tblProductInfo.Rows[i];

                object url = row.Cells["colUrl"].Value;
                object size = row.Cells["colSize"].Value;
                object profile = row.Cells["colProfile"].Value;
                object autoCheckout = row.Cells["colAutoCheckout"].Value;
                object backdoor = row.Cells["colBackdoor"].Value;
                object backdoorInfo = row.Cells["colBackdoorInfo"].Tag;

                if ((url == null || string.IsNullOrEmpty(url.ToString())) && (backdoor == null || (bool)backdoor == false))
                {
                    Messagebox.show("Please enter the product Url!");
                    return false;
                }

                if ((size == null || string.IsNullOrEmpty(size.ToString())) && (backdoor == null || (bool)backdoor == false))
                {
                    Messagebox.show("Please enter the size!");
                    return false;
                }

                if (backdoor != null && (bool)backdoor && (backdoorInfo == null || string.IsNullOrEmpty(backdoorInfo.ToString())))
                {
                    Messagebox.show("Please enter the backend info!");
                    return false;
                }

                TaskInfo taskInfo = new TaskInfo();
                taskInfo.productUrl = url == null ? null : url.ToString();
                taskInfo.size = size == null ? null : size.ToString();
                taskInfo.profileName = profile == null ? null : profile.ToString();
                taskInfo.profile = getProfileByName(taskInfo.profileName);
                taskInfo.autoCheckout = (autoCheckout == null || (bool)autoCheckout == false) ? false : true;
                taskInfo.backdoor = (backdoor == null || (bool)backdoor == false) ? false : true;
                taskInfo.backdoorInfo = backdoorInfo == null ? null : backdoorInfo.ToString();
                taskInfoList.Add(taskInfo);
            }

            if(taskInfoList.Count < 1)
            {
                Messagebox.show("Please enter the task information!");
                return false;
            }

            return true;
        }

        private Profile getProfileByName(string profileName)
        {
            if (string.IsNullOrEmpty(profileName))
                return null;

            foreach(Profile profile in profileList)
            {
                if (profile.profileName == profileName)
                    return profile;
            }

            return null;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!canStart())
                return;

            saveSettingInfo();

            Constant.bRun = true;
            onWriteStatus("The software has been started!");

            int nCount = -1;
            foreach(TaskInfo taskInfo in taskInfoList)
            {
                nCount++;
                if ((!string.IsNullOrEmpty(taskInfo.profileName) && taskInfo.profile != null) || !taskInfo.autoCheckout)
                {
                    if (proxyList.Count > nCount)
                        taskInfo.proxy = proxyList[nCount];

                    Thread thread = new Thread(new ParameterizedThreadStart(buyFunc));
                    thread.Start(taskInfo);
                }
                else
                {
                    foreach(Profile profile in profileList)
                    {
                        TaskInfo taskInfoEx = new TaskInfo(taskInfo);
                        taskInfoEx.profile = profile;

                        if (proxyList.Count > nCount)
                            taskInfoEx.proxy = proxyList[nCount];

                        Thread thread = new Thread(new ParameterizedThreadStart(buyFunc));
                        thread.Start(taskInfoEx);
                    }
                }
            }
        }

        
        private void buyFunc(object obj)
        {
            TaskInfo item = obj as TaskInfo;
            if (item == null)
                return;

            Auto auto = new Auto(item, onWriteStatus);
            bool bSuccess = auto.doWork().Result;
            if(bSuccess)
            {
                onWriteStatus(string.Format("Bought successfully! OrderID: {0}", auto.order));
            }
            else
            {
                onWriteStatus("Failed to buying!");
            }
        }


        private HttpsProxy pickOneProxy()
        {
            if (Setting.instance.proxyList.Count == 0)
                return null;

            lock (Setting.instance.proxyList)
            {
                HttpsProxy proxy = Setting.instance.proxyList[0];
                Setting.instance.proxyList.RemoveAt(0);
                Setting.instance.proxyList.Add(proxy);

                return proxy;
            }
        }

        private string getLogTitle()
        {
            string date = string.Format("[{0}] ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return date;
        }

        private void writeStatus(string status)
        {
            if (rtLog.InvokeRequired)
                rtLog.Invoke(onWriteStatus, status);
            else
            {
                rtLog.AppendText(((string.IsNullOrEmpty(rtLog.Text) ? "" : "\r\n") + string.Format("{0}", getLogTitle() + status)));
                rtLog.ScrollToCaret();
            }
        }

        private void initControls()
        {
            btnIcon.Parent = picTitle;
            btnMin.Parent = picTitle;
            btnClose.Parent = picTitle;
            lblTitle.Parent = picTitle;
        }

        private void ExitProcess(string procName)
        {
            try
            {
                Process[] liveProcess = Process.GetProcesses();
                if (liveProcess == null)
                    return;

                foreach (Process proc in liveProcess)
                {
                    if (proc.ProcessName == procName)
                        proc.Kill();
                }
            }
            catch (Exception)
            {

            }
        }

        private string getMacAddress()
        {
            return NetworkInterface.GetAllNetworkInterfaces()[0].GetPhysicalAddress().ToString();
        }

        private bool keepService()
        {
            try
            {
                //HttpClient httpClientKeep = new HttpClient();
                //HttpResponseMessage responseMessageKeep = httpClientKeep.PostAsync("http://101.102.224.98:8811/poster/keep.php", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[3]{
                //    new KeyValuePair<string, string>("user", "adidas"),
                //    new KeyValuePair<string, string>("pass", "adidas"),
                //    new KeyValuePair<string, string>("mac", getMacAddress())
                //})).Result;
                //responseMessageKeep.EnsureSuccessStatusCode();

                //string responseMessageKeepString = responseMessageKeep.Content.ReadAsStringAsync().Result;
                //if (string.IsNullOrEmpty(responseMessageKeepString))
                //    return false;

                //if (responseMessageKeepString != "success")
                //    return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ExitProcess("chromedriver");
            initControls();

            if (this.onWriteStatus == null)
                this.onWriteStatus += writeStatus;

            loadSettingInfo();

            if (!keepService())
                this.Close();

            //timerKeep.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if(!Constant.bRun)
            {
                Messagebox.show("Please start this software first!");
                return;
            }

            onWriteStatus("Stop the software!");
            Constant.bRun = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Constant.bRun = false;
            this.Close();
        }

        private void timerKeep_Tick(object sender, EventArgs e)
        {
            if(!keepService())
            {
                Constant.bRun = false;
                this.Close();
            }
        }

        
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            frmProfile frm = new frmProfile();
            frm.buyInfoList = profileList;

            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                profileList = frm.buyInfoList;
                refreshProfileList();
            }
        }

        private void refreshProfileList()
        {
            colProfile.Items.Clear();

            foreach (Profile profile in profileList)
            {
                if (string.IsNullOrEmpty(profile.profileName))
                    continue;

                colProfile.Items.Add(profile.profileName);
            }
        }

        private void picTitle_MouseDown(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
            this._ptPrevPoint.X = e.X;
            this._ptPrevPoint.Y = e.Y;
        }

        private void picTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Point point = new Point(e.X - this._ptPrevPoint.X, e.Y - this._ptPrevPoint.Y);
            point.X = this.Location.X + point.X;
            point.Y = this.Location.Y + point.Y;
            this.Location = point;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Constant.bRun = false;
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDlg = new OpenFileDialog();
            fileDlg.Filter = "Proxy List Files | *.txt";
            if (fileDlg.ShowDialog() == DialogResult.OK)
            {
                List<HttpsProxy> tempProxyList = loadProxy(fileDlg.FileName);
                if (tempProxyList == null || tempProxyList.Count < 1)
                    return;

                frmStatus frm = new frmStatus();
                frm.proxyList = tempProxyList;

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    proxyList = frm.availableProxyList;
                    onWriteStatus(string.Format("Loaded {0} proxies successfully!", proxyList.Count));
                }
            }
        }

        private List<HttpsProxy> loadProxy(string filename)
        {
            if (!File.Exists(filename))
                return null;

            string[] lines = File.ReadAllLines(filename);
            if (lines == null || lines.Length < 1)
                return null;

            List<HttpsProxy> tempProxyList = new List<HttpsProxy>();

            foreach (string line in lines)
            {
                string[] lineArray = line.Split(new char[] { ':' }, StringSplitOptions.None);
                if (lineArray == null)
                    continue;

                if (lineArray.Length < 2)
                    continue;

                if (lineArray.Length == 4)
                {
                    HttpsProxy proxy = new HttpsProxy(lineArray[0], lineArray[1], lineArray[2], lineArray[3]);
                    tempProxyList.Add(proxy);
                }

                if(lineArray.Length == 2)
                {
                    HttpsProxy proxy = new HttpsProxy(lineArray[0], lineArray[1]);
                    tempProxyList.Add(proxy);
                }
            }

            return tempProxyList;
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tblProductInfo.SelectedRows == null || tblProductInfo.SelectedRows.Count < 1)
                    return;

                int selectedIndex = tblProductInfo.SelectedRows[0].Index;
                if (selectedIndex < 0)
                    return;

                DataGridViewRow row = tblProductInfo.SelectedRows[0];
                int nIndex = tblProductInfo.Rows.Add();

                object[] values = new object[]{
                    row.Cells["colUrl"].Value, row.Cells["colSize"].Value, row.Cells["colProfile"].Value, row.Cells["colAutoCheckout"].Value, row.Cells["colBackdoor"].Value, row.Cells["colBackdoorInfo"].Value
                };
                tblProductInfo.Rows[nIndex].SetValues(values);
                tblProductInfo.Rows[nIndex].Cells["colBackdoorInfo"].Tag = row.Cells["colBackdoorInfo"].Tag;
            }
            catch(Exception)
            {

            }
        }

        private void addProductInfo(ProductInfo productInfo)
        {
            int index = tblProductInfo.Rows.Add();
            if (index < 0)
                return;

            object[] values = new object[]{
                productInfo.productUrl, productInfo.size
            };

            tblProductInfo.Rows[index].SetValues(values);
            tblProductInfo.Rows[index].Tag = productInfo;
            productInfoList.Add(productInfo);
        }

        private void updateProductInfo(int index, ProductInfo productInfo)
        {
            if (index < 0)
            {
                Messagebox.show("Please select the item!");
                return;
            }

            ProductInfo productInfoOld = tblProductInfo.Rows[index].Tag as ProductInfo;
            if (productInfoOld == null)
            {
                Messagebox.show("Cannot delete the item!");
                return;
            }

            object[] values = new object[]{
                productInfo.productUrl, productInfo.size
            };

            tblProductInfo.Rows[index].SetValues(values);
            tblProductInfo.Rows[index].Tag = productInfo;

            productInfoList.RemoveAt(index);
            productInfoList.Insert(index, productInfo);
        }

        private void tblProductInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewCheckBoxCell chkCell = tblProductInfo.Rows[e.RowIndex].Cells["colBackdoor"] as DataGridViewCheckBoxCell;
                if (chkCell == null || chkCell.Value == null)
                    return;

                bool bChecked = (bool)chkCell.Value;
                if (!bChecked)
                    return;

                frmBackdoor frm = new frmBackdoor();

                DataGridViewButtonCell btnCell = tblProductInfo.Rows[e.RowIndex].Cells["colBackdoorInfo"] as DataGridViewButtonCell;
                if (btnCell.Tag != null)
                    frm.productId = btnCell.Tag as string;
                else
                    frm.productId = string.Empty;

                if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tblProductInfo.Rows[e.RowIndex].Cells[5].Tag = frm.productId;
                }
            }
        }

        private void tblProductInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tblProductInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveSettingInfo();
        }
    }
}
