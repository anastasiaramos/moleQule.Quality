using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class AuditoriaMap : ClassMapping<AuditoriaRecord>
	{	
		public AuditoriaMap()
		{
			Table("`Auditoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Auditoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAuditor, map => { map.Column("`OID_AUDITOR`"); map.Length(32768); });
			Property(x => x.OidTipoAuditoria, map => { map.Column("`OID_TIPO_AUDITORIA`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.FechaInicio, map => { map.Column("`FECHA_INICIO`"); map.Length(32768); });
			Property(x => x.FechaFin, map => { map.Column("`FECHA_FIN`"); map.Length(32768); });
			Property(x => x.Referencia, map => { map.Column("`REFERENCIA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.Estado, map => { map.Column("`ESTADO`"); map.Length(32768); });
			Property(x => x.OidResponsable, map => { map.Column("`OID_RESPONSABLE`"); map.Length(32768); });
			Property(x => x.OidUsuarioAuditor, map => { map.Column("`OID_USUARIO_AUDITOR`"); map.Length(32768); });
			Property(x => x.OidUsuarioResponsable, map => { map.Column("`OID_USUARIO_RESPONSABLE`"); map.Length(32768); });
			Property(x => x.OidDepartamentoAuditor, map => { map.Column("`OID_DEPARTAMENTO_AUDITOR`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidDepartamentoResponsable, map => { map.Column("`OID_DEPARTAMENTO_RESPONSABLE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidPlanTipo, map => { map.Column("`OID_PLAN_TIPO`"); map.Length(32768); });
			Property(x => x.FechaComunicacion, map => { map.Column("`FECHA_COMUNICACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
