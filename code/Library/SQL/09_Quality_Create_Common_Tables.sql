/* INVOICE MODULE COMMON SCHEMA SCRIPT	*/
/* Requires STORE MODULE 				*/

SET SEARCH_PATH = 'COMMON';

INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('Auditoria', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeDiscrepancia', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeCorrector', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeAmpliacion', FALSE, FALSE);

/* Conjunto de INSERT generados para rellenar la tabla Entidad */
INSERT INTO "Entidad" ("TIPO") VALUES ('Auditoria');
INSERT INTO "Entidad" ("TIPO") VALUES ('InformeDiscrepancia');
INSERT INTO "Entidad" ("TIPO") VALUES ('InformeCorrector');
INSERT INTO "Entidad" ("TIPO") VALUES ('InformeAmpliacion');