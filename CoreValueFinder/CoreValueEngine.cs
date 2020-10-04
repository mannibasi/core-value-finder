using System.Collections.Generic;
using System.Linq;

namespace CoreValueFinder
{
    public class CoreValueEngine
    {
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
            currentCoreValueElementPosition++;
        }
    }
}