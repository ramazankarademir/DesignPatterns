namespace AbstractFactory
{

    /// <summary>
    /// AbstractFactory
    /// </summary>
    public interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostService();
    }

    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IDiscountService    
    {
        int DiscountPercentage { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumDiscountService : IDiscountService
    {
        public int DiscountPercentage => 20;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }


    /// <summary>
    /// AbstractProduct
    /// </summary>
    public interface IShippingCostService
    {
        decimal ShippingCosts { get; }
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class BelgiumShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 20;
    }

    /// <summary>
    /// ConcreteProduct
    /// </summary>
    public class FranceShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 25;
    }

    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class BelguimShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new BelgiumShippingCostService();
        }
    }

    /// <summary>
    /// ConcreteFactory
    /// </summary>
    public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostService()
        {
            return new FranceShippingCostService();
        }
    }

    /// <summary>
    /// Client class
    /// </summary>
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostsService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService  = factory.CreateDiscountService();
            _shippingCostsService = factory.CreateShippingCostService();
            // assume that the total cost of all the items we ordered = 200 euro.
            _orderCosts = 200;
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total costs = " +
                $"{_orderCosts - (_orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostsService.ShippingCosts}");
        }
    }
}
