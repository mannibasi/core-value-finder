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
}