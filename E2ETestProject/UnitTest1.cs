using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace E2ETestProject
{
    public class Tests
    {
        const string test_url = "https://www.google.com";

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ShouldCloseDivAfterRefuseBtnClickTest()
        {
            driver.Url = test_url;

            Thread.Sleep(2000);

            IWebElement refuseCookiesBtn = driver.FindElement(By.Id("W0wltc"));

            if(refuseCookiesBtn != null) { refuseCookiesBtn.Click(); }

            IWebElement cookieDiv = driver.FindElement(By.Id("xe7COe"));

            if(cookieDiv == null) { Assert.Fail("cookie div not found"); return; }

            string expected = "none";
            string actual = cookieDiv.GetCssValue("display");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldShowResultsAfterSearchBtnClickTest()
        {
            driver.Url = test_url;

            IWebElement acceptCookiesBtn = driver.FindElement(By.Id("L2AGLb"));

            if (acceptCookiesBtn != null) { acceptCookiesBtn.Click(); }

            Thread.Sleep(2000);

            IWebElement searchText = driver.FindElement(By.Name("q"));

            searchText.SendKeys("LambdaTest");

            Thread.Sleep(1000);

            searchText.SendKeys(Keys.Enter);

            Thread.Sleep(10000);

            IWebElement h3TitleLambdaTestResult = driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div[5]/div/div/div/div/div/div/div[1]/div[2]/div/div/span/a/h3"));

            string expected = "LambdaTest: Power Your Software Testing with AI and Cloud";
            string actual = h3TitleLambdaTestResult.Text;

            Assert.AreEqual(expected, actual);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}