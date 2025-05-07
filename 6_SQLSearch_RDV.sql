CREATE     PROCEDURE dbo.Search_RDV
    @NomRDV VARCHAR(30),
	@DateDebut datetime2(0),
	@DateFin datetime2(0),
    @Adresse VARCHAR(50),
    @NomReference VARCHAR(30),
    @NumeroRejoindre VARCHAR(14),
    @Description VARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT NomRDV,
		DateDebut,
		DateFin, 
		Adresse, 
		NomReference,
		NumeroRejoindre,
		Description 
	FROM RendezVous
	WHERE NomRDV = @NomRDV OR
		DateDebut = @DateDebut OR
		DateFin = @DateFin OR
		Adresse = @Adresse OR
		NomReference = @NomReference OR
		NumeroRejoindre = @NumeroRejoindre OR
		Description = @Description
	ORDER BY NomRDV  
END;


