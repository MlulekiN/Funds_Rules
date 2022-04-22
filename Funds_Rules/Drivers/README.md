using System;
using System.Collections.Generic;
using System.Text;

namespace Funds_Rules.Drivers
{
    class README
    { using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;



namespace Funds_Rules.Steps
{
    [Binding]

  
    public sealed class Promo_Rules
    {
        public string url = "https://to-pdi.salesperformanceplatform.com/xtelsp-automhfx/web/SM1V6/SM1.aspx?DBG=1";
        // public string url = "https://to-pdi.salesperformanceplatform.com/xtelsp-autom/web/?DBG=1";
        public static IWebDriver driver;
        public static WebDriverWait Wait;

       
        IWebElement loadWait = driver.FindElement(By.XPath("//div[@id='sm1WaitDiv' and @class='sm1waitdiv']"));

        [Given(@"The user has logged in the application")]
        public void GivenTheUserHasLoggedInTheApplication()
        {

            ChromeOptions options = new ChromeOptions();
            var userProfile = @"%UserProfile%\AppData\Local\Google\Chrome\User Data\Profile 2";
            options.AddArgument("--profile-directory=Profile 2");

            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(180));
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Manage().Window.Maximize();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(300))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };
            wait.IgnoreExceptionTypes(typeof(TimeoutException), typeof(NoSuchElementException));
            wait.Until(ExpectedConditions.ElementIsVisible(Elements.homeToolBar));
        }

        [When(@"User clicks on toolbar menu")]
        public void WhenUserClicksOnToolbarMenu()
        {

            IWebElement homePage = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.homeToolBar));
            homePage.Click();
        }

        [When(@"User searches and clicks on '(.*)'")]
        public void WhenUserClicksOn(string getText)
        {
            IWebElement searchBox = driver.FindElement(Elements.searchBox);
            searchBox.Click();
            searchBox.SendKeys(getText);
            IWebElement toolTab = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.ToolFunction(getText)));
            toolTab.Click();
        }

        [Then(@"Multiple ID's are displayed\.")]
        public void ThenMultipleIDSAreDisplayed_()
        {
            Assert.IsNotEmpty("toolTab");
        }

        [When(@"User clicks on the add button")]
        public void WhenUserClicksOnTheAddButton()
        {
            IWebElement addButton = driver.FindElement(Elements.addButton);
            addButton.Click();
        }

        [When(@"Inputs '(.*)'")]
        public void WhenInputs(string configSelect)
        {
            IWebElement selectID = driver.FindElement(Elements.selectConfigID(configSelect));
            selectID.Click();
        }

        [When(@"Clicks on the ok button")]
        public void WhenClicksOnTheOkButton()
        {
            IWebElement configOkButton = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.configIdOkButton));
            configOkButton.Click();
        }

        [When(@"User waits for the page to load")]
        public void WhenUserWaitsForThePageToLoad()
        {
            Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Elements.loading));
        }

        [When(@"User clicks on customer level dropdown list until '(.*)' is displayed")]
        public void WhenUserClicksOnCustomerLevelDropdownList(string level)
        {
            ClickUntilElementIsDisplayed(Elements.customerLevelDropList, Elements.CustomerLevel(level));
        }

        [When(@"User selects on the customer level '(.*)'")]
        public void WhenUserSelectsOnTheCustomerLevel(string level)
        {
            IWebElement levelSelect = driver.FindElement(Elements.CustomerLevel(level));
            levelSelect.Click();
        }

        [When(@"Clicks on the config id dropdown list until '(.*)' is displayed")]
        public void WhenClicksOnTheTextTab(string configSelect)
        {
            ClickUntilElementIsDisplayed(Elements.dropDownList, Elements.selectConfigID(configSelect));
        }

        public void ClickUntilElementIsDisplayed(By elementToClick, By elementToValidate)
        {
            //  IWebElement column = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-qtip='Close dialog']")));
            //  column.Click();
            driver.FindElement(elementToClick).Click();
            bool isKPIDisplayed = false;
            while (!isKPIDisplayed)
            {
                if (driver.FindElements(elementToValidate).Count > 0)
                {
                    if (driver.FindElement(elementToValidate).Displayed)
                    {
                        isKPIDisplayed = true;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        driver.FindElement(elementToClick).Click();
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    driver.FindElement(elementToClick).Click();
                }
            }
        }

        [When(@"User selects the sell in period (.*)")]
        public void WhenUserSelectsTheSellInPeriod(string sellInDate)
        {
            string date = "21/Apr/2022";
            string expectdateDay = date.Split("/")[0];
            string expectdateMonth = date.Split("/")[1];
            string expectdateYear = date.Split("/")[2];

            IWebElement selectDate = driver.FindElement(Elements.startElDate);
            selectDate.Click();
            IWebElement selectMonth = driver.FindElement(Elements.monthSelect);
            selectMonth.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.SpecificDateMonth(expectdateMonth))).Click();
            driver.FindElement(Elements.specificDateYear(expectdateYear)).Click();
            //driver.FindElement(Elements.specificDate(expectdateMonth)).Click();
            //driver.FindElement(Elements.specificDate(expectdateYear)).Click();
            driver.FindElement(Elements.innerMonthOkButton).Click();
            driver.FindElement(Elements.selectEndDay(expectdateDay)).Click();
            driver.FindElement(By.XPath("//span[text()='OK']/parent::span")).Click();
        }

        [When(@"sell out date ""(.*)""")]
        public void WhenSellOutDate(string sellOut)
        {
            string date = "30/Apr/2022";
            string expectdateDay = date.Split("/")[0];
            string expectdateMonth = date.Split("/")[1];
            string expectdateYear = date.Split("/")[2];

            IWebElement selectDate = driver.FindElement(Elements.endDatePicker);
            selectDate.Click();
            IWebElement selectMonth = driver.FindElement(Elements.monthSelect);
            selectMonth.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.SpecificDateMonth(expectdateMonth))).Click();
            driver.FindElement(Elements.specificDateYear(expectdateYear)).Click();
            driver.FindElement(Elements.innerMonthOkButton).Click();
            driver.FindElement(Elements.selectEndDay(expectdateDay)).Click();
            driver.FindElement(By.XPath("//span[text()='OK']/parent::span")).Click();
        }
        [When(@"User clicks on product groups drop down list")]
        public void WhenUserClicksOnProductGroupsDropDownList()
        {
            driver.FindElement(Elements.productDownList).Click();
        }

        [When(@"User selects the product and clicks the ok button")]
        public void WhenUserSelectsTheProductAndClicksTheOkButton()
        {
            driver.FindElement(Elements.productSelect).Click();
            driver.FindElement(Elements.productOkButton).Click();
        }

        [When(@"User clicks the save button")]
        public void WhenUserClicksTheSaveButton()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Elements.saveButton)).Click();
        }

        [Then(@"User closes the promo")]
        public void ThenUserClosesThePromo()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Elements.closeButton)).Click();
        }
        [When(@"User clicks on the contractor button")]
        public void WhenUserClicksOnTheContractorButton()
        {
            driver.FindElement(Elements.contractorButton).Click();
        }
        [When(@"Selects the customer level '(.*)'")]
        public void WhenSelectsTheCustomerLevel(string level)
        {
            driver.FindElement(Elements.levelSelect(level)).Click();
        }
        [When(@"User clicks on on customer trigger and search id and select the id '(.*)'")]
        public void WhenUserClicksOnOnCustomerTriggerAndSearchIdAndSelectTheId(string customerID)
        {
            bool result = false;
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    driver.FindElement(Elements.customerCodeTrigger).Click();
                    result = true;
                    break;
                }
                catch
                {
                    Assert.IsFalse(result);
                }
                attempts++;
            }

            IWebElement textBox = driver.FindElement(Elements.customerCodeTextBox);
            textBox.SendKeys(customerID);
            driver.FindElement(Elements.custCodeOkButton).Click();

            bool result1 = false;
            int attempts1 = 0;
            while (attempts < 2)
            {
                try
                {
                    driver.FindElement(Elements.customerIdSelect(customerID)).Click();
                    result1 = true;
                    break;
                }
                catch
                {
                    Assert.IsFalse(result1);
                }
                attempts1++;
            }

            driver.FindElement(Elements.customerSelectOkButton).Click();
            driver.FindElement(Elements.contractorOkButton).Click();
        }

        [When(@"User selects sell in start date and sell out date")]
        public void WhenUserSelectsSellInStartDateAndSellOutDate()
        {
            string date = "21/Apr/2022";
            string expectdateDay = date.Split("/")[0];
            string expectdateMonth = date.Split("/")[1];
            string expectdateYear = date.Split("/")[2];
            IWebElement selectDate = driver.FindElement(Elements.startElDate);
            selectDate.Click();
            IWebElement selectMonth = driver.FindElement(Elements.monthSelect);
            selectMonth.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.SpecificDateMonth(expectdateMonth))).Click();
            driver.FindElement(Elements.specificDateYear(expectdateYear)).Click();
            driver.FindElement(Elements.innerMonthOkButton).Click();
            driver.FindElement(Elements.SelectDate(expectdateDay)).Click();
            driver.FindElement(By.XPath("//span[text()='OK']/parent::span")).Click();

            string date1 = "30/Apr/2022";
            string expectdateDay1 = date1.Split("/")[0];
            string expectdateMonth1 = date1.Split("/")[1];
            string expectdateYear1 = date1.Split("/")[2];
            IWebElement selectDate1 = driver.FindElement(Elements.endElDate);
            selectDate1.Click();
            IWebElement selectMonth1 = driver.FindElement(Elements.monthSelect);
            selectMonth1.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.SpecificDateMonth(expectdateMonth1))).Click();
            driver.FindElement(Elements.specificDateYear(expectdateYear1)).Click();
            driver.FindElement(Elements.innerMonthOkButton).Click();
            driver.FindElement(Elements.selectStartDay(expectdateDay1)).Click();
            driver.FindElement(By.XPath("//span[text()='OK']/parent::span")).Click();
        }

        [When(@"User selects '(.*)' and clicks on TPR in")]
        public void WhenUserSelectsAndClicksOnTPRIn(string tabSelect)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.tabSelect(tabSelect))).Click();
            driver.FindElement(Elements.TPRin).Click();
        }

        [When(@"User select the '(.*)' tab")]
        public void WhenUserSelectTheTab(string tabSelect)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(Elements.tabSelect(tabSelect))).Click();
        }

        [When(@"User selects id '(.*)' checkbox and clicks the ok button")]
        public void WhenUserSelectsIdCheckbox(string getID)
        {
            driver.FindElement(Elements.productID(getID)).Click();
            driver.FindElement(Elements.productIdOkButton).Click();
        }

        [When(@"User clicks on the product add button")]
        public void WhenUserClicksOnTheProductAddButton()
        {
            driver.FindElement(Elements.productAddButton).Click();
        }

        [When(@"User is at the promo navigator")]
        public void WhenUserIsAtThePromoNavigator()
        {
            driver.FindElement(Elements.promoPage);
        }

        [When(@"User opens the created promo '(.*)'")]
        public void WhenUserOpensTheCreatedPromo(string IdCode)
        {
            driver.FindElement(Elements.openPromo(IdCode)).Click();
        }

        [When(@"clicks the edit button")]
        public void WhenClicksTheEditButton()
        {
            driver.FindElement(Elements.editButton).Click();
        }
    }
}

    }
}
