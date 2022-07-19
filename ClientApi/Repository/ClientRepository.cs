using ClientApi.Context;
using ClientApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Repository;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client> GetClientById(int id)
    {
        return await _context.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Client> AddClient(Client client)
    {
        _context.Clients.Add(client); 
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client> UpdateClient(Client client)
    {
        _context.Entry(client).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return client;
    }
    public async Task<Client> DeleteClient(int id)
    {
        var client = await GetClientById(id);
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return client;
    }

}

