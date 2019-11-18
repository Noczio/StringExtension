using System;
using Xunit;
using Xunit.Abstractions;
using StringExtension;

namespace XUnitTestProject
{
    public class UnitTestTransform
    {
        private readonly ITestOutputHelper output;

        public UnitTestTransform(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void TestDiacritics()
        {
            const string EXPECTED = "a";
            string test_string = "á";
            string fixed_string = test_string.Remove_Diacritics();
            output.WriteLine($"{test_string} goes to {fixed_string}");
            Assert.Equal(EXPECTED,fixed_string);
        }

        [Fact]
        public void TestDiacriticsWord()
        {
            const string EXPECTED = "Ivan";
            string test_string = "Iván";
            output.WriteLine($"{test_string} goes to {test_string.Remove_Diacritics()}");
            Assert.Equal(EXPECTED, test_string.Remove_Diacritics());
        }

        [Fact]
        public void TestDiacriticsWordWithSpace()
        {
            const string EXPECTED = "Cancion aeiouu por Guete";
            string test_string = "Canción áéíóúü por Güete";
            output.WriteLine($"{test_string} goes to {test_string.Remove_Diacritics()}");
            Assert.Equal(EXPECTED, test_string.Remove_Diacritics());
        }
    }
}
