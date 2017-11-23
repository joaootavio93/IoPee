using Quartz;
using Quartz.Impl;
using System;

namespace IoPee.Schedules
{
    public class ChangeDeviceStatusScheduler
    {
        public ChangeDeviceStatusScheduler()
        {
            try
            {
                ISchedulerFactory schedFact = new StdSchedulerFactory();
                IScheduler sched = schedFact.GetScheduler();
                sched.Start();

                IJobDetail job = JobBuilder.Create<ChangeDeviceStatusJob>()
                    .WithIdentity("DeviceStatusJob", "DeviceStatusGroup1")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("DeviceStatusTrigger")
                    .WithSimpleSchedule(s => s.WithIntervalInSeconds(10).RepeatForever())
                    .StartAt(DateTime.Now)
                    .Build();

                sched.ScheduleJob(job, trigger);
            }
            catch(Exception e)
            {
                Console.WriteLine("An exception has been thrown: " + e.Message);
            }
        }
    }
}