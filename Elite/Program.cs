using BarRaider.SdTools;
using System;
using System.IO;
using System.Xml.Serialization;
using EliteAPI;
using Elite.EliteApi;


namespace Elite
{
    class Program
    {
        public static EliteDangerousAPI EliteApi;

        public static UserBindings Bindings;

        static void Main(string[] args)
        {
            // Uncomment this line of code to allow for debugging
            //while (!System.Diagnostics.Debugger.IsAttached) { System.Threading.Thread.Sleep(100); }

            Logger.Instance.LogMessage(TracingLevel.DEBUG, "Init Elite Api");

            try
            {


                EliteApi = new EliteDangerousAPI();
                EliteApi.Start();

                var path =
                    $@"C:\Users\{Environment.UserName}\AppData\Local\Frontier Developments\Elite Dangerous\Options\Bindings\";

                var fileName = File.ReadAllText(path + "StartPreset.start") + ".binds";

                var serializer = new XmlSerializer(typeof(UserBindings));

                var reader = new StreamReader(Path.Combine(path, fileName));
                Bindings = (UserBindings) serializer.Deserialize(reader);
                reader.Close();

            }
            catch (Exception ex)
            {
                Logger.Instance.LogMessage(TracingLevel.FATAL, $"Elite Api: {ex}");
            }


            //EliteAPI.Events.AllEvent += (sender, e) => Console.Beep();


            SDWrapper.Run(args);
        }


    }
}
