using System;

namespace specf1.utils
{
    public class TimingHelpers
    {
        public static TimeSpan vergangeneZeit(DateTime startZeit)
        {
            return TimeSpan.FromSeconds((DateTime.Now - startZeit).TotalSeconds);
        }

       
    }
}
