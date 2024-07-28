using Newtonsoft.Json;
using TurtleChallenge.Models;

namespace TurtleChallenge.Services
{
    public class InputService
    {
        /// <summary>
        /// Read game settings file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public GameSettings ReadGameSettings(string filePath)
        {
            filePath = "Data\\" + filePath + ".json";
            var json = File.ReadAllText(filePath);
            var settings = JsonConvert.DeserializeObject<GameSettings>(json);
            
            if (settings == null)
            {
                throw new InvalidOperationException("Invalid game settings file.");
            }

            return settings;
        }

        /// <summary>
        /// Read move sequences file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<MoveSequence> ReadMoveSequences(string filePath)
        {
            filePath =  "Data\\" + filePath + ".json";
            var json = File.ReadAllText(filePath);
            var moveSequences = JsonConvert.DeserializeObject<List<MoveSequence>>(json);
            
            if (moveSequences == null)
            {
                throw new InvalidOperationException("Invalid move sequences file.");
            }

            return moveSequences;
        }
    }
}
