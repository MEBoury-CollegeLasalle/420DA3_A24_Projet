using _420DA3_A24_Projet.Business;
using _420DA3_A24_Projet.Business.Domain;
using _420DA3_A24_Projet.Business.Services;
using Project_Utilities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _420DA3_A24_Projet.Presentation.Views;
internal partial class AdresseView : Form {

    private readonly ProjectApplication parentApp;

    public Adresse CurrentInstance { get; private set; }
    public ViewActionsEnum CurrentAction { get; private set; }

    public AdresseView(ProjectApplication parentApp) {
        this.parentApp = parentApp;
        this.InitializeComponent();
    }

    public DialogResult OpenForCreation(Adresse emptyAdresse) {
        this.PreOpenSetup(ViewActionsEnum.Creation, emptyAdresse, "Creation d'un A dresse", "CREER");
        return this.ShowDialog();
    }

    public DialogResult OpenForDetailsView(Adresse adresse) {
        this.PreOpenSetup(ViewActionsEnum.Visualization, adresse, "Details d'un Adresse", "OK");
        return this.ShowDialog();

    }
    public DialogResult OpenForEdition(Adresse adresse) {
        this.PreOpenSetup(ViewActionsEnum.Edition, adresse, "Modification d'un Adresse", "ENREGISTRER");
        return this.ShowDialog();
    
    }

    public DialogResult OpenForDeletion(Adresse adresse) {
        this.PreOpenSetup(ViewActionsEnum.Deletion, adresse, "Suppresion d'un Adresse", "SUPPRIMER");
        return this.ShowDialog();

    }

    private void PreOpenSetup(ViewActionsEnum action,Adresse instance,string windowsTitle,string actionButtonText) {
        this.CurrentAction = action;
        this.CurrentInstance = instance;
        this.Text = windowsTitle;
        this.valueModeFentre.Text = action.ToString();
        this.BtnAction.Text = actionButtonText;
        this.LoadAdresseDataInControls(instance); 

        if(action == ViewActionsEnum.Creation || action == ViewActionsEnum.Edition) {
            this.ActivateEdidtableControls();
        } else {
            this.DesactivateEdidtableControls();
        }
    }

    private void LoadAdresseDataInControls(Adresse adresse) {
        //TODO @MAGUETTE: Charger les donnes de l'adresse dans les controls

    }

    private  void UpdateAdresseInstanceFromControls(Adresse adresse) {
        try {
            

        } catch(Exception ex) {
            _ = MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;

        }
       

    }



    private void ValidateControlsValues() {
        if (this.valueAdresss.Text.Length < Adresse.AdresseMinLength) {

            throw new Exception($"L'adresse doit contenir au moins {Adresse.AdresseMinLength} caracteres.", );

        }
        if (this.valueAdresss.Text.Length > Adresse.AdresseMaxLength) {

            throw new Exception(($"L'adresse ne doit pas contenir plus de {Adresse.AdresseMaxLength} caracteres.", );

        }
        ///TODO il me reste les autres attributs de la classeAdresse a valider
    }
    /// <summary>
    /// cette fonction permet d'activer certains controls  pour faire en sorte que l'utilisateur 
    /// puisse modifier des valeurs de dans quand il va etre en mode creation ou bien update   
    /// </summary>
    private  void ActivateEdidtableControls() {
        this.valueAdresss.Enabled = true;
        this.valueCivicNumber.Enabled = true;
        this.valueAdresseTypeCB.Enabled = true;
        this.valueStreet.Enabled = true;
        this.valueCity.Enabled = true;
        this.valueState.Enabled = true;
        this.valueCountry.Enabled = true;
        this.valuePostalCode.Enabled = true;
    }

    /// <summary>
    /// Contrairement a ActivateEdidtableControls cette fonction va nous permetre de
    /// desactiver des controls dont l'utilisateur ne va pas pouvoir touche
    /// </summary>
    private void DesactivateEdidtableControls() {
        this.valueAdresss.Enabled = false;
        this.valueCivicNumber.Enabled = false;
        this.valueAdresseTypeCB.Enabled = false;
        this.valueStreet.Enabled = false;
        this.valueCity.Enabled = false;
        this.valueState.Enabled = false;
        this.valueCountry.Enabled = false;
        this.valuePostalCode.Enabled =false;

    }

    private void btnAnnuler_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
    }

    private void BtnAction_Click(object sender, EventArgs e) {

        try {
            this.ProcessAction();
            this.DialogResult=DialogResult.OK;
        }
        catch (Exception ex){
            //TODO @maguette afficher erreur
        }
    }

    private void ProcessAction() {

    }
   
}
