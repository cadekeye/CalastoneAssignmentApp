using System.Threading.Tasks;

namespace CalastoneLibrary
{
    public interface IUtility
    {
        Task<string> ReadTextFileContentsAsync(string filePath);

        Task<string> RemoveNonAlphaCharacter(string input);
    }
}
