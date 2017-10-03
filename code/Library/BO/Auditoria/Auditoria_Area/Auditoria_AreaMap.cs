using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class Auditoria_AreaMap : ClassMapping<Auditoria_AreaRecord>
	{	
		public Auditoria_AreaMap()
		{
			Table("`Auditoria_Area`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Auditoria_Area_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAuditoria, map => { map.Column("`OID_AUDITORIA`"); map.Length(32768); });
			Property(x => x.OidArea, map => { map.Column("`OID_AREA`"); map.Length(32768); });
					}
	}
}
