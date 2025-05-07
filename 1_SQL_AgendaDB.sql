USE master

USE AgendaDB

CREATE TABLE AgendaDB.dbo.Contact (
	ID_Contact int IDENTITY(1,1) NOT NULL,
	FirstName varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LastName varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Adresse varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Ville varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Code_Postal char(7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NumeroCell varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	LienAvecContact varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ID_Rendezvous int NULL,
	CONSTRAINT Contact_PK PRIMARY KEY (ID_Contact),
	CONSTRAINT Contact_RendezVous_FK FOREIGN KEY (ID_RendezVous) REFERENCES AgendaDB.dbo.RendezVous(ID_RendezVous)

);
 CREATE NONCLUSTERED INDEX Contact_NumeroCell_IDX ON AgendaDB.dbo.Contact (  NumeroCell ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;

CREATE TABLE AgendaDB.dbo.RendezVous (
	ID_RendezVous int IDENTITY(1,1) NOT NULL,
	LaRaison varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Date] date NULL,
	HeureDebut datetime2(0) NULL,
	HeureFin datetime2(0) NULL,
	Adresse char(7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NumeroRejoindre varchar(12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Description varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT RendezVous_PK PRIMARY KEY (ID_RendezVous));


-- Créer un login SQL Server (niveau instance)
CREATE LOGIN AgendaUser WITH PASSWORD = 'Agenda123!';

-- Associer ce login à la base de données
USE AgendaDB;
CREATE USER AgendaUser FOR LOGIN AgendaUser;

-- Lui donner les droits dans la base
ALTER ROLE db_owner ADD MEMBER AgendaUser;


----- Precedure pour entrer des contact automatique et Securitaire pour eviter les INGECTIONS

USE AgendaDB

SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

ALTER PROCEDURE dbo.Contact_GetByLastName
		@NomFamille varchar(50)
		AS
		BEGIN
			SET NOCOUNT ON;
		
			SELECT *
			FROM Contact c 
			WHERE NomFamille = @NomFamille;
		END



ALTER TABLE AgendaDB.dbo.Contact ADD CONSTRAINT Contact_ListeFavoris FOREIGN KEY (ID_ListeFavoris) REFERENCES AgendaDB.dbo.ListeFavoris(ID_ListeFavoris);
ALTER TABLE AgendaDB.dbo.RendezVous  ADD CONSTRAINT RendezVous_Contact FOREIGN KEY (ID_Contact) REFERENCES AgendaDB.dbo.Contact(ID_Contact);



SELECT Prenom , NomFamille , Nom_Liste_Filtre 
FROM Contact c 
	INNER JOIN ListeFavoris lf ON lf.ID_ListeFavoris = c.ID_ListeFavoris



SELECT Prenom,
		NomFamille, 
		Adresse, 
		Ville,
		CodePostal , 
		TelephoneCellulaire , 
		Email ,
		Nom_Liste_Filtre 
FROM Contact c 
	INNER JOIN ListeFavoris lf  ON lf.ID_ListeFavoris = c.ID_ListeFavoris
ORDER BY Prenom , NomFamille 



SELECT NomRDV,
		CONCAT(c.Prenom,' ',c.NomFamille) AS NomContact,
		FORMAT(DateDebut ,'ddd  dd  MMM  yyyy ') AS DateDebut ,
		FORMAT(DateDebut, ' HH:mm') AS HeureDebut,
		FORMAT(DateFin ,'ddd  dd  MMM  yyyy ') AS DateFin , 
		FORMAT(DateFin, 'HH:mm') AS HeureFin ,
		CONCAT(c.Adresse,' ',c.Ville) AS Adresse, 
		c.TelephoneBureau AS NumeroRejoindre,
		Description, 
	CASE
		WHEN rv.ID_Contact IS NOT NULL THEN 'max'
	END AS 'rien'
FROM RendezVous rv 
	INNER JOIN Contact c ON rv.ID_Contact = c.ID_Contact
ORDER BY NomContact 


SELECT *
FROM RendezVous rv 
	INNER JOIN Contact c ON c.ID_Contact = rv.ID_Contact
	LEFT JOIN ListeFavoris lf ON c.ID_ListeFavoris = lf.ID_ListeFavoris 
ORDER BY c.Prenom ,c.NomFamille 


SELECT FORMAT(HeureDebut, 'HH:mm')AS HeureDebut,
		FORMAT(HeureFin, 'HH:mm')AS HeureFin
FROM RendezVous rv 


SELECT rv.NomRDV,
		rv.DateDebut ,
		rv.DateFin , 
		rv.Adresse, 
		rv.NomReference,
		rv.NumeroRejoindre,
		rv.Description 
	FROM RendezVous rv 
	INNER JOIN Contact c ON c.ID_Contact = rv.ID_Contact


SELECT 
		NomRDV,
		FORMAT(DateDebut ,'ddd d MMMM yyyy, a HH:mm Heure') AS DateDebut,
		CONCAT(FORMAT(DateFin ,'ddd d MMMM yyyy, a HH:mm')) Heure AS DateFin
	FROM RendezVous 






















