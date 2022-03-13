using System;
using System.Threading;
using LiftManagementSystem.Controllers;
using LiftManagementSystem.Models;
namespace LiftManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int noOfFloor = 10;
            int noOfLift = 2;
            Building building = new Building(noOfFloor,noOfLift);
            BuildingLiftController buildingLiftController = new BuildingLiftController(building);
            int[,] initialRequest = new int[,] { {0, 7} , {3, 0} };
            for (int i = 0; i < initialRequest.GetLength(0); i++)
            {
                LiftRequest liftRequest = new LiftRequest(initialRequest[i,0], initialRequest[i,1]);
                buildingLiftController.scheduleRequest(liftRequest);
            }
            while (!buildingLiftController.executionDone)
            {
                buildingLiftController.progress();
                Thread.Sleep(1000);
            }
        }
    }
}
