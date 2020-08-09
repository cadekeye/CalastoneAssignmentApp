using System;
using System.IO;
using System.Threading.Tasks;

namespace CalastoneLibrary
{
    public class Utility : IUtility
    {
        public async Task<string> ReadTextFileContentsAsync(string filePath)
        {
            var fileContent = await File.ReadAllTextAsync(filePath);

            return fileContent;
        }

        public Task<string> RemoveNonAlphaCharacter(string input)
        {

            char[] arr = input.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetter(c) ||
                char.IsWhiteSpace(c))));

            return Task.FromResult(new string(arr));
        }
    }
}
