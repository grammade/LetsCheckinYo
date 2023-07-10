using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.DevTools.V107.Debugger;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


var cred = File.ReadAllLines("cred.txt").ToList();

System.Console.WriteLine("Sit tight, let me do all the work....");


new DriverManager().SetUpDriver(new ChromeConfig());
var driver = new ChromeDriver();
var coord = new Dictionary<string, object>{
    {"latitude", -6.18432},
    {"longitude", 106.931903},
    {"accuracy", 20}
};
driver.Navigate().GoToUrl("https://heart.globalservice.co.id/");
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

var username = driver.FindElement(By.Name("username"));
var password = driver.FindElement(By.Name("password"));
var loginSubmitBtn = driver.FindElement(By.TagName("button"));

username.SendKeys(cred[0]);
password.SendKeys(cred[1]);
loginSubmitBtn.Click();

var a = driver.ExecuteCdpCommand("Emulation.setGeolocationOverride", coord);
driver.Navigate().GoToUrl("https://heart.globalservice.co.id/staff/absensi");

var mood = driver.FindElement(By.CssSelector("[src*='https://heart.globalservice.co.id/assets/img/emoji/3.png']"));
var desc = driver.FindElement(By.Id("note"));
var submitBtn = driver.FindElement(By.CssSelector("[type*='submit']"));

desc.SendKeys($"{submitBtn.Text} at {Round(DateTime.Now, TimeSpan.FromMinutes(1)).ToString("H:mm")}");
mood.Click();
Thread.Sleep(7000);

submitBtn.Click();

Thread.Sleep(3000);
return;

static DateTime Round(DateTime date, TimeSpan interval) {
    return new DateTime(
        (long)Math.Round(date.Ticks / (double)interval.Ticks) * interval.Ticks
    );
}