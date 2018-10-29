using MarsExplorer.Enums;
using System;

namespace MarsExplorer.Classes
{
    public class Process
    {
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
                        coortinates.Y = GoProcess(limit.Y, coortinates.Y, CalculusEnum.Plus);
                        break;
                    }
                case DirectionEnum.S:
                    {
                        coortinates.Y = GoProcess(limit.Y, coortinates.Y, CalculusEnum.Minus);
                        break;
                    }
                case DirectionEnum.E:
                    {
                        coortinates.X = GoProcess(limit.X, coortinates.X, CalculusEnum.Plus);
                        break;
                    }
                case DirectionEnum.W:
                    {
                        coortinates.X = GoProcess(limit.X, coortinates.X, CalculusEnum.Minus);
                        break;
                    }
            }
            return coortinates;
        }

        public static int GoProcess(int limit, int number, CalculusEnum calculus)
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

        public static Limit GetLimit()
        {
            Console.WriteLine("Lütfen x ve y sınırlarını giriniz..");
            var limitString = Console.ReadLine();
            var limitArray = limitString.Split(' ');

            if (limitArray.Length != 2)
            {
                Console.WriteLine("İçerik yanlış girildi!");
                return GetLimit();
            }

            var limit = new Limit
            {
                X = Convert.ToInt32(limitArray[0]),
                Y = Convert.ToInt32(limitArray[1])
            };

            return limit;
        }
    }
}
