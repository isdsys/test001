using AppCommon.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClassGen
{
    class TableInfo
    {
        public String DataGridName { set; get; }
        public String LogicalName { set; get; }
        public String PhysicalName { set; get; }
        public List<FieldInfo> FifList { set; get; }
        public TableInfo()
        {
            FifList = new List<FieldInfo>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DataGridName :").Append(DataGridName).Append(SysConst.CRLF);
            sb.Append("LogicalName :").Append(LogicalName).Append(SysConst.CRLF);
            sb.Append("PhysicalName :").Append(PhysicalName).Append(SysConst.CRLF);

            foreach(FieldInfo finfo in FifList)
            {
                finfo.ToString();
            }
            return sb.ToString();
        }
    }
}
