using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using moleQule.Library.CslaEx;
using moleQule.Library;
using moleQule.Library.Quality.Properties;

namespace moleQule.Library.Quality
{

	[Serializable()]
	public class ModuleController
	{
		#region Attributes & Properties
        
		#endregion

		#region Factory Methods

		/// <summary>
		/// Única instancia de la clase ControlerBase (Singleton)
		/// </summary>
		protected static ModuleController _main;

		/// <summary>
		/// Unique Controler Class Instance
		/// </summary>
		public static ModuleController Instance { get { return (_main != null) ? _main : new ModuleController(); } }

		/// <summary>
		/// Contructor 
		/// </summary>
		protected ModuleController()
		{
			// Singleton
			_main = this;

			Init();
		}

		private void Init()
		{
		}

        public static void CheckDBVersion()
        {
            ApplicationSettingInfo dbVersion = ApplicationSettingInfo.Get(Settings.Default.DB_VERSION_VARIABLE);

            //Version de base de datos equivalente o no existe la variable
            if ((dbVersion.Value == string.Empty) ||
                (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) == 0))
            {
                return;
            }
            //Version de base de datos superior
            else if (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) > 0)
            {
                throw new iQException(String.Format(Library.Resources.Messages.DB_VERSION_HIGHER,
                                                    dbVersion.Value,
                                                    ModulePrincipal.GetDBVersion(),
                                                    Settings.Default.NAME),
                                                    iQExceptionCode.DB_VERSION_MISSMATCH);
            }
            //Version de base de datos inferior
            else if (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) < 0)
            {
                throw new iQException(String.Format(Library.Resources.Messages.DB_VERSION_LOWER,
                                                    dbVersion.Value,
                                                    ModulePrincipal.GetDBVersion(),
                                                    Settings.Default.NAME),
                                                    iQExceptionCode.DB_VERSION_MISSMATCH);
            }
        }

        public static void UpgradeSettings() { ModulePrincipal.UpgradeSettings(); }

        #endregion

        #region Variables

        public static string GetAvisoDiscrepanciasAbiertasVariableName()
        {
            return Settings.Default.SETTING_NAME_AVISO_DISCREPANCIAS_ABIERTAS;
        }

        public static string GetPlazoMaximoAmpliacionVariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_AMPLIACION;
        }

        public static string GetPlazoMaximoDiscrepanciasN1VariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N1;
        }

        public static string GetPlazoMaximoDiscrepanciasN2VariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N2;
        }


        public static string GetPlazoMaximoDiscrepanciasN3VariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N3;
        }

        public static string GetPlazoMaximoGeneracionInformeVariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_GENERACION_INFORME;
        }

        public static string GetPlazoMaximoNotificacionDiscrepanciasVariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS;
        }

        public static string GetPlazoMaximoNotificacionFinAuditoriaVariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA;
        }

        public static string GetPlazoMaximoRespuestaAmpliacionVariableName()
        {
            return Settings.Default.SETTING_NAME_PLAZO_MAXIMO_RESPUESTA_AMPLIACION;
        }

        #endregion

        #region Settings

        #endregion

        #region Business Methods

        public void AutoPilot()
        {
            //ShowApuntesPendientes();
        }

		#endregion

        #region Scripts

        public static AuditoriaList GetAvisoDiscrepanciasAbiertas()
        {
            DateTime f_fin = DateTime.Today.AddDays((double)Library.Quality.ModulePrincipal.GetAvisoDiscrepanciasAbiertasSetting());
            AuditoriaList list = AuditoriaList.GetAvisoDiscrepanciasAbiertasList(f_fin);

            return list;
        }

        public static AuditoriaList GetAvisoGeneracionInforme()
        {
            DateTime f_fin = DateTime.Today.AddDays((double)Library.Quality.ModulePrincipal.GetNotifyPlazoAuditorias());
            AuditoriaList list = AuditoriaList.GetAvisoInformesNoGenerados(f_fin);

            return list;
        }

        #endregion
    }

    public class ModuleDef : IModuleDef
    {
        public string Name { get { return "Quality"; } }
        public Type Type { get { return typeof(Library.Quality.ModuleController); } }
        public Type[] Mappings
        {
            get
            {
                return new Type[] 
                {   
					typeof(AccionCorrectoraMap),
					typeof(ActaComiteMap),
					typeof(AmpliacionMap),
					typeof(AreaMap),
					typeof(AuditoriaMap),
					typeof(Auditoria_AreaMap),
					typeof(ClaseAuditoriaMap),
					typeof(CriterioMap),
					typeof(CuestionMap),
					typeof(CuestionAuditoriaMap),
					typeof(DepartamentoMap),
					typeof(DiscrepanciaMap),
					typeof(HistoriaAuditoriaMap),
					typeof(IncidenciaMap),
					typeof(InformeAmpliacionMap),
					typeof(InformeCorrectorMap),
					typeof(InformeDiscrepanciaMap),
                    typeof(NotificacionInternaMap),
					typeof(Plan_TipoMap),
					typeof(PlanAnualMap),
					typeof(PuntoActaMap),
					typeof(TipoAuditoriaMap)
                };
            }
        }

        public void GetEntities(Dictionary<Type, Type> recordEntities)
        {
            if (recordEntities.ContainsKey(typeof(AccionCorrectora))) return;

            recordEntities.Add(typeof(AccionCorrectora), typeof(AccionCorrectoraRecord));
            recordEntities.Add(typeof(ActaComite), typeof(ActaComiteRecord));
            recordEntities.Add(typeof(Ampliacion), typeof(AmpliacionRecord));
            recordEntities.Add(typeof(Area), typeof(AreaRecord));
            recordEntities.Add(typeof(Auditoria), typeof(AuditoriaRecord));
            recordEntities.Add(typeof(Auditoria_Area), typeof(Auditoria_AreaRecord));
            recordEntities.Add(typeof(ClaseAuditoria), typeof(ClaseAuditoriaRecord));
            recordEntities.Add(typeof(Criterio), typeof(CriterioRecord));
            recordEntities.Add(typeof(Cuestion), typeof(CuestionRecord));
            recordEntities.Add(typeof(CuestionAuditoria), typeof(CuestionAuditoriaRecord));
            recordEntities.Add(typeof(Departamento), typeof(DepartamentoRecord));
            recordEntities.Add(typeof(Discrepancia), typeof(DiscrepanciaRecord));
            recordEntities.Add(typeof(HistoriaAuditoria), typeof(HistoriaAuditoriaRecord));
            recordEntities.Add(typeof(Incidencia), typeof(IncidenciaRecord));
            recordEntities.Add(typeof(InformeAmpliacion), typeof(InformeAmpliacionRecord));
            recordEntities.Add(typeof(InformeCorrector), typeof(InformeCorrectorRecord));
            recordEntities.Add(typeof(InformeDiscrepancia), typeof(InformeDiscrepanciaRecord));
            recordEntities.Add(typeof(NotificacionInterna), typeof(NotificacionInternaRecord));
            recordEntities.Add(typeof(Plan_Tipo), typeof(Plan_TipoRecord));
            recordEntities.Add(typeof(PlanAnual), typeof(PlanAnualRecord));
            recordEntities.Add(typeof(PuntoActa), typeof(PuntoActaRecord));
            recordEntities.Add(typeof(TipoAuditoria), typeof(TipoAuditoriaRecord));
        }
    }
}
