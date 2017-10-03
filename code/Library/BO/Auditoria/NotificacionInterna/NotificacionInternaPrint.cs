using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library.Common;
using moleQule.Library.Instruction;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class NotificacionInternaPrint : NotificacionInternaInfo
    {

        #region Business Methods

        //Asociado a la auditoría
        private string _telefono = string.Empty;
        private string _email = string.Empty;
        private string _depto_auditor = string.Empty;
        private string _fax_auditor = string.Empty;
        private string _depto_responsable = string.Empty;
        private string _fax_responsable = string.Empty;
        private string _areas = string.Empty;
        private string _numero_auditoria = string.Empty;
        private string _nombre_auditoria = string.Empty;
        protected string _auditor = string.Empty;
        protected string _responsable = string.Empty;

        //Asociado a la notificación
        private string _fecha_notificacion = string.Empty;
        private string _otros = string.Empty;
        private string _titulo = string.Empty;
        //private string _texto_propio_notificacion = string.Empty;

        //General
        private System.Byte[] _logo_emp;
        private string _texto_pie = string.Empty;


        public string Telefono { get { return _telefono; } }
        public string Email { get { return _email; } }
        public string DeptoAuditor { get { return _depto_auditor; } }
        public string FaxAuditor { get { return _fax_auditor; } }
        public string DeptoResponsable { get { return _depto_responsable; } }
        public string FaxResponsable { get { return _fax_responsable; } }
        public string Areas { get { return _areas; } }
        public string NumeroAuditoria { get { return _numero_auditoria; } }
        public string NombreAuditoria { get { return _nombre_auditoria; } }
        public string Auditor { get { return _auditor; } }
        public string Responsable { get { return _responsable; } }

        public string FechaNotificacion { get { return _fecha_notificacion; } }
        public string Otros { get { return _otros; } }
        public string Titulo { get { return _titulo; } }
        //public string TextoPropioNotificacion { get { return _texto_propio_notificacion; }}

        public System.Byte[] LogoEmp { get { return _logo_emp; } }
        public string TextoPie { get { return _texto_pie; } }
 
        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(NotificacionInternaInfo item, AuditoriaInfo source,
                                    InstructorList instructores, CompanyInfo empresa)
        {
            if (source == null) return;

            Oid = item.Oid;
            _base.Record.OidAsociado = item.OidAsociado;
            _base.Record.TipoAsociado = item.TipoAsociado;
            _base.Record.Serial = item.Serial;
            _base.Record.Codigo = item.Codigo;
            _base.Record.Numero = item.Numero;
            _base.Record.Fecha = item.Fecha;
            _base.Record.Comentarios = item.Comentarios;
            _base.Record.Asunto = item.Asunto;
            _base.Record.Atencion = item.Atencion;
            _base.Record.Copia = item.Copia;
            _fecha_notificacion = item.Fecha.ToShortDateString();
            _otros = item.Asunto;
            _titulo = "COMUNICADO DE AUDITORIA";

            if (source.Responsable == string.Empty)
            {
                InstructorInfo instructor = instructores.GetItem(source.OidResponsable);
                if (instructor != null)
                    _responsable = instructor.Nombre;
            }
            else
                _responsable = source.Responsable;

            if (source.Auditor == string.Empty)
            {
                InstructorInfo instructor = instructores.GetItem(source.OidAuditor);
                if (instructor != null)
                    _auditor = instructor.Nombre;
            }
            else
                _auditor = source.Auditor;


            DepartamentoList departamentos = DepartamentoList.GetList();

            if (source.OidDepartamentoAuditor != 0)
            {
                DepartamentoInfo depto = departamentos.GetItem(source.OidDepartamentoAuditor);
                if (depto != null)
                {
                    _depto_auditor = depto.Nombre;
                    _fax_auditor = depto.Fax;
                }
            }

            if (source.OidDepartamentoResponsable != 0)
            {
                DepartamentoInfo depto = departamentos.GetItem(source.OidDepartamentoResponsable);
                if (depto != null)
                {
                    _depto_responsable = depto.Nombre;
                    _fax_responsable = depto.Fax;
                    _telefono = depto.Telefonos;
                    _email = depto.Email;
                }
            }

            TipoAuditoriaInfo tipo = TipoAuditoriaInfo.Get(source.OidTipoAuditoria,true);
            if (tipo != null)
            {
                _numero_auditoria = source.Codigo;
                _nombre_auditoria = " _(" + tipo.Numero + ") " + tipo.Nombre;
                AreaList areas = AreaList.GetList(false);
                
                foreach (Auditoria_AreaInfo info in tipo.Areas)
                {
                    AreaInfo area = areas.GetItem(info.OidArea);
                    if (area != null)
                    {
                        if (_areas != string.Empty)
                            _areas += ", ";
                        _areas = area.Nombre;
                    }
                }
            }

            if (empresa == null) return;

            string path = Library.Common.ModuleController.LOGOS_EMPRESAS_PATH + empresa.Logo;

            // Cargamos la imagen en el buffer
            if (File.Exists(path))
            {
                //Declaramos fs para poder abrir la imagen.
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                // Declaramos un lector binario para pasar la imagen a bytes
                BinaryReader br = new BinaryReader(fs);
                _logo_emp = new byte[(int)fs.Length];
                br.Read(LogoEmp, 0, (int)fs.Length);
                br.Close();
                fs.Close();
            }

            _texto_pie = empresa.Direccion +
                " C.P " + empresa.CodPostal.ToString() +
                " " + empresa.Municipio +
                " " + empresa.Provincia +
                " tfno: " + empresa.Telefonos;

        }


        #endregion

        #region Factory Methods

        private NotificacionInternaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static NotificacionInternaPrint New(NotificacionInternaInfo source, AuditoriaInfo auditoria,
                                        InstructorList instructores, CompanyInfo empresa)
        {
            NotificacionInternaPrint item = new NotificacionInternaPrint();
            item.CopyValues(source, auditoria, instructores, empresa);

            return item;
        }

        #endregion

    }
}
