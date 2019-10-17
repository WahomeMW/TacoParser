using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var taco = new TacoParser();
            var doing = "34.492949,-85.848196,Taco Bell Rainsvill...";

            //Act
            var actual = taco.Parse(doing);
            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("31.570771, -84.10353,Taco Bell Albany...")]
        [InlineData("34.039588, -84.283254,Taco Bell Alpharetta...")]
        [InlineData("33.648244, -84.011856,Taco Bell Conyers...")]
        public void ShouldParse(string str)
        {
            // TODO: Complete Should Parse

            //Arrange
            var taco = new TacoParser();

            //Act
            var actual = taco.Parse(str);
            //Assert

            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            var taco = new TacoParser();
            //Act
            var actual = false;
            //Assert
            Assert.Null(actual);
        }
    }
}
