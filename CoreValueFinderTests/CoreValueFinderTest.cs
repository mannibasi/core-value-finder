using CoreValueFinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoreValueFinderTests
{
    [TestClass]
    public class CoreValueFinderTest
    {
        [TestMethod]
        public void TestCoreValueHasDescription()
        {
            var value = new CoreValue("Abundance");
            Assert.AreEqual("Abundance", value.GetDescription());
        }

        [TestMethod]
        public void TestCoreValueEngineHasValues()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Accomplishment"));
            Assert.AreEqual(2, engine.GetCoreValues().Count);
        }

        [TestMethod]
        public void TestRetrievalOfValueForRating()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Accomplishment"));

            Assert.AreEqual("Abundance", engine.GetCoreValueForRating());
        }

        [TestMethod]
        public void TestCoreValueRating()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Accomplishment"));

            engine.GetCoreValueForRating();
            engine.RateCoreValue(3);

            Assert.AreEqual(3, engine.GetCoreValues().FirstOrDefault().GetRating());
        }
    }
}