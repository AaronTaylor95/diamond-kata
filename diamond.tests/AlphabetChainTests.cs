using NUnit.Framework;
using System.Linq;

namespace diamond.tests
{
    // 0 based
    [TestFixture]
    public class AlphabetChainTests
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static char[] Alphabet = alphabet.ToCharArray();

        [Test]
        public void ShouldPrintOneRowWhenDiamondIsA()
        {
            var sut = CreateSut('A');

            var result = sut.Execute();

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHave2RowsForEveryPrintedLetterThatIsntTheMidpoint(char letter)
        {   
            var lettersThatShouldHave2Rows = LettersThatShouldAppearTwice(letter);

            var sut = CreateSut(letter);
            var result = sut.Execute();

            foreach(var x in lettersThatShouldHave2Rows.ToCharArray())
            {
                Assert.That(result.Count(r => r.ToString().Contains(x)), Is.EqualTo(2));
            }
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHave2RowsForEveryLetterPlus1ForMidpoint(char letter)
        {
            var lettersToAdd = alphabet.Substring(0, alphabet.IndexOf(letter) + 1);
            var expectedRowCount = lettersToAdd == letter.ToString() ? 1
                                                                     : lettersToAdd.ToCharArray().Count() * 2 - 1;
            var sut = CreateSut(letter);
            var result = sut.Execute();

            Assert.That(result.Count, Is.EqualTo(expectedRowCount));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldDisplaySingleLetterInTopAndBottomOfDiamond(char letter)
        {
            var sut = CreateSut(letter);

            var result = sut.Execute();

            Assert.That(result.First().ToString().Trim(), Is.EqualTo("A"));
            Assert.That(result.Last().ToString().Trim(), Is.EqualTo("A"));
        }

        [Test, TestCaseSource(nameof(Alphabet))]
        public void ShouldHaveCorrectLineLength(char letter)
        {
            var expectedLineLength = (alphabet.IndexOf(letter) + 1) * 2 - 1;
            var sut = CreateSut(letter);

            var result = sut.Execute();

            result.ForEach(x => Assert.That(x.ToString().ToCharArray().Count, Is.EqualTo(expectedLineLength)));
        }

        private AlphabetChain.AlphabetChain CreateSut(char letter) => new AlphabetChain.AlphabetChain(new Letter(letter));
        private string LettersThatShouldAppearTwice(char letter) => alphabet.Substring(0, alphabet.IndexOf(letter));
    }
}
