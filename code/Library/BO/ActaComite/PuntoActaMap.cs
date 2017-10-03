using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class PuntoActaMap : ClassMapping<PuntoActaRecord>
	{	
		public PuntoActaMap()
		{
			Table("`PuntoActa`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`PuntoActa_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidActa, map => { map.Column("`OID_ACTA`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
					}
	}
}
