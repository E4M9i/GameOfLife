using System;
using System.IO;
using GameOfLife.Components;
using GameOfLife.Entities;
using Newtonsoft.Json;

namespace GameOfLife
{
   public class Program
    {
        private const string SettingFileName = "setting.json";

        private static void Main(string[] args)
        {
           
            var setting = JsonConvert.DeserializeObject<GameSetting>(File.ReadAllText( SettingFileName));
            //var layout=new BoardLayout(){LiveSymbol ="@",DeadSymbol = "/"};
            //var setting = new GameSetting()
            //{
            //    BoardWidth = 50,
            //    BoardHeight = 30,
            //    Generation = 100,
            //    Interval = 200,
            //    BoardLayout = layout
            //};
            var runner=new GameRunner(setting);
            runner.Run();
            Console.ReadKey();
        }
    }
}
