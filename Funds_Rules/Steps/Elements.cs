using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Funds_Rules.Steps
{
    public class Elements
    {
        public static By homeToolBar = By.XPath("//div[@sm1-id='homeToolbarMenuBTN']");
        public static By searchBox = By.XPath("//div[@sm1-id='mainMenuSearchBox']/descendant::input[@placeholder='Search']");
        public static By viewCompleteMenu = By.XPath("//span[text()='View Complete Menu']");
        public static By ToolFunction(string getTab) => By.XPath($"//span[contains(@class,'sm1-mainmenu-entry-icon')]/following::span[text()='{getTab}']");
        public static By addButton = By.XPath("//div[@sm1-id='NavigatorGridToolbar']/descendant::span[@sm1-id='AddButton']");
        public static By dropDownList = By.XPath("//span[text()='Configuration ID:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
        public static By configurationID = By.XPath($"//li[text()='629 - KPI']");
        public static By configIdOkButton = By.XPath("//span[text()='OK']/parent::span[contains(@id,'sm1okbutton')]");
        public static By loading = By.XPath("//div[contains(@class, 'x-component sm1-mask x-mask x-component-default')]");
        public static By selectConfigID(string selectConfig) => By.XPath($"//li[text()='{selectConfig}']");
        public static By inputText = By.XPath("//div[@sm1-id='LEVEL_CLIENT']/descendant::div[@class='sm1-triggers']");
        public static By customerLevelDropList = By.XPath("//span[text()='Customer level:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
        public static By CustomerLevel(string level) => By.XPath($"//li[text()='{level}']");
        public static By startDatePicker = By.XPath("//input[@data-ref='startDtpEl']");

        public static By endDatePicker = By.XPath("//input[@data-ref='endDtpEl']");
        public static By monthSelect = By.XPath("//div[contains(@class,'x-datepicker')]/child::div[contains(@sm1-id,'PICKERFIELD-sm1dateperiod')]/descendant::a[@data-qtip='Choose Month']");
        public static By innerMonthOkButton = By.XPath("//div[contains(@class,'x-monthpicker x-monthpicker')]/descendant::span[not(text()='Cancel') and @class='x-btn-inner x-btn-inner-default-small']/parent::span");
        public static By SpecificDateMonth(string SelectMonth) => By.XPath($"//div[@data-ref='monthEl']/child::div/a[text()='{SelectMonth}']/parent::div");
        public static By specificDateYear(string SelectYear) => By.XPath($"//div[@data-ref='yearEl']/child::div/a[text()='{SelectYear}']/parent::div");
        public static By selectEndDay(string day) => By.XPath($"//div[contains(@class,'x-datepicker x-datepicker')]/descendant::td[@data-qtip='Date After Max Date']/child::div[text()='{day}']");
        public static By selectStartDay(string day1) => By.XPath($"//div[text()='{day1}']/parent::td[contains(@class,'x-datepicker-active x-datepicker')]");
        public static By SelectDate(string date) => By.XPath($"//td[@aria-selected='false']/child::div[@class='x-datepicker-date' and text()='{date}']");
        public static By productDownList = By.XPath("//span[text()='Product Groups:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
        public static By productSelect = By.XPath("//div[text()='ITALIAN WINE']/parent::td/preceding-sibling::td[contains(@class,'checkcolumn')]");
        public static By productOkButton = By.XPath("//div[text()='Product level']/ancestor::div[contains(@class,'x-horizontal')]/following-sibling::div/descendant::span[text()='OK']/parent::span");
        public static By saveButton = By.XPath("//a[@sm1-id='TLBSAVEBUTTON']/descendant::span[@data-ref='btnIconEl']");
        public static By contractorButton = By.XPath("//div[@sm1-id='CUSTOMER']/descendant::div[@class='sm1-triggers']/child::div[contains(@id,'trigger-open')]");
        public static By levelSelect(string level) => By.XPath($"//div[contains(@class,'grid-view x-grid')]/descendant::div[text()='{level}']");
        public static By customerCodeTrigger = By.XPath("//div[@sm1-id='CODNODE']/child::div[@data-qtip='Customer code']/descendant::div[@data-ref='triggerEl']");
        public static By customerCodeTextBox = By.XPath("//div[@sm1-id='likeValue']/descendant::div[contains(@name,'sm1text')]");
        public static By custCodeOkButton = By.XPath("//div[@sm1-id='LOGICALTEXTBOXCOLUMNPOPUP']/descendant::span[text()='OK']/parent::span");
        public static By customerIdSelect(string ID) => By.XPath($"//div[text()='{ID}']/parent::td[contains(@class,'grid')]");
        public static By customerSelectOkButton = By.XPath("//span[@sm1-id='SM1OkButton' and @aria-disabled='false']/descendant::span[text()='OK']/parent::span");
        public static By contractorOkButton = By.XPath("//span[text()='OK']/parent::span");
        public static By startElDate = By.XPath("//div[@sm1-id='DATE_SELLIN']/descendant::input[@class='sm1-startDate placeholderColor']");
        public static By endElDate = By.XPath("//div[@sm1-id='DATE_SELLIN']/descendant::input[@class='sm1-endDate placeholderColor']");
        public static By tabSelect(string getTab) => By.XPath($"//span[text()='{getTab}']/parent::span");
        public static By TPRin = By.XPath("//div[text()='TPR in %']/parent::td/preceding-sibling::td/child::div[@class='x-grid-cell-inner ']");
        public static By productID(string getID) => By.XPath($"//div[text()='{getID}' and @class='x-grid-cell-inner ']/parent::td/preceding-sibling::td[contains(@class,'checkbox')]");
        public static By productIdOkButton = By.XPath("//span[text()='OK']/parent::span[contains(@id,'sm1okbutton')]");
        public static By productAddButton = By.XPath("//span[@sm1-id='AddButton' and @aria-hidden='false']/child::span");
        public static By closeButton = By.XPath("//a[@sm1-id='TLBGUICLOSEBUTTON']/child::span[@data-ref='btnWrap']");
        public static By promoPage = By.XPath("//span[text()='Promotional actions']/parent::span[contains(@class,'icon-left')]");
        public static By openPromo(string IdCode) => By.XPath($"//div[text()='EC86160']/parent::td/preceding-sibling::td/descendant::span[@class='sm1-column-link' and text()='{IdCode}']");
        public static By loadWait = By.XPath("//div[@id='sm1WaitDiv' and @class='sm1waitdiv']");
        public static By editButton = By.XPath("//span[text()='Edit']/parent::span[@data-ref='btnEl']");
        

    }
}
