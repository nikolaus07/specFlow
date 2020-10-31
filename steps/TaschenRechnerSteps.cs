using TechTalk.SpecFlow;
using specf1.TaschenRechner;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace specf1.steps {
    [Binding]
    public class TaschenRechnerSteps     {
        [Given(@"the first number is '(.*)'")]
        public void GivenTheFirstNumberIs(int p0) {
            Rechner.Zahl1 = p0;
        }
        
        [Given(@"the second number is '(.*)'")]
        public void GivenTheSecondNumberIs(int p0) {
            Rechner.Zahl2 = p0;
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded() {
            Rechner.getAddieren();
        }
        
        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(int p0) {
            Assert.AreEqual(p0, Rechner.Ergebnis);
        }
        
        [When(@"Subtraktion wird gestartet")]
        public void WhenZahlMinusZahl() {
            Rechner.getSubtrahieren();
        }

        [Then(@"Ergebnis der Subtraktion sollte '(.*)'")]
        public void ThenErgebnisDerSubtraktionSollte(int p0) {
            Assert.AreEqual(p0, Rechner.Ergebnis);
        }
    }
}
