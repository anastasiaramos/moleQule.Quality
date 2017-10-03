-- MOLEQULE COMMON DATA SCRIPT

-- INSERTS

INSERT INTO "COMMON"."Variable" ("NAME", "VALUE") VALUES ('QUALITY_DB_VERSION', '5.0.0.0');

INSERT INTO "UserSetting" ("OID_USER", "NAME", "VALUE") (SELECT U."OID", 'NOTIFY_AUDITORIAS', 'TRUE' FROM "User" AS U);
INSERT INTO "UserSetting" ("OID_USER", "NAME", "VALUE") (SELECT U."OID", 'NOTIFY_PLAZO_AUDITORIAS', 7 FROM "User" AS U);

-- HIPATIA INSERTS

INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('ActaComite', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('Auditoria', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeCorrector', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeAmpliacion', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeDiscrepancia', FALSE, FALSE);

INSERT INTO "COMMON"."Entidad" ("TIPO", "OBSERVACIONES") VALUES ('ActaComite', 'Actas de Comit�');
INSERT INTO "COMMON"."Entidad" ("TIPO", "OBSERVACIONES") VALUES ('Auditoria', 'Auditor�as');
INSERT INTO "COMMON"."Entidad" ("TIPO", "OBSERVACIONES") VALUES ('InformeCorrector', 'Informes Correctores');
INSERT INTO "COMMON"."Entidad" ("TIPO", "OBSERVACIONES") VALUES ('InformeAmpliacion', 'Informes de Ampliaci�n');
INSERT INTO "COMMON"."Entidad" ("TIPO", "OBSERVACIONES") VALUES ('InformeDiscrepancia', 'Informes de Discrepancias');

-- SECURE ITEMS INSERTS

INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Discrepancias', '501', 'DISCREPANCIA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Clases de Auditor�as', '502', 'CLASE_AUDITORIA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Auditor�as', '503', 'AUDITORIA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('�reas', '504', 'AREA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Ampliaciones', '505', 'AMPLIACION');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Actas del Comit� de Calidad', '506', 'ACTA_COMITE');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Acciones Correctoras', '507', 'ACCION_CORRECTORA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Incidencias', '508', 'INCIDENCIA');
INSERT INTO "COMMON"."SecureItem" ("NAME", "TIPO", "DESCRIPTOR") VALUES ('Planes Anuales', '509', 'PLAN_ANUAL');

--ITEM MAPS 

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'ACCION_CORRECTORA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'ACCION_CORRECTORA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'ACCION_CORRECTORA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'ACCION_CORRECTORA' AND ASI."TIPO" = 'AUDITORIA'	;
	
--AUDITORIA -> DISCREPANCIA

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'DISCREPANCIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'DISCREPANCIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'DISCREPANCIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'DISCREPANCIA'	;
	
--AUDITORIA -> AMPLIACION

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'AMPLIACION'	;
		
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'AMPLIACION'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'AMPLIACION'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'AMPLIACION'	;

--AUDITORIA -> ACCION_CORRECTORA

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'AUDITORIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;
	
--CLASE_AUDITORIA -> AUDITORIA

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'AUDITORIA'	;

INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'AUDITORIA'	;

--CLASE_AUDITORIA -> PLAN_ANUAL
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'PLAN_ANUAL'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'PLAN_ANUAL'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'PLAN_ANUAL'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'CLASE_AUDITORIA' AND ASI."TIPO" = 'PLAN_ANUAL'	;

--DISCREPANCIA -> ACCION_CORRECTORA
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'ACCION_CORRECTORA'	;

--DISCREPANCIA -> AMPLIACION
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AMPLIACION'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AMPLIACION'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AMPLIACION'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AMPLIACION'	;

--DISCREPANCIA -> AUDITORIA
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '1', ASI."OID", '1' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AUDITORIA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '2', ASI."OID", '2' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AUDITORIA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '3', ASI."OID", '3' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AUDITORIA'	;
	
INSERT INTO "COMMON"."ItemMap" ("OID_ITEM","PRIVILEGE","OID_ASSOCIATE_ITEM","ASSOCIATE_PRIVILEGE")  
	SELECT SI."OID", '4', ASI."OID", '4' 
	FROM "COMMON"."SecureItem" AS SI
	INNER JOIN "COMMON"."SecureItem" AS ASI ON SI."TIPO" = 'DISCREPANCIA' AND ASI."TIPO" = 'AUDITORIA'	;