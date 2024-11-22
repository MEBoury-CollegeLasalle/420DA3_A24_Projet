using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.DAOs;


public class FournisseurDAO {
    private readonly WsysDbContext _context;

 
    public FournisseurDAO(WsysDbContext context) {
        _context = context;
    }

    public async Task<List<Fournisseur>> ObtenirTousAsync() {
        return await _context.Fournisseurs
            .Include(f => f.Produits)
            .ToListAsync();
    }

   
    public async Task<Fournisseur?> ObtenirParIdAsync(int id) {
        return await _context.Fournisseurs
            .Include(f => f.Produits)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Fournisseur> AjouterAsync(Fournisseur fournisseur) {
        _context.Fournisseurs.Add(fournisseur);
        await _context.SaveChangesAsync();
        return fournisseur;
    }

    public async Task MettreAJourAsync(Fournisseur fournisseur) {
        _context.Fournisseurs.Update(fournisseur);
        await _context.SaveChangesAsync();
    }

    public async Task SupprimerAsync(int id) {
        var fournisseur = await ObtenirParIdAsync(id);
        if (fournisseur != null) {
            _context.Fournisseurs.Remove(fournisseur);
            await _context.SaveChangesAsync();
        }
    }
}

