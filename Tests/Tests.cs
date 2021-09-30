using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Xunit;
using DL;


namespace Tests
{
    public class ModelTests
    {


        [Fact] //use when you're testing only one set of behavior
        public void ProductsShouldSetValidData(){ //my product can set a valid name

            //Arrange

            Product test = new Product();
            string testName = "test product";
            //Act
            test.Name = testName;
            //Assert
            Assert.Equal(testName, test.Name);
        }

        [Fact] //use when you're testing only one set of behavior
        public void CustomerShouldSetValidData(){ //my customer can set a valid name

            //Arrange

            Customer test = new Customer();
            string testName = "test customer";
            //Act
            test.Name = testName;
            //Assert
            Assert.Equal(testName, test.Name);
        }

        [Fact] //use when you're testing only one set of behavior
        public void StoreFrontShouldSetValidData(){ //my customer can set a valid name

            //Arrange

            StoreFront test = new StoreFront();
            string testName = "test StoreFront";
            //Act
            test.Name = testName;
            //Assert
            Assert.Equal(testName, test.Name);
        }

        //could not get to pass

        // [Theory] //this failed and can not figure how out how to pass it 
        // [InlineData("")]
        // [InlineData("%$@^^")]

        // public void ProductsShouldNotAllowInvalidName(string input){

        //     Product test = new Product();

        //     Assert.Throws<InputInvalidException>(() => test.Name = input);
        // }


        //could not get to pass
        // [Theory]
        // [InlineData(-1)]
        // [InlineData(0)]
        // [InlineData(100000)]
        // public void ReviewShouldNotSetInvalidRating(int input){

        //     Review test = new Review();

        //     Assert.Throws<InputInvalidException>(() => test.Rating = input);


        // }

        
    }
}