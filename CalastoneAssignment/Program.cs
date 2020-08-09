using CalastoneLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CalastoneAssignment
{
    class Program
    {
        private static ServiceProvider serviceProvider;
        private static ILogger<Program> logger;

        static void Main(string[] args)
        {
             serviceProvider = new ServiceCollection()
              .AddLogging(opt => { opt.AddConsole(); })
              .AddSingleton<IUtility, Utility>()
              .AddSingleton<ITextFileProcessorService, TextFileProcessorService>()
              .BuildServiceProvider();

            serviceProvider
                .GetService<ILoggerFactory>();

             logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();


            var textFileFullPath = RequestingUserInput();

            var fileContent = ReadFileContent(textFileFullPath);

            ApplyFilterAndDisplayResultToConsole(fileContent);

            Console.ReadKey();
        }

        private static string ReadFileContent(string fileFullPath)
        {
            var fileProcessor = serviceProvider.GetService<ITextFileProcessorService>();
            var textFileContent =  fileProcessor.ReadFileContentAsync(fileFullPath)
                .GetAwaiter()
                .GetResult();

            return textFileContent;

        }
        private static string RequestingUserInput()
        {
            Console.WriteLine($"Enter the text file full path including the text file name: ");
            var fileFullPath = Console.ReadLine();

            if (string.IsNullOrEmpty(fileFullPath))
            {
                return RequestingUserInput();
            }

            if (!File.Exists(fileFullPath))
            {
                Console.WriteLine($"The text file detail supplied does not exists.\r\nPlease enter a valid file. ");
                return RequestingUserInput();
            }

            return fileFullPath;
        }

        private static void ApplyFilterAndDisplayResultToConsole(string fileContent)
        {
            var fileProcessor = serviceProvider.GetService<ITextFileProcessorService>();

            var results = Task.Run(async () => await fileProcessor.GetContentAfterApplyFilterRulesAsync(fileContent))
                .GetAwaiter()
                .GetResult();

            Console.WriteLine();
            Console.WriteLine("%%%%%%%%%%%%%%%%%%% OutPut %%%%%%%%%%%%%%%%%%%%%%%%%%%");
            Console.WriteLine(results);
            Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

        }
    }
}
