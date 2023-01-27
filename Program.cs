using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V107.Debugger;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


var cred = File.ReadAllLines("cred.txt").ToList();

System.Console.WriteLine("Sit tight, let me do all the work....");


new DriverManager().SetUpDriver(new ChromeConfig());
var driver = new ChromeDriver();


driver.Navigate().GoToUrl("https://heart.globalservice.co.id/");
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

var username = driver.FindElement(By.Name("username"));
var password = driver.FindElement(By.Name("password"));
var submitButton = driver.FindElement(By.TagName("button"));

username.SendKeys(cred[0]);
password.SendKeys(cred[1]);
submitButton.Click();

driver.Navigate().GoToUrl("https://heart.globalservice.co.id/staff/absensi");

var mood = driver.FindElement(By.CssSelector("[src*='https://heart.globalservice.co.id/assets/img/emoji/3.png']"));
var desc = driver.FindElement(By.Id("note"));
var submitButton2 = driver.FindElement(By.CssSelector("[type*='submit']"));

desc.SendKeys($"{submitButton2.Text} at {DateTime.Now.ToString()}");
mood.Click();

submitButton2.Click();

Thread.Sleep(3000);
driver.Quit();
return;