using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class AmpliacionMap : ClassMapping<AmpliacionRecord>
	{	
		public AmpliacionMap()
		{
			Table("`Ampliacion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Ampliacion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInformeAmpliacion, map => { map.Column("`OID_INFORME_AMPLIACION`"); map.Length(32768); });
			Property(x => x.OidDiscrepancia, map => { map.Column("`OID_DISCREPANCIA`"); map.Length(32768); });
			Property(x => x.FechaDebida, map => { map.Column("`FECHA_DEBIDA`"); map.Length(32768); });
			Property(x => x.FechaCierre, map => { map.Column("`FECHA_CIERRE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
					}
	}
}
