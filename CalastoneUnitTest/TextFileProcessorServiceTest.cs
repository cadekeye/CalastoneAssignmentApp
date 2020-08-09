using CalastoneAssignment;
using CalastoneLibrary;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CalastoneUnitTest
{
    [TestFixture]
    public class TextFileProcessorServiceTest
    {
        [TestCase("Alice was beginning to get very tired of sitting by her sister on the bank")]
        public void TestGetContentAfterApplyFilterRulesAsync(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            var actual = _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual("beginning", actual);
            Assert.IsNotNull(actual);

        }

        [TestCase("Alice was to get very tired of sitting by her sister on the bank")]
        public void TestGetContentAfterApplyFilterRulesAsyncReturnEmpty(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            var actual = _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult();

            Assert.IsEmpty(actual);

        }

        [TestCase(null)]
        public void TestGetContentAfterApplyFilterRulesAsyncWithNullInputRaisedException(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            Assert.Throws<NullReferenceException>(() => _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult());

        }

        [TestCase("beginning")]
        public void TestGetContentAfterApplyFirstFilterRulesAsync(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            var actual = _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual("beginning", actual);
            Assert.IsNotNull(actual);

        }

        [TestCase("go to my")]
        public void TestGetContentAfterApplySecondFilterRulesReturnEmpty(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            var actual = _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(string.Empty, actual);
            Assert.IsNotNull(actual);

        }

        [TestCase("Titus took the tapes to thomas")]
        public void TestGetContentAfterApplyThirdFilterRulesReturnEmpty(string input)
        {
            IUtility _utility = new Utility();
            ITextFileProcessorService _textFileProcessorService = new TextFileProcessorService(_utility);

            var actual = _textFileProcessorService.GetContentAfterApplyFilterRulesAsync(input)
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(string.Empty, actual);
            Assert.IsNotNull(actual);

        }
    }
}
