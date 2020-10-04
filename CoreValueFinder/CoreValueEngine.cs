using System.Collections.Generic;
using System.Linq;

namespace CoreValueFinder
{
    public class CoreValueEngine
    {
        private const int ROUND_1_RATING_THRESHOLD = 3;
        private const int ROUND_2_RATING_THRESHOLD = 6;

        private readonly List<CoreValue> coreValues = new List<CoreValue>();
        private int currentCoreValueElementPosition = 0;

        public CoreValueEngine()
        {
        }

        public void Add(CoreValue coreValue)
        {
            coreValues.Add(coreValue);
        }

        public List<CoreValue> GetCoreValues()
        {
            return coreValues;
        }

        public string GetCoreValueForRating()
        {
            return this.coreValues.ElementAt(currentCoreValueElementPosition).GetDescription();
        }

        public void RateCoreValue(int rating)
        {
            this.coreValues.ElementAt(currentCoreValueElementPosition).Rate(rating);       
            if (currentCoreValueElementPosition < this.coreValues.Count)
            {
                currentCoreValueElementPosition++;
            }
        }

        public void RoundOneValueElimination()
        {
            this.coreValues.RemoveAll(cv => cv.GetRating() < ROUND_1_RATING_THRESHOLD);
        }

        public void RoundTwoValueElimination()
        {
            this.coreValues.RemoveAll(cv => cv.GetRating() < ROUND_2_RATING_THRESHOLD);
        }
    }
}