using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class NotificacionInternaMap : ClassMapping<NotificacionInternaRecord>
	{	
		public NotificacionInternaMap()
		{
			Table("`NotificacionInterna`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`NotificacionInterna_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAsociado, map => { map.Column("`OID_ASOCIADO`"); map.Length(32768); });
			Property(x => x.TipoAsociado, map => { map.Column("`TIPO_ASOCIADO`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
			Property(x => x.Comentarios, map => { map.Column("`COMENTARIOS`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Asunto, map => { map.Column("`ASUNTO`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.Length(32768); });
			Property(x => x.Atencion, map => { map.Column("`ATENCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Copia, map => { map.Column("`COPIA`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
