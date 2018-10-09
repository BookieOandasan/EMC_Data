using ResidencyApplication.Repository.ResidencyApplication;
using System;
using System.Linq;
using Xunit;

namespace ResidencyApplication.Repository.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            var context = new ResidencyApplicationContext();

            //Act
            var data = context.Applicants.ToList();


            //assert
            Assert.True(data.Any());

        }
    }
}
