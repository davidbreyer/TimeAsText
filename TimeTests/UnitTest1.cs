using System;
using ClockLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetTime_Returns3Oclock()
        {
            var threeOclockInWords = ClockApi.GetTimeAsWords(3, 00);

            Assert.AreEqual("It is Three o'clock.", threeOclockInWords);
        }

        [TestMethod]
        public void GetTime_Returns4Oclock()
        {
            var fourOclockInWords = ClockApi.GetTimeAsWords(4, 00);

            Assert.AreEqual("It is Four o'clock.", fourOclockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsQuarterAfter4()
        {
            var fourOclockInWords = ClockApi.GetTimeAsWords(4, 15);

            Assert.AreEqual("It is Quarter past Four.", fourOclockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsHalfPastAfter4()
        {
            var fourOclockInWords = ClockApi.GetTimeAsWords(4, 30);

            Assert.AreEqual("It is Half past Four.", fourOclockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsFiveMinutesPastFour()
        {
            var fourOclockInWords = ClockApi.GetTimeAsWords(4, 5);

            Assert.AreEqual("It is Five minutes past Four.", fourOclockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsTwentyFiveMinutesPastFour()
        {
            var fourOclockInWords = ClockApi.GetTimeAsWords(4, 25);

            Assert.AreEqual("It is Twenty-Five minutes past Four.", fourOclockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsTenMinutestoFive()
        {
            var tenMinutesUntilFiveInWords = ClockApi.GetTimeAsWords(4, 50);

            Assert.AreEqual("It is Ten minutes to Five.", tenMinutesUntilFiveInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsTwelveOclock()
        {
            var twelveOClockInWords = ClockApi.GetTimeAsWords(12, 00);

            Assert.AreEqual("It is Twelve o'clock.", twelveOClockInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsTentoOne()
        {
            var tentoOneInWords = ClockApi.GetTimeAsWords(12, 50);

            Assert.AreEqual("It is Ten minutes to One.", tentoOneInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsQuartertoTwo()
        {
            var quartertoTwoInWords = ClockApi.GetTimeAsWords(1, 45);

            Assert.AreEqual("It is Quarter to Two.", quartertoTwoInWords);
        }

        [TestMethod]
        public void EnumHelper_GetDiplayNameForQuarterto()
        {
            var quartertoInWords = ClockApi.Past.Quarterto.ToDisplayName();

            Assert.AreEqual("Quarter to", quartertoInWords);
        }

        [TestMethod]
        public void EnumHelper_GetDescriptionNameForQuarterto()
        {
            var quartertoInWords = ClockApi.Past.Quarterto.ToDescription();

            Assert.AreEqual("Quarterto", quartertoInWords);
        }

        [TestMethod]
        public void EnumHelper_GetDisplayNameForQuarterAfter_WhereNoDisplayNameExists()
        {
            var quarterInWords = ClockApi.Past.Quarter.ToDisplayName();

            Assert.AreEqual("Quarter", quarterInWords);
        }

        [TestMethod]
        public void EnumHelper_GetDescriptionForHalf()
        {
            var halfInWords = ClockApi.Past.Half.ToDescription();

            Assert.AreEqual("Half Past The Hour", halfInWords);
        }

        [TestMethod]
        public void GetTime_ReturnsTwoMinutestoEleven()
        {
            var twoMinutestoEleven = ClockApi.GetTimeAsWords(10, 58);

            Assert.AreEqual("It is Two minutes to Eleven.", twoMinutestoEleven);
        }

        [TestMethod]
        public void GetTime_ReturnsOneMinutePastEleven()
        {
            var oneMinutePastEleven = ClockApi.GetTimeAsWords(11, 01);

            Assert.AreEqual("It is One minute past Eleven.", oneMinutePastEleven);
        }

        [TestMethod]
        public void GetTime_ReturnsOneMinutePastEleven_InTwentyFourHourTime()
        {
            var oneMinutePastEleven = ClockApi.GetTimeAsWords(23, 01);

            Assert.AreEqual("It is One minute past Eleven.", oneMinutePastEleven);
        }

        [TestMethod]
        public void GetTime_ReturnsTwelveAfter11_InTwentyFourHourTime()
        {
            var twelveMinutesPastEleven = ClockApi.GetTimeAsWords(23, 12);

            Assert.AreEqual("It is Twelve minutes past Eleven.", twelveMinutesPastEleven);
        }

        [TestMethod]
        public void GetTime_ReturnsNineteenAfter11_InTwentyFourHourTime()
        {
            var nineteenMinutesPastEleven = ClockApi.GetTimeAsWords(23, 19);

            Assert.AreEqual("It is Nineteen minutes past Eleven.", nineteenMinutesPastEleven);
        }

        [TestMethod]
        public void GetTime_ReturnsTwelveOclock_inTwentyFourHourTime()
        {
            var twelveoclock = ClockApi.GetTimeAsWords(00, 00);

            Assert.AreEqual("It is Twelve o'clock.", twelveoclock);
        }

        [TestMethod]
        public void GetTime_ReturnsOneMinuteToTwelve_inTwentyFourHourTime()
        {
            var OneMinuteToTwelve = ClockApi.GetTimeAsWords(11, 59);

            Assert.AreEqual("It is One minute to Twelve.", OneMinuteToTwelve);
        }

        [TestMethod]
        public void GetTime_ReturnsTwentyNineMinutesToEight()
        {
            var twentyNineMinutesToEight = ClockApi.GetTimeAsWords(7, 31);

            Assert.AreEqual("It is Twenty-Nine minutes to Eight.", twentyNineMinutesToEight);
        }

        [TestMethod]
        public void GetTime_ReturnsTwentyMinutesPastEight()
        {
            var twentyMinutesPastEight = ClockApi.GetTimeAsWords(8, 20);

            Assert.AreEqual("It is Twenty minutes past Eight.", twentyMinutesPastEight);
        }

        [TestMethod]
        public void GetTime_ReturnsTwentyMinutesToNine()
        {
            var twentyMinutesToNine = ClockApi.GetTimeAsWords(8, 40);

            Assert.AreEqual("It is Twenty minutes to Nine.", twentyMinutesToNine);
        }
    }
}
