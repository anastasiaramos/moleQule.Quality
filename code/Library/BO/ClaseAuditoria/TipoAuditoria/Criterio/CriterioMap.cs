using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class CriterioMap : ClassMapping<CriterioRecord>
	{	
		public CriterioMap()
		{
			Table("`Criterio`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Criterio_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidTipoAuditoria, map => { map.Column("`OID_TIPO_AUDITORIA`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
					}
	}
}
