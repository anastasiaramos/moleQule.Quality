SET search_path TO "0001";


CREATE TABLE "Plan_Tipo" ( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" int8 NOT NULL,
	"OID_TIPO" int8 NOT NULL,	
	"ORDEN" int8 NOT NULL,
	CONSTRAINT "PLAN_TIPO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS
;
ALTER TABLE "Plan_Tipo" OWNER TO hangar_admin;
GRANT ALL ON TABLE "Plan_Tipo" TO GROUP "HANGAR_ADMINISTRADOR";


ALTER TABLE "Plan_Tipo" ADD CONSTRAINT FK_Plan_Tipo_TipoAuditoria 
	FOREIGN KEY ("OID_TIPO") REFERENCES "TipoAuditoria" ("OID")
ON UPDATE CASCADE ON DELETE RESTRICT
;

ALTER TABLE "Plan_Tipo" ADD CONSTRAINT FK_Plan_Tipo_PlanAnual 
	FOREIGN KEY ("OID_PLAN") REFERENCES "PlanAnual" ("OID")
ON UPDATE CASCADE ON DELETE RESTRICT
;

DROP TABLE "Plan_Clase";

ALTER TABLE "Auditoria" ADD COLUMN "OID_PLAN_TIPO" int8 NOT NULL;

ALTER TABLE "Auditoria" ADD CONSTRAINT FK_Auditoria_Plan_Tipo 
	FOREIGN KEY ("OID_PLAN_TIPO") REFERENCES "Plan_Tipo" ("OID")
ON UPDATE CASCADE ON DELETE RESTRICT
;

ALTER TABLE "Auditoria_Area" DROP CONSTRAINT fk_auditoria_area_auditoria;


ALTER TABLE "Auditoria_Area" ADD CONSTRAINT FK_Auditoria_Area_Auditoria 
	FOREIGN KEY ("OID_AUDITORIA") REFERENCES "TipoAuditoria" ("OID")
ON UPDATE CASCADE ON DELETE CASCADE
;

DROP TABLE "ComunicadoAuditoria";

CREATE TABLE "NotificacionInterna" 
( 
	"OID" bigserial NOT NULL,
	"OID_ASOCIADO" int8 NOT NULL,
	"TIPO_ASOCIADO" int8 NOT NULL,
	"CODIGO" varchar(255) NOT NULL,
	"SERIAL" int8 NOT NULL,
	"NUMERO" int8 NOT NULL,
	"COMENTARIOS" varchar,
	"ASUNTO" varchar NOT NULL,
	"FECHA" date NOT NULL,
	CONSTRAINT "NOTIFICACION_INTERNA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS
;
ALTER TABLE "NotificacionInterna" OWNER TO hangar_admin;
GRANT ALL ON TABLE "NotificacionInterna" TO GROUP "HANGAR_ADMINISTRADOR";

ALTER TABLE "TipoAuditoria" ADD COLUMN "TEXTO_INFORME" varchar;

ALTER TABLE "Discrepancia" ADD COLUMN "OID_CUESTION" int8 NOT NULL;

ALTER TABLE "Discrepancia" ADD CONSTRAINT FK_Discrepancia_CuestionAuditoria 
	FOREIGN KEY ("OID_CUESTION") REFERENCES "CuestionAuditoria" ("OID")
ON UPDATE CASCADE ON DELETE RESTRICT
;


INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_AMPLIACION', '50');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_GENERACION_INFORME', '14');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS', '7');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA', '7');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_DISCREPANCIAS_N1', '7');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_DISCREPANCIAS_N2', '60');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_DISCREPANCIAS_N3', '90');
INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('PLAZO_MAXIMO_RESPUESTA_AMPLIACION', '14');

ALTER TABLE "InformeDiscrepancia" DROP CONSTRAINT UQ_InformeDiscrepancia_NUMERO;
ALTER TABLE "NotificacionInterna" ADD COLUMN "ATENCION" varchar(255);
ALTER TABLE "NotificacionInterna" ADD COLUMN "COPIA" varchar(255);
ALTER TABLE "Plan_Tipo" ADD COLUMN "ENERO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "FEBRERO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "MARZO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "ABRIL" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "MAYO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "JUNIO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "JULIO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "AGOSTO" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "SEPTIEMBRE" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "OCTUBRE" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "NOVIEMBRE" boolean DEFAULT false;
ALTER TABLE "Plan_Tipo" ADD COLUMN "DICIEMBRE" boolean DEFAULT false;
ALTER TABLE "Discrepancia" ADD COLUMN "DISCREPANCIA" boolean DEFAULT true;
ALTER TABLE "InformeDiscrepancia" ADD COLUMN "NOTIFICADO" boolean DEFAULT false;
ALTER TABLE "InformeCorrector" ADD COLUMN "NOTIFICADO" boolean DEFAULT false;
ALTER TABLE "InformeAmpliacion" ADD COLUMN "NOTIFICADO" boolean DEFAULT false;

alter table "Discrepancia" drop CONSTRAINT fk_discrepancia_informediscrepancia;
alter table "Discrepancia" add constraint fk_discrepancia_informediscrepancia FOREIGN KEY ("OID_INFORME")
      REFERENCES "0001"."InformeDiscrepancia" ("OID") MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE cascade;

alter table "AccionCorrectora" drop constraint fk_accioncorrectora_informecorrector;
alter table "AccionCorrectora" add CONSTRAINT fk_accioncorrectora_informecorrector FOREIGN KEY ("OID_INFORME_CORRECTOR")
      REFERENCES "0001"."InformeCorrector" ("OID") MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE cascade;

alter table "Ampliacion" drop constraint fk_ampliacion_informeampliacion;
alter table "Ampliacion" add CONSTRAINT fk_ampliacion_informeampliacion FOREIGN KEY ("OID_INFORME_AMPLIACION")
      REFERENCES "0001"."InformeAmpliacion" ("OID") MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE cascade;
      
ALTER TABLE "InformeDiscrepancia" ADD COLUMN "TITULO" varchar;
ALTER TABLE "InformeCorrector" ADD COLUMN "TITULO" varchar;
ALTER TABLE "InformeAmpliacion" ADD COLUMN "TITULO" varchar;


SET SEARCH_PATH = 'COMMON';

INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeDiscrepancia', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeCorrector', FALSE, FALSE);
INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('InformeAmpliacion', FALSE, FALSE);

INSERT INTO "COMMON"."Entidad" ("TIPO") VALUES ('InformeDiscrepancia');
INSERT INTO "COMMON"."Entidad" ("TIPO") VALUES ('InformeCorrector');
INSERT INTO "COMMON"."Entidad" ("TIPO") VALUES ('InformeAmpliacion');


INSERT INTO "COMMON"."Variable" ("NAME" , "VALUE") VALUES ('AVISO_DISCREPANCIAS_ABIERTAS', '7');

