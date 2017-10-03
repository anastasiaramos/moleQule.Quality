SET search_path TO "0001";
      
ALTER TABLE "InformeDiscrepancia" ADD COLUMN "FECHA_CREACION" timestamp without time zone;
ALTER TABLE "InformeCorrector" ADD COLUMN "FECHA_CREACION" timestamp without time zone;
ALTER TABLE "InformeAmpliacion" ADD COLUMN "FECHA_CREACION" timestamp without time zone;

ALTER TABLE "InformeAmpliacion" ADD COLUMN "VALORADO" boolean DEFAULT false;

ALTER TABLE "PlanAnual" ADD COLUMN "ANO" int8;
ALTER TABLE "Auditoria" ADD COLUMN "FECHA_COMUNICACION" date;
ALTER TABLE "InformeDiscrepancia" ADD COLUMN "FECHA_COMUNICACION" date;
ALTER TABLE "InformeAmpliacion" ADD COLUMN "FECHA_COMUNICACION" date;
ALTER TABLE "InformeCorrector" ADD COLUMN "FECHA_COMUNICACION" date;


ALTER TABLE "InformeDiscrepancia" DROP COLUMN "NUMERO";
ALTER TABLE "InformeDiscrepancia" ADD COLUMN "NUMERO" varchar NOT NULL;
ALTER TABLE "InformeAmpliacion" DROP COLUMN "NUMERO";
ALTER TABLE "InformeAmpliacion" ADD COLUMN "NUMERO" varchar NOT NULL;
ALTER TABLE "InformeCorrector" DROP COLUMN "NUMERO";
ALTER TABLE "InformeCorrector" ADD COLUMN "NUMERO" varchar NOT NULL;
ALTER TABLE "Discrepancia" ADD COLUMN "FECHA_AMPLIACION" date NOT NULL;

INSERT INTO "COMMON"."TIPOENTIDAD" ("VALOR", "USER_CREATED", "COMMON_SCHEMA") VALUES ('ActaComite', FALSE, FALSE);

INSERT INTO "COMMON"."Entidad" ("TIPO") VALUES ('ActaComite');
