using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using static AgendaWF.DataAccess;

namespace AgendaWF
{
    public class StructAgenda
    {
        public class Contact
        {
            public string Prenom { get; set; }
            public string NomFamille { get; set; }
            public string Adresse { get; set; }
            public string Ville { get; set; }
            public string CodePostal { get; set; }
            public string TelephoneCellulaire { get; set; }
            public string TelephoneBureau { get; set; }
            public string Email { get; set; }
            public string Nom_Liste_Filtre { get; set; }
            public List<Contact> CarnetAdresse { get; set; }

            public Contact() { }

            public Contact(string prenom, string nomFamille, string adresse, string ville, string codePostal, string cell, string bureau, string email, string nom_Liste_Filtre, List<Contact> carnetAdresse)
            {
                this.Prenom = prenom;
                this.NomFamille = nomFamille;
                this.Adresse = adresse;
                this.Ville = ville;
                this.CodePostal = codePostal;
                this.TelephoneCellulaire = cell;
                this.TelephoneBureau = bureau;
                this.Email = email;
                this.Nom_Liste_Filtre = nom_Liste_Filtre;
                this.CarnetAdresse = carnetAdresse;
            }
            public string SearchContactInfo
            {
                get
                {
                    return $"{Prenom} {NomFamille} {Adresse} {Ville} {CodePostal} {TelephoneCellulaire} {Nom_Liste_Filtre} {Email}";
                }
            }
        }
        public class ListeFavoris
        {
            public string Favoris { get; set; }
            public string Famille { get; set; }
            public string Amis { get; set; }
            public string Bureau { get; set; }
            public string LienProfessionnel { get; set; }
            public string Contact_Urgence { get; set; }
            public string Divers { get; set; }
            public List<ListeFavoris> ListFavoris { get; set; }

            public ListeFavoris() { }

            public ListeFavoris(string favoris, string famille, string amis, string bureau, string lienProfessionnel, string contact_Urgence, string divers, List<ListeFavoris> listeFavoris)
            {
                this.Favoris = favoris;
                this.Famille = famille;
                this.Amis = amis;
                this.Bureau = bureau;
                this.LienProfessionnel = lienProfessionnel;
                this.Contact_Urgence = contact_Urgence;
                this.Divers = divers;
                this.ListFavoris = listeFavoris;
            }            
        }
        public class RendezVous
        {
            public string NomRDV { get; set; }
            public DateTime DateDebut { get; set; }
            public DateTime DateFin { get; set; }
            public string Adresse { get; set; }
            public string NomReference { get; set; }
            public string NumeroRejoindre { get; set; }
            public string Description { get; set; }
            public List<RendezVous> CarnetRDV { get; set; }

            public RendezVous() { }

            public RendezVous(string nomRDV, DateTime dateDebut, DateTime dateFin, string nomReference, string description, string numeroRejoindre, List<RendezVous> carnetRDV, string adresse)//, List<Contact> CarnetAdresse)
            {
                this.NomRDV = nomRDV;
                this.DateDebut = dateDebut;
                this.DateFin = dateFin;
                this.Adresse = adresse;
                this.NomReference = nomReference;
                this.NumeroRejoindre = numeroRejoindre;
                this.Description = description;
                this.CarnetRDV = carnetRDV;
            }
            public string FullInfoRDV
            {
                get
                {
                    return $"{NomRDV} " +
                        $"\nle {DateDebut.ToString("ddd d MMMM yyyy")} a {DateDebut.ToString("HH mm")} " +
                        $"\nau {DateFin.ToString("ddd d MMMM yyyy ")} a {DateFin.ToString("HH mm")}" +
                        $"\nContact: {NomReference} " +
                        $"\nNo Bureau {NumeroRejoindre} " +
                        $"\nAdresse: {Adresse}" +
                        $"\n{Description} ";
                }
            }
            public string SearchRDVInfo
            {
                get
                {
                    return $"{NomRDV} " +
                        $"\nle {DateDebut.ToString("ddd d MMMM yyyy")} a {DateDebut.ToString("HH mm")} " +
                        $"\nau {DateFin.ToString("ddd d MMMM yyyy ")} a {DateFin.ToString("HH mm")}" +
                        $"\nContact: {NomReference} " +
                        $"\nNo Bureau {NumeroRejoindre} " +
                        $"\nAdresse: {Adresse}" +
                        $"\n{Description} ";
                }
            }
        }
        public static class GestionConflits
        {
            
        }
        public static class GestionRDV
        {
            static List<RendezVous> carnetRDV = new List<RendezVous>();
            static List<Contact> carnetAdresse = new List<Contact>();
            //static List<string> favoris = new List<string>();


            public static void AjouterRDV(RendezVous newRDV)
            {
                carnetRDV.Add(newRDV);
            }
            public static void AjouterContact(Contact addContact)
            {
                carnetAdresse.Add(addContact);
            }

            public static bool GestionConflits(DateTime dateDebut, DateTime dateFin, DateTime newDateDebut, DateTime newDateFin )
            {
                foreach (var rdv in carnetRDV)
                {
                    if (newDateDebut < rdv.DateDebut && newDateFin > rdv.DateDebut)
                    {
                        if (dateDebut < dateFin && dateFin > dateDebut)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            public static void AfficheRDV(DateTime date)
            {
                foreach (var rdv in carnetRDV)
                {
                    if (rdv.DateDebut.Date == date.Date)
                    {
                        Console.WriteLine($"Rendez-Vous: {rdv.NomRDV} " +
                                $"\nLe  {rdv.DateDebut.ToString("dddd dd MMMM YYYY")}  a  {rdv.DateDebut.ToString("HH:mm")} Heure" +
                                $"\nau  {rdv.DateFin.ToString("dddd dd MMMM YYYY")}  a  {rdv.DateFin.ToString("HH:mm")} Heure" +
                                $"\nAdresse: {rdv.Adresse} " +
                                $"\nNomReference: {rdv.NomReference}" +
                                $"\nNumero a Rejoindre: {rdv.NumeroRejoindre}" +
                                $"\nDescription: {rdv.Description}");
                    }
                    Console.WriteLine($"Aucun Rendez-Vous trouver ");
                }                
            }
            public static void AfficherContact( )
            {
            }
            public static void SuprimerDate()
            {
            }
            public static void ChercheRDV(DateTime date)
            {
                foreach (var rdv in carnetRDV) 
                {
                    if (rdv.DateDebut.Month == date.Month || rdv.DateDebut.Year == date.Year)
                    {
                        AfficheRDV(date);
                    }
                }
            }
            public static bool ChercherDate(List<RendezVous> listRDV, DateTime quelDate)
            {
                bool Trouver = false;
                for (int i = 0; i < listRDV.Count; i++)
                {
                    if (listRDV[i].DateDebut == quelDate)
                    {
                        Trouver = true;
                    }
                    else
                    {
                        Console.WriteLine("Veuille entrer une date valide EX: 2025/04/06");
                    }
                }
                return false;
            }
            public static void RDV(RendezVous addRDV)
            {


            }

        }
        public static void Principal()
        {

            Console.Write($"============ Journal de Mimi ========== " +
            $"\n1 - Ajouter un Contact: " +
            $"\n2 - Ajouter un Rendrez-Vous: " +
            $"\n3 - Modifier un Rendez-Vous: " +
            $"\n4 - Suprimer un Rendez-Vous: Chercher une Date, un mois, un annee: " +
            $"\n5 - Afficher les dates disponible (Par jours, nois, annee): " +
            $"\n6 - Afficher votre Agenda par Date: " +
            $"\n7 - Rechercher un Contact, Un RDV, ou dans la liste de Favoris " +
                $"\n8 - Chercher par Prenom, Par NomFamille, Par Ville, Par No Cellulaire, Par Email: " +
                $"\n9 - Chercher par Date, Par Mois, Par Annee , Par nom Evenement, par ville, par no de telephone: " +
                $"\n10 - Chercher par Groupeliste Favoris, Famille, Amis, Bureau, Lien Professionnel, Concact Urgence, Divers" +
            $"\n0 - Quiter " +
            $"\nQuel est ton choix? ");

            int choix = int.Parse(Console.ReadLine());
            while (choix != 0)
            {
                switch (choix)
                {
                    case 1:
                        List<string> newRDV = new List<string>() { };
                        List<string> infoRDV = new List<string>() {
                                    "La raison du Rendez_Vous: ",
                                    "La Date: ",
                                    "L'Heure du Debut: ",
                                    "L'Heure de la Fin: ",
                                    "Description: ",
                                    "Personne acompagner: "
                        };
                        for (int i = 0; i < infoRDV.Count; i++)
                        {
                            Console.Write(infoRDV[i]);
                            newRDV.Add(Console.ReadLine());
                        }
                        Console.WriteLine(String.Join(", ", newRDV));
                        break;
                    case 2:
                        Console.WriteLine("Quel Date vous rechercher");
                        DateTime datedonner = DateTime.Parse(Console.ReadLine());
                        //GestionRDV.AjouterRDV(datedonner);
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("Quel Date vous rechercher");
                        DateTime dateChercher = DateTime.Parse(Console.ReadLine());
                        GestionRDV.AfficheRDV(dateChercher);
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 0:
                        Console.WriteLine("Merci d'avoir utiliser notre service,\nBonne Journee");
                        break;
                    default:
                        Console.WriteLine("Option invalide, veuillez essayer de nouveau");
                        break;
                }
            }
        }
    }
}

