using System;
using Xunit;
using Statistics;
using System.Collections.Generic;

namespace Statistics.Test
{
    public class StatsUnitTest
    {

        [Fact]
        public void ReportsAverageMinMax()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(new List<double> { 1.5, 8.9, 3.2, 4.5 });

            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.5) <= epsilon);
        }

        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(new List<double> { });

            var expectedResult = new Stats(double.NaN, double.NaN, double.NaN);
            Assert.True(double.IsNaN(computedStats.average));
            Assert.True(double.IsNaN(computedStats.min));
            Assert.True(double.IsNaN(computedStats.max));

            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1
        }

        [Fact]
        public void RemovesNANInputsAndReturnsStats()
        {
            var statsComputer = new StatsComputer();
            var computedStats = statsComputer.CalculateStatistics(new List<double> { 1.0, double.NaN, 5.0 });

            float epsilon = 0.001F;
            Assert.True(Math.Abs(computedStats.average - 3.000) <= epsilon);
            Assert.True(Math.Abs(computedStats.max - 5.0) <= epsilon);
            Assert.True(Math.Abs(computedStats.min - 1.0) <= epsilon);
        }

        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            var emailAlert = new EmailAlert();
            var ledAlert = new LEDAlert();
            IAlerter[] alerters = { emailAlert, ledAlert };

            const double maxThreshold = 10.2;
            var statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.checkAndAlert(new List<double> { 0.2, 11.9, 4.3, 8.5 });

            Assert.True(emailAlert.SendAlert());
            Assert.True(ledAlert.SendAlert());
        }

    }
}


