namespace EmployeeAPIProject.Services
{
    public class UtilityService : IUtilityService
    {
        public string calculateAge(string dob)
        {
            DateTime dateOfBirth;

            bool check = DateTime.TryParse(dob, out dateOfBirth);
            if (check == false)
            {
                return "invalid date of birth";
            }
            DateTime currentDate = DateTime.Now;

            TimeSpan difference = currentDate.Subtract(dateOfBirth);

            // This is to convert the timespan to datetime object
            DateTime age = DateTime.MinValue + difference;

            // Min value is 01/01/0001
            // Actual age is say 24 yrs, 9 months and 3 days represented as timespan
            // Min Valye + actual age = 25 yrs , 10 months and 4 days.
            // subtract our addition or 1 on all components to get the actual date.

            int ageInYears = age.Year - 1;
            int ageInMonths = age.Month - 1;
            int ageInDays = age.Day - 1;

            return " Year " + ageInYears + ",Months " + ageInMonths + " ,Days " + ageInDays;
        }

    }
}
