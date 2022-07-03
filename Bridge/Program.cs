using Bridge;

Console.Title = "Bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuorCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");


meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euro.");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian based menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");


vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian based menu, no coupon: {vegetarianMenu.CalculatePrice()} euro.");

Console.ReadKey();