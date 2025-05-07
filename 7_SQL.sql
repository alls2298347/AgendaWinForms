CREATE       PROCEDURE dbo.RDV_GetALL	
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		NomRDV,
		DateDebut ,
		DateFin ,
		Adresse, 
		NomReference,
		NumeroRejoindre,
		Description 
	FROM RendezVous 
ORDER BY NomRDV
END;
