using System;
using System.Collections.Generic;

namespace LiftManagementSystem.Models
{
    public interface IScheduler
    {
        public void scheduleRequest(LiftRequest liftRequest, List<Lift> liftList);
    }
}
