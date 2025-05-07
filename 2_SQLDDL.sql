-- DROP SCHEMA dbo;

CREATE SCHEMA dbo;
-- AgendaDB.dbo.ListeFavoris definition

-- Drop table

-- DROP TABLE AgendaDB.dbo.ListeFavoris;

CREATE TABLE AgendaDB.dbo.ListeFavoris (
	ID_ListeFavoris int IDENTITY(1,1) NOT NULL,
	Nom_Liste_Filtre varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT Filtre_Contact_PK PRIMARY KEY (ID_ListeFavoris)
);


-- AgendaDB.dbo.Contact definition

-- Drop table

-- DROP TABLE AgendaDB.dbo.Contact;

CREATE TABLE AgendaDB.dbo.Contact (
	ID_Contact int IDENTITY(1,1) NOT NULL,
	Prenom varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NomFamille varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Adresse varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Ville varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CodePostal varchar(8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TelephoneCellulaire varchar(14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	TelephoneBureau varchar(14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Email varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Nom_Liste_Filtre varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ID_ListeFavoris int NULL,
	CONSTRAINT Contact_PK PRIMARY KEY (ID_Contact),
	CONSTRAINT Contact_ListeFavoris FOREIGN KEY (ID_ListeFavoris) REFERENCES AgendaDB.dbo.ListeFavoris(ID_ListeFavoris)
);
 CREATE NONCLUSTERED INDEX Contact_NumeroCell_IDX ON AgendaDB.dbo.Contact (  TelephoneCellulaire ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;


-- AgendaDB.dbo.RendezVous definition

-- Drop table

-- DROP TABLE AgendaDB.dbo.RendezVous;

CREATE TABLE AgendaDB.dbo.RendezVous (
	ID_RendezVous int IDENTITY(1,1) NOT NULL,
	NomRDV varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	DateDebut datetime2(0) NULL,
	DateFin datetime2(0) NULL,
	Adresse varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	NumeroRejoindre varchar(14) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	Description varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	ID_Contact int NULL,
	NomReference varchar(30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	CONSTRAINT RendezVous_PK PRIMARY KEY (ID_RendezVous),
	CONSTRAINT RendezVous_Contact FOREIGN KEY (ID_Contact) REFERENCES AgendaDB.dbo.Contact(ID_Contact)
);


