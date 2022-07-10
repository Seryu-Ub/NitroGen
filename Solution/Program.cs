using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using CloudFlareUtilities;

namespace DiscordNitroGeneratorBasic
{
    class Program
    {
        public static string oldCode = string.Empty;
        static void Main(string[] args)
        {
            Console.Title = "Generator Discord Nitro | SeryûApp";
            Timer t = new Timer(TimerCallback, null, 0, 3500);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"$$\   $$\ $$$$$$\ $$$$$$$$\ $$$$$$$\   $$$$$$\   $$$$$$\  $$$$$$$$\ $$\   $$\ ");
            Console.WriteLine(@"$$$\  $$ |\_$$  _|\__$$  __|$$  __$$\ $$  __$$\ $$  __$$\ $$  _____|$$$\  $$ |");
            Console.WriteLine(@"$$$$\ $$ |  $$ |     $$ |   $$ |  $$ |$$ /  $$ |$$ /  \__|$$ |      $$$$\ $$ |");
            Console.WriteLine(@"$$ $$\$$ |  $$ |     $$ |   $$$$$$$  |$$ |  $$ |$$ |$$$$\ $$$$$\    $$ $$\$$ |");
            Console.WriteLine(@"$$ \$$$$ |  $$ |     $$ |   $$  __$$< $$ |  $$ |$$ |\_$$ |$$  __|   $$ \$$$$ |");
            Console.WriteLine(@"$$ |\$$$ |  $$ |     $$ |   $$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |\$$$ |");
            Console.WriteLine(@"$$ | \$$ |$$$$$$\    $$ |   $$ |  $$ | $$$$$$  |\$$$$$$  |$$$$$$$$\ $$ | \$$ |");
            Console.WriteLine(@"\__|  \__|\______|   \__|   \__|  \__| \______/  \______/ \________|\__|  \__|" + Environment.NewLine);
            Console.WriteLine("==============================================================================================");
            Console.WriteLine("Click on the windows to freeze the generator and press the Enter key to reactivate everything.");
            Console.WriteLine("==============================================================================================" + Environment.NewLine);
            Console.WriteLine("Powered By Seryû" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        private static void TimerCallback(Object o)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            var link = "https://discord.gift/";
            if (oldCode == finalString)
            {

            }
            else
            {
                string Error = "{*code*: 10038, *message*: *Unknown Gift Code*}";
                string noExistFinal = Error.Replace('*', '"');
                var handler = new ClearanceHandler();

                handler.MaxRetries = 3;

                var client = new HttpClient(handler);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.109 Safari/537.36");

                try
                {

                    var content = client.GetStringAsync(new Uri("https://discordapp.com/api/v6/entitlements/gift-codes/" + finalString + "?with_application=false&with_subscription_plan=true")).Result;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(link + finalString + "Est un code fonctionnel ! Il a été sauvegarder dans le nitro.txt" + Environment.NewLine);
                    Console.ResetColor();

                    var s = File.Create("nitro.txt");
                    s.Dispose();

                    File.WriteAllText("nitro.txt", link + finalString);
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(link + finalString);
                    Console.ForegroundColor = ConsoleColor.White;
                    if (ex.InnerException.Message.Contains("404"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Code nitro invalide]" + Environment.NewLine);
                        Console.ResetColor();
                    }
                    if (ex.InnerException.Message.Contains("429"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[Trop de Request]" + Environment.NewLine);
                        Console.ResetColor();
                    }

                }
            }
            GC.Collect();
        }
    }
}
