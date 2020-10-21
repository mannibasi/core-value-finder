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
            CoreValueEngine engine = TestCoreValueEngine();

            engine.RateCoreValue(3);
            engine.RateCoreValue(2);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);

            engine.RoundOneValueElimination();

            Assert.AreEqual(4, engine.GetCoreValues().Count);
        }

        [TestMethod]
        public void TestRoundTwoRetrievalOfValueForRating()
        {
            CoreValueEngine engine = TestCoreValueEngine();

            engine.RateCoreValue(3);
            engine.RateCoreValue(2);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);

            engine.RoundOneValueElimination();

            engine.PrepareForValueRating();

            Assert.AreEqual("Abundance", engine.GetCoreValueForRating());
        }

        [TestMethod]
        public void TestRoundTwoValuesFilter()
        {
            CoreValueEngine engine = TestCoreValueEngine();

            engine.RateCoreValue(3);
            engine.RateCoreValue(2);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);
            engine.RateCoreValue(7);

            engine.RoundOneValueElimination();

            engine.PrepareForValueRating();

            engine.RateCoreValue(4);
            engine.RateCoreValue(5);
            engine.RateCoreValue(6);
            engine.RateCoreValue(7);

            engine.RoundTwoValueElimination();

            Assert.AreEqual(2, engine.GetCoreValues().Count);
        }

        private static CoreValueEngine TestCoreValueEngine()
        {
            var engine = new CoreValueEngine();
            engine.Add(new CoreValue("Abundance"));
            engine.Add(new CoreValue("Acceptance"));
            engine.Add(new CoreValue("Accessibility"));
            engine.Add(new CoreValue("Accomplishment"));
            engine.Add(new CoreValue("Accuracy"));
            return engine;
        }

        [TestMethod]
        public void TestParsingOfValidZeroIntegerConsoleInput()
        {
            Assert.IsTrue(new Finder().RatingIsValid("0"));
        }

        [TestMethod]
        public void TestParsingOfValidNonZeroIntegerConsoleInput()
        {
            Assert.IsTrue(new Finder().RatingIsValid("3"));
        }

        [TestMethod]
        public void TestParsingOfInvalidIntegerConsoleInput()
        {
            Assert.IsFalse(new Finder().RatingIsValid("abc"));
        }

        [TestMethod]
        public void TestDefaultValueEngineHasValues()
        {
            Assert.AreNotEqual(0, Finder.DefaultCoreValueEngine().GetCoreValues().Count);
        }
    }
}