using NUnit.Framework;
using System.Linq;

namespace diamond.tests
{
    public class DiamondTests
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static char[] Alphabet = alphabet.ToCharArray();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldPrintOneRowWhenDiamondIsA()
        {
            var sut = CreateSut('A');

            var result = sut.Print();

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHave2RowsForEveryPrintedLetterThatIsntTheMidpoint(char letter)
        {
            var sut = CreateSut(letter);
            var lettersThatShouldHave2Rows = alphabet.Substring(0, alphabet.IndexOf(letter));

            var result = sut.Print();
            
            foreach(var x in lettersThatShouldHave2Rows.ToCharArray())
            {
                Assert.That(result.Count(row => row.Contains(x.ToString())), Is.EqualTo(2));
            }
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHave2RowsForEveryLetterPlus1ForMidpoint(char letter)
        {
            var lettersToAdd = alphabet.Substring(0, alphabet.IndexOf(letter) + 1);
            var expectedRowCount = lettersToAdd == letter.ToString() ? 1 
                                                                     : lettersToAdd.ToCharArray().Count() * 2 - 1;
            var sut = CreateSut(letter);

            var result = sut.Print();

            Assert.That(result.Count, Is.EqualTo(expectedRowCount));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldDisplaySingleLetterInTopAndBottomOfDiamond(char letter)
        {
            var sut = CreateSut(letter);

            var result = sut.Print();

            Assert.That(result.First().Trim(), Is.EqualTo("A"));
            Assert.That(result.Last().Trim(), Is.EqualTo("A"));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHaveCorrectLineLength(char letter)
        {
            var expectedLineLength = (alphabet.IndexOf(letter) + 1) * 2 - 1;
            var sut = CreateSut(letter);

            var result = sut.Print();

            result.ForEach(x => Assert.That(x.ToCharArray().Count, Is.EqualTo(expectedLineLength)));
        }

        private PaddedDiamond CreateSut(char letter) => new PaddedDiamond(letter);
    }
}