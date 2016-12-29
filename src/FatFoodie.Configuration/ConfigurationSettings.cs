using System.Configuration;

namespace FatFoodie.Configuration
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        public string RecipeConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Recipe"].ConnectionString;
            }
        }
    }
}