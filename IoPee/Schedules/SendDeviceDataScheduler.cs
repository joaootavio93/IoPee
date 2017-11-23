using Quartz;
using Quartz.Impl;
using System;

namespace IoPee.Schedules
{
    public class SendDeviceDataScheduler
    {
        public SendDeviceDataScheduler()
        {
            try
            {
                ISchedulerFactory schedFact = new StdSchedulerFactory();
                IScheduler sched = schedFact.GetScheduler();
                sched.Start();

                IJobDetail job = JobBuilder.Create<SendDeviceDataJob>()
                    .WithIdentity("SendDeviceDataJob", "SendDeviceDataGroup1")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("SendDeviceDataTrigger")
                    .WithSimpleSchedule(s => s.WithIntervalInSeconds(3).RepeatForever())
                    .StartAt(DateTime.Now)
                    .Build();

                sched.ScheduleJob(job, trigger);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
        }
    }
}