using System.Threading.Tasks;

namespace CalastoneAssignment
{
    public interface ITextFileProcessorService
    {
        Task<string> ReadFileContentAsync(string fileFullPath);

        Task<string> GetContentAfterApplyFilterRulesAsync(string content);
    }
}