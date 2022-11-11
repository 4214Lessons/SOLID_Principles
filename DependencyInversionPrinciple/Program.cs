#region DIP_Before


//class MySQLDatabase
//{
//    public void Insert()
//    {
//        // do smth...
//    }

//    public void Update()
//    {
//        // do smth...
//    }
//    public void Delete()
//    {
//        // do smth...
//    }
//}




//class BudgetReport
//{
//    public MySQLDatabase database { get; set; }

//    public void Open(DateOnly date)
//    {
//        // do smth...
//    }
//    public void Save()
//    {
//        // do smth...
//    }
//}



#endregion





#region DIP_After



interface IDatabase
{
    void Insert();
    void Update();
    void Delete();
}



class MySQL : IDatabase
{
    public void Insert()
    {
        // do smth...
    }

    public void Update()
    {
        // do smth...
    }

    public void Delete()
    {
        // do smth...
    }
}

class MongoDB : IDatabase
{
    public void Insert()
    {
        // do smth...
    }

    public void Update()
    {
        // do smth...
    }

    public void Delete()
    {
        // do smth...
    }
}




class BudgetReport
{
    private IDatabase database;

    public void Open(DateOnly date)
    {
        // do smth...
    }

    public void Save()
    {
        // do smth...
    }
}



#endregion