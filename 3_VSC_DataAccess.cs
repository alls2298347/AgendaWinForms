using System;
using Dapper;
using System.Collections.Generic;
using System.Data;
using static AgendaWF.StructAgenda;
using System.Data.SqlClient;

namespace AgendaWF
{
    public class DataAccess
    {
        public List<Contact> GetContact(string nomFamille)   // Ici c'est pour rechercher dans la liste de contact par le nom de famille
        {
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {                                       // Ici c'est quand on a pas de procedure(enregistrer inLine)
                //var output = connection.Query<Contact>($"SELECT * FROM Contact WHERE NomFamille = @NomFamille", new { NomFamille = nomFamille }).ToList();  
                var output = connection.Query<Contact>("Contact_GetByNomFamille",  // Ici c'est quand on a une procedure pour enregistrer automatiquement dans la Bade de Donner
                    new { NomFamille = nomFamille },
                    commandType: CommandType.StoredProcedure).ToList();
                return output;
            }
        }
        public List<Contact> GetSearchContact(Contact contacts)
        {
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {
                var output = connection.Query<Contact>("Search_Contact",
                    new
                    {
                        contacts.Prenom,
                        contacts.NomFamille,
                        contacts.Adresse,
                        contacts.Ville,
                        contacts.CodePostal,
                        contacts.TelephoneCellulaire,
                        contacts.Email,
                        contacts.Nom_Liste_Filtre,

                    },
                commandType: CommandType.StoredProcedure).ToList();
                return output;
            }
        }                                // Ici c'est pour rechercher un RDV encore avec une procedure DB 
        public List<RendezVous> GetSearchRDV(RendezVous carnetRDV)
        {
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {
                var output = connection.Query<RendezVous>("Search_RDV", new
                {
                    carnetRDV.NomRDV,
                    carnetRDV.DateDebut,
                    carnetRDV.DateFin,
                    carnetRDV.NomReference,
                    carnetRDV.NumeroRejoindre,
                    carnetRDV.Adresse,
                    carnetRDV.Description,

                },             // Quand c'est des recherche ou pour afficher des information,
                commandType: CommandType.StoredProcedure).ToList();  //Doit raire un Return
                return output;  
            }
        }                      
        public void InsertContact(Contact contact)  // Pareil que les creation de rendez-vous, ici je cree un contact 
        {
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {
                connection.Execute("Contact_Insert", new   // La procedure ajoute tout les information donner dans la DB
                {
                    contact.Prenom,
                    contact.NomFamille,
                    contact.Adresse,
                    contact.Ville,
                    contact.CodePostal,
                    contact.TelephoneCellulaire,
                    contact.TelephoneBureau,
                    contact.Email,
                    contact.Nom_Liste_Filtre,

                }, commandType: CommandType.StoredProcedure);
            }
        }
        public void InsertRDV(RendezVous rendezVous)       // Avec la structure Rendezvous 
        {                           // Connection a ma procedure RDV_Insert dur la DB pour Cree un rendezvous avec les objet de la structure
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {
                connection.Execute("RDV_Insert", new
                {
                    rendezVous.NomRDV,
                    rendezVous.DateDebut,
                    rendezVous.DateFin,
                    rendezVous.Adresse,
                    rendezVous.NomReference,
                    rendezVous.NumeroRejoindre,                    
                    rendezVous.Description

                }, commandType: CommandType.StoredProcedure);
            }
        }                                    // Avec la Procedure RDV_GetAll que j'ai cree dans DB 
        public List<RendezVous> GetAllRDV()    // C'est pour rechercher dans la liste de contact
        {                                          // La procedure donne tout les informations et que j'apelle dans ma StructAgenda
            using IDbConnection connection = new Microsoft.Data.SqlClient.SqlConnection(Helper.CnnVal("AgendaBD"));
            {
                var output = connection.Query<RendezVous>("RDV_GetALL", commandType: CommandType.StoredProcedure).ToList();
                return output;       // donc le Output, va sortir ce que la procedure fait
            }
        }
    }
}
