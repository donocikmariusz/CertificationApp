
namespace CertificationApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void TestRef()
        {
            //arrange
            var lok1 = GetLok("EP08");
            var lok2 = GetLok("EP08");

            //act


            //assert
            Assert.AreEqual(lok1.Type, lok2.Type);
        }

        [Test]
        public void TestValue()
        {
            //arrange
            int number1 = 1;
            int number2 = 2;

            //act


            //assert
            Assert.AreEqual(number1, number2);
        }

        private Lok GetLok(string type)
        {
            return new Lok(type);
        }
    }
}
