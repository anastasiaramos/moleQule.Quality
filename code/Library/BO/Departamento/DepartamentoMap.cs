using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class DepartamentoMap : ClassMapping<DepartamentoRecord>
	{	
		public DepartamentoMap()
		{
			Table("`Departamento`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Departamento_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Telefonos, map => { map.Column("`TELEFONOS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Fax, map => { map.Column("`FAX`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Email, map => { map.Column("`EMAIL`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
