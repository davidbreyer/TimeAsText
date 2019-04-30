using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ClockLibrary
{
    public class ClockApi
    {
        public enum Hour
        {
            One = 1,
            Two = 2,
            Three = 3
            , Four = 4
            , Five
            , Six
            , Seven
            , Eight
            , Nine
            , Ten
            , Eleven = 11
            , Twelve = 12
        }

        public enum Past
        {
            Quarter = 15,
            [Description("Half Past The Hour")]
            Half = 30,
            [Display(Name = "Quarter to")]
            Quarterto = 45
        }

        enum Minute
        {
            One = 1,
            Two, Three, Four, Five, Six,
            Seven, Eight, Nine, Ten, Eleven, Twelve, Thirteen,
            Fourteen, Fifthteen, Sixteen, Seventeen,
            Eighteen, Nineteen, Twenty, TwentyOne, TwentyTwo,
            TwentyThree, TwentyFour, TwentyFive, TwentySix, TwentySeven,
            TwentyEight, TwentyNine, Thirty
        }

        enum MinutePreFix
        {
            Twenty = 20, Thirty = 30, Fourty = 40, Fifty = 50
        }

        public static string GetTimeAsWords(int hour, int minute)
        {
            if (hour > 12)
            {
                hour = hour - 12;
            }

            if(hour == 0)
            {
                hour = 12;
            }

            var hourName = Enum.GetName(typeof(Hour), hour);

            var pastName = Enum.GetName(typeof(Past), minute);

            var minuteName = Enum.GetName(typeof(Minute), minute);

            var TenInterval = int.Parse(minute.ToString().Substring(0, 1) + "0");

            var minutePrefix = Enum.GetName(typeof(MinutePreFix), TenInterval);


            //Top of the hour
            if (minute == 0)
            {
                return $"It is {hourName} o'clock.";
            }
            //Past the half hour
            else if (minute > 30)
            {
                var newHour2 = hour + 1;
                if (newHour2 > 12) { newHour2 = 1; }

                hourName = Enum.GetName(typeof(Minute), newHour2);

                //Quarter To the Hour
                if (minute == 45)
                {
                    return $"It is Quarter to {hourName}.";
                }
                else
                {
                    var newHour = hour + 1;
                    if (newHour > 12) { newHour = 1; }

                    hourName = Enum.GetName(typeof(Minute), newHour);
                    var toTheHour = 60 - minute;
                    minuteName = Enum.GetName(typeof(Minute), toTheHour);

                    if (toTheHour > 1)
                    {
                        if (toTheHour < 30 && toTheHour > 20)
                        {
                            TenInterval = int.Parse((toTheHour.ToString().Substring(0, 1) + "0"));

                            minutePrefix = Enum.GetName(typeof(MinutePreFix), TenInterval);
                            minuteName = Enum.GetName(typeof(Minute), int.Parse(toTheHour.ToString().Substring(1)));
                            return $"It is {minutePrefix}-{minuteName} minutes to {hourName}.";
                        }

                        return $"It is {minuteName} minutes to {hourName}.";
                    } 
                    else //It it one minute to the hour
                    {
                        return $"It is {minuteName} minute to {hourName}.";
                    }
                }
            }
            else if ((minute > 10 && minute < 15) || (minute > 15 && minute < 20))
            {
                minuteName = Enum.GetName(typeof(Minute), minute);
                return $"It is {minuteName} minutes past {hourName}.";
            }
            else if (minute >= 15)
            {
                if (!String.IsNullOrWhiteSpace(pastName))
                {
                    return $"It is {pastName} past {hourName}.";
                }
                else
                {
                    minuteName = Enum.GetName(typeof(Minute), int.Parse(minute.ToString().Substring(1)));

                    if (string.IsNullOrWhiteSpace(minuteName))
                    {
                        return $"It is {minutePrefix} minutes past {hourName}.";
                    }
                    else {
                        return $"It is {minutePrefix}-{minuteName} minutes past {hourName}.";
                    }
                }
            }
            else //The minutes is single digits
            {
                if (minute > 1)
                {
                    return $"It is {minuteName} minutes past {hourName}.";
                }
                else //It's one
                {
                    return $"It is {minuteName} minute past {hourName}.";
                }
            }
        }
    }
}
