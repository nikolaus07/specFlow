using TechTalk.SpecFlow;
using specf1.TaschenRechner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace specf1.steps {
    [Binding]

    public class GoogleWebToolKit    
    {


     

        [Then(@"Ergebnis der Subtraktion sollte '(.*)'")]
        public void ThenErgebnisDerSubtraktionSollte(int p0) {
            Assert.AreEqual(p0, Rechner.Ergebnis);
        }
    }
}
