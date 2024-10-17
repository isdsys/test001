using AppCommon.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClassGen
{
    class FieldInfo
    {
        public String LogicalName { set; get; }
        public String PhysicalName { set; get; }

        public String DataType { set; get; }
        public String CsDataType { set; get; }
        public int Length { set; get; }
        public　String EditType { set; get; }
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb = sb.Append("Datatype :").Append(DataType).Append(SysConst.CRLF);
            sb = sb.Append("CsDataType :").Append(CsDataType).Append(SysConst.CRLF);
            sb = sb.Append("LogicalName :").Append(LogicalName).Append(SysConst.CRLF);
            sb = sb.Append("PhysicalName :").Append(PhysicalName).Append(SysConst.CRLF);
            sb = sb.Append("Length :").Append(Length).Append(SysConst.CRLF);
            sb = sb.Append("EditType :").Append(EditType).Append(SysConst.CRLF);

            return sb.ToString();

        }
    }
}
