namespace CertificationApp.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            int age1 = 10;
            int age2 = 20;

            int result = age1 + age2;

            Assert.AreEqual(30, result);
        }

        [Test]
        public void Test2()
        {
            //arrange
            var lok = new Lok("EP09", "345");
            lok.AddKilometers(500);
            lok.AddKilometers(150);
        

            // act
            var result = lok.TotalKilometers;
            
            //assert
            Assert.AreEqual(650, result);
        }
    }
}