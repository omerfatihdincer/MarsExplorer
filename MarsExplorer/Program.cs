using MarsExplorer.Classes;
using MarsExplorer.Enums;
using System;

namespace MarsExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen x ve y sınırlarını giriniz..");
            var limitString = Console.ReadLine();
            var limitArray = limitString.Split(' ');

            var limit = new Limit
            {
                X = Convert.ToInt32(limitArray[0]),
                Y = Convert.ToInt32(limitArray[1])
            };

            Console.WriteLine("Lütfen robotun koordinatlarını giriniz..");
            var coordinatString = Console.ReadLine();
            var coordinatArray = coordinatString.Split(' ');
            DirectionEnum direction;
            direction = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), coordinatArray[2]);
            var coordinates = new Coordinates
            {
                X = Convert.ToInt32(coordinatArray[0]),
                Y = Convert.ToInt32(coordinatArray[1]),
                Direction = direction
            };

            Console.WriteLine("Lütfen komut harf katarını giriniz..");
            var commands = Console.ReadLine();
            var commandArray = commands.ToCharArray();
            foreach (var item in commandArray)
            {
                var command = (CommandEnum)Enum.Parse(typeof(CommandEnum), item.ToString());
                coordinates = Command(coordinates, limit, command);
            }

            Console.WriteLine($"{coordinates.X} {coordinates.Y} {coordinates.Direction.ToString()}");
            Console.ReadKey();

        }

        public static Coordinates Command(Coordinates coortinates, Limit limit, CommandEnum command)
        {
            var result = new Coordinates();
            switch (command)
            {
                case CommandEnum.L:
                case CommandEnum.R:
                    {
                        coortinates.Direction = Direction(coortinates.Direction, command);
                        result = coortinates;
                        break;
                    }
                case CommandEnum.M:
                    {
                        result = GoOn(coortinates, limit);
                        break;
                    }
            }
            return result;
        }

        public static DirectionEnum Direction(DirectionEnum firstDirection, CommandEnum command)
        {
            var result = DirectionEnum.N;
            switch (firstDirection)
            {
                case DirectionEnum.N:
                    {
                        if (command == CommandEnum.R)
                        {
                            result = DirectionEnum.E;
                        }
                        else
                        {
                            result = DirectionEnum.W;
                        }
                        break;
                    }
                case DirectionEnum.S:
                    {
                        if (command == CommandEnum.R)
                        {
                            result = DirectionEnum.W;
                        }
                        else
                        {
                            result = DirectionEnum.E;
                        }
                        break;
                    }
                case DirectionEnum.E:
                    {
                        if (command == CommandEnum.R)
                        {
                            result = DirectionEnum.S;
                        }
                        else
                        {
                            result = DirectionEnum.N;
                        }
                        break;
                    }
                case DirectionEnum.W:
                    {
                        if (command == CommandEnum.R)
                        {
                            result = DirectionEnum.N;
                        }
                        else
                        {
                            result = DirectionEnum.S;
                        }
                        break;
                    }
            }
            return result;
        }

        public static Coordinates GoOn(Coordinates coortinates, Limit limit)
        {
            switch (coortinates.Direction)
            {
                case DirectionEnum.N:
                    {
                        coortinates.Y = Process(limit.Y, coortinates.Y, CalculusEnum.Plus);
                        break;
                    }
                case DirectionEnum.S:
                    {
                        coortinates.Y = Process(limit.Y, coortinates.Y, CalculusEnum.Minus);
                        break;
                    }
                case DirectionEnum.E:
                    {
                        coortinates.X = Process(limit.X, coortinates.X, CalculusEnum.Plus);
                        break;
                    }
                case DirectionEnum.W:
                    {
                        coortinates.X = Process(limit.X, coortinates.X, CalculusEnum.Minus);
                        break;
                    }
            }
            return coortinates;
        }

        public static int Process(int limit, int number, CalculusEnum calculus)
        {
            if (calculus == CalculusEnum.Plus)
            {
                number++;
                if (number > limit)
                {
                    return limit;
                }
                else
                {
                    return number;
                }
            }
            else
            {
                number--;
                if (number < 0)
                {
                    return 0;
                }
                else
                {
                    return number;
                }
            }
        }
    }
}
