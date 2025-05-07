CREATE     PROCEDURE dbo.Contact_Insert
    @Prenom VARCHAR(30),
    @NomFamille VARCHAR(30),
    @Adresse VARCHAR(100),
    @Ville VARCHAR(50),
    @CodePostal VARCHAR(8),
    @TelephoneCellulaire VARCHAR(14),
    @TelephoneBureau VARCHAR(14),
    @Email VARCHAR(100),
    @Nom_Liste_Filtre VARCHAR(30)
AS
BEGIN
    INSERT INTO Contact (Prenom, NomFamille, Adresse, Ville, CodePostal, TelephoneCellulaire, TelephoneBureau, Email, Nom_Liste_Filtre)
    VALUES (@Prenom, @NomFamille, @Adresse, @Ville, @CodePostal, @TelephoneCellulaire, @TelephoneBureau, @Email, @Nom_Liste_Filtre)
END;
