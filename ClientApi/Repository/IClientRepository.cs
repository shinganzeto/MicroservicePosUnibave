using ClientApi.Models;

namespace ClientApi.Repository;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAll();

    Task<Client> GetClientById(int id);

    Task<Client> AddClient(Client client);

    Task<Client> UpdateClient(Client client);  
    
    Task<Client> DeleteClient(int id);

}
