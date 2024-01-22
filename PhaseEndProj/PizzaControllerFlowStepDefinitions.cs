using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace PhaseEndProj
{
    [Binding]
    public class PizzaControllerFlowStepDefinitions
    {
        private IWebDriver driver = new ChromeDriver();

        [Given(@"the user is on the first view")]
        public void GivenTheUserIsOnTheFirstView()
        {
            driver.Navigate().GoToUrl("http://localhost:38768/Pizza");
        }

        [When(@"the user performs some action")]
        public void WhenTheUserPerformsSomeAction()
        {
            IWebElement actionLink = driver.FindElement(By.LinkText("Add to Cart"));
            actionLink.Click();
        }

        [Then(@"the user should be on the second view")]
        public void ThenTheUserShouldBeOnTheSecondView()
        {
            Assert.AreEqual("http://localhost:38768/Pizza/Cart/1", driver.Url);
        }

        [When(@"the user performs another action")]
        public void WhenTheUserPerformsAnotherAction()
        {
            IWebElement submitButton = driver.FindElement(By.CssSelector("#form-group input[type='submit']"));
            submitButton.Click();
        }

        [Then(@"the user should be on the third view")]
        public void ThenTheUserShouldBeOnTheThirdView()
        {
            Assert.AreEqual("http://localhost:38768/Pizza/Checkout", driver.Url);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
            driver.Quit();
        }
    }
}
