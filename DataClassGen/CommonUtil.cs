using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClassGen
{
    /// <summary>
    /// 
    /// </summary>
    class CommonUtil
    {
        /// <summary>
        /// DataTableカラム名toC#プロパティ名変換
        /// </summary>
        /// <param name="ColName">DataTableカラム名</param>
        /// <returns></returns>
        public String ColNameToProperty(String ColName)
        {
            //Classのプロパティ名作成
            String[] items = ColName.Split('_');

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Length; i++)
            {
                String tmp = items[i].ToLower();
                String wk = tmp.Substring(0, 1).ToUpper();

                tmp = wk + tmp.Substring(1, tmp.Length - 1);

                sb.Append(tmp);
            }
            String propName = sb.ToString();

            return propName;
        }

    }
}
