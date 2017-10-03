using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class CuestionMap : ClassMapping<CuestionRecord>
	{	
		public CuestionMap()
		{
			Table("`Cuestion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Cuestion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidTipoAuditoria, map => { map.Column("`OID_TIPO_AUDITORIA`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`");	map.Length(255);  });
			Property(x => x.Nota, map => { map.Column("`NOTA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Referencias, map => { map.Column("`REFERENCIAS`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
