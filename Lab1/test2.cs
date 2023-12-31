namespace First.TestProject1

{
    public class UnitTest2
    {
        [Fact]
        public void ColsWithZerosCountTest()
        {
            int[,] arr = {
    { 1, 2, 0 },
    { 0, 1, 1 },
    { 3, 1, 1 }
            };
            var secondPart = new SecondPart(3, 3);

            Assert.Equal(2, secondPart.ColsWithZerosCount());
        }

        [Fact]
        public void GetMaxRepeatingNumberTest()
        {
            int[,] arr = {
    { 1, 2, 0 },
    { 2, 2, 0 },
    { 3, 0, 1 }
            }; ;
            var secondPart = new SecondPart(3, 3);

            Assert.Equal(2, secondPart.GetMaxRepeatingNumber());
        }

    }
}
