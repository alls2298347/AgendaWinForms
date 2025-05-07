CREATE       PROCEDURE dbo.Search_Contact
	@Prenom VARCHAR(30),
	@NomFamille VARCHAR(30), 
	@Adresse VARCHAR(50), 
	@Ville VARCHAR(30),
	@CodePostal VARCHAR(8), 
	@TelephoneCellulaire VARCHAR(14), 
	@Email VARCHAR(50),
	@Nom_Liste_Filtre VARCHAR(30)
AS 
BEGIN
	SET NOCOUNT ON;

	SELECT Prenom,
		NomFamille, 
		Adresse, 
		Ville,
		CodePostal , 
		TelephoneCellulaire, 
		Email ,
		Nom_Liste_Filtre 
	FROM Contact
	WHERE Prenom = @Prenom OR
			NomFamille = @NomFamille OR
			Ville = @Ville OR
			TelephoneCellulaire = @TelephoneCellulaire OR 
			Email = @Email OR 
			Nom_Liste_Filtre = @Nom_Liste_Filtre
ORDER BY Prenom , NomFamille 	
END;
