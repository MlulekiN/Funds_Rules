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
        public static By ToolFunction(string getTab) => By.XPath($"//span[text()='{getTab}']"); 
        public static By addButton = By.XPath("//span[@sm1-id='AddButton']");
        public static By dropDownList = By.XPath("//span[text()='Configuration ID:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
        public static By configurationID = By.XPath($"//li[text()='629 - KPI']");
        public static By configIdOkButton = By.XPath("//span[text()='OK']/parent::span[contains(@id,'sm1okbutton')]");
        public static By loading = By.XPath("//div[contains(@class, 'x-component sm1-mask x-mask x-component-default')]");
        public static By selectConfigID(string selectConfig) => By.XPath($"//li[text()='{selectConfig}']"); 
        public static By inputText = By.XPath("//div[@sm1-id='LEVEL_CLIENT']/descendant::div[@class='sm1-triggers']");
        public static By customerLevelDropList = By.XPath("//span[text()='Customer level:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
        public static By CustomerLevel(string level) =>  By.XPath($"//li[text()='{level}']");
        public static By startDatePicker = By.XPath("//input[@data-ref='startDtpEl']");
        public static By monthSelect = By.XPath("//div[contains(@class,'x-datepicker')]/child::div[contains(@sm1-id,'PICKERFIELD-sm1dateperiod')]/descendant::a[@data-qtip='Choose Month']");
        public static By innerMonthOkButton = By.XPath("//div[contains(@class,'x-monthpicker x-monthpicker')]/descendant::span[not(text()='Cancel') and @class='x-btn-inner x-btn-inner-default-small']/parent::span");
        public static By specificDate(string SelectMonth) => By.XPath($"//div[@data-ref='monthEl']/child::div/a[text()='{SelectMonth}']/parent::div']");
        public static By selectDay(string day) => By.XPath($"//div[@class='x-datepicker-date' and text()='{day}']");
        public static By productDownList = By.XPath("//span[text()='Product Groups:']//ancestor::label/following-sibling::div//div[@class='sm1-triggers']//div[contains(@id,'trigger-select') or contains(@id,'trigger-picker') or contains(@id,'trigger-openStatuses') or contains(@id,'trigger-filtermaker') or contains(@class,'sm1textboxactiontriggerdoc')]");
    }
    
}
