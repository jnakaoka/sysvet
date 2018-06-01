--ALTER TABLE Pet RENAME COLUMN Dt_Adcocao to Dt_Adocao;

EXEC sp_rename 'Pet.Dt_Adcocao', 'Dt_Adocao', 'COLUMN';