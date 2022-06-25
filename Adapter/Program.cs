using Adapter;

Console.Title = "Adapter"; 

ICityAdapter adapter = new CityAdapter();

var city = adapter.GetCity();

Console.WriteLine($"{city.FullName}, {city.Inhabitants}");


ClassAdapter.ICityAdapter classAdapter = new ClassAdapter.CityAdapter();

var city2 = classAdapter.GetCity();

Console.WriteLine($"{city2.FullName}, {city2.Inhabitants}");