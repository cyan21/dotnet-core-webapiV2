using Xunit;
using Greeting;

namespace greeting.Tests
{
    public class GreetingService_test
    {
        private readonly Greetings _greetingService;

        public GreetingService_test()
        {
            _greetingService = new Greetings();
        }

        [Fact]
        public void TestFrenchGreeting()
        {
            var result = _greetingService.fr();

            // cheat sheet for Assert : https://lukewickstead.wordpress.com/2013/01/16/xunit-cheat-sheet/
            Assert.Contains(result, "Bonjour");
        }

        [Theory]
        [InlineData("Bonjour")]
        [InlineData("Hola")]
//        [InlineData("Konnichiwa")]
        public void TestAllGreeting(string g)
        {
            var result = _greetingService.sp();

            Assert.Contains(result, g);
        }
    }
}
