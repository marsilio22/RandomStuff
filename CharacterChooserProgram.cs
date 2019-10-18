using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
            Console.Write("How many teams are there: ");
            string numberOfTeams = Console.ReadLine();

            Console.Write("How many characters per team: ");
            string numberOfCharacters = Console.ReadLine();

            var teamColours = new List<string> { "Red", "Blue", "Green", "Yellow" };
            var teams = new List<string>();

            if (int.TryParse(numberOfTeams, out int result) && result <= teamColours.Count && int.TryParse(numberOfCharacters, out int teamSize) && teamSize <= Enum.GetNames(typeof(Character)).Length)
            {
                teams = teamColours.GetRange(0, result);
            }
            else
            {
                Console.WriteLine("you've done a bad there...");
                Console.ReadLine();
                return;
            }
            
            Random rng = new Random();

            while (true)
            {
                foreach (var team in teams)
                {
                    var characters = Determiner.DetermineTeam(rng, teamSize);
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
        /// <param name="teamSize">Number of Characters per team</param>
        /// <returns>List of <see cref="Character"/></returns>
        public static List<Character> DetermineTeam(Random rng, int teamSize)
        {
            List<Character> characters = new List<Character>();
            while (characters.Count < teamSize)
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
        PacMan = 2,
        Mewtwo = 3,
        Incineroar = 4,
        ZeroSuitSamus = 5,
        MrGameAndWatch = 6,
        Palutena = 7,
        DarkSamus = 8,
        Jigglypuff = 9,
        NormalSamus = 10,
        Greninja = 11,
        PokemonTrainer = 12,
        ROB = 13
    }
}
