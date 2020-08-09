using CalastoneLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalastoneAssignment
{
    public class TextFileProcessorService : ITextFileProcessorService
    {
        private readonly IUtility _utility;
        private const string VOWEL_RULES = "AEIOU";

        public TextFileProcessorService(IUtility utility)
        {
            _utility = utility;
        }

        public Task<string> GetContentAfterApplyFilterRulesAsync(string content)
        {
            List<string> filterResults = new List<string>();

            content = content.FormatString();

            var contentArray = content.Split(new char[] { ' ', '\r' }, StringSplitOptions.RemoveEmptyEntries);


            contentArray.ToList().ForEach((word) =>
            {
                if (!string.IsNullOrEmpty(word))
                {
                    var alphaWord = GetAlphaCharacterOnly(word.Trim());

                    if (!IsContainVowelInTheMiddle(alphaWord.Trim()) 
                        && alphaWord.Length >= 3
                        && !alphaWord.ToLower().Contains('t'))
                    {
                        filterResults.Add(word.Trim());
                    }
                }
            });

            var result = string.Join(' ', filterResults);
            return Task.FromResult(result);
        }

        private string GetAlphaCharacterOnly(string input)
        {
            var result = Task.Run(async () => await _utility.RemoveNonAlphaCharacter(input)).GetAwaiter().GetResult();

            return result;
        }

        public async Task<string> ReadFileContentAsync(string fileFullPath)
        {
            var textFileContent = await _utility.ReadTextFileContentsAsync(fileFullPath);

            return textFileContent;
        }

        private string FindMiddleContent(string search)
        {
            search = search.Trim();

            var inputLenght = search.Trim().Length;

            if (inputLenght < 2)
            {
                return search;
            }

            var mod = inputLenght % 2;
            decimal val = inputLenght / 2;
            var pos = Math.Floor(val);

            if (mod == 0)
            {
                return search.Substring(decimal.ToInt32(pos) - 1, 2).ToLower();
            }
            else
            {
                return search.Substring(decimal.ToInt32(pos), 1).ToLower();
            }
        }

        private bool IsContainVowelInTheMiddle(string search)
        {
            return FindMiddleContent(search).Any(c => VOWEL_RULES.ToLower().Contains(c));
        }
    }
}