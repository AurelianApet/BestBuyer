using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;

using BestBot.Model;

namespace BestBot.View
{
    public partial class frmStatus : Form
    {
        public List<HttpsProxy> proxyList { get; set; }
        public List<HttpsProxy> availableProxyList { get; set; }
        public frmStatus()
        {
            InitializeComponent();
            availableProxyList = new List<HttpsProxy>();
        }

        private void frmStatus_Load(object sender, EventArgs e)
        {
            timerProgress.Start();
        }

        private bool checkProxy(HttpsProxy proxy)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.Proxy = new WebProxy(proxy._strIP, int.Parse(proxy._nPort));
                HttpClient httpClient = new HttpClient(handler);
                HttpResponseMessage responseMessage = httpClient.GetAsync("http://www.adidas.com/").Result;
                if (responseMessage.StatusCode != HttpStatusCode.OK)
                    return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar.Maximum = proxyList.Count;
                for (int i = 0; i < proxyList.Count; i++)
                {
                    progressBar.Value = i + 1;
                    lblStatus.Text = string.Format("checking {0}th proxy of {1} proxy list...", (i + 1), proxyList.Count);

                    if (checkProxy(proxyList[i]))
                        availableProxyList.Add(proxyList[i]);
                }
            }
            catch(Exception)
            {

            }

            timerProgress.Stop();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
