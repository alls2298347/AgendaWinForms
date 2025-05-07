CREATE   PROCEDURE dbo.RDV_Insert
    @NomRDV VARCHAR(30),
	@DateDebut datetime2(0),
	@DateFin datetime2(0),
    @Adresse VARCHAR(50),
    @NomReference VARCHAR(30),
    @NumeroRejoindre VARCHAR(14),
    @Description VARCHAR(30)
AS
BEGIN
    INSERT INTO RendezVous (NomRDV, DateDebut, DateFin, Adresse, NomReference, NumeroRejoindre, Description)
    VALUES (@NomRDV, @DateDebut, @DateFin, @Adresse, @NomReference, @NumeroRejoindre, @Description)
END;
