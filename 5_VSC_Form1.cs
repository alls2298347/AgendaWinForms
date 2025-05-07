using System.Collections.Generic;
using static AgendaWF.StructAgenda;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgendaWF
{
    public partial class Form1 : Form
    {

        List<Contact> carnetAdresse = new List<Contact>();
        List<RendezVous> carnetRDV = new List<RendezVous>();
        List<ListeFavoris> ID_listeFavoris = new List<ListeFavoris>();
        public Form1()
        {
            InitializeComponent();
        }
        //private void label1_Click(object sender, EventArgs e)
        //{

        //}
        private void SearchButton_Click(object sender, EventArgs e)
        {
        }

        private void SaveNewContactButton_Click(object sender, EventArgs e)
        {        // Je cree mon bouton enregistrer qui cree tout mes champs dans ma base de donner
            Contact contact = new Contact      //
            {
                Prenom = prenomInsertTexBox.Text,
                NomFamille = nomInsertTexBox.Text,
                Adresse = adresseInsertTexBox.Text,
                Ville = villeInsertTexBox.Text,
                CodePostal = codePostalInsertTexBox.Text,
                TelephoneCellulaire = cellulaireMaskInsertTexBox.Text,
                TelephoneBureau = bureauMaskInsertTexBox.Text,
                Email = emailInsertTexBox.Text,
            };
            StructAgenda.GestionRDV.AjouterContact(contact);
            MessageBox.Show("Contact ajouté avec succès!");
            DataAccess db = new DataAccess();
            db.InsertContact(contact);

            prenomInsertTexBox.Text = "";   // Ici sa Clear les champs une fois sauvgarder
            nomInsertTexBox.Text = "";
            adresseInsertTexBox.Text = "";
            villeInsertTexBox.Text = "";
            codePostalInsertTexBox.Text = "";
            cellulaireMaskInsertTexBox.Text = "";
            bureauMaskInsertTexBox.Text = "";
            emailInsertTexBox.Text = "";
            listeFavorisInsertComboBox.Text = "";
        }

        private void SaveNewRDVButton_Click(object sender, EventArgs e)
        {
            DateTime dateFin;
            DateTime dateDebut;
            if (!DateTime.TryParse(dateDebutMaskInsertTexBox.Text, out dateDebut) ||
                !DateTime.TryParse(dateFinMaskInsertTexBox.Text, out dateFin))
            {
                MessageBox.Show("La Date n'est pas valide DSL");
                return;
            }
            RendezVous carnetRDV = new RendezVous
            {
                NomRDV = leNomRDVInsertTexBox.Text,
                DateDebut = DateTime.Parse(dateDebutMaskInsertTexBox.Text),
                DateFin = DateTime.Parse(dateFinMaskInsertTexBox.Text),
                Adresse = adresse1InsertTexBox.Text,
                NomReference = textBoxNomReferenceInsertRDV.Text,
                NumeroRejoindre = numeroRejoindreMaskInsertTexBox.Text,
                Description = descriptionInsertTexBox.Text,
            };
            MessageBox.Show("Votre Rendez-Vous a été ajouté avec succès! ;-)");
            StructAgenda.GestionRDV.AjouterRDV(carnetRDV);
            DataAccess db = new DataAccess();
            db.InsertRDV(carnetRDV);

            leNomRDVInsertTexBox.Text = "";
            dateDebutMaskInsertTexBox.Text = "";
            dateFinMaskInsertTexBox.Text = "";
            adresse1InsertTexBox.Text = "";
            textBoxNomReferenceInsertRDV.Text = "";
            numeroRejoindreMaskInsertTexBox.Text = "";
            descriptionInsertTexBox.Text = "";
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearchContact_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact
            {
                Prenom = textBoxChercheParPrenom.Text,
                NomFamille = textBoxChercheParNomFamille.Text,
                Ville = textBoxChercheParVille.Text,
                TelephoneCellulaire = textBoxChercheParNoCellulaire.Text,
                Email = textBoxChercheParEmail.Text,
            };
            DataAccess db = new DataAccess();
            carnetAdresse = db.GetSearchContact(contact);
            listBoxResultatDeRecherche.DataSource = null;
            listBoxResultatDeRecherche.DataSource = carnetAdresse;
            listBoxResultatDeRecherche.DisplayMember = "SearchContactInfo";

            textBoxChercheParPrenom.Text = "";
            textBoxChercheParNomFamille.Text = "";
            textBoxChercheParVille.Text = "";
            textBoxChercheParNoCellulaire.Text = "";
            textBoxChercheParEmail.Text = "";
        }
        private void comboBoxSearchContact_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxSearchRDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            RendezVous searchRDV = new RendezVous();
            switch (comboBoxSearchRDV.SelectedItem.ToString())
            {               
                case "Nom de Rendez-Vous":
                    searchRDV.NomRDV = textBoxSearchRDV.Text;
                    break;
                case "Adresse":
                    searchRDV.Adresse = textBoxSearchRDV.Text;
                    break;
                case "Numero de Telephone":
                    searchRDV.NumeroRejoindre = textBoxSearchRDV.Text;
                    break;
            }
        }
        private void buttonSearchRDV_Click(object sender, EventArgs e)
        {
            RendezVous rendezVous = new RendezVous
            {
                NomRDV = textBoxSearchRDV.Text,
                Adresse = textBoxSearchRDV.Text,
                NumeroRejoindre = textBoxSearchRDV.Text,
            };
            DataAccess db = new DataAccess();
            carnetRDV = db.GetSearchRDV(rendezVous);
            listBoxResultatDeRecherche.DataSource = null;
            listBoxResultatDeRecherche.DataSource = carnetRDV;
            listBoxResultatDeRecherche.DisplayMember = "SearchRDVInfo";

            comboBoxSearchRDV.Text = "";
        }
        private void dateTimePickerSearchRDV_ValueChanged(object sender, EventArgs e)
        {
            RendezVous searchRDV = new RendezVous
            {
                //DateDebut = DateTime.Parse(dateChercherRDVMaskInsertTexBox.Text),
            //     case "Par Mois":
            //    StructAgenda.GestionRDV.ChercheRDV(DateTime.Parse(textBoxSearchRDV.Text));
            //    break;
            //case "Par Annee":
            //    StructAgenda.GestionRDV.ChercheRDV(DateTime.Parse(textBoxSearchRDV.Text));
            //    break;
            };
        }
        private void buttonSearchDateRDV_Click(object sender, EventArgs e)
        {
            //Contact contact = new Contact
            //{
            //    Prenom = comboBoxSearchContact.Text,
            //    NomFamille = comboBoxSearchContact.Text,
            //    Ville = comboBoxSearchContact.Text,
            //    TelephoneCellulaire = comboBoxSearchContact.Text,
            //    Email = comboBoxSearchContact.Text,
            //    Nom_Liste_Filtre = comboBoxSearchContact.Text

            //};
            //DataAccess db = new DataAccess();
            //carnetAdresse = db.GetSearchContact(contact);

            //listBoxResultatDeRecherche.DataSource = null;
            //listBoxResultatDeRecherche.DataSource = carnetAdresse;
            //listBoxResultatDeRecherche.DisplayMember = "SearchContactInfo";

            //comboBoxSearchContact.Text = "";

            RendezVous searchRDV = new RendezVous
            {
                //DateDebut = DateTime.Parse(dateChercherRDVMaskInsertTexBox.Text),
            };
            DataAccess db = new DataAccess();
            carnetRDV = db.GetSearchRDV(searchRDV);
            listBoxResultatDeRecherche.DataSource = null;
            listBoxResultatDeRecherche.DataSource = carnetRDV;
            listBoxResultatDeRecherche.DisplayMember = "SearchRDVInfo";
        }

        private void calendarAfficherRDVenUnClick_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dateCliquer = calendarAfficherRDVenUnClick.SelectionStart;
            List<RendezVous> rdvTrouver = new List<RendezVous>();

            DataAccess db = new DataAccess();
            carnetRDV = db.GetAllRDV();
            var listrdv = carnetRDV.ToList();

            foreach (var rdv in carnetRDV)
            {
                if (rdv.DateDebut.Date == dateCliquer.Date)
                {
                    rdvTrouver.Add(rdv);
                }
            }
            if (listrdv.Count > 0)
            {
                listBoxResultatDeRecherche.DataSource = null;
                listBoxResultatDeRecherche.DataSource = rdvTrouver;
                listBoxResultatDeRecherche.DisplayMember = "FullInfoRDV";
            }
            MessageBox.Show("Aucun RDV de trouver a cette Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}






