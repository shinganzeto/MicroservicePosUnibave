using ClientApi.DTO;

namespace ClientApi.Service;

public interface IClientService
{
    Task<IEnumerable<ClientDTO>> GetClients();

    Task<ClientDTO> GetClientById(int id);

    Task AddClient(ClientDTO clientDto);

    Task UpdateClient(ClientDTO clientDto);

    Task DeleteClient(int id);

}
