using DronesEntity;
using Newtonsoft.Json;
using System;
using System.Text.Json.Nodes;

namespace DroneWebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

       
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scopeeee = app.ApplicationServices.CreateScope();
            var context = scopeeee.ServiceProvider.GetRequiredService<DronesDbContext>();
            AddTestData(context);
        }

        private static void AddTestData(DronesDbContext context)
        {
            string droneArray = "[{\"SerialNumber\": \"12345\",\"Model\": \"Lightweight\",\"BatteryCapasity\": \"50\",\"WeightLimit\": \"20\",\"State\": \"IDLE\"},{\"SerialNumber\": \"t3r43\",\"Model\": \"Middleweight\",\"BatteryCapasity\": \"70\",\"WeightLimit\": \"50\",\"State\": \"LOADED\"},{\"SerialNumber\": \"435d3\",\"Model\": \"Heavyweight\",\"BatteryCapasity\": \"73\",\"WeightLimit\": \"300\",\"State\": \"LOADED\"}]";
            var droneList = JsonConvert.DeserializeObject<IList<DroneEntity>>(droneArray);

            context.Drones.AddRange(droneList);
            //context.SaveChanges();


            string medicationArray = "[{\"name\": \"Paracetamol\",\"weight\": 1,\"code\": \"med1\",\"image\": \"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAABuUlEQVR4nO2WOUtDQRSFP4MiWlhY2LggpLKxUUsbt06I/gDRTlHQPxAUbQQXcCm1sTNNCsHCBStBwaWQIGJlI0QRC0EQVwZOILy8zMSYF5scuM27555z5903Mw9K+Du+FW9A33828O2J6WI30qe3kGpgJmjDeiAG7ADNFBHlwCTwkrbaV624MmjzTuDKMvcboCcI41pgBfi0mKfiC9gC6gphXAYMAY85GHvjWaMK5WveChznYeyNM6DjN8bV+qDSt9Rf410jrHGZ9wN3BTT2xr1G6ovdAI29YbwycJ5G+ADWgRZgDrjVXr8ARjXTOPCkiOvZGHAprqmZBZqAcY0hpW+8MlAJHImQoPBISPvQdmANirQdQAPb0o7YSAMiRQNoICrtgVxIEYdYBbAIJBULemZDJJfFxUQKO8QWfL7seUdNWDzjkRXXuuVCjuPZ72h+VC4bQtI2Hr6o0vY7cayk0bK/Gxy1p/IwXhlol8iGQ6TX0oDrKt4Ur80vOaKkucFsmLA0YA4cG6bEG/ZLLivZ5RBZszSw6qjtFm/JL3mgpOtHYt/SwJ6jtk48o5GBZBEvowdHoyWUQNHwA4gIGXYK34+kAAAAAElFTkSuQmCC\"},{\"name\": \"Amoxilin\",\"weight\": 3,\"code\": \"med2\",\"image\": \"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAABuUlEQVR4nO2WOUtDQRSFP4MiWlhY2LggpLKxUUsbt06I/gDRTlHQPxAUbQQXcCm1sTNNCsHCBStBwaWQIGJlI0QRC0EQVwZOILy8zMSYF5scuM27555z5903Mw9K+Du+FW9A33828O2J6WI30qe3kGpgJmjDeiAG7ADNFBHlwCTwkrbaV624MmjzTuDKMvcboCcI41pgBfi0mKfiC9gC6gphXAYMAY85GHvjWaMK5WveChznYeyNM6DjN8bV+qDSt9Rf410jrHGZ9wN3BTT2xr1G6ovdAI29YbwycJ5G+ADWgRZgDrjVXr8ARjXTOPCkiOvZGHAprqmZBZqAcY0hpW+8MlAJHImQoPBISPvQdmANirQdQAPb0o7YSAMiRQNoICrtgVxIEYdYBbAIJBULemZDJJfFxUQKO8QWfL7seUdNWDzjkRXXuuVCjuPZ72h+VC4bQtI2Hr6o0vY7cayk0bK/Gxy1p/IwXhlol8iGQ6TX0oDrKt4Ur80vOaKkucFsmLA0YA4cG6bEG/ZLLivZ5RBZszSw6qjtFm/JL3mgpOtHYt/SwJ6jtk48o5GBZBEvowdHoyWUQNHwA4gIGXYK34+kAAAAAElFTkSuQmCC\"},{\"name\": \"Captopril\",\"weight\": 3,\"code\": \"med3\",\"image\": \"iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAACXBIWXMAAAsTAAALEwEAmpwYAAABuUlEQVR4nO2WOUtDQRSFP4MiWlhY2LggpLKxUUsbt06I/gDRTlHQPxAUbQQXcCm1sTNNCsHCBStBwaWQIGJlI0QRC0EQVwZOILy8zMSYF5scuM27555z5903Mw9K+Du+FW9A33828O2J6WI30qe3kGpgJmjDeiAG7ADNFBHlwCTwkrbaV624MmjzTuDKMvcboCcI41pgBfi0mKfiC9gC6gphXAYMAY85GHvjWaMK5WveChznYeyNM6DjN8bV+qDSt9Rf410jrHGZ9wN3BTT2xr1G6ovdAI29YbwycJ5G+ADWgRZgDrjVXr8ARjXTOPCkiOvZGHAprqmZBZqAcY0hpW+8MlAJHImQoPBISPvQdmANirQdQAPb0o7YSAMiRQNoICrtgVxIEYdYBbAIJBULemZDJJfFxUQKO8QWfL7seUdNWDzjkRXXuuVCjuPZ72h+VC4bQtI2Hr6o0vY7cayk0bK/Gxy1p/IwXhlol8iGQ6TX0oDrKt4Ur80vOaKkucFsmLA0YA4cG6bEG/ZLLivZ5RBZszSw6qjtFm/JL3mgpOtHYt/SwJ6jtk48o5GBZBEvowdHoyWUQNHwA4gIGXYK34+kAAAAAElFTkSuQmCC\"}]";
            var mediList = JsonConvert.DeserializeObject<IList<MedicationEntity>>(medicationArray);

            context.Medications.AddRange(mediList);
            //context.SaveChanges();


            string dispatchArray = "[{\"droneId\": 1,\"medicationId\": 1,\"noOfMedications\": 2\r\n    },{\"droneId\": 1,\"medicationId\": 2,\"noOfMedications\": 3}]";
            var dispatchList = JsonConvert.DeserializeObject<IList<DroneMedicationEntity>>(dispatchArray);

            context.DroneMedications.AddRange(dispatchList);
            context.SaveChanges();
        }
    }
}
