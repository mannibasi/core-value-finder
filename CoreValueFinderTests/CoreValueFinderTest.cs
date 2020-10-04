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
        public void TestRetrievalOfMultipleValuesForRating()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Accomplishment"));

            Assert.AreEqual("Abundance", engine.GetCoreValueForRating());

            engine.RateCoreValue(3);

            Assert.AreEqual("Accomplishment", engine.GetCoreValueForRating());
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

        [TestMethod]
        public void TestMultipleCoreValueRatings()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Accomplishment"));

            engine.RateCoreValue(3);
            engine.RateCoreValue(4);

            Assert.AreEqual(3, engine.GetCoreValues().FirstOrDefault().GetRating());
            Assert.AreEqual(4, engine.GetCoreValues().LastOrDefault().GetRating());
        }

        [TestMethod]
        public void TestRoundOneValuesFilter()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Acceptance"));
            engine.Add(new CoreValue("Accessibility"));
            engine.Add(new CoreValue("Accomplishment"));
            engine.Add(new CoreValue("Accuracy"));

            engine.RateCoreValue(3);
            engine.RateCoreValue(2);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);

            engine.RoundOneValueElimination();

            Assert.AreEqual(4, engine.GetCoreValues().Count);
        }

        [TestMethod]
        public void TestRoundOneAndTwoValuesFilter()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Acceptance"));
            engine.Add(new CoreValue("Accessibility"));
            engine.Add(new CoreValue("Accomplishment"));
            engine.Add(new CoreValue("Accuracy"));

            engine.RateCoreValue(3);
            engine.RateCoreValue(2);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);

            engine.RoundOneValueElimination();

            Assert.AreEqual(4, engine.GetCoreValues().Count);

            engine.RoundTwoValueElimination();

            //TODO: rate values again...

            Assert.AreEqual(3, engine.GetCoreValues().Count);
        }
    }
}