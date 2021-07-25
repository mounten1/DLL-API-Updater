using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API_Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting update...");

            UpdateDarkClubAPI();
            
            Console.WriteLine("DarkClub updated.");

            UpdateAnemo();
                       
            Console.WriteLine("Anemo updated.");

            UpdateEasyExploits();

            Console.WriteLine("EasyExploits updated.");

            UpdateWeAreDevs(); 

            Console.WriteLine("WeAreDevs updated.");
        }

        static void UpdateDarkClubAPI()
        {
            WebClient webclient = new WebClient();

            string text = webclient.DownloadString("https://clubdark.net/auto");
            string exploitdllname = "clubdark.dll";
            if (File.Exists(exploitdllname))
            {
                File.Delete(exploitdllname);
            }
            webclient.DownloadFile(text.Split(new char[]
            {
        ' '
            })[1], exploitdllname);
        }

        static void UpdateAnemo()
        {
            WebClient webclient = new WebClient();
            string[] array = webclient.DownloadString("https://anemo.solutions/api/Update.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string exploitdllname = "AnemoDLL.dll";
            if (File.Exists(exploitdllname))
            {
                File.Delete(exploitdllname);
            }

            webclient.DownloadFile(array[1], "AnemoDLL.dll");          
        }

        static void UpdateEasyExploits()
        {
            WebClient webclient = new WebClient();
            string[] array = webclient.DownloadString("https://raw.githubusercontent.com/GreenMs02/Update/master/Module.txt").Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string exploitdllname = "EasyExploitsDLL.dll";
            if (File.Exists(exploitdllname))
            {
                webclient.DownloadFile(array[4], "EasyExploitsDLL.dll");
            }
            else
            {
                webclient.DownloadFile(array[1], "EasyExploitsDLL.dll");
            }
        }

        static void UpdateWeAreDevs()
        {
            WebClient webclient = new WebClient();
            if (File.Exists("exploit-main.dll"))
            {
                File.Delete("exploit-main.dll");
            }
            string latestData = GetLatestData();
            if (latestData.Length > 0)
            {
                webclient.DownloadFile(latestData.Split(new char[]
                {
                    ' '
                })[1], "exploit-main.dll");
            }
        }

        private static string GetLatestData()
        {
            WebClient webclient = new WebClient();
            string text = webclient.DownloadString("https://cdn.wearedevs.net/software/exploitapi/latestdata.txt");
            if (text.Length > 0)
            {
                return text;
            }
            string text2 = webclient.DownloadString("https://pastebin.com/raw/Ly9mJwH7");
            if (text2.Length > 0)
            {
                return text2;
            }
            return "";
        }
    }
}
