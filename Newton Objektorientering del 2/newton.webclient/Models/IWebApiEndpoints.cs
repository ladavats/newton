namespace newton.webclient.Models
{
    public interface IWebApiEndpoints
    {
        string GetCustomers { get; }
        string CreateCustomer { get; }
    }
}