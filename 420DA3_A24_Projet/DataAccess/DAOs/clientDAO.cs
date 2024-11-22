
using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.DAOs;


public class ClientDAO {
    private readonly WsysDbContext _context;

    public ClientDAO(WsysDbContext context) {
        _context = context;
    }

    
    public async Task<List<Client>> ObtenirTousAsync() {
        return await _context.Clients
            .Include(c => c.Entrepot)
            .Include(c => c.Produits)
            .ToListAsync();
    }

    
    public async Task<Client?> ObtenirParIdAsync(int id) {
        return await _context.Clients
            .Include(c => c.Entrepot)
            .Include(c => c.Produits)
            .FirstOrDefaultAsync(c => c.Id == id);
    }


    public async Task<Client> AjouterAsync(Client client) {
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

   
    /// <param name="client">Le client à mettre à jour.</param>
    public async Task MettreAJourAsync(Client client) {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task SupprimerAsync(int id) {
        var client = await ObtenirParIdAsync(id);
        if (client != null) {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}

