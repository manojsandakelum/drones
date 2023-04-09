# Drones
Using this Apis can save Drones,Medications and add medications to Drone.
To save Drone use this sample payload.
{
    "serialNumber": "123456",
    "model": "Lightweight",
    "batteryCapasity": "50",
    "weightLimit": "20",
    "state": "IDLE"
}
A Drone has following limitasions:
serial number (100 characters max);
model (Lightweight, Middleweight, Cruiserweight, Heavyweight);
weight limit (500gr max);
battery capacity (percentage);
state (IDLE, LOADING, LOADED, DELIVERING, DELIVERED, RETURNING).

Medication can add as followng input
{
    "name":"Paracetamol",
    "weight": 1,
    "code": "med1",
    "image":"base64String"
}


Can load a drone with medications using following post request

type=> POST
api => api/Dispatch
body => 
        {
          "droneId": 1,
          "medicationId": 1,
          "noOfMedications": 1
        }

Can check loaded medications for given drone
type=> GET
api => api/Dispatch/{DroneId}


To check available drones for loading;
type=> GET
api => api/Drone/GetAllAvailablesForLoading


Check drone battery level for a given drone
type=> GET
api => api/Drone/getBatteryLevelByDroneId/{droneId}

