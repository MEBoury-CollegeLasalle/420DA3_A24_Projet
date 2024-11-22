using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.Business.Domain;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.DAOs;

/// <summary>
/// DAO pour la gestion des données de l'entité Adresse.
/// </summary>
public class AdresseDAO {

    private readonly WsysDbContext _context;

    /// <summary>
    /// Constructeur pour initialiser le contexte de la base de données.
    /// </summary>
    /// <param name="context">Contexte de la base de données.</param>
    public AdresseDAO(WsysDbContext context) {
        _context = context;
    }

    /// <summary>
    /// Récupère toutes les adresses dans la base de données.
    /// </summary>
    /// <returns>Liste d'adresses.</returns>
    public async Task<List<Adresse>> ObtenirToutesLesAdressesAsync() {
        return await _context.Adresses.ToListAsync();
    }

    /// <summary>
    /// Récupère une adresse par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant de l'adresse.</param>
    /// <returns>Adresse correspondante ou null si non trouvée.</returns>
    public async Task<Adresse?> ObtenirAdresseParIdAsync(int id) {
        return await _context.Adresses.FindAsync(id);
    }

    /// <summary>
    /// Ajoute une nouvelle adresse dans la base de données.
    /// </summary>
    /// <param name="adresse">Adresse à ajouter.</param>
    /// <returns>L'adresse ajoutée.</returns>
    public async Task<Adresse> AjouterAdresseAsync(Adresse adresse) {
        _context.Adresses.Add(adresse);
        await _context.SaveChangesAsync();
        return adresse;
    }

    /// <summary>
    /// Met à jour une adresse existante.
    /// </summary>
    /// <param name="adresse">Adresse à mettre à jour.</param>
    public async Task MettreAJourAdresseAsync(Adresse adresse) {
        _context.Adresses.Update(adresse);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Supprime une adresse par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant de l'adresse à supprimer.</param>
    public async Task SupprimerAdresseAsync(int id) {
        var adresse = await ObtenirAdresseParIdAsync(id);
        if (adresse != null) {
            _context.Adresses.Remove(adresse);
            await _context.SaveChangesAsync();
        }
    }
}
