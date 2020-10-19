using System;

namespace CoreValueFinder
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Core Value Finder! http://www.mypersonalimprovement.com/personalcorevalues.shtml");
            new Finder().Find();
        }
    }

    public class Finder
    {
        private const int CORE_VALUE_UPPER_BOUND = 10;
        private int parsedRatingInput;
        private readonly CoreValueEngine engine;

        public Finder()
        {
            this.engine = DefaultCoreValueEngine();
        }

        public bool RatingIsValid(string ratingInput)
        {
            return int.TryParse(ratingInput, out parsedRatingInput);
        }

        internal void Find()
        {
            CaptureValueRatings(engine);
            engine.RoundOneValueElimination();
            engine.PrepareForValueRating();
            CaptureValueRatings(engine);
            engine.RoundTwoValueElimination();
            PrintCoreValues(engine);
        }

        private void CaptureValueRatings(CoreValueEngine engine)
        {
            Console.Clear();
            Console.WriteLine("Please (re-)rate remaining values on a scale of zero to ten:");
            foreach (var cv in engine.GetCoreValues())
            {
                bool validRating = false;
                while(!validRating)
                {
                    Console.WriteLine(cv.GetDescription());
                    string input = Console.ReadLine();
                    if (RatingIsValid(input))
                    {
                        cv.Rate(parsedRatingInput);
                        validRating = true;
                    }
                }
            }
        }

        private static void PrintCoreValues(CoreValueEngine engine)
        {
            Console.Clear();
            Console.WriteLine("The following constitutes your list of personal core values:");
            foreach (var cv in engine.GetCoreValues())
            {
                Console.WriteLine(cv.GetDescription());
            }
            if(engine.GetCoreValues().Count < CORE_VALUE_UPPER_BOUND)
            {
                Console.WriteLine("If your personal core values list is still too long and bulky, " +
                    "chip away at it some more until you only have about 10 values on your list. " +
                    "Make that part of who you are and know that this is your code (or map) to your best life.");
            }
        }

        private static CoreValueEngine DefaultCoreValueEngine()
        {
            var cve = new CoreValueEngine();
            cve.Add(new CoreValue("Abundance"));
            cve.Add(new CoreValue("Acceptance"));
            cve.Add(new CoreValue("Accessibility"));
            cve.Add(new CoreValue("Accomplishment"));
            cve.Add(new CoreValue("Accuracy"));
            return cve;
        }
    }
}