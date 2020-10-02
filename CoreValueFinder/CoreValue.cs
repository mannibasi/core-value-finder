using System;

namespace CoreValueFinder
{
    public class CoreValue
    {
        private readonly string description;
        private int rating;

        public CoreValue(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public int GetRating()
        {
            return this.rating;
        }

        internal void Rate(int rating)
        {
            this.rating = rating;
        }
    }
}