using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing;

using HtmlAgilityPack;
using Newtonsoft.Json;

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

namespace BestBot.Controller
{
    public class Auto
    {
        private HttpClient httpClient = null;
        private TaskInfo item = null;
        private onWriteStatusEvent onWriteStatus = null;
        private string paymentUrl = string.Empty;
        public string price = string.Empty;
        public string order = string.Empty;
        private CookieContainer container = null;

        private IWebDriver driverChrome = null;
        private IWebDriver driverFirefox = null;
        private IWebDriver driverIE = null;

        public Auto(TaskInfo _item, onWriteStatusEvent _onWriteStatus)
        {
            item = _item;
            onWriteStatus = _onWriteStatus;

            if (httpClient == null)
                initHttpClient();

            //initChrome();
        }

        #region Selenium
        private void openIE()
        {
            try
            {
                if (item.proxy != null)
                {
                    Proxy proxy = new Proxy();
                    proxy.HttpProxy = string.Format("{0}:{1}", item.proxy._strIP, item.proxy._nPort);
                    
                }

                InternetExplorerDriverService ieDriverService = InternetExplorerDriverService.CreateDefaultService();
                ieDriverService.HideCommandPromptWindow = true;

                InternetExplorerOptions option = new InternetExplorerOptions();

                driverIE = new InternetExplorerDriver(ieDriverService, option);
                driverIE.Manage().Window.Maximize();

                System.Net.CookieCollection cookies = container.GetCookies(new Uri("http://www.adidas.com/"));
                if (cookies == null)
                    return;

                foreach (System.Net.Cookie cookie in cookies)
                {
                    driverIE.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value));
                }

                driverIE.Navigate().GoToUrl("https://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-Show");
            }
            catch (Exception e)
            {

            }
        }

        private void initChrome()
        {
            try
            {
                if (item.proxy != null)
                {
                    Proxy proxy = new Proxy();
                    proxy.HttpProxy = string.Format("{0}:{1}", item.proxy._strIP, item.proxy._nPort);

                }

                ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
                chromeDriverService.HideCommandPromptWindow = true;

                ChromeOptions option = new ChromeOptions();

                driverChrome = new ChromeDriver(chromeDriverService, option);
                driverChrome.Manage().Window.Maximize();

                driverChrome.Navigate().GoToUrl("https://www.adidas.com/");
                WaitForPageLoad(driverChrome, 30);
                ((IJavaScriptExecutor)driverChrome).ExecuteScript("return window.stop();");
            }
            catch(Exception e)
            {

            }
        }

        private void openChrome()
        {
            try
            {
                initChrome();

                driverChrome.Manage().Cookies.DeleteAllCookies();

                System.Net.CookieCollection cookies = container.GetCookies(new Uri("https://www.adidas.com/"));
                if (cookies == null)
                    return;

                foreach (System.Net.Cookie cookie in cookies)
                {
                    driverChrome.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, cookie.Expires));
                }

                driverChrome.Navigate().GoToUrl("https://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-Show");
            }
            catch (Exception e)
            {

            }
        }

        private void closeChrome()
        {
            try
            {
                if (driverChrome != null)
                    driverChrome.Close();
            }
            catch(Exception e)
            {

            }
        }

        private void openFirefox()
        {
            try
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.SetPreference("browser.startup.homepage", "about:blank");
                firefoxProfile.SetPreference("startup.homepage_welcome_url", "about:blank");
                firefoxProfile.SetPreference("startup.homepage_welcome_url.additional", "about:blank");

                if (item.proxy != null)
                {
                    Proxy proxy = new Proxy();
                    proxy.HttpProxy = string.Format("{0}:{1}", item.proxy._strIP, item.proxy._nPort);
                    firefoxProfile.SetProxyPreferences(proxy);
                }

                FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService();
                firefoxDriverService.HideCommandPromptWindow = true;

                FirefoxOptions option = new FirefoxOptions();
                option.Profile = firefoxProfile;

                driverFirefox = new FirefoxDriver(firefoxDriverService, option, TimeSpan.FromSeconds(60));
                driverFirefox.Manage().Window.Maximize();

                System.Net.CookieCollection cookies = container.GetCookies(new Uri("http://www.adidas.com/"));
                if (cookies == null)
                    return;

                foreach (System.Net.Cookie cookie in cookies)
                {
                    driverFirefox.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(cookie.Name, cookie.Value));
                }

                driverFirefox.Navigate().GoToUrl("https://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-Show");
            }
            catch(Exception e)
            {

            }
        }

        public void WaitForPageLoad(IWebDriver driver, int maxWaitTimeInSeconds)
        {
            string state = string.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitTimeInSeconds));

                //Checks every 500 ms whether predicate returns true if returns exit otherwise keep trying till it returns ture


                wait.Until(d =>
                {
                    try
                    {
                        state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();
                    }
                    catch (InvalidOperationException)
                    {
                        //Ignore
                    }
                    catch (NoSuchWindowException)
                    {
                        //when popup is closed, switch to last windows
                        driver.SwitchTo().Window(driver.WindowHandles.Last());
                    }
                    //In IE7 there are chances we may get state as loaded instead of complete
                    return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase));
                });
            }
            catch (TimeoutException)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls 

                //if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))
                //    throw;
            }
            catch (NullReferenceException)
            {
                //sometimes Page remains in Interactive mode and never becomes Complete, then we can still try to access the controls 

                //if (!state.Equals("interactive", StringComparison.InvariantCultureIgnoreCase))

                //    throw;
            }
            catch (WebDriverException)
            {
                if (driver.WindowHandles.Count == 1)
                {
                    driver.SwitchTo().Window(driver.WindowHandles[0]);
                }

                state = ((IJavaScriptExecutor)driver).ExecuteScript(@"return document.readyState").ToString();

                //if (!(state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase)))
                //    throw;
            }
        }

        #endregion


        #region HttpRequest
        private void initHttpClient()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                container = new CookieContainer();
                handler.CookieContainer = container;

                if (item.proxy != null && !string.IsNullOrEmpty(item.proxy._strIP))
                {
                    int port = 8080;
                    if (int.TryParse(item.proxy._nPort, out port))
                    {
                        handler.Proxy = new WebProxy(item.proxy._strIP, int.Parse(item.proxy._nPort));
                        if (!string.IsNullOrEmpty(item.proxy._cId))
                            handler.Proxy.Credentials = new NetworkCredential(item.proxy._cId, item.proxy._cPass);
                    }
                }

                httpClient = new HttpClient(handler);

                initHttpHeader();
            }
            catch(Exception e)
            {

            }
        }

        private void initHttpHeader()
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en");
        }
        #endregion


        #region Shopping

        public async Task<bool> doWork()
        {
            try
            {
                //addtocart
                
                while (Constant.bRun && !await doAddToCart())
                {
                    onWriteStatus("Failed to add to cart, so it will be delay for 5 seconds...");
                    onWriteStatus("Add to cart retrying...");
                    Thread.Sleep(5000);
                }

                if (!Constant.bRun)
                    return false;

                onWriteStatus("Successfully add to cart!");

                if (!item.autoCheckout)
                {
                    openChrome();
                    return true;
                }

                if (!Constant.bRun)
                    return false;

                //checkout
                onWriteStatus("Check out...");
                bool bSuccess = await doCheckout();
                if (bSuccess)
                    onWriteStatus("Successfully check out!");
                else
                    onWriteStatus("Fail to check out!");

                return bSuccess;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private async Task<bool> doAddToCart()
        {
            try
            {
                if (item.backdoor)
                    return await doBackdoor();
                else
                    return await doUnBackdoor();
            }
            catch(Exception)
            {
                return false;
            }
        }

        private async Task<bool> doUnBackdoor()
        {
            try
            {
                HtmlNode.ElementsFlags.Remove("form");
                HtmlNode.ElementsFlags.Remove("option");
                HtmlDocument doc = new HtmlDocument();

                string strContent = string.Empty;
                string recaptchaCode = string.Empty;

                while(Constant.bRun)
                {
                    try
                    {
                        onWriteStatus("Scanning the product...");
                        HttpResponseMessage message = await httpClient.GetAsync(item.productUrl);
                        if (message.StatusCode == HttpStatusCode.Forbidden)
                        {
                            onWriteStatus("Proxy address has been banned!");
                            return false;
                        }

                        strContent = await message.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(strContent))
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        GroupCollection groups = Regex.Match(strContent, "app\\.URLs\\.paymentPage = \"(?<paymentUrl>.*)\";").Groups;
                        if (groups == null || groups["paymentUrl"] == null)
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        paymentUrl = groups["paymentUrl"].Value;
                        if (string.IsNullOrEmpty(paymentUrl))
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        httpClient.DefaultRequestHeaders.Referrer = new Uri(item.productUrl);

                        doc.LoadHtml(strContent);

                        IEnumerable<HtmlNode> nodeCart = doc.DocumentNode.Descendants("button").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "add-to-cart-button");
                        if (nodeCart == null || nodeCart.LongCount() < 1)
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        onWriteStatus("Product found!");

                        break;
                    }
                    catch(Exception)
                    {
                        Thread.Sleep(Setting.instance.interval);
                    }
                }

                string backContent = strContent;

                if (strContent.Contains("https://www.google.com/recaptcha/api.js"))
                {
                    recaptchaCode = trySolvingCaptcha();
                    if (string.IsNullOrEmpty(recaptchaCode))
                    {
                        onWriteStatus("Cannot solve captcha!");
                        return false;
                    }
                }

                doc.LoadHtml(backContent);
                IEnumerable<HtmlNode> nodeForms = doc.DocumentNode.Descendants("form").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "addProductForm");
                if (nodeForms == null || nodeForms.LongCount() < 1)
                    return false;

                HtmlNode nodeForm = nodeForms.ToArray()[0];
                if (nodeForm == null)
                    return false;

                IEnumerable<HtmlNode> nodeLayer = nodeForm.Descendants("input").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "layer");
                if (nodeLayer == null || nodeLayer.LongCount() < 1)
                    return false;

                string layer = nodeLayer.ToArray()[0].GetAttributeValue("value", "");
                if (string.IsNullOrEmpty(layer))
                {
                    onWriteStatus("There is no correct size!");
                    return false;
                }

                IEnumerable<HtmlNode> nodemasterPid = doc.DocumentNode.Descendants("input").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "masterPid");
                if (nodemasterPid == null || nodemasterPid.LongCount() < 1)
                {
                    onWriteStatus("There is no correct size!");
                    return false;
                }

                string masterPid = nodemasterPid.ToArray()[0].GetAttributeValue("value", "");
                if (masterPid == null)
                {
                    onWriteStatus("There is no correct size!");
                    return false;
                }

                IEnumerable<HtmlNode> nodeSelect = doc.DocumentNode.Descendants("select").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "pid");
                if (nodeSelect == null || nodeSelect.LongCount() < 1)
                {
                    onWriteStatus("There is no correct size!");
                    return false;
                }

                string pid = getPid(nodeSelect.ToArray()[0], item.size);
                if (string.IsNullOrEmpty(pid))
                {
                    onWriteStatus("There is no correct size!");
                    return false;
                }

                if (pid == "Sold out")
                {
                    onWriteStatus("Sold out");
                    return false;
                }

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");

                //onWriteStatus("Add to bag...");

                if (!Constant.bRun)
                    return false;

                HttpResponseMessage responseMessageAddToCart = null;

                if (string.IsNullOrEmpty(recaptchaCode))
                {
                    responseMessageAddToCart = await httpClient.PostAsync("http://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-MiniAddProduct", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[5]{
                        new KeyValuePair<string, string>("layer", layer),
                        new KeyValuePair<string, string>("pid", pid),
                        new KeyValuePair<string, string>("Quantity", "1"),
                        new KeyValuePair<string, string>("masterPid", masterPid),
                        new KeyValuePair<string, string>("ajax", "true")
                    }));
                }
                else
                {
                    responseMessageAddToCart = await httpClient.PostAsync("http://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-MiniAddProduct", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[6]{
                        new KeyValuePair<string, string>("layer", layer),
                        new KeyValuePair<string, string>("pid", pid),
                        new KeyValuePair<string, string>("Quantity", "1"),
                        new KeyValuePair<string, string>("g-recaptcha-response", recaptchaCode),
                        new KeyValuePair<string, string>("masterPid", masterPid),
                        new KeyValuePair<string, string>("ajax", "true")
                    }));
                }

                responseMessageAddToCart.EnsureSuccessStatusCode();

                HttpResponseMessage responseMessageCartProductCount = await httpClient.GetAsync("http://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-ProductCount");
                responseMessageCartProductCount.EnsureSuccessStatusCode();

                string productCount = await responseMessageCartProductCount.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(productCount))
                {
                    onWriteStatus("Failed to Cart!");
                    return false;
                }

                int nCount = 0;
                if (!int.TryParse(productCount.Trim().Trim('"'), out nCount) || nCount < 1 || nCount > 3)
                {
                    onWriteStatus("Failed 3 over carts!");
                    return false;
                }

                if (productCount.Contains("{\"success\": false,\"error\":\"INVALID_CAPTCHA\"}"))
                {
                    onWriteStatus("Cannot solve the captcha!");
                    return false;
                }

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private async Task<bool> doBackdoor()
        {
            try
            {
                HtmlNode.ElementsFlags.Remove("form");
                HtmlNode.ElementsFlags.Remove("option");
                HtmlDocument doc = new HtmlDocument();

                string strContent = string.Empty;

                while (Constant.bRun)
                {
                    try
                    {
                        onWriteStatus("Scanning the product...");
                        HttpResponseMessage message = await httpClient.GetAsync(item.productUrl);
                        if (message.StatusCode == HttpStatusCode.Forbidden)
                        {
                            onWriteStatus("Proxy address has been banned!");
                            return false;
                        }

                        strContent = await message.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(strContent))
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        GroupCollection groups = Regex.Match(strContent, "app\\.URLs\\.paymentPage = \"(?<paymentUrl>.*)\";").Groups;
                        if (groups == null || groups["paymentUrl"] == null)
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        paymentUrl = groups["paymentUrl"].Value;
                        if (string.IsNullOrEmpty(paymentUrl))
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        httpClient.DefaultRequestHeaders.Referrer = new Uri(item.productUrl);

                        doc.LoadHtml(strContent);

                        IEnumerable<HtmlNode> nodeCart = doc.DocumentNode.Descendants("button").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "add-to-cart-button");
                        if (nodeCart == null || nodeCart.LongCount() < 1)
                        {
                            Thread.Sleep(Setting.instance.interval);
                            continue;
                        }

                        onWriteStatus("Product found!");

                        break;
                    }
                    catch (Exception)
                    {
                        Thread.Sleep(Setting.instance.interval);
                    }
                }

                string recaptchaCode = trySolvingCaptcha();

                string masterId = item.backdoorInfo.Split(new char[]{'_'})[0];
                string backdoorUrl = string.Format("http://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/Cart-MiniAddProduct?pid={0}&masterPid={1}&ajax=true&g-recaptcha-response={2}", item.backdoorInfo, masterId, recaptchaCode);

                onWriteStatus(backdoorUrl);

                HttpResponseMessage responseMessageBackdoor = await httpClient.GetAsync(backdoorUrl);
                //responseMessageBackdoor.EnsureSuccessStatusCode();

                string responseMessageBackdoorString = await responseMessageBackdoor.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessageBackdoorString))
                    return false;

                File.WriteAllText(string.Format("{0}.txt", masterId), responseMessageBackdoorString);

                doc.LoadHtml(responseMessageBackdoorString);

                IEnumerable<HtmlNode> nodeA = doc.DocumentNode.Descendants("a").Where(node => node.Attributes["class"] != null && node.Attributes["class"].Value == "minicarttotal");
                if (nodeA == null || nodeA.LongCount() < 1)
                    return false;

                if (nodeA.ToArray()[0].InnerText.Trim() == "1")
                    return true;

                return false;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private async Task<bool> doCheckout()
        {
            try
            {
                HttpResponseMessage responseMessageStart = await httpClient.GetAsync("https://www.adidas.com/us/delivery-start");
                responseMessageStart.EnsureSuccessStatusCode();

                string responseMessageStartString = await responseMessageStart.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessageStartString))
                    return false;

                HtmlNode.ElementsFlags.Remove("form");
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(responseMessageStartString);

                IEnumerable<HtmlNode> nodeForms = doc.DocumentNode.Descendants("form").Where(node => node.Attributes["id"] != null && node.Attributes["id"].Value == "dwfrm_delivery");
                if (nodeForms == null || nodeForms.LongCount() < 1)
                    return false;

                HtmlNode nodeForm = nodeForms.ToArray()[0];
                if (nodeForm == null)
                    return false;

                string action = nodeForm.GetAttributeValue("action", "");
                if (string.IsNullOrEmpty(action))
                    return false;

                IEnumerable<HtmlNode> nodeInputs = nodeForm.Descendants("input").Where(node => node.Attributes["name"] != null);
                if (nodeInputs == null || nodeInputs.LongCount() < 1)
                    return false;

                IList<KeyValuePair<string, string>> postParams = new List<KeyValuePair<string, string>>();
                foreach(HtmlNode nodeInput in nodeInputs)
                {
                    string name = nodeInput.GetAttributeValue("name", "");
                    if (string.IsNullOrEmpty(name))
                        continue;

                    string value = nodeInput.GetAttributeValue("value", "");
                    if (value == null)
                        value = string.Empty;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_firstName")
                        value = item.profile.deliveryInfo.firstName;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_lastName")
                        value = item.profile.deliveryInfo.lastName;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_address1")
                        value = item.profile.deliveryInfo.address.Length > 25 ? item.profile.deliveryInfo.address.Substring(0, 25) : item.profile.deliveryInfo.address;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_city")
                        value = item.profile.deliveryInfo.city;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_zip")
                        value = item.profile.deliveryInfo.zipCode;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_addressFields_phone")
                        value = item.profile.deliveryInfo.phone;

                    if (name == "dwfrm_foreignaddress_firstName")
                        continue;

                    if (name == "dwfrm_foreignaddress_lastName")
                        continue;

                    if (name == "dwfrm_foreignaddress_address1")
                        continue;

                    if (name == "dwfrm_foreignaddress_address2")
                        continue;

                    if (name == "dwfrm_foreignaddress_city")
                        continue;

                    if (name == "dwfrm_foreignaddress_zip")
                        continue;

                    if (name == "dwfrm_foreignaddress_phone")
                        continue;

                    if (name == "dwfrm_delivery_singleshipping_shippingAddress_email_emailAddress")
                        value = item.profile.deliveryInfo.email;

                    if(name == "shipping-group-0")
                    {
                        string checkedAttr = nodeInput.GetAttributeValue("checked", "");
                        if (checkedAttr != "checked")
                            continue;
                    }

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_firstName")
                        value = item.profile.deliveryInfo.firstName;

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_lastName")
                        value = item.profile.deliveryInfo.lastName;

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_address1")
                        value = item.profile.deliveryInfo.address.Length > 25 ? item.profile.deliveryInfo.address.Substring(0, 25) : item.profile.deliveryInfo.address;

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_city")
                        value = item.profile.deliveryInfo.city;

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_phone")
                        value = item.profile.deliveryInfo.phone;

                    if (name == "dwfrm_delivery_billing_billingAddress_addressFields_zip")
                        value = item.profile.deliveryInfo.zipCode;

                    if (name == "state")
                        name = "state[]";

                    postParams.Add(new KeyValuePair<string, string>(name, value));
                }

                postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_singleshipping_shippingAddress_addressFields_countyProvince", Constant.states[item.profile.deliveryInfo.state]));
                postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_billing_billingAddress_addressFields_countyProvince", Constant.states[item.profile.deliveryInfo.state]));
                postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_billing_billingAddress_addressFields_country", "US"));
                //postParams.Add(new KeyValuePair<string, string>("shipping-group-0", "Standard"));
                postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_savedelivery", "Review%20and%20Pay"));
                postParams.Add(new KeyValuePair<string, string>("format", "ajax"));

                if (responseMessageStartString.Contains("dwfrm_delivery_singleshipping_shippingAddress_addressFields_birthday_month"))
                {
                    string[] birthdays = item.profile.deliveryInfo.birthday.Split(new char[] { '/' }, StringSplitOptions.None);
                    if(birthdays == null || birthdays.Length < 3)
                        return false;

                    if(string.IsNullOrEmpty(birthdays[0]) || string.IsNullOrEmpty(birthdays[1]) || string.IsNullOrEmpty(birthdays[2]))
                        return false;

                    postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_singleshipping_shippingAddress_addressFields_birthday_month", (int.Parse(birthdays[0]) - 1).ToString()));
                    postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_singleshipping_shippingAddress_addressFields_birthday_dayofmonth", birthdays[1]));
                    postParams.Add(new KeyValuePair<string, string>("dwfrm_delivery_singleshipping_shippingAddress_addressFields_birthday_year", birthdays[2]));
                }

                httpClient.DefaultRequestHeaders.Remove("Accept");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html, */*; q=0.01");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
                httpClient.DefaultRequestHeaders.Referrer = new Uri("https://www.adidas.com/us/delivery-start");
                HttpResponseMessage responseMessageCheckout = await httpClient.PostAsync(action, (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)postParams));
                responseMessageCheckout.EnsureSuccessStatusCode();

                //HttpResponseMessage responseMessagePayment = await httpClient.GetAsync(paymentUrl);
                //responseMessagePayment.EnsureSuccessStatusCode();

                //string responseMessagePaymentString = await responseMessagePayment.Content.ReadAsStringAsync();
                //if (string.IsNullOrEmpty(responseMessagePaymentString))
                //    return false;

                //GroupCollection groups = Regex.Match(responseMessagePaymentString, "\"sklUrl\": \"(?<sklUrl>.*)\",").Groups;
                //if (groups == null || groups["sklUrl"] == null)
                //    return false;

                //string sklUrl = groups["sklUrl"].Value;
                //if (string.IsNullOrEmpty(sklUrl))
                //    return false;

                //if (!sklUrl.Contains("https://www.adidas.com"))
                //    sklUrl = "https://www.adidas.com" + sklUrl;

                //httpClient.DefaultRequestHeaders.Referrer = new Uri(paymentUrl);
                httpClient.DefaultRequestHeaders.Remove("Accept");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                httpClient.DefaultRequestHeaders.Remove("X-Requested-With");
                HttpResponseMessage responseMessageSkl = await httpClient.GetAsync("https://www.adidas.com/on/demandware.store/Sites-adidas-US-Site/en_US/COSummary-Start");
                responseMessageSkl.EnsureSuccessStatusCode();

                string responseMessageSklString = await responseMessageSkl.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessageSklString))
                    return false;

                doc.LoadHtml(responseMessageSklString);

                nodeForms = doc.DocumentNode.Descendants("form").Where(node => node.Attributes["id"] != null && node.Attributes["id"].Value == "dwfrm_delivery");
                if (nodeForms == null || nodeForms.LongCount() < 1)
                    return false;

                action = nodeForms.ToArray()[0].GetAttributeValue("action", "");
                if (string.IsNullOrEmpty(action))
                    return false;

                nodeForms = doc.DocumentNode.Descendants("form").Where(node => node.Attributes["id"] != null && node.Attributes["id"].Value == "dwfrm_payment");
                if (nodeForms == null || nodeForms.LongCount() < 1)
                    return false;

                nodeForm = nodeForms.ToArray()[0];
                if (nodeForm == null)
                    return false;

                IEnumerable<HtmlNode> nodeOwner = doc.DocumentNode.Descendants("input").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "dwfrm_payment_creditCard_owner");
                if(nodeOwner == null || nodeOwner.LongCount() < 1)
                    return false;

                string owner = nodeOwner.ToArray()[0].GetAttributeValue("value", "");
                if(string.IsNullOrEmpty(owner))
                    return false;

                IEnumerable<HtmlNode> nodeSecuriy = doc.DocumentNode.Descendants("input").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "dwfrm_payment_securekey");
                if(nodeSecuriy == null || nodeSecuriy.LongCount() < 1)
                    return false;

                string security = nodeSecuriy.ToArray()[0].GetAttributeValue("value", "");
                if(string.IsNullOrEmpty(security))
                    return false;

                IEnumerable<HtmlNode> nodeSign = doc.DocumentNode.Descendants("input").Where(node => node.Attributes["name"] != null && node.Attributes["name"].Value == "dwfrm_payment_signcreditcardfields");
                if (nodeSign == null || nodeSign.LongCount() < 1)
                    return false;

                string sign = nodeSign.ToArray()[0].GetAttributeValue("value", "");
                if (string.IsNullOrEmpty(sign))
                    return false;

                string[] expires = item.profile.cardInfo.expires.Split(new char[] { '/' }, StringSplitOptions.None);
                if(expires == null || expires.Length < 2)
                    return false;

                if(string.IsNullOrEmpty(expires[0]) || string.IsNullOrEmpty(expires[1]))
                    return false;

                if (!Constant.bRun)
                    return false;

                httpClient.DefaultRequestHeaders.Remove("Accept");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json, text/javascript, */*; q=0.01");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "XMLHttpRequest");
                HttpResponseMessage responseMessagePay = await httpClient.PostAsync(action, (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[9]{
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_type", "001"),
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_owner", owner),
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_month", expires[0]),
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_year", "20" + expires[1]),
                    new KeyValuePair<string, string>("dwfrm_payment_securekey", security),
                    new KeyValuePair<string, string>("dwfrm_payment_signcreditcardfields", sign),
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_number", item.profile.cardInfo.cardNo),
                    new KeyValuePair<string, string>("dwfrm_payment_creditCard_cvn", item.profile.cardInfo.security),
                    new KeyValuePair<string, string>("selectedPaymentMethodID", "CREDIT_CARD")
                }));
                responseMessagePay.EnsureSuccessStatusCode();

                string responseMessagePayString = await responseMessagePay.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessagePayString))
                    return false;

                JsonData data = JsonConvert.DeserializeObject<JsonData>(responseMessagePayString);
                if (data == null || data.hasErrors)
                    return false;

                if (data.fieldsToSubmit == null)
                    return false;

                price = data.fieldsToSubmit.amount;
                if (string.IsNullOrEmpty(price))
                    return false;

                httpClient.DefaultRequestHeaders.Remove("Accept");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                httpClient.DefaultRequestHeaders.Remove("X-Requested-With");
                HttpResponseMessage responseMessageSlient = await httpClient.PostAsync("https://secureacceptance.cybersource.com/silent/pay", (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)new KeyValuePair<string, string>[57]{
                    new KeyValuePair<string, string>("access_key", data.fieldsToSubmit.access_key),
                    new KeyValuePair<string, string>("amount", data.fieldsToSubmit.amount),
                    new KeyValuePair<string, string>("bill_to_address_city", data.fieldsToSubmit.bill_to_address_city),
                    new KeyValuePair<string, string>("bill_to_address_country", data.fieldsToSubmit.bill_to_address_country),
                    new KeyValuePair<string, string>("bill_to_address_line1", data.fieldsToSubmit.bill_to_address_line1),
                    new KeyValuePair<string, string>("bill_to_address_postal_code", data.fieldsToSubmit.bill_to_address_postal_code),
                    new KeyValuePair<string, string>("bill_to_address_state", data.fieldsToSubmit.bill_to_address_state),
                    new KeyValuePair<string, string>("bill_to_email", data.fieldsToSubmit.bill_to_email),
                    new KeyValuePair<string, string>("bill_to_forename", data.fieldsToSubmit.bill_to_forename),
                    new KeyValuePair<string, string>("bill_to_phone", data.fieldsToSubmit.bill_to_phone),
                    new KeyValuePair<string, string>("bill_to_surname", data.fieldsToSubmit.bill_to_surname),
                    new KeyValuePair<string, string>("card_cvn", item.profile.cardInfo.security),
                    new KeyValuePair<string, string>("card_expiry_date", data.fieldsToSubmit.card_expiry_date),
                    new KeyValuePair<string, string>("card_number", item.profile.cardInfo.cardNo),
                    new KeyValuePair<string, string>("card_number", item.profile.cardInfo.cardNo.Replace(" ", "")),
                    new KeyValuePair<string, string>("card_type", data.fieldsToSubmit.card_type),
                    new KeyValuePair<string, string>("currency", data.fieldsToSubmit.currency),
                    new KeyValuePair<string, string>("customer_ip_address", data.fieldsToSubmit.customer_ip_address),
                    new KeyValuePair<string, string>("device_fingerprint_id", data.fieldsToSubmit.device_fingerprint_id),
                    new KeyValuePair<string, string>("item_0_code", data.fieldsToSubmit.item_0_code),
                    new KeyValuePair<string, string>("item_0_name", data.fieldsToSubmit.item_0_name),
                    new KeyValuePair<string, string>("item_0_quantity", data.fieldsToSubmit.item_0_quantity),
                    new KeyValuePair<string, string>("item_0_sku", data.fieldsToSubmit.item_0_sku),
                    new KeyValuePair<string, string>("item_0_tax_amount", data.fieldsToSubmit.item_0_tax_amount),
                    new KeyValuePair<string, string>("item_0_unit_price", data.fieldsToSubmit.item_0_unit_price),
                    new KeyValuePair<string, string>("item_1_code", data.fieldsToSubmit.item_1_code),
                    new KeyValuePair<string, string>("item_1_name", data.fieldsToSubmit.item_1_name),
                    new KeyValuePair<string, string>("item_1_quantity", data.fieldsToSubmit.item_1_quantity),
                    new KeyValuePair<string, string>("item_1_sku", data.fieldsToSubmit.item_1_sku),
                    new KeyValuePair<string, string>("item_1_tax_amount", data.fieldsToSubmit.item_1_tax_amount),
                    new KeyValuePair<string, string>("item_1_unit_price", data.fieldsToSubmit.item_1_unit_price),
                    new KeyValuePair<string, string>("line_item_count", data.fieldsToSubmit.line_item_count),
                    new KeyValuePair<string, string>("locale", data.fieldsToSubmit.locale),
                    new KeyValuePair<string, string>("merchant_defined_data1", data.fieldsToSubmit.merchant_defined_data1),
                    new KeyValuePair<string, string>("merchant_defined_data2", data.fieldsToSubmit.merchant_defined_data2),
                    new KeyValuePair<string, string>("merchant_defined_data4", data.fieldsToSubmit.merchant_defined_data4),
                    new KeyValuePair<string, string>("merchant_defined_data6", data.fieldsToSubmit.merchant_defined_data6),
                    new KeyValuePair<string, string>("merchant_defined_data7", data.fieldsToSubmit.merchant_defined_data7),
                    new KeyValuePair<string, string>("override_custom_receipt_page", data.fieldsToSubmit.override_custom_receipt_page),
                    new KeyValuePair<string, string>("payment_method", data.fieldsToSubmit.payment_method),
                    new KeyValuePair<string, string>("profile_id", data.fieldsToSubmit.profile_id),
                    new KeyValuePair<string, string>("reference_number", data.fieldsToSubmit.reference_number),
                    new KeyValuePair<string, string>("ship_to_address_city", data.fieldsToSubmit.ship_to_address_city),
                    new KeyValuePair<string, string>("ship_to_address_country", data.fieldsToSubmit.ship_to_address_country),
                    new KeyValuePair<string, string>("ship_to_address_line1", data.fieldsToSubmit.ship_to_address_line1),
                    new KeyValuePair<string, string>("ship_to_address_postal_code", data.fieldsToSubmit.ship_to_address_postal_code),
                    new KeyValuePair<string, string>("ship_to_address_state", data.fieldsToSubmit.ship_to_address_state),
                    new KeyValuePair<string, string>("ship_to_forename", data.fieldsToSubmit.ship_to_forename),
                    new KeyValuePair<string, string>("ship_to_phone", data.fieldsToSubmit.ship_to_phone),
                    new KeyValuePair<string, string>("ship_to_surname", data.fieldsToSubmit.ship_to_surname),
                    new KeyValuePair<string, string>("signature", data.fieldsToSubmit.signature),
                    new KeyValuePair<string, string>("signed_date_time", data.fieldsToSubmit.signed_date_time),
                    new KeyValuePair<string, string>("signed_field_names", data.fieldsToSubmit.signed_field_names),
                    new KeyValuePair<string, string>("tax_amount", data.fieldsToSubmit.tax_amount),
                    new KeyValuePair<string, string>("transaction_type", data.fieldsToSubmit.transaction_type),
                    new KeyValuePair<string, string>("transaction_uuid", data.fieldsToSubmit.transaction_uuid),
                    new KeyValuePair<string, string>("unsigned_field_names", data.fieldsToSubmit.unsigned_field_names)
                }));

                responseMessageSlient.EnsureSuccessStatusCode();

                string responseMessageSlientString = await responseMessageSlient.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessageSlientString))
                    return false;

                doc.LoadHtml(responseMessageSlientString);

                nodeForms = doc.DocumentNode.Descendants("form").Where(node => node.Attributes["id"] != null && node.Attributes["id"].Value == "custom_redirect");
                if (nodeForms == null || nodeForms.LongCount() < 1)
                    return false;

                nodeForm = nodeForms.ToArray()[0];
                if (nodeForm == null)
                    return false;

                action = nodeForm.GetAttributeValue("action", "");
                if (string.IsNullOrEmpty(action))
                    return false;

                nodeInputs = nodeForm.Descendants("input").Where(node => node.Attributes["name"] != null);
                if (nodeInputs == null || nodeInputs.LongCount() < 1)
                    return false;

                postParams = new List<KeyValuePair<string, string>>();
                foreach (HtmlNode nodeInput in nodeInputs)
                {
                    string name = nodeInput.GetAttributeValue("name", "");
                    if (string.IsNullOrEmpty(name))
                        continue;

                    string value = nodeInput.GetAttributeValue("value", "");
                    if (value == null)
                        value = string.Empty;

                    if (name == "commit")
                        continue;

                    postParams.Add(new KeyValuePair<string, string>(name, value));
                }

                httpClient.DefaultRequestHeaders.Referrer = new Uri("https://secureacceptance.cybersource.com/silent/pay");
                HttpResponseMessage responseMessageOrder = await httpClient.PostAsync(action, (HttpContent)new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>)postParams));
                responseMessageOrder.EnsureSuccessStatusCode();

                string responseMessageOrderString = await responseMessageOrder.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseMessageOrderString))
                    return false;

                GroupCollection groups = Regex.Match(responseMessageOrderString, "{\"orderId\":\"(?<order>\\w*)\"").Groups;
                if (groups == null || groups["order"] == null)
                    return false;

                order = groups["order"].Value;
                if (string.IsNullOrEmpty(order))
                    return false;

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        private string trySolvingCaptcha()
        {
            onWriteStatus("Solving captcha...");

            string verifyCode = string.Empty;

            try
            {
                string sendUrl = string.Format("http://2captcha.com/in.php?key={0}&method=userrecaptcha&googlekey={1}", Setting.instance.captchaKey, Constant.googleKey);
                HttpResponseMessage responseMessageMain = httpClient.GetAsync(sendUrl).Result;
                responseMessageMain.EnsureSuccessStatusCode();

                string sendUrlString = responseMessageMain.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(sendUrlString))
                    return verifyCode;

                if (!sendUrlString.Contains("OK|"))
                    return verifyCode;

                string captchaId = sendUrlString.Replace("OK|", string.Empty);
                if (string.IsNullOrEmpty(captchaId))
                    return verifyCode;

                string verifyUrl = string.Format("http://2captcha.com/res.php?key={0}&action=get&id={1}", Setting.instance.captchaKey, captchaId);

                int requestCount = 0;
                while (requestCount < 20)
                {
                    Thread.Sleep(5000);
                    requestCount++;

                    HttpResponseMessage responseMessageVerify = httpClient.GetAsync(verifyUrl).Result;
                    responseMessageVerify.EnsureSuccessStatusCode();

                    string verifyUrlString = responseMessageVerify.Content.ReadAsStringAsync().Result;
                    if (string.IsNullOrEmpty(verifyUrlString))
                        continue;

                    if (!verifyUrlString.Contains("OK|"))
                        continue;

                    verifyCode = verifyUrlString.Replace("OK|", string.Empty);
                    break;
                }

                return verifyCode;
            }
            catch (Exception e)
            {
                return verifyCode;
            }
        }

        private string getPid(HtmlNode node, string size)
        {
            List<string> sizeList = new List<string>();

            IEnumerable<HtmlNode> nodeOptions = node.Descendants("option");
            if (nodeOptions == null || nodeOptions.LongCount() < 1)
                return "";

            foreach (HtmlNode nodeOption in nodeOptions)
            {
                string sizeTemp = nodeOption.InnerText.Trim();

                if (sizeTemp == "Sold out")
                    return sizeTemp;

                if (sizeTemp == size)
                    return nodeOption.GetAttributeValue("value", "");
            }

            return "";
        }

        #endregion
    }
}