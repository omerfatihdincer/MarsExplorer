using MarsExplorer.Classes;
using MarsExplorer.Enums;
using System;
using System.Collections.Generic;

namespace MarsExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsProcess();
            Console.ReadKey();

        }

        public static void MarsProcess()
        {
            try
            {
                int robotQuantity = 2;
                var robotList = new List<ProcessTemplate>();
                var limit = Process.GetLimit();

                for (int i = 0; i < robotQuantity; i++)
                {
                    var robot = new ProcessTemplate(limit, i + 1);
                    robot.GetCoordinates();
                    robot.GetLetterString();
                    robotList.Add(robot);
                }

                for (int i = 0; i < robotQuantity; i++)
                {
                    var coordinates = robotList[i].Coordinates;
                    foreach (var item in robotList[i].LetterString)
                    {
                        var command = (CommandEnum)Enum.Parse(typeof(CommandEnum), item.ToString());
                        coordinates = Process.Command(coordinates, robotList[i].Limit, command);
                    }

                    Console.WriteLine($"{coordinates.X} {coordinates.Y} {coordinates.Direction.ToString()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu. Hata mesajı: {ex.Message}");
                MarsProcess();
                return;
            }       
        }
    }
}
