using System;
using System.Collections.Generic;
using LiftManagementSystem.Models;
namespace LiftManagementSystem.Controllers
{
    public class BuildingLiftController
    {
        private Building building;
        List<LiftRequest> unassignedRequest;
        List<Lift> buildingLifts;
        private static int timeCounter = 0;
        private bool flag = true;
        Scheduler scheduler;
        public bool executionDone = false;

        public BuildingLiftController(Building building)
        {
            this.building = building;
            unassignedRequest = new List<LiftRequest>();
            scheduler = new Scheduler();
            buildingLifts = building.getLifts();
        }

        public void addRequest(LiftRequest liftRequest)
        {
            unassignedRequest.Add(liftRequest);
        }

        public void scheduleRequest(LiftRequest liftRequest)
        {
            scheduler.scheduleRequest(liftRequest, buildingLifts);
        }

        public void printOutput()
        {
            Console.WriteLine("Time " + timeCounter);
            String str = "";
            foreach (Lift lift in buildingLifts)
            {
                string liftState = lift.IsLiftOpen() ? "OPEN" : "CLOSE";
                str = str + "Lift " + lift.getLiftId() + "-> " + lift.getCurrentFloor() + " (" + liftState + "), ";
            }
            str = str.Substring(0, str.Length - 2);
            Console.WriteLine(str);
        }

        public void progress()
        {

            if (flag == true)
            {
                printOutput();
            }
            else
            {
                foreach (Lift lift in buildingLifts)
                {
                    Console.WriteLine("Lift " + lift.getLiftId() + " " + lift.getUnitTime() + "SECONDS");

                }
                executionDone = true;
            }

            flag = false;
            foreach (Lift lift in buildingLifts)
            {
                if (lift.getLiftRequests().Count > 0 || lift.IsLiftOpen())
                {
                    lift.move();
                    flag = true;
                }
            }
            timeCounter++;

        }
    }
}
