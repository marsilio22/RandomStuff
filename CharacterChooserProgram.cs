using System;
using System.Collections.Generic;

namespace CharacterChooser
{
    /// <summary>
    /// Program for choosing teams of characters on Smash
    /// </summary>
    public class Chooser
    {
        /// <summary>
        /// Main entry point for the console application
        /// </summary>
        static void Main()
        {
            var bigiftrue = true; // bants
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
                    var characters = Determiner.DetermineTeam(thing);
                    Determiner.PrintThingForTeam(team, characters);
                }

                var end = Console.ReadLine();
                if (string.Equals(end, "wilfsucks", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
        }
    }

    public static class Determiner
    {

        /// <summary>
        /// For a given team colour and collection of characters, print this to the console.
        /// </summary>
        /// <param name="teamName">Team Name</param>
        /// <param name="chars">Characters</param>
        public static void PrintThingForTeam(string teamName, List<Character> chars)
        {
            foreach (var character in chars)
            {
                Console.WriteLine($"{teamName} team picks: {character}");
            }
        }

        /// <summary>
        /// Given a RNG, create a list of Characters without replacement
        /// </summary>
        /// <param name="rng">Random Number Generator</param>
        /// <returns>List of <see cref="Character"/></returns>
        public static List<Character> DetermineTeam(Random rng)
        {
            List<Character> characters = new List<Character>();
            while (characters.Count < 3)
            {
                Character charc = (Character) rng.Next(Enum.GetNames(typeof(Character)).Length);
                if (characters.Contains(charc))
                {
                    continue;
                }

                characters.Add(charc);
            }

            return characters;
        }
    }

    public enum Character
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
