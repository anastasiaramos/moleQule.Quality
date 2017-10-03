using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class DiscrepanciaMap : ClassMapping<DiscrepanciaRecord>
	{	
		public DiscrepanciaMap()
		{
			Table("`Discrepancia`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Discrepancia_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInforme, map => { map.Column("`OID_INFORME`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Nivel, map => { map.Column("`NIVEL`"); map.Length(32768); });
			Property(x => x.FechaDebida, map => { map.Column("`FECHA_DEBIDA`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.FechaCierre, map => { map.Column("`FECHA_CIERRE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.OidCuestion, map => { map.Column("`OID_CUESTION`"); map.Length(32768); });
			Property(x => x.Discrepancia, map => { map.Column("`DISCREPANCIA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaAmpliacion, map => { map.Column("`FECHA_AMPLIACION`"); map.Length(32768); });
					}
	}
}
