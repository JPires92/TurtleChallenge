namespace TurtleChallenge.Utilities
{
    public class FileReader : IFileReader
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}