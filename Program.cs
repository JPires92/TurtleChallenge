namespace TurtleChallenge;
using TurtleChallenge.Services;
using TurtleChallenge.Models;
class Program
{
    static void Main(string[] args)
    {
        //Check if the user provided the required filenames
        if (args.Length < 2)
        {
            Console.WriteLine("Please provide paths for game-settings and moves files.");
            return;
        }

        InputService inputService = new InputService();
        GameService gameService = new GameService();

        try
        {
            //Read the game settings and move sequences
            GameSettings settings = inputService.ReadGameSettings(args[0]);
            List<MoveSequence> moveSequences = inputService.ReadMoveSequences(args[1]);

            //Execute the game for each move sequence and print the result~
            int nSequence = 1;
            foreach (var sequence in moveSequences)
            {
                
                var result = gameService.PlayGame(settings, sequence);
                Console.WriteLine("Sequence {0}: {1}",nSequence, result);
                //Read the game settings again for the next sequence
                settings = inputService.ReadGameSettings(args[0]);
                nSequence++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}