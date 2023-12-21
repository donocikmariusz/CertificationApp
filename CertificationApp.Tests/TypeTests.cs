namespace CertificationApp
{

    public class LokTests
    {
        [Test]
        public void Test1()
        {
            // arrange
            var lok = new lokSavedInFile("SP32", "181");
            lok.AddKilometer(99);
            lok.AddKilometer(45);
            lok.AddKilometer(12);
            lok.AddKilometer(11);
            // act
            var result = lok.GetStatistics();

            // assert
            Assert.AreEqual(41.8, result.Average, 1);
            Assert.AreEqual(99, result.dailyMax, 1);
            Assert.AreEqual(11, result.dailyMin, 1);
        }
    }
}
