using MarsExplorer.Enums;
using System;
using System.Linq;

namespace MarsExplorer.Classes
{
    public class ProcessTemplate : IProcessTemplate
    {
        public ProcessTemplate(Limit limit, int number)
        {
            this.Limit = limit;
            this.Number = number;
        }

        public Limit Limit { get; set; }
        public Coordinates Coordinates { get; set; }
        public char[] LetterString { get; set; }
        public int Number { get; set; }

        public void GetCoordinates()
        {
            Console.WriteLine($"Lütfen {Number}. robotun koordinatlarını giriniz..");
            var coordinatString = Console.ReadLine();
            var coordinatArray = coordinatString.ToUpper().Split(' ');

            if (coordinatArray.Length != 3)
            {
                Console.WriteLine("İçerik yanlış girildi!");
                GetCoordinates();
                return;
            }

            DirectionEnum direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), coordinatArray[2]);
            var coordinates = new Coordinates
            {
                X = Convert.ToInt32(coordinatArray[0]),
                Y = Convert.ToInt32(coordinatArray[1]),
                Direction = direction
            };

            this.Coordinates = coordinates;
        }

        public void GetLetterString()
        {
            Console.WriteLine($"Lütfen {Number}. robotun komut harf katarını giriniz..");
            var commands = Console.ReadLine();
            var commandArray = commands.ToUpper().ToCharArray();

            if ((commandArray.Length < 0) || (commandArray.Any(x => x != 'L' && x != 'R' && x != 'M')))
            {
                Console.WriteLine("İçerik yanlış girildi!");
                GetLetterString();
                return;
            }

            this.LetterString = commandArray;
        }
    }
}
