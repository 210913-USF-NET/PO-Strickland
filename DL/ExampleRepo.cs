using System;
using System.Collections.Generic;
using Models;
using System.Text.Json;
using System.Linq;
using System.IO;

namespace DL
{
    public class ExampleRepo : IRepo
    {
        private const string MoviesFilePath = "../DL/Movies.json";
        private string jsonString;
        
        // public List<StoreFront> GetAllStoreFronts()
        // {
        //     //Put your logic to get data here
        //     return new List<StoreFront>(){
        //         new StoreFront(){
        //             Name = "Store One"
        //         }
        //     };
        // }

        public List<Movies> GetAllMovies(){
            jsonString = File.ReadAllText(MoviesFilePath);

            return JsonSerializer.Deserialize<List<Movies>>(jsonString);
        }
        /// <summary>
        /// This method updates Movies 
        /// </summary>
        /// <param name="MoviesToUpdate"></param>
        /// <returns></returns>
        public Movies UpdateMovies(Movies MoviesToUpdate) //just updated. delete if needed
        {
            //first, find the restaurant to update
            //by first, getting all restaurants, using getAllRestaurants method
            //and then use FindIndex method with the lambda expression
            //to get me the location of the restaurant in the list
            //if there is a match
            List<Movies> allMovies = GetAllMovies();
            int MovieIndex = allMovies.FindIndex(r => r.Equals(MoviesToUpdate));

            //update the restaurant in the list itself
            allMovies[MovieIndex] = MoviesToUpdate;

            //serialize 
            jsonString = JsonSerializer.Serialize(allMovies);

            //write to a file
            System.IO.File.WriteAllText(MoviesFilePath, jsonString);
            
            return MoviesToUpdate;
        }

    }
}
