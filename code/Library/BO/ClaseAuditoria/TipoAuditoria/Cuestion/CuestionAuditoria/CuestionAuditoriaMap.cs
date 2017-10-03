using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class CuestionAuditoriaMap : ClassMapping<CuestionAuditoriaRecord>
	{	
		public CuestionAuditoriaMap()
		{
			Table("`CuestionAuditoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`CuestionAuditoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAuditoria, map => { map.Column("`OID_AUDITORIA`"); map.Length(32768); });
			Property(x => x.OidCuestion, map => { map.Column("`OID_CUESTION`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
			Property(x => x.Aceptado, map => { map.Column("`ACEPTADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
