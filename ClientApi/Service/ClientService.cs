using AutoMapper;
using ClientApi.DTO;
using ClientApi.Models;
using ClientApi.Repository;

namespace ClientApi.Service;

public class ClientService : IClientService
{
    private IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IMapper mapper, IClientRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }
    public async Task<IEnumerable<ClientDTO>> GetClients()
    {
        var clientEntity = await _clientRepository.GetAll();
        return _mapper.Map<IEnumerable<ClientDTO>>(clientEntity);
    }

    public async Task<ClientDTO> GetClientById(int id)
    {
        var clientEntity = await _clientRepository.GetClientById(id);
        return _mapper.Map<ClientDTO>(clientEntity);
    }

    public async Task AddClient(ClientDTO clientDto)
    {
        var clientEntity = _mapper.Map<Client>(clientDto);
        await _clientRepository.AddClient(clientEntity);
        clientDto.Id = clientEntity.Id;
    }

    public async Task UpdateClient(ClientDTO clientDto)
    {
        var clientEntity = _mapper.Map<Client>(clientDto);
        await _clientRepository.UpdateClient(clientEntity);

    }

    public async Task DeleteClient(int id)
    {
        var clientEntity = await _clientRepository.GetClientById(id);
        await _clientRepository.DeleteClient(clientEntity.Id);
    }

}
