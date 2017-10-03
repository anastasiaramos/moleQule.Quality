using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Quality
{
	/// <summary>
	/// Editable Business Object Root Collection
	/// </summary>
    [Serializable()]
    public class Incidencias : BusinessListBaseEx<Incidencias, Incidencia>
    {
		
		#region Root Business Methods
        
		/// <summary>
        /// Crea y añade un nuevo elemento a la lista principal
        /// El elemento SE CREARA en la tabla correspondiente cuando se guarde la lista
        /// </summary>
        public Incidencia NewItem()
        {
            this.AddItem(Incidencia.NewChild());
            return this[Count - 1];
        }

        #endregion
		
		#region Common Factory Methods

		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
        private Incidencias() { }

		#endregion		
		
		#region Root Factory Methods
		
        /// <summary>
        /// Crea una nueva lista vacía
        /// </summary>
        /// <returns>Lista vacía</returns>
        public static Incidencias NewList() 
		{ 	
			if (!Incidencia.CanAddObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new Incidencias(); 
		}

        /// <summary>
        /// Obtiene de la base de datos todos los elementos y construye la lista
        /// </summary>
        /// <returns>Lista de los elementos de la tabla en la base de datos</returns>
        /// <remarks>No obtiene los hijos de los elementos de la lista</remarks>
        public static Incidencias GetList() { return GetList(false); }

        /// <summary>
        /// Obtiene de la base de datos todos los elementos y construye la lista
        /// </summary>
		/// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        /// <returns>Lista de los elementos de la tabla en la base de datos</returns>
        public static Incidencias GetList(bool retrieve_childs)
        {
            if (!Incidencia.CanEditObject())
				throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Incidencia.GetCriteria(Incidencia.OpenSession());
			criteria.Childs = retrieve_childs;
			
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Incidencias.SELECT();
            
            Incidencia.BeginTransaction(criteria.SessionCode);

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<Incidencias>(criteria);
        }

        #endregion
		
		#region Root Data Access

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        /// <remarks>LA UTILIZA EL DATAPORTAL</remarks>
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

		/// <summary>
		/// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        private void Fetch(CriteriaEx criteria)
        {
            try
            {
				this.RaiseListChangedEvents = false;
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
                {
                    Incidencia.DoLOCK( Session());

                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                        this.AddItem(Incidencia.GetChild(reader, Childs));
                }
                else
                {
                    IList list = criteria.List();

                    foreach (Incidencia item in list)
                    {
                        //Bloqueamos todos los elementos de la lista
                        Session().Lock(Session().Get<IncidenciaRecord>(item.Oid), LockMode.UpgradeNoWait);
                        this.AddItem(Incidencia.GetChild(item, Childs));
                    }
                }

            }
            catch (NHibernate.ADOException ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.ThrowExceptionByCode(ex);
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                this.RaiseListChangedEvents = true;
            }
        }

        /// <summary>
        /// Realiza el Save de los objetos de la lista. Inserta, Actualiza o Borra en función
		/// de los flags de cada objeto de la lista
		/// </summary>
		/// <param name="reader">IDataReader origen</param>
        protected override void DataPortal_Update()
        {
            bool success = false;

            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Incidencia obj in DeletedList)
                obj.DeleteSelf(this);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            try
            {
				// add/update any current child objects
				foreach (Incidencia obj in this)
				{
					if (!this.Contains(obj))
					{
						if (obj.IsNew)
							obj.Insert(this);
						else
							obj.Update(this);
					}
				}

                Transaction().Commit();

                success = true;
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                if (!success)
                    if (Transaction() != null) Transaction().Rollback();

                BeginTransaction();
                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region SQL

        public new static string SELECT() { return Incidencia.SELECT(0); }

        #endregion
    }
}

