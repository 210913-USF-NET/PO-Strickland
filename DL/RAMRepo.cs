using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{ 
    // Implement IRepo using singleton design pattern
    // SDP is used if you want one instance of something regardless of where it is 
    //need non access modifer of sealed to make this work
    //sealed means class is no longer inheiritable
    public class RAMRepo : IRepo
    {
        // public RAMRepo(){

        // }

        public List<StoreFront> GetAllStoreFronts()
        {
            //Put your logic to get data here
            return new List<StoreFront>(){
                new StoreFront(){
                    Name = "Lucky Disks",
                    Address = "2400 Elder Rd, Charlotte, NC"
                }
            };
        }


        private static RAMRepo _instance; //only I can access this instance. NO ONE ELSE CAN. We have an instance
        private RAMRepo(){ //I hid my constructor. Way to instaniate an object

            _movies = new List<Movies>(){

                new Movies(){ //seeded one instance 

                    Title = "Lord of the Rings Box Set",
                    Quantity = "35",
                    Price = 49.99M
                }
            };

        }

        public static RAMRepo GetInstance(){ // a constructor to return the instance 

            if(_instance == null) //if there is nothing, then we will instantiate for it
            {
                _instance = new RAMRepo();
            }
            return _instance; //if not, then return what is there already
        }

        private static List<Movies> _movies; //where I will store all my movies

        public Movies AddMovie(Movies newMovie){ //we have a way to add a Movie

            _movies.Add(newMovie); //.ADD method comes from system.linq
            return newMovie;

        }
    

        public List<Movies> GetAllMovies(){ //we have a way to get all the movies

            return _movies;
            
        }
        
    }
}