using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.Business.Domain;
using Microsoft.EntityFrameworkCore;

namespace _420DA3_A24_Projet.DataAccess.DAOs;

/// <summary>
/// DAO pour la gestion des données de l'entité Expedition.
/// </summary>
public class ExpeditionDAO {

    private readonly WsysDbContext _context;

    /// <summary>
    /// Constructeur pour initialiser le contexte de la base de données.
    /// </summary>
    /// <param name="context">Contexte de la base de données.</param>
    public ExpeditionDAO(WsysDbContext context) {
        _context = context;
    }

    /// <summary>
    /// Récupère toutes les expéditions dans la base de données.
    /// </summary>
    /// <returns>Liste d'expéditions.</returns>
    public async Task<List<Expedition>> ObtenirToutesLesExpeditionsAsync() {
        return await _context.Expeditions.Include(e => e.OrdreExpedition).ToListAsync();
    }

    /// <summary>
    /// Récupère une expédition par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant de l'expédition.</param>
    /// <returns>Expédition correspondante ou null si non trouvée.</returns>
    public async Task<Expedition?> ObtenirExpeditionParIdAsync(int id) {
        return await _context.Expeditions.Include(e => e.OrdreExpedition).FirstOrDefaultAsync(e => e.ExpeditionId == id);
    }

    /// <summary>
    /// Ajoute une nouvelle expédition dans la base de données.
    /// </summary>
    /// <param name="expedition">Expédition à ajouter.</param>
    /// <returns>L'expédition ajoutée.</returns>
    public async Task<Expedition> AjouterExpeditionAsync(Expedition expedition) {
        _context.Expeditions.Add(expedition);
        await _context.SaveChangesAsync();
        return expedition;
    }

    /// <summary>
    /// Met à jour une expédition existante.
    /// </summary>
    /// <param name="expedition">Expédition à mettre à jour.</param>
    public async Task MettreAJourExpeditionAsync(Expedition expedition) {
        _context.Expeditions.Update(expedition);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Supprime une expédition par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant de l'expédition à supprimer.</param>
    public async Task SupprimerExpeditionAsync(int id) {
        var expedition = await ObtenirExpeditionParIdAsync(id);
        if (expedition != null) {
            _context.Expeditions.Remove(expedition);
            await _context.SaveChangesAsync();
        }
    }
}
