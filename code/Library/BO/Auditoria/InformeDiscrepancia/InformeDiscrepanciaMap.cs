using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Quality
{
	[Serializable()]
	public class InformeDiscrepanciaMap : ClassMapping<InformeDiscrepanciaRecord>
	{	
		public InformeDiscrepanciaMap()
		{
			Table("`InformeDiscrepancia`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`InformeDiscrepancia_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAuditoria, map => { map.Column("`OID_AUDITORIA`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Notificado, map => { map.Column("`NOTIFICADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Titulo, map => { map.Column("`TITULO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaCreacion, map => { map.Column("`FECHA_CREACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaComunicacion, map => { map.Column("`FECHA_COMUNICACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.Length(32768); });
					}
	}
}
