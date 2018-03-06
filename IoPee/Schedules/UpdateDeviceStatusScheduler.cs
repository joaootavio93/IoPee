using Quartz;
using Quartz.Impl;
using System;

namespace IoPee.Schedules
{
    public class UpdateDeviceStatusScheduler
    {
        public UpdateDeviceStatusScheduler()
        {
            try
            {
                ISchedulerFactory schedFact = new StdSchedulerFactory();
                IScheduler sched = schedFact.GetScheduler();
                sched.Start();

                IJobDetail job = JobBuilder.Create<UpdateDeviceStatusJob>()
                    .WithIdentity("UpdateDeviceStatusJob", "UpdateDeviceStatusGroup1")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("UpdateDeviceStatusTrigger")
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