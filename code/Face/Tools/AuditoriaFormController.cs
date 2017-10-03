using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Quality;

namespace moleQule.Face.Quality.Tools
{
    class AuditoriaFormController
    {
        public static bool IsActionEnabled(Auditoria auditoria, AccionAuditoria accion)
        {
            return IsActionEnabled(auditoria, accion, -1);
        }
        /// <summary>
        /// Función que determina si la acción indicada puede ser llevada a cabo en la auditoría actual
        /// en función del estado de la misma
        /// </summary>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static bool IsActionEnabled(Auditoria auditoria, AccionAuditoria accion, long oid_auxiliar)
        {
            try
            {
                if (!AuditoriaController.IsActionEnabled(auditoria, accion, oid_auxiliar))
                {
                    MessageBox.Show(string.Format(Resources.Messages.NOT_ENABLED_ACTION,
                        ((AccionAuditoria)accion).ToString().Replace('_', ' '),
                        ((EstadoAuditoria)auditoria.Estado).ToString()), moleQule.Face.Resources.Labels.ADVISE_TITLE);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void DoAction(Auditoria auditoria, AccionAuditoria accion)
        {
            DoAction(auditoria, accion, -1);
        }

        /// <summary>
        /// Función que determina si la acción indicada puede ser llevada a cabo en la auditoría actual
        /// en función del estado de la misma
        /// </summary>
        /// <param name="accion"></param>
        /// <returns></returns>
        public static void DoAction(Auditoria auditoria, AccionAuditoria accion, long oid_auxiliar)
        {
            try
            {
                if (IsActionEnabled(auditoria, accion, oid_auxiliar))
                    AuditoriaController.DoAction(auditoria, accion, oid_auxiliar);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
