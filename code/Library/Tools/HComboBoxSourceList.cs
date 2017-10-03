using System;
using System.Collections.Generic;
using System.Text;

using moleQule.Library;

namespace moleQule.Library.Quality
{
    public class HComboBoxSourceList : ComboBoxSourceList
    {
        public HComboBoxSourceList() { }

        public HComboBoxSourceList(AreaList lista)
        {
            this.AddEmptyItem();
            foreach (AreaInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }
        
        public HComboBoxSourceList(DepartamentoList lista)
        {
            this.AddEmptyItem();
            foreach (DepartamentoInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }
        
        public HComboBoxSourceList(ClaseAuditoriaList lista, bool empty_item)
        {
            if (empty_item) this.AddEmptyItem();
            foreach (ClaseAuditoriaInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Numero + " " + item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }

        }

        public HComboBoxSourceList(ClaseAuditoriaList lista)
        :this (lista, true){}

        public HComboBoxSourceList(PlanAnualList lista)
        {
            this.AddEmptyItem();
            foreach (PlanAnualInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Nombre;
                combo.Oid = item.Oid;

                this.Add(combo);
            }
        }

        public HComboBoxSourceList(TipoAuditoriaList lista)
        :this(lista, true){}

        public HComboBoxSourceList(TipoAuditoriaList lista, bool empty_item)
        {
            if (empty_item) AddEmptyItem();

            foreach (TipoAuditoriaInfo item in lista)
            {
                ComboBoxSource combo = new ComboBoxSource();

                combo.Texto = item.Numero + " " + item.Nombre;
                combo.Oid = item.Oid;
                combo.OidAjeno = item.OidClaseAuditoria;

                this.Add(combo);
            }

        }
        
    }
}
