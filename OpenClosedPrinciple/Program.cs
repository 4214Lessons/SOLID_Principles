#region OCP_Before

//class Product
//{
//    public Guid Id { get; set; }
//    public string Name { get; set; }
//    public decimal Price { get; set; }
//    public decimal Weight { get; set; }
//}


//class Order
//{
//    private List<Product> items = new();
//    private string shipping = default;

//    public decimal GetTotal() => items.Sum(p => p.Price);
//    public decimal GetTotalWeight() => items.Sum(p => p.Weight);
//    public void SetShippingType(string type) => shipping = type;


//    public decimal GetShippingCost()
//    {
//        if (shipping == "ground")
//        {
//            // Free ground delivery on big orders
//            if (GetTotal() > 100)
//                return 0;

//            // $1.5 per kilogram, but $10 minumum
//            return Math.Max(10, GetTotalWeight() * 1.5M);
//        }

//        if (shipping == "air")
//        {
//            // $3 per kilogram, but $20 minumum
//            return Math.Max(20, GetTotalWeight() * 3);
//        }

//        throw new ArgumentException(nameof(shipping));
//    }


//    public DateTime GetShippingDate()
//    {
//        if(shipping == "ground")
//        {
//            return DateTime.Now.AddDays(7);
//        }

//        if (shipping == "air")
//        {
//            return DateTime.Now.AddDays(7);
//        }

//        throw new ArgumentException(nameof(shipping));
//    }
//}




#endregion




#region OCP_After


class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}


interface IShipping
{
    decimal GetCost(Order order);
    DateTime GetDate(Order order);
}


class Ground : IShipping
{
    public decimal GetCost(Order order)
    {
        // Free ground delivery on big orders
        if (order.GetTotal() > 100)
            return 0;

        // $1.5 per kilogram, but $10 minumum
        return Math.Max(10, order.GetTotalWeight() * 1.5M);
    }

    public DateTime GetDate(Order order) => DateTime.Now.AddDays(7);
}



class Air : IShipping
{
    public decimal GetCost(Order order)
    {
        // $3 per kilogram, but $20 minumum
        return Math.Max(20, order.GetTotalWeight() * 3);
    }

    public DateTime GetDate(Order order) => DateTime.Now.AddDays(2);
}







class Order
{
    private List<Product> items = new();
    private IShipping shipping;

    public decimal GetTotal() => items.Sum(p => p.Price);
    public decimal GetTotalWeight() => items.Sum(p => p.Weight);
    public void SetShippingType(IShipping type) => shipping = type;

    public decimal GetShippingCost() => shipping.GetCost(this);
    public DateTime GetShippingDate() => shipping.GetDate(this);
}



class Program
{
    static void Main()
    {
        Order order = new();
        order.SetShippingType(new Air());
        Console.WriteLine(order.GetShippingDate());
    }
}

#endregion