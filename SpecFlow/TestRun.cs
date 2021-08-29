using TechTalk.SpecFlow;
using PuppeteerSharp;
using System.Threading.Tasks;
using specf1.pages;

namespace specf1.SpecFlow
{
    [Binding]
    public static class TestRun
    {
        public static Browser browser;
        public static WebPage webPage { get; set; }
        public static Page Page { get; private set; }

        [BeforeScenario("webBrowser")]
        public static async Task BeforeScenarioTask()
        {
            var options = new LaunchOptions
            {
                Headless = false,
                DefaultViewport = new ViewPortOptions
                {
                    Width = 900,
                    Height = 500
                }
            };

            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

            Task<Browser> browserTask = Task.Run(() =>Puppeteer.LaunchAsync(options));
            browser = browserTask.Result;

            webPage = new WebPage();
            Page = webPage.getPage();
        }

        [AfterScenario("webBrowser")]
        public static async Task AfterScenario()
        {
            browser.DisposeAsync(); // close Browser
        }

    }
}
