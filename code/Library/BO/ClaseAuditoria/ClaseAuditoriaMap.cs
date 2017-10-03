using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class ClaseAuditoriaMap : ClassMapping<ClaseAuditoriaRecord>
	{	
		public ClaseAuditoriaMap()
		{
			Table("`ClaseAuditoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`ClaseAuditoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
