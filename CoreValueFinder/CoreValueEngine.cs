using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreValueFinder
{
    public class CoreValueEngine
    {
        private readonly List<CoreValue> coreValues = new List<CoreValue>();
        private CoreValue coreValue = null;

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
            //TODO:
            this.coreValue = coreValues.FirstOrDefault();
            return this.coreValue.GetDescription();
        }

        public void RateCoreValue(int rating)
        {
            //TODO:
            this.coreValue = coreValues.FirstOrDefault();
            this.coreValue.Rate(rating);
        }
    }
}