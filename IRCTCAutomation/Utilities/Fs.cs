using DoorwardGUIAutomation.Managers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorwardGUIAutomation.Utilities
{
    class Fs
    {
        public static string GetApplicationRootDir()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        public static string GetCurrentWorkingDir()
        {
            return Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        }
        public static JObject ReadJsonFile(string jsonfilePath)
        {
            return Newtonsoft.Json.Linq.JObject.Parse(File.ReadAllText(jsonfilePath));
        }
        public static string GetConfigFilePath()
        {
            return Path.Combine(GetCurrentWorkingDir(), "Configuration", "Config.json");
        }

        public static string GetConfigurationDir()
        {
            return Path.Combine(GetCurrentWorkingDir(), "Configuration");
        }
        public Dictionary <string,string> MapJsonToDictionary(string jsontextfilepath, string token)
        {
            return JObject.Parse(File.ReadAllText(jsontextfilepath)).SelectToken(token).ToObject<Dictionary<string,string>>();
        }
        public static string GetAppUrl()
        {
            return ReadJsonFile(GetConfigFilePath()).SelectToken("url").SelectToken("doorwardQAT").ToString().Trim();
        }

        public static string GetOtherAppUrl()
        {
            return ReadJsonFile(GetConfigFilePath()).SelectToken("url").SelectToken("Other").ToString().Trim();
        }

        public static string GetIRCTCAppUrl()
        {
            return ReadJsonFile(GetConfigFilePath()).SelectToken("url").SelectToken("irctc").ToString().Trim();
        }
        public static string GetCurrentBrowser()
        {
            return ReadJsonFile(GetConfigFilePath()).SelectToken("browserinfo").SelectToken("currentbrowser").ToString().Trim();
        }
        public static string GetCurrentEnvironmentType()
        {
            return ReadJsonFile(GetConfigFilePath()).SelectToken("environment").SelectToken("current").ToString().Trim();
        }

        public static BrowserType GetBrowser()
        {
            string browserName = Fs.GetCurrentBrowser();
            if (browserName == null || browserName.Equals("chrome")) return BrowserType.CHROME;
            if (browserName.Equals("firefox")) return BrowserType.FIREFOX;
            else return BrowserType.CHROME;
        }
        public static EnvironmentType GetEnvironmant()
        {
            string envName = Fs.GetCurrentEnvironmentType();
            if (envName == null || envName.Equals("local")) return EnvironmentType.LOCAL;
            else return EnvironmentType.REMOTE;

        }
        public static string GetDriverPath()
        {
            return Path.Combine(GetCurrentWorkingDir(), "Drivers");
        }
        public static string GetReportPath()
        {
            return Path.Combine(GetCurrentWorkingDir(), "Reports");
        }
        public static string GetScreenshotPath()
        {
            return Path.Combine(GetCurrentWorkingDir(), "Screenshots");
        }
        public static int GetDefaultWaitTime()
        {
            return Int32.Parse(ReadJsonFile(GetConfigFilePath()).SelectToken("defaultwait").SelectToken("wait").ToString().Trim());
        }
    }
}
