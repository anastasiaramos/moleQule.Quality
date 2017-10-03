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
    public class AuditoriaPrint : AuditoriaInfo
    {

        #region Business Methods

        //NUEVO
        private string _titulo_informe = string.Empty;
        private string _numero_clase_auditoria = string.Empty;
        private string _nombre_clase_auditoria = string.Empty;
        private string _nombre_clase_auditoria_upper = string.Empty;
        private string _codigo_tipo_auditoria = string.Empty;
        private string _nombre_tipo_auditoria = string.Empty;
        private string _nombre_tipo_auditoria_upper = string.Empty;
        private System.Byte[] _logo_emp;
        private string _texto_pie;
        private string _fecha_inicio_string = string.Empty;
        private string _fecha_fin_string = string.Empty;
        private string _areas = string.Empty;
        private string _documentacion = string.Empty;
        private string _apreciaciones = string.Empty;

        public string TituloInforme { get { return _titulo_informe; } }
        public string NumeroClaseAuditoria { get { return _numero_clase_auditoria; } }
        public string NombreClaseAuditoria { get { return _nombre_clase_auditoria; } }
        public string NombreClaseAuditoriaUpper { get { return _nombre_clase_auditoria_upper; } }
        public string CodigoTipoAuditoria { get { return _codigo_tipo_auditoria; } }
        public string NombreTipoAuditoria { get { return _nombre_tipo_auditoria; } }
        public string NombreTipoAuditoriaUpper { get { return _nombre_tipo_auditoria_upper; } }
        public System.Byte[] LogoEmp { get { return _logo_emp; } }
        public string TextoPie { get { return _texto_pie; } }
        public string FechaInicioString { get { return _fecha_inicio_string; } }
        public string FechaFinString { get { return _fecha_fin_string; } }
        public string Areas { get { return _areas; } set { _areas = value; } }
        public string Documentacion { get { return _documentacion; } set { _documentacion = value; } }
        public string Apreciaciones { get { return _apreciaciones; } set { _apreciaciones = value; } }

        //FIN NUEVO

        private string _telefono = string.Empty;
        private string _email = string.Empty;
        private string _depto_auditor = string.Empty;
        private string _fax_auditor = string.Empty;
        private string _depto_responsable = string.Empty;
        private string _fax_responsable = string.Empty;
        private string _comentarios = string.Empty;
        private string _asunto = string.Empty;
        private string _fecha = string.Empty;

        private new CuestionAuditoriaList _cuestiones;
        private new InformeDiscrepanciaList _informes;
        private new HistoriaAuditoriaList _historial;

        public string Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string DeptoAuditor { get { return _depto_auditor; } set { _depto_auditor = value; } }
        public string FaxAuditor { get { return _fax_auditor; } set { _fax_auditor = value; } }
        public string DeptoResponsable { get { return _depto_responsable; } set { _depto_responsable = value; } }
        public string FaxResponsable { get { return _fax_responsable; } set { _fax_responsable = value; } }
        public string Comentarios { get { return _comentarios; } set { _comentarios = value; } }
        public string Asunto { get { return _asunto; } set { _asunto = value; } }

        public override CuestionAuditoriaList Cuestiones { get { return _cuestiones; } }
        public override InformeDiscrepanciaList Informes { get { return _informes; } }
        public override HistoriaAuditoriaList Historial
        {
            get
            {
                return _historial;
            }
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(CompanyInfo empresa, AuditoriaInfo source, ClaseAuditoriaInfo clase, TipoAuditoriaInfo tipo)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidAuditor = source.OidAuditor;
            _base.Record.OidTipoAuditoria = source.OidTipoAuditoria;
            _base.Record.OidPlan = source.OidPlan;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Serial = source.Serial;
            _base.Record.OidResponsable = source.OidResponsable;
            _base.Record.FechaInicio = source.FechaInicio;
            _base.Record.FechaFin = source.FechaFin;
            _base.Record.Referencia = source.Referencia;
            _base.Record.Estado = source.Estado;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.OidDepartamentoAuditor = source.OidDepartamentoAuditor;
            _base.Record.OidDepartamentoResponsable = source.OidDepartamentoResponsable;
            _base.Auditor = source.Auditor;
            _base.Responsable = source.Responsable;

            _cuestiones = source.Cuestiones;
            _informes = source.Informes;
            _historial = source.Historial;

            _titulo_informe = "INFORME DE AUDITORÍA";
            if (clase != null)
            {
                _numero_clase_auditoria = clase.Numero.ToString();
                _nombre_clase_auditoria = clase.Nombre;
                _nombre_clase_auditoria_upper = clase.Nombre.ToUpper();
            }
            if (tipo != null)
            {
                _codigo_tipo_auditoria = tipo.Numero;
                _nombre_tipo_auditoria = tipo.Nombre;
                _nombre_tipo_auditoria_upper = _nombre_tipo_auditoria.ToUpper();


                foreach (Auditoria_AreaInfo item in tipo.Areas)
                {
                    AreaInfo area = AreaInfo.Get(item.OidArea);
                    _areas += area.Nombre;
                    if (tipo.Areas.IndexOf(item) != tipo.Areas.Count - 1)
                        _areas += ", ";
                }

                _documentacion = tipo.Documentacion;
                _apreciaciones = tipo.Apreciaciones;
            }

            _fecha_inicio_string = FechaInicio.ToShortDateString();
            _fecha_fin_string = FechaFin.ToShortDateString();

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

        private AuditoriaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static AuditoriaPrint New(AuditoriaInfo source, ClaseAuditoriaInfo clase, TipoAuditoriaInfo tipo, CompanyInfo empresa)
        {
            AuditoriaPrint item = new AuditoriaPrint();
            item.CopyValues(empresa, source, clase, tipo);

            return item;
        }

        #endregion

    }
}
