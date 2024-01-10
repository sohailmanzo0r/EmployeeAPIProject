using EmployeeAPIProject.Models;

namespace FirstUnitTest
{
    [TestClass]
    public class calculateAgeUnitTest
    {
        [TestMethod]

        public void CalculateAge_GivenValidDateOfBirth_ReturnsCorrectAge()
        {
            // Arrange
            var employeeDto = new EmployeeDTO();
            var testDate = new DateTime(2000, 1, 1);
            var expectedAge = "Year 24, Months 0, Days 9"; // Adjust the expected string based on the current date

            // Act
            var result = employeeDto.calculateAge(testDate);

            // Assert
            Assert.AreEqual(expectedAge, result);
        }




    }
}