using System;
using System.Collections.Generic;

namespace LiftManagementSystem.Models
{
    public class Scheduler:IScheduler
    {
        //Schedules request in round robin manner
        public void scheduleRequest(LiftRequest liftRequest, List<Lift> liftList)
        {
            Lift minLoadLift = liftList[0];
            foreach (Lift lift in liftList)
            {
                if (minLoadLift.getLiftRequests().Count > lift.getLiftRequests().Count)
                {
                    minLoadLift = lift;
                }
            }
            minLoadLift.setRequest(liftRequest);
        }
    }
}
