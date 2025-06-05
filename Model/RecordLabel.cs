using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class RecordLabel
    {
        public string RecordLabel_Name { get; set; }
        public int RecordLabel_ID { get; set; }

        public RecordLabel(string inRecordLabel_Name, int inRecordLabel_ID)
        {
            RecordLabel_Name = inRecordLabel_Name;
            RecordLabel_ID = inRecordLabel_ID;
        }
    }
}
