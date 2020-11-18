using NLayerProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.EntityFramework.Seed.SeedHelpers
{
    public static class CountrySeedHelper
    {
        public static List<Country> GetListCountrySeed()
        {
            try
            {
                List<Country> List = new List<Country>();
                List.Add(
                    new Country
                    {
                        Id = 1,
                        Iso = "AF",
                        Name = "Afghanistan",
                        Iso3 = "AFG",
                        NumCode = 4,
                        PhoneCode = 93
                    }
                    );
                return List;
            }
            catch
            {
                throw new Exception();
            }
            
        }
    }
}
