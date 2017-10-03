using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class AccionCorrectoraMap : ClassMapping<AccionCorrectoraRecord>
	{	
		public AccionCorrectoraMap()
		{
			Table("`AccionCorrectora`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`AccionCorrectora_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInformeCorrector, map => { map.Column("`OID_INFORME_CORRECTOR`"); map.Length(32768); });
			Property(x => x.OidDiscrepancia, map => { map.Column("`OID_DISCREPANCIA`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
					}
	}
}
