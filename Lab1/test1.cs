namespace First.TestProject1

{
    public class UnitTest1
    {
        [Fact]
        public void SumTest()
        {
            int[] arr = { 1, 0, 3, 0, 5, 6 };
            var firstPart = new FirstPart(arr);

            Assert.Equal(3, firstPart.Sum());
        }

        [Fact]
        public void MultiplicationTest()
        {
            int[] arr = { 1, 2, 3};

            var firstPart = new FirstPart(arr);

            Assert.Equal(3, firstPart.Multiplication());
        }

    }
}
