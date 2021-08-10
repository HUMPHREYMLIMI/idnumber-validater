using System;

namespace idnumber_validater
{
    class Program
    {
        static void Main(string[] args)
        {
            string idNumber;
            int numericValue;
            bool correct = true;

            Console.WriteLine("please enter the id number ");
            idNumber = Console.ReadLine();
            if (idNumber.Length != 13 || !int.TryParse(idNumber, out numericValue) == false)
            {
                Console.WriteLine("ID number does not appear to be authentic - input not a valid number ");
                correct = false;
            }
            else {
                int num1 = Convert.ToInt32(idNumber.Substring(0, 2));
                int num2 = Convert.ToInt32(idNumber.Substring(2, 4));
                int num3 = Convert.ToInt32(idNumber.Substring(4, 6));

                var tempDate = new DateTime(num1, num2 - 1, num3);

                var id_date = tempDate.Day;
                var id_month = tempDate.Month;
                var id_year = tempDate.Year;

                var fullDate = id_date + "-" + (id_month + 1) + "-" + id_year;

                if (!(id_month == Convert.ToInt32(idNumber.Substring(0, 2))) && (id_month == Convert.ToInt32(idNumber.Substring(2, 4)) - 1) && (id_date == Convert.ToInt32(idNumber.Substring(4, 6))))
                {
                    Console.WriteLine("ID number does not appear to be authentic - date part not valid");
                    correct = false;
                }
                else { 
                // get the gender
                var genderCode = idNumber.Substring(6, 10);
                var gender = Convert.ToInt32(genderCode) < 5000 ? "Female" : "Male";

                // get country ID for citzenship
                var citzenship = Convert.ToInt32(idNumber.Substring(10, 11)) == 0 ? "Yes" : "No";

                    Console.WriteLine("correct Identification your fulldate is " + fullDate + "your gender is " + gender);

               }
        }   }
    }
}

