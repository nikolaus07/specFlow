using TechTalk.SpecFlow;
using System.Threading.Tasks;
using PuppeteerSharp;
using specf1.SpecFlow;
using System.Threading;
using specf1.pages;
using NLog;

namespace specf1.steps {
    [Binding]

    public class GoogleWebToolKit    
    {
        WebPage webPage = TestRun.webPage;
        Page page       = TestRun.Page;
        private static readonly ILogger _NLogger = LogManager.GetCurrentClassLogger();


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
        public async Task ThenFlexTable(string befehl)
        {
            string xPath = "";
            if (befehl.Contains("Add a row"))
            {
               xPath = "//button[contains(text(),'Add a row')]";
            } else
            {
                xPath = "//button[contains(text(),'Remove a row')]";
            }
            ElementHandle element = await page.WaitForXPathAsync(xPath);
            await element.ClickAsync();
            Thread.Sleep(1000);
        }


        [Then(@"Set favorit-sport RB to: ""(.*)""")]
        public async Task ThenSetFavorit_SportRBTo(string faforitSport)
        {
            string xPath =  "//input [@id='gwt-debug-cwRadioButton-sport-Hockey-input']";
            ElementHandle element = await page.WaitForXPathAsync(xPath);
            await element.ClickAsync();
            Thread.Sleep(1000);
        }


     
        [Then(@"click-button mit Text: '(.*)'")]
        public async Task ThenClick_ButtonMitText(string erwarteterText)
        {
            ElementHandle[] elements = await webPage.WarteForSelector("button", erwarteterText, 15);
            bool gefunden = false;
         
            if (elements != null)
            {
                foreach (var element in elements)
                {
                    var textId = (await page.EvaluateFunctionAsync<string>("e => e.innerText", element));
                    string innerText = (await page.EvaluateFunctionAsync<string>("e => e.innerText", element));
                    _NLogger.Info("textId=" + textId   + "    **** innerTex=" + innerText);

                    if (innerText == erwarteterText)
                    {
                        gefunden = true;
                        await element.ClickAsync();
                        break;
                    }
                }
            }

            Thread.Sleep(2000);

        }


    }
}
