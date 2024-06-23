namespace App.API.Extension
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - dob.Year;

            // Check if the birthday hasn't occurred yet this year
            if (dob.Date > today.AddYears(-age))
                age--;

            return age;
        }




    }
}
