using TechTalk.SpecFlow;
using System.Threading.Tasks;
using PuppeteerSharp;
using specf1.SpecFlow;
using specf1.pages;
using System.Threading;

namespace specf1.steps {
    [Binding]

    public class GoogleWebToolKit    
    {
        private Page page = TestRun.web_page;

        [When(@"navigate to page: '(.*)'")]
        public async Task WhenNavigateToPage(string seite)
        {
            await page.EvaluateExpressionAsync(@"{ localStorage.setItem('emulate_Test', '1') }");
            await page.ReloadAsync();
            await page.GoToAsync(seite);
            await Task.Delay(2000);
        }

        [Then(@"Set Checkbox on day: '(.*)'")]
        public async Task ThenSetCheckboxOnDay(string day)
        {
            string xPath = "";
            if (day.ToLower().Contains("tuesday"))
            {
                xPath = "//input [@id='gwt-debug-cwCheckBox-Tuesday-input']";
            }
            else
                xPath = "//input [@id='gwt-debug-cwCheckBox-Wednesday-input']";

            ElementHandle element = await page.WaitForXPathAsync(xPath);
            await element.ClickAsync();
        }

        [Then(@"zeitschleife")]
        public async Task ThenZeitschleife()
        {
            Thread.Sleep(200);
        }

        [Then(@"Flex Table: ""(.*)""")]
        public async Task ThenFlexTable(string day)
        {
            string xPath = "//input [@id='gwt-debug-cwCheckBox-Tuesday-input']";
          
            ElementHandle element = await page.WaitForXPathAsync(xPath);
            await element.ClickAsync();

        }


    }
}
