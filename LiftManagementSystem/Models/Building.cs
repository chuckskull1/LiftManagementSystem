using System;
using System.Collections.Generic;

namespace LiftManagementSystem.Models
{
    public class Building
    {
        private int maxFloor, noOfLift;
        private List<Lift> Lifts;

        public Building(int maxFloor, int noOfLift)
        {
            this.maxFloor = maxFloor;
            this.noOfLift = noOfLift;
            this.Lifts = new List<Lift>();
            this.LiftInitializer();
        }

        public void LiftInitializer()
        {
            for(int i=0; i<noOfLift; i++)
            {
                Lifts.Add(new Lift(i+1,0,maxFloor));
            }
        }

        public List<Lift> getLifts()
        {
            return Lifts;
        }
    }
}
