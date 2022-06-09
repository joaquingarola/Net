using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class xmlFileHandler: fileHandler
    {
        protected DataSet ds;

        public override System.Data.DataTable getTable()
        {
            this.ds = new DataSet();
            this.ds.ReadXml("agenda.xml");

            return this.ds.Tables["contactos"];
        }

        public override void applyChanges()
        {
            this.ds.WriteXml("agenda.xml");
            this.ds.WriteXml("agendaconschema.xml", XmlWriteMode.WriteSchema);
        }
    }
}
