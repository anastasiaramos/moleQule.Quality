using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class ActaComiteMap : ClassMapping<ActaComiteRecord>
	{	
		public ActaComiteMap()
		{
			Table("`ActaComite`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`ActaComite_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Titulo, map => { map.Column("`TITULO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Revision, map => { map.Column("`REVISION`"); map.Length(32768); });
			Property(x => x.Motivo, map => { map.Column("`MOTIVO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
