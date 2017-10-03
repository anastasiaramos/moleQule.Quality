/* UPDATE 5.0.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '5.0.0.0' WHERE "NAME" = 'QUALITY_DB_VERSION';

UPDATE "Entidad" SET "OBSERVACIONES" = 'Auditor�as' WHERE "TIPO" = 'Auditoria';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Informes de Discrepancias' WHERE "TIPO" = '"InformeDiscrepancia"';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Informes Correctores' WHERE "TIPO" = 'InformeCorrector';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Informes de Ampliaci�n' WHERE "TIPO" = 'InformeAmpliacion';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Actas de Comit�' WHERE "TIPO" = 'ActaComite';

SET SEARCH_PATH = "0001";
