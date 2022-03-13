using System;
namespace LiftManagementSystem.Models
{
    public class LiftRequest
    {
        private int sourceFloor;
        private int destinationFloor;
        private int liftId;
        private int time;
        private bool pickupDone;
        private bool dropDone;

        public LiftRequest(int sourceFloor, int destinationFloor)
        {
            this.sourceFloor = sourceFloor;
            this.destinationFloor = destinationFloor;
            this.pickupDone = this.dropDone = false;
        }

        public int getSourceFloor()
        {
            return sourceFloor;
        }

        public int getDestinationFloor()
        {
            return destinationFloor;
        }

        public int getLiftId()
        {
            return liftId;
        }

        public int getTime()
        {
            return time;
        }

        public bool IsPickupDone()
        {
            return pickupDone;
        }

        public bool IsDropDone()
        {
            return dropDone;
        }

        public void setSourceFloor(int sourceFloor)
        {
            this.sourceFloor = sourceFloor;
        }

        public void setDestinationFloor(int destinationFloor)
        {
            this.destinationFloor = destinationFloor;
        }

        public void setLiftId(int liftId)
        {
            this.liftId = liftId;
        }

        public void setTime(int time)
        {
            this.time = time;
        }

        public void setPickupDone(bool pickupDone)
        {
            this.pickupDone = pickupDone;
        }

        public void setDropDone(bool dropDone)
        {
            this.dropDone = dropDone;
        }
    }
}
