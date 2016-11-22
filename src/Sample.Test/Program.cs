using Shouldly;
using Xunit;

namespace Sample.Test
{
    public class Program
    {
        [Fact]
        public void Test1()
        {
            for (var i = 0; i < 10; i++)
            {
                i.ShouldBe(i);
            }
        }
    }
}
