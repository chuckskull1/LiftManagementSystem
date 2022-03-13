using System;
using System.Collections.Generic;

namespace LiftManagementSystem.Models
{
    public class Lift
    {
        private int liftId;
        private bool liftOpened;
        private int maxFloor, currentFloor;
        private List<LiftRequest> liftRequests;
        private LiftDirection liftDirection;
        private int lastFloorServed;
        private int unitTime;

        public Lift(int liftId, int currentFloor, int maxFloor, bool liftOpened = false)
        {
            this.liftId = liftId;
            this.currentFloor = currentFloor;
            this.maxFloor = maxFloor;
            this.liftRequests = new List<LiftRequest>();
            this.liftOpened = liftOpened;
            this.lastFloorServed = -1;
        }

        public int getLiftId()
        {
            return liftId;
        }

        public List<LiftRequest> getLiftRequests()
        {
            return liftRequests;
        }

        public bool IsLiftOpen()
        {
            return liftOpened;
        }

        public int getCurrentFloor()
        {
            return currentFloor;
        }

        public int getlastFloorServed()
        {
            return lastFloorServed;
        }

        public int getUnitTime()
        {
            return unitTime;
        }

        public void setUnitTime(int unitTime)
        {
            this.unitTime = unitTime;
        }

        public void setLiftOpened(bool liftOpened)
        {
            this.liftOpened = liftOpened;
        }

        public void moveUp()
        {
            currentFloor++;
        }

        public void moveDown()
        {
            currentFloor--;
        }

        public void setRequest(LiftRequest liftRequest)
        {
            if (liftRequests.Count == 0)
            {
                if (liftRequest.getSourceFloor() > currentFloor)
                    liftDirection = LiftDirection.UP;
                else if (liftRequest.getSourceFloor() < currentFloor)
                    liftDirection = LiftDirection.DOWN;
                else if (liftRequest.getDestinationFloor() > currentFloor)
                    liftDirection = LiftDirection.UP;
                else if (liftRequest.getDestinationFloor() < currentFloor)
                    liftDirection = LiftDirection.DOWN;
            }
            liftRequests.Add(new LiftRequest(liftRequest.getSourceFloor(), liftRequest.getDestinationFloor()));
        }

        public void setDirection()
        {
            if (liftDirection == LiftDirection.UP)
            {
                foreach(var liftRequest in liftRequests)
                {
                    if (liftRequest.getDestinationFloor() > currentFloor)
                        return;
                }
                liftDirection = LiftDirection.DOWN;
            }
            else if (liftDirection == LiftDirection.DOWN)
            {
                foreach (var liftRequest in liftRequests)
                {
                    if (liftRequest.getDestinationFloor() < currentFloor)
                        return;
                }
                liftDirection = LiftDirection.UP;
            }
        }

        public void move()
        {
            if (liftRequests.Count == 0)
            {
                liftOpened = false;
                return;
            }
            unitTime++;

            if (liftOpened == true)
            {
                liftOpened = false; ;
                return;
            }

            //Check for source
            foreach (var liftRequest in liftRequests)
            {
                if (currentFloor == liftRequest.getSourceFloor() && liftRequest.IsDropDone() == false && lastFloorServed != currentFloor)
                {
                    liftOpened = true;
                    liftRequest.setDropDone(true);
                    lastFloorServed = currentFloor;
                    setDirection();
                    return;
                }

            }

            //Check for destination 
            foreach (var liftRequest in liftRequests)
            {
                if (currentFloor == liftRequest.getDestinationFloor() && liftRequest.IsDropDone() == true && lastFloorServed != currentFloor)
                {
                    liftRequests.Remove(liftRequest);
                    liftOpened = true;
                    lastFloorServed = currentFloor;
                    setDirection();
                    return;
                }

            }

            if (liftDirection == LiftDirection.UP)
                moveUp();
            else
                moveDown();

        }
    }
}
