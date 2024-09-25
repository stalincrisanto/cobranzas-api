using Newtonsoft.Json;

public class ClientService
{
    private const string DataFilePath = "Data/clientsData.json";

    public List<ClientModel> GetAllClients()
    {
        var jsonData = File.ReadAllText(DataFilePath);
        return JsonConvert.DeserializeObject<List<ClientModel>>(jsonData);
    }

    public ClientModel GetCustomerByIdCard(string idCard){
        var customers = GetAllClients();
        return customers.FirstOrDefault(c => c.Id == idCard);
    }

}