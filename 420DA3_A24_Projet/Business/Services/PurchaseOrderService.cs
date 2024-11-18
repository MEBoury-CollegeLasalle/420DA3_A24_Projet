using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.DataAccess.Contexts;
using _420DA3_A24_Projet.DataAccess.DAOs;
using _420DA3_A24_Projet.Presentation.Views;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _420DA3_A24_Projet.Business.Services;
internal class PurchaseOrderService {
    private readonly Application application;
    private readonly PurchaseOrderView view;
    private readonly PurchaseOrderDAO dao;
    

    public PurchaseOrderService(Application app , WsysDbContext context) {
        this.application = app;
        this.dao = new PurchaseOrderDAO(context);
        this.view = new PurchaseOrderView(app);
    }

    public PurchaseOrder? OpenViewFor(ViewActionsEnum viewAction , PurchaseOrder? purchaseOrder = null) {
        try {
            DialogResult result = this.view.OpenFor(viewAction, purchaseOrder);
            if (result == DialogResult.OK) {
                switch (viewAction) {
                    case ViewActionsEnum.Creation:
                    case ViewActionsEnum.Edition:
                        _ = this.OpenViewFor(ViewActionsEnum.Visualization, this.view.GetCurrentInstance());
                        break;
                    default:
                        break;
                }
            }
            return this.view.GetCurrentInstance();
        }catch(Exception ex) {
            this.application.HandleException(ex);
            return null;
        }
    }

    public List<PurchaseOrder> Search(string filter) {
        try {
            return this.dao.Search(filter);
        }catch(Exception ex) {
            throw new Exception("Failed to search for [PurchaseOrder].", ex);
        }
    }
    public PurchaseOrder? GetById(int id) {
        try {
            return this.dao.GetById(id);
        }catch(Exception ex) {
            throw new Exception($"Failed to obtain [PurchaseOrder] instance with id# {id}.", ex);
        }
    }

    public PurchaseOrder Create(PurchaseOrder newPurchaseOrder) {
        try {
            return this.dao.Create(newPurchaseOrder);
        }catch(Exception ex) {
            throw new Exception($"Failed to create new [PurchaseOrder]", ex);
        }
    }
    
    public PurchaseOrder Update(PurchaseOrder purchaseOrder) {
        try {
            return this.dao.Update(purchaseOrder);
        }catch(Exception ex) {
            throw new Exception($"Failed to update [PurchaseOrder] instance with id# {purchaseOrder.Id}.", ex);
        }
    }

    public void Delete(PurchaseOrder purchaseOrder , bool softDeletes = true) {
        try {
             this.dao.Delete(purchaseOrder,softDeletes);
        }catch(Exception ex) {
            throw new Exception($"Failed to delte [PurchaseOrder] instance with id# {purchaseOrder.Id}.", ex);
        }
    }
}
