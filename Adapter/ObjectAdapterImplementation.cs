using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; private set; }
        public string NickName { get; private set; }
        public int Inhabitants { get; private set; }

        public CityFromExternalSystem(string  name, string nickName, int inhabitants)
        {
            Name = name;
            NickName = nickName;
            Inhabitants = inhabitants;
        }
    }

    /// <summary>
    /// Adaptee
    /// </summary>
    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity()
        {
            return new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
               
        }
    }

    public class City 
    {
        public string FullName { get; set; }
        public long Inhabitants { get; set; }

        public City(string fullName, long inhabitants)
        {
            FullName = fullName;
            Inhabitants = inhabitants;
        }
    }

    /// <summary>
    /// Target
    /// </summary>
    public interface ICityAdapter
    {
        City GetCity();
    }

    /// <summary>
    /// Adapter
    /// </summary>
    public class CityAdapter : ICityAdapter
    {
        public ExternalSystem ExternalSystem { get; private set; } = new();
        public City GetCity()
        {
            var cityFromExternalSystem = ExternalSystem.GetCity();

            return new City(
                $"{cityFromExternalSystem.Name}-{cityFromExternalSystem.NickName}",
                cityFromExternalSystem.Inhabitants
            );
        }
    }
}
