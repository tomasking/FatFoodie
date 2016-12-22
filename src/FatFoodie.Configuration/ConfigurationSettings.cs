using Microsoft.Extensions.Configuration;

namespace FatFoodie.Configuration
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        private readonly IConfigurationRoot configurationRoot;

        public ConfigurationSettings(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public string RecipeConnectionString
        {
            get
            {
                return configurationRoot.GetConnectionString("Recipe");
            }
        }
    }
}