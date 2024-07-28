namespace TurtleChallenge.Utilities
{
    public class FileReader : IFileReader
    {
        public string ReadAllText(string path) => File.ReadAllText(path);
    }
}