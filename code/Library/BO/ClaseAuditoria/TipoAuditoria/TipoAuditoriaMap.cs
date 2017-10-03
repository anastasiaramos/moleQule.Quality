using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class TipoAuditoriaMap : ClassMapping<TipoAuditoriaRecord>
	{	
		public TipoAuditoriaMap()
		{
			Table("`TipoAuditoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`TipoAuditoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidClaseAuditoria, map => { map.Column("`OID_CLASE_AUDITORIA`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.Documentacion, map => { map.Column("`DOCUMENTACION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Apreciaciones, map => { map.Column("`APRECIACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Numero, map => { map.Column("`NUMERO`");	map.Length(255);  });
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
			Property(x => x.TextoInforme, map => { map.Column("`TEXTO_INFORME`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
