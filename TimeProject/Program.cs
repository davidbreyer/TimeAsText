using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace TimeProject
{
    class Program
    {
        public static int CurrentMinute { get; set; }

        static void Main(string[] args)
        {

            try
            {
                //while (true)
                //{
                AutoResetEvent exit = new AutoResetEvent(false);

                RegisteredWaitHandle h = ThreadPool.RegisterWaitForSingleObject(exit, new WaitOrTimerCallback(WriteTimeInWords),
                                                                                null, 1000, false);

                Console.WriteLine("Running - press enter to stop");
                CurrentMinute = DateTime.Now.Minute;
                Console.WriteLine(ClockLibrary.ClockApi.GetTimeAsWords(DateTime.Now.Hour, DateTime.Now.Minute));
                Console.ReadLine();

                //Timer timer = new Timer(1000);
                //    timer.Elapsed += async (sender, e) => await WriteTimeInWords();
                //    timer.Start();
                //    Console.ReadKey();
                //}
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.GetBaseException().Message);
            }
        }

        public static void WriteTimeInWords(object state, bool timedOut)
        {
            int updatedMinute = DateTime.Now.Minute;

            if (CurrentMinute != updatedMinute)
            {
                var timeInWordsResponse = ClockLibrary.ClockApi.GetTimeAsWords(DateTime.Now.Hour, DateTime.Now.Minute);
                Console.WriteLine(timeInWordsResponse);
                CurrentMinute = updatedMinute;
            }
            //return Task.CompletedTask;
        }

        public static Task WriteTimeInWords()
        {
            int updatedMinute = DateTime.Now.Minute;

            if (CurrentMinute != updatedMinute)
            {
                var timeInWordsResponse = ClockLibrary.ClockApi.GetTimeAsWords(DateTime.Now.Hour, DateTime.Now.Minute);
                Console.WriteLine(timeInWordsResponse);
                CurrentMinute = updatedMinute;
            }
            return Task.CompletedTask;
        }
    }
}
