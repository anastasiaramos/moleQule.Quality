using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Quality
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class NotificacionesInternas : BusinessListBaseEx<NotificacionesInternas, NotificacionInterna>
    {

        #region Business Methods

        public NotificacionInterna NewItem(Auditoria parent)
        {
            this.AddItem(NotificacionInterna.NewChild(parent));
            return this[Count - 1];
        }

        public NotificacionInterna NewItem(InformeDiscrepancia parent)
        {
            this.AddItem(NotificacionInterna.NewChild(parent));
            return this[Count - 1];
        }

        public NotificacionInterna NewItem(InformeCorrector parent)
        {
            this.AddItem(NotificacionInterna.NewChild(parent));
            return this[Count - 1];
        }

        public NotificacionInterna NewItem(InformeAmpliacion parent)
        {
            this.AddItem(NotificacionInterna.NewChild(parent));
            return this[Count - 1];
        }
		
        #endregion

        #region Factory Methods

        private NotificacionesInternas()
        {
            MarkAsChild();
        }

        private NotificacionesInternas(IList<NotificacionInterna> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private NotificacionesInternas(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }


        public static NotificacionesInternas NewChildList() { return new NotificacionesInternas(); }

        public static NotificacionesInternas GetChildList(IList<NotificacionInterna> lista) { return new NotificacionesInternas(lista); }

        public static NotificacionesInternas GetChildList(IDataReader reader, bool childs) { return new NotificacionesInternas(reader, childs); }

        public static NotificacionesInternas GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<NotificacionInterna> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (NotificacionInterna item in lista)
                this.AddItem(NotificacionInterna.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(NotificacionInterna.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }

		
        internal void Update(Auditoria parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (NotificacionInterna obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (NotificacionInterna obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }
			
            this.RaiseListChangedEvents = true;
        }


        internal void Update(InformeDiscrepancia parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (NotificacionInterna obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (NotificacionInterna obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }


        internal void Update(InformeCorrector parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (NotificacionInterna obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (NotificacionInterna obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }


        internal void Update(InformeAmpliacion parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (NotificacionInterna obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (NotificacionInterna obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }
		

        #endregion

        #region SQL

        public static string SELECT_BY_AUDITORIA(long oid_auditoria, TipoNotificacionAsociado tipo)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Auditoria = AuditoriaInfo.New(),
                TipoNotificacionAsociado = tipo
            };

            conditions.Auditoria.Oid = oid_auditoria;

            return NotificacionInterna.SELECT(conditions, true);
        }

        public static string SELECT_BY_INFORME_AMPLIACION(long oid_informe_ampliacion, TipoNotificacionAsociado tipo)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeAmpliacion = InformeAmpliacionInfo.New(),
                TipoNotificacionAsociado = tipo
            };

            conditions.InformeAmpliacion.Oid = oid_informe_ampliacion;

            return NotificacionInterna.SELECT(conditions, true);
        }

        public static string SELECT_BY_INFORME_CORRECTOR(long oid_informe_corrector, TipoNotificacionAsociado tipo)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeCorrector = InformeCorrectorInfo.New(),
                TipoNotificacionAsociado = tipo
            };

            conditions.InformeCorrector.Oid = oid_informe_corrector;

            return NotificacionInterna.SELECT(conditions, true);
        }

        public static string SELECT_BY_INFORME_DISCREPANCIA(long oid_informe_discrepancia, TipoNotificacionAsociado tipo)
        {
            QueryConditions conditions = new QueryConditions()
            {
                InformeDiscrepancia = InformeDiscrepanciaInfo.New(),
                TipoNotificacionAsociado = tipo
            };

            conditions.InformeDiscrepancia.Oid = oid_informe_discrepancia;

            return NotificacionInterna.SELECT(conditions, true);
        }

        //public static string SELECT_BY_FIELD(string field, object value, TipoNotificacionAsociado tipo)
        //{
        //    string query = SELECT_BY_FIELD(field, value);

        //    switch (tipo)
        //    {
        //        case TipoNotificacionAsociado.COMUNICADO_AUDITORIA:
        //        case TipoNotificacionAsociado.INFORME_DISCREPANCIAS:
        //        case TipoNotificacionAsociado.CONCESION_AMPLIACION:
        //        case TipoNotificacionAsociado.DENEGACION_AMPLIACION:
        //        case TipoNotificacionAsociado.INFORME_ACCIONES_CORRECTORAS:
        //        case TipoNotificacionAsociado.INFORME_FIN_AUDITORIA:
        //        case TipoNotificacionAsociado.SOLICITUD_AMPLIACION:
        //            {
        //                int pos = query.IndexOf(';');
        //                if (pos != -1)
        //                    query = query.Substring(0, pos);
        //                query += " AND \"TIPO_ASOCIADO\" = " + ((long)tipo).ToString() + ";";
        //            } break;
        //    }

        //    return query;
        //}

        //public static string SELECT_BY_FIELD(string field, object value, string order_field, TipoNotificacionAsociado tipo)
        //{
        //    string query = SELECT_BY_FIELD(field, value);
        //    string columna = nHManager.Instance.GetTableField(typeof(NotificacionInterna), order_field);

        //    switch (tipo)
        //    {
        //        case TipoNotificacionAsociado.COMUNICADO_AUDITORIA:
        //            {
        //                query = query.Substring(0, query.Length - 1);
        //                query += " AND \"TIPO_ASOCIADO\" = " + ((long)tipo).ToString() + ";";
        //            } break;
        //    }

        //    query = query.Substring(0, query.Length - 1);
        //    query += " ORDER BY \"" + columna + "\";";

        //    return query;
        //}


        #endregion

    }
}
