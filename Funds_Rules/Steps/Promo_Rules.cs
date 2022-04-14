using System;
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
        public static int test;

        [Given(@"The user has logged in the application")]
        public void GivenTheUserHasLoggedInTheApplication()
        {
            test = 2;
            ChromeOptions options = new ChromeOptions();

            var userProfile = @"%UserProfile%\AppData\Local\Google\Chrome\User Data\Profile 2";
            options.AddArgument("--profile-directory=Profile 2");

            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(180));
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
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
            Console.WriteLine(test);
            IWebElement homePage = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.homeToolBar));
            homePage.Click();
        }

        [When(@"User clicks on view complete menu")]
        public void WhenUserClicksOnViewCompleteMenu()
        {
            IWebElement viewCompleteMenu = driver.FindElement(Elements.searchBox);
            viewCompleteMenu.Click();
            viewCompleteMenu.SendKeys("Funds & Rules");
        }

        [When(@"User clicks on '(.*)'")]
        public void WhenUserClicksOn(string getTab)
        {
            IWebElement toolTab = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.ToolFunction(getTab)));
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
            IWebElement addButton = Wait.Until(ExpectedConditions.ElementIsVisible(Elements.addButton));
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
            string date = "17/Apr/2022";
            string expectdateDay = date.Split("/")[0];
            string expectdateMonth = date.Split("/")[1];
            string expectdateYear = date.Split("/")[2];

            IWebElement selectDate = driver.FindElement(Elements.startDatePicker);
            selectDate.Click();
            IWebElement selectMonth = driver.FindElement(Elements.monthSelect);
            selectMonth.Click();
            Wait.Until(ExpectedConditions.ElementIsVisible(Elements.SpecificDateMonth(expectdateMonth))).Click();
            driver.FindElement(Elements.specificDateYear(expectdateYear)).Click();
            driver.FindElement(Elements.innerMonthOkButton).Click();
            driver.FindElement(Elements.selectDay(expectdateDay)).Click();
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
            driver.FindElement(Elements.selectDay(expectdateDay)).Click();
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
            driver.FindElement(Elements.saveButton).Click();
        }

    }
}
