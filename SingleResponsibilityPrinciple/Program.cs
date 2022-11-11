#region SRP_Before

// class Employee
// {
//     public string Name { get; set; }
//     public string Surname { get; set; }
//     public DateOnly DateOfBirth { get; set; }


//     public void PrintTimeSheetReport()
//     {
//         // do something...
//     }
// }

#endregion




#region SRP_After


class TimeSheetReport
{
    public void Print(Employee employee)
    {
        // do something...
    }
}

class Employee
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly DateOfBirth { get; set; }
}

#endregion