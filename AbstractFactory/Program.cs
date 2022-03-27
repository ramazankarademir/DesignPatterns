using AbstractFactory;

Console.Title = "Abstract Factory";

var belguimShoppingCartPurchaseFactory = new BelguimShoppingCartPurchaseFactory();
var shoppingCartForBelgium = new ShoppingCart(belguimShoppingCartPurchaseFactory);
shoppingCartForBelgium.CalculateCosts();


var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);
shoppingCartForFrance.CalculateCosts();