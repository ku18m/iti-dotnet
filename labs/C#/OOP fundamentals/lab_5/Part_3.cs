namespace part_3
{
    class Duration
    {
        int hours;
        int minutes;
        int seconds;

        #region Properties
        public int Hours
        {
            get { return hours; }
            set { 
                if (value < 0 || value > 23)
                    hours = 0;
                else
                    hours = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set { 
                if (value < 0)
                    minutes = 0;
                
                if (value > 59)
                {
                    minutes = value % 60;
                    Hours += (value - minutes) / 60;
                }
                else
                    minutes = value;
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set {
                if (value < 0)
                    seconds = 0;

                if (value > 59)
                {
                    seconds = value % 60;
                    Minutes += (value - seconds) / 60;
                }
                else
                    seconds = value;
            }
        }
        #endregion
        #region Constructors
        public Duration(int seconds)
        {
            Seconds = seconds;
        }

        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }
        #endregion
        #region Methods
        public string GetString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        public int GetTotalSeconds()
        {
            return Hours * 3600 + Minutes * 60 + Seconds;
        }
        #endregion
        #region Operators
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.GetTotalSeconds() + d2.GetTotalSeconds());
        }

        public static Duration operator +(Duration d1, int seconds)
        {
            return new Duration(d1.GetTotalSeconds() + seconds);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(d1.GetTotalSeconds() - d2.GetTotalSeconds());
        }

        public static Duration operator -(Duration d1, int seconds)
        {
            return new Duration(d1.GetTotalSeconds() - seconds);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return d1.GetTotalSeconds() > d2.GetTotalSeconds();
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return d1.GetTotalSeconds() < d2.GetTotalSeconds();
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return d1.GetTotalSeconds() <= d2.GetTotalSeconds();
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return d1.GetTotalSeconds() >= d2.GetTotalSeconds();
        }
        #endregion
    }

    class Part3
    {
        public static void Run()
        {
            Duration d1 = new Duration(6000);
            Console.WriteLine(d1.GetString());
            Duration d2 = new Duration(1, 0, 6000);
            Console.WriteLine(d2.GetString());
            Duration d3 = d1 + d2;
            Console.WriteLine(d3.GetString());
            Console.WriteLine(d3.GetTotalSeconds());
            Console.WriteLine(d1 > d2);
            Console.WriteLine(d1 < d2);
            Console.WriteLine(d1 >= d2);
            Console.WriteLine(d1 <= d2);
        }
    }
}
