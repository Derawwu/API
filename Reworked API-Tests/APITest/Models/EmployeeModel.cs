using System;
using System.Collections.Generic;

namespace APITest.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }
        public string Employee_name { get; set; }
        public string Employee_salary { get; set; }
        public string Employee_age { get; set; }
        public string Profile_image { get; set; }
        public Dictionary<string, string> DataTemplate { get; set; } = new Dictionary<string, string>()
        {
            ["id"] = "",
            ["employee_name"] = "",
            ["employee_salary"] = "",
            ["employee_age"] = "",
            ["profile_image"] = ""
        };

        public static explicit operator Dictionary<string, string>(EmployeeModel v)
        {
            return v.DataTemplate;
        }
    }
}
