using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheWorld92.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task EnsureSeedDataAsync()
        {
            if(await _userManager.FindByEmailAsync("mtayyab@theworld.com") == null)
            {
                //Add the user.
                var newUser = new WorldUser()
                {
                    UserName = "mtayyab",
                    Email = "mtayyab@theworld.com"
                };

              await  _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }


            if (!_context.Trips.Any())
            {
                // Add new Data
                var pkTrip = new Trip()
                {
                    Name = "PK Trip",
                    Created = DateTime.UtcNow,
                    UserName = "mtayyab",
                    Stops = new List<Stop>()
                    {
                         new Stop() { Name= "Lahore, Pakistan", Arrival= new DateTime(2016,8,1), Latitude=31.582045, Longitude=74.329376, Order=0},
                        new Stop()  { Name= "Gujranwala, Pakistan", Arrival= new DateTime(2016,8,2), Latitude=32.154377, Longitude=74.184227, Order=1},
                        new Stop()  { Name= "Gujrat, Punjab, Pakistan", Arrival= new DateTime(2016,8,5), Latitude=32.571144, Longitude=74.075005, Order=2},
                        new Stop()  { Name= "Jhelum, Punjab, Pakistan", Arrival= new DateTime(2016,8,8), Latitude=32.940548, Longitude=73.727631, Order=3},
                        new Stop()  { Name= "New,Mirepur Azad Kashmir", Arrival= new DateTime(2016,8,12), Latitude=33.14176, Longitude=73.76736, Order=4},
                        new Stop()  { Name= "Islamabad, Pakistan", Arrival= new DateTime(2016,8,15), Latitude=33.738045, Longitude=73.084488, Order=5},
                        new Stop()  { Name= "Muzaffarabad, Pakistan", Arrival= new DateTime(2016,8,18), Latitude=34.359688, Longitude=73.471054, Order=6}


                    }
                };
                _context.Trips.Add(pkTrip);
                _context.Stops.AddRange(pkTrip.Stops);

                var worldTrip = new Trip()
                {
                    Name = "World Trip",
                    Created = DateTime.UtcNow,
                    UserName = "mtayyab",
                    Stops = new List<Stop>()
                    {
                        new Stop()  { Name= "Pakistan", Arrival= new DateTime(2016,09,1), Latitude=30.3753, Longitude=69.3451, Order=0},
                        new Stop()  { Name= "Afghanistan", Arrival= new DateTime(2016,10,1), Latitude=34.51666667, Longitude=69.183333, Order=1},   
                        new Stop()  { Name= "Aland Islands", Arrival= new DateTime(2016,11,1), Latitude=60.116667, Longitude=19.9, Order=2}




                    }

                };

                _context.Trips.Add(worldTrip);
                _context.Stops.AddRange(worldTrip.Stops);

                _context.SaveChanges();
            }

        }
    }
}
