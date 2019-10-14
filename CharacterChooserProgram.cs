using System;
using System.Collections.Generic;

namespace CharacterChooser
{
    /// <summary>
    /// A random character chooser for smash, or whatever I guess
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var bigiftrue = true;
            Random thing = new Random();

            var teams = new List<string>()
            {
                "Red",
                "Blue"
            };

            while (bigiftrue)
            {
                foreach (var team in teams)
                {
                    var characters = DoList(thing);
                    PrintThingForTeam(team, characters);
                }
                
                var end = Console.ReadLine();
                if (string.Equals(end, "wilfsucks", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }

        private static void PrintThingForTeam(string teamColour, List<Character> chars)
        {
            foreach (var character in chars)
            {
                Console.WriteLine($"{teamColour} team picks: {character}");
            }
        }

        private static List<Character> DoList(Random thing)
        {
            List<Character> characters = new List<Character>();
            while (characters.Count < 3)
            {
                Character charc = (Character) thing.Next(8);
                if (characters.Contains(charc))
                {
                    continue;
                }

                characters.Add(charc);
            }

            return characters;
        }
    }

    enum Character
    {
        Mario = 0,
        DarkPit = 1,
        DuckHuntDuo = 2,
        Mewtwo = 3,
        Incineroar = 4,
        ZeroSuitSamus = 5,
        MrGameAndWatch = 6,
        Palutena = 7
    }
}
