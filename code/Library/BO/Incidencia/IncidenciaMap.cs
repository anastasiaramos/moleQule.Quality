using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class IncidenciaMap : ClassMapping<IncidenciaRecord>
	{	
		public IncidenciaMap()
		{
			Table("`Incidencia`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Incidencia_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAgente, map => { map.Column("`OID_AGENTE`"); map.Length(32768); });
			Property(x => x.TipoAgente, map => { map.Column("`TIPO_AGENTE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
