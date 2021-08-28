using TechTalk.SpecFlow;
using PuppeteerSharp;
using specf1.SpecFlow;
using System.Threading.Tasks;
using System.Threading;
using specf1.utils;

namespace specf1.pages
{
    [Binding]
    public class WebPage
    {
        private static Page page;
        private const string pageAdresse = @"http://samples.gwtproject.org/samples/Showcase/Showcase.html";

        public WebPage()
        {
            page = (TestRun.browser.PagesAsync().Result)[0];
            page.GoToAsync(pageAdresse).Wait();
        }

        public Page getPage()
        {
            return page;
        }

        private static async Task<ElementHandle[]> CallElementAsyn(string element)
        {
            return await page.QuerySelectorAllAsync(element);
        }

        public async Task<ElementHandle[]> WarteForSelector(string selector, string expInnerText, int timeOut)
        {
            bool gefunden = true;
            ElementHandle[] elements = await CallElementAsyn(selector);
            System.DateTime startTime = System.DateTime.Now;
            System.TimeSpan timeOutSpan = new System.TimeSpan(0, 0, 0, timeOut);

            while (gefunden)
            {
                foreach(var element in elements)
                {
                    string innerText = (await getPage().EvaluateFunctionAsync<string>("e => e.innerText", element));

                    if(elements.Length > 0 && innerText.Equals(expInnerText) || expInnerText == null)
                    {
                        gefunden = false;
                        break;
                    }

                    if (TimingHelpers.vergangeneZeit(startTime) > timeOutSpan)
                        throw new WaitTaskTimeoutException("zu viel Zeit verbraten");
                    else
                    {
                        Thread.Sleep(200);
                        elements = await CallElementAsyn(selector);
                    }

                }
            }
            return elements;
        } // end while
    } // end class
} // end name-space
