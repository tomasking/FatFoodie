namespace FatFoodie.Contracts
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class HealthCheck
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string Error { get; set; }
    }
}
