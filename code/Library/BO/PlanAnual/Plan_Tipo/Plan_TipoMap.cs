using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class Plan_TipoMap : ClassMapping<Plan_TipoRecord>
	{	
		public Plan_TipoMap()
		{
			Table("`Plan_Tipo`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Plan_Tipo_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.OidTipo, map => { map.Column("`OID_TIPO`"); map.Length(32768); });
			Property(x => x.Orden, map => { map.Column("`ORDEN`"); map.Length(32768); });
			Property(x => x.Enero, map => { map.Column("`ENERO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Febrero, map => { map.Column("`FEBRERO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Marzo, map => { map.Column("`MARZO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Abril, map => { map.Column("`ABRIL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Mayo, map => { map.Column("`MAYO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Junio, map => { map.Column("`JUNIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Julio, map => { map.Column("`JULIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Agosto, map => { map.Column("`AGOSTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Septiembre, map => { map.Column("`SEPTIEMBRE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Octubre, map => { map.Column("`OCTUBRE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Noviembre, map => { map.Column("`NOVIEMBRE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Diciembre, map => { map.Column("`DICIEMBRE`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
