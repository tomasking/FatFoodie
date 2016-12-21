namespace FatFoodie.Infrastructure.Configuration
{
    public interface IConfigurationSettings
    {
        string RecipeConnectionString { get; set; }
    }

    public class ConfigurationSettings : IConfigurationSettings
    {
        public string RecipeConnectionString { get; set; }
    }
}
