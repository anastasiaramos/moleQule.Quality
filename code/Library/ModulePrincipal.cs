using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;

using moleQule.Library;
using moleQule.Library.Quality.Properties;

namespace moleQule.Library.Quality
{
    [Serializable()]
    public class ModulePrincipal
    {
        #region Application Settings

        public static void SaveSettings() { Settings.Default.Save(); }

        public static void UpgradeSettings()
        {
            Assembly ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            Version ver = ensamblado.GetName().Version;

            if (Properties.Settings.Default.MODULE_VERSION != ver.ToString())
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.MODULE_VERSION = ver.ToString();
            }
        }

        public static string GetDBVersion() { return Settings.Default.DB_VERSION; }

        #endregion

        #region Schema Settings

        public static long GetAvisoDiscrepanciasAbiertasSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_AVISO_DISCREPANCIAS_ABIERTAS)); }
            catch { return 0; }
        }
        public static void SetAvisoDiscrepanciasAbiertasSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_AVISO_DISCREPANCIAS_ABIERTAS, value.ToString());
        }

        public static long GetPlazoMaximoAmpliacionSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_AMPLIACION)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoAmpliacionSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_AMPLIACION, value.ToString());
        }

        public static long GetPlazoMaximoDiscrepanciasN1Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N1)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoDiscrepanciasN1Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N1, value.ToString());
        }

        public static long GetPlazoMaximoDiscrepanciasN2Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N2)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoDiscrepanciasN2Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N2, value.ToString());
        }

        public static long GetPlazoMaximoDiscrepanciasN3Setting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N3)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoDiscrepanciasN3Setting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_DISCREPANCIAS_N3, value.ToString());
        }

        public static long GetPlazoMaximoGeneracionInformeSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_GENERACION_INFORME)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoGeneracionInformeSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_GENERACION_INFORME, value.ToString());
        }

        public static long GetPlazoMaximoNotificacionDiscrepanciasSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoNotificacionDiscrepanciasSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_DISCREPANCIAS, value.ToString());
        }

        public static long GetPlazoMaximoNotificacionFinAuditoriaSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA)); }
            catch { return 0; }
        }
        public static void SetPlazoMaximoNotificacionFinAuditoriaSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_NOTIFICACION_FIN_AUDITORIA, value.ToString());
        }

        public static long GetPlazoMaximoRespuestaAmpliacionSetting()
        {
            try { return Convert.ToInt64(SettingsMng.Instance.SchemaSettings.GetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_RESPUESTA_AMPLIACION)); }
            catch { return 0; }
        }
        public static void SetPazoMaximoRespuestaAmpliacionSetting(long value)
        {
            SettingsMng.Instance.SchemaSettings.SetValue(Settings.Default.SETTING_NAME_PLAZO_MAXIMO_RESPUESTA_AMPLIACION, value.ToString());
        }

        #endregion

        #region User Settings

        //AUDITORIAS
        public static void SetNotifyAuditorias(bool value)
        {
            SettingsMng.Instance.UserSettings.SetValue(Settings.Default.SETTING_NAME_NOTIFY_AUDITORIAS, value.ToString());
        }
        public static bool GetNotifyAuditorias()
        {
            try { return Convert.ToBoolean(SettingsMng.Instance.UserSettings.GetValue(Settings.Default.SETTING_NAME_NOTIFY_AUDITORIAS)); }
            catch { return false; }
        }

        public static void SetNotifyPlazoAuditorias(decimal value)
        {
            SettingsMng.Instance.UserSettings.SetValue(Settings.Default.SETTING_NAME_NOTIFY_PLAZO_AUDITORIAS, value.ToString());
        }
        public static int GetNotifyPlazoAuditorias()
        {
            try { return Convert.ToInt32(SettingsMng.Instance.UserSettings.GetValue(Settings.Default.SETTING_NAME_NOTIFY_PLAZO_AUDITORIAS)); }
            catch { return 0; }
        }

        #endregion
    }
}