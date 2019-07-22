using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartE;

namespace BasicUnitTest
{
    [TestClass]
    public class UnitTest1
    { 
        [TestMethod]
        public void Test_Login()
        {
            bool expected_result = true;
            bool actual_result = DataAccessLayer.Equals("admin", "admin");
            Assert.AreEqual(expected_result, actual_result, "Test is passed");
        }

        private TimeSpan Time(Action toTime)
        {
            var timer = Stopwatch.StartNew();
            toTime();
            timer.Stop();
            return timer.Elapsed;
        }

        [TestMethod]
        public void PerformanceSpeedEnd(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Run Time: " + elapsedTime);
        }
    }

}

