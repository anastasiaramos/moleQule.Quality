using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
	/// <summary>
	/// ReadOnly Root Object
	/// ReadOnly Child Object
	/// </summary>
	[Serializable()]
	public class IncidenciaInfo : ReadOnlyBaseEx<IncidenciaInfo>
    {
        #region Attributes

        protected IncidenciaBase _base = new IncidenciaBase();


        #endregion

        #region Properties

        public IncidenciaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAgente { get { return _base.Record.OidAgente; } }
        public string TipoAgente { get { return _base.Record.TipoAgente; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public string Agente { get { return _base.Agente; } /*set { _agente = value; }*/ }



        #endregion

        #region Business Methods

        public void CopyFrom(Incidencia source) { _base.CopyValues(source); }

        #endregion		
		
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		protected IncidenciaInfo() { /* require use of factory methods */ }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		private IncidenciaInfo(IDataReader reader, bool retrieve_childs)
		{
			Childs = retrieve_childs;
			Fetch(reader);
		}
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="BusinessBaseEx"/> origen</param>
        /// <param name="copy_childs">Flag para copiar los hijos</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		internal IncidenciaInfo(Incidencia item, bool copy_childs)
		{
			_base.CopyValues(item);
			
			if (copy_childs)
			{
				
			}
		}
	
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>
		/// NO OBTIENE los datos de los hijos. Para ello utiliza GetChild(IDataReader reader, bool retrieve_childs)
		/// La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista
		/// <remarks/>
		public static IncidenciaInfo GetChild(IDataReader reader)
        {
			return GetChild(reader, false);
		}
		
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
		/// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
		/// <remarks>La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista<remarks/>
		public static IncidenciaInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
			return new IncidenciaInfo(reader, retrieve_childs);
		}
		
 		#endregion
		
		#region Root Factory Methods
		
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> de la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        public static IncidenciaInfo Get(long oid)
        {
            return Get(oid, false);
        }
		
        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> de la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
		/// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
		public static IncidenciaInfo Get(long oid, bool retrieve_childs)
		{
			CriteriaEx criteria = Incidencia.GetCriteria(Incidencia.OpenSession());
			criteria.Childs = retrieve_childs;

			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = IncidenciaInfo.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
	
			IncidenciaInfo obj = DataPortal.Fetch<IncidenciaInfo>(criteria);
			Incidencia.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		#endregion
		
		#region Root Data Access
		 
        /// <summary>
        /// Obtiene un registro de la base de datos
        /// </summary>
        /// <param name="criteria"><see cref="CriteriaEx"/> con los criterios</param>
        /// <remarks>
        /// La llama el DataPortal
        /// </remarks>
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			
			try
			{
				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
		
					if (reader.Read())
						_base.CopyValues(reader);
					
				}
				else
				{
                    _base.Record.CopyValues((IncidenciaRecord)(criteria.UniqueResult()));
					
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion
		
		#region Child Data Access
		
        /// <summary>
        /// Obtiene un objeto a partir de un <see cref="IDataReader"/>.
        /// Obtiene los hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria"><see cref="IDataReader"/> con los datos</param>
        /// <remarks>
        /// La utiliza el <see cref="ReadOnlyListBaseEx"/> correspondiente para construir los objetos de la lista
        /// </remarks>
		private void Fetch(IDataReader source)
		{
			try
			{
				_base.CopyValues(source);
				
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion

        #region SQL

        public static string SELECT(long oid)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(IncidenciaRecord));
            string inner1 = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string inner2 = nHManager.Instance.GetSQLTable(typeof(InstructorRecord));

            string query = string.Empty;

            query = "SELECT c.*, i1.\"NOMBRE\" ||' '|| i1.\"APELLIDOS\" AS \"AGENTE\"" +
           " FROM " + tabla + " AS c" +
           " INNER JOIN " + inner1 + " AS i1 ON c.\"OID_AGENTE\" = i1.\"OID\"" +
           " WHERE c.\"TIPO_AGENTE\" = '" + (ETipoAgente.Alumno).ToString() + "'";
            if (oid > 0)
                query += "AND  c.\"OID\" = '" + oid.ToString() + "'";

            query += " UNION" +
            " SELECT c.*, i2.\"NOMBRE\" || ' ' ||i2.\"APELLIDOS\" AS \"AGENTE\"" +
            " FROM " + tabla + " AS c" +
            " INNER JOIN " + inner2 + " AS i2 ON c.\"OID_AGENTE\" = i2.\"OID\"" +
            " WHERE c.\"TIPO_AGENTE\" = '" + (ETipoAgente.Instructor).ToString() + "'";
            if (oid > 0)
                query += "AND  c.\"OID\" = '" + oid.ToString() + "'";

            return query;
        }

        #endregion
    }
}
