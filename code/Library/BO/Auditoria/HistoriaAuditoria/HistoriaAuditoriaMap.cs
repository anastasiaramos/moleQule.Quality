using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class HistoriaAuditoriaMap : ClassMapping<HistoriaAuditoriaRecord>
	{	
		public HistoriaAuditoriaMap()
		{
			Table("`HistoriaAuditoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`HistoriaAuditoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAuditoria, map => { map.Column("`OID_AUDITORIA`"); map.Length(32768); });
			Property(x => x.OidEmpleado, map => { map.Column("`OID_EMPLEADO`"); map.Length(32768); });
			Property(x => x.Estado, map => { map.Column("`ESTADO`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hora, map => { map.Column("`HORA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
