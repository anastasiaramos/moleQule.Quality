using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class AreaMap : ClassMapping<AreaRecord>
	{	
		public AreaMap()
		{
			Table("`Area`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Area_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
