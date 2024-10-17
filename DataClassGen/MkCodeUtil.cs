using AppCommon.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataClassGen
{
    class MkCodeUtil
    {

        public String GridName { set; get; }


        /// <summary>
        ///   //カラムデータ転送コード編集
        /// </summary>
        /// <param name="tif">DBテーブル情報</param>
        /// <param name="tranDataTempPath">テンプレートファイルパス</param>
        /// <returns></returns>
        public String EditDataGrid(TableInfo tif, PathParam param)
        {
            //カラム定義を作成
            FileUtil fileUtil = new FileUtil();

            //カラムテンプレート読み込み
            String columnBuff = fileUtil.ReadTextAll(param.DataGridColumnTempPath, Encoding.UTF8);

            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo fif in tif.FifList)
            {
                string buff = columnBuff;
                String work =buff.Replace("#LOGICNAME", fif.LogicalName);

                //Classのプロパティ名作成
                CommonUtil commonUtil = new CommonUtil();
                String propName = commonUtil.ColNameToProperty(fif.PhysicalName);

                work = work.Replace("#COLUMN_NAME", fif.PhysicalName);
                work = work.Replace("#PROPERTY_NAME", propName);

                //EditItem 編集
                if (fif.EditType.Length == 0)
                {
                    work = work.Replace("#EDITITEM_TEMPLATE", "");

                }
                else
                {
                    //EditItemTemplateテンプレート読み込み
                    String editItem = fileUtil.ReadTextAll(param.DataGridEditItemTempPath, Encoding.UTF8);
                    String editItemBuff = editItem.Replace("#COLUMN_NAME", fif.PhysicalName);
                    editItemBuff = editItemBuff.Replace("#PROPERTY_NAME", propName);

                    work = work.Replace("#EDITITEM_TEMPLATE", editItemBuff);


                }
                sb.Append(work).Append(SysConst.CRLF);

            }
            //カラムデータ転送部分作成した
            String columnData = sb.ToString();

            //DataGrid 全体
            String dgBuff = fileUtil.ReadTextAll(param.DataGridTempPath, Encoding.UTF8);

            String temp = dgBuff.Replace("#DGNAME", tif.DataGridName);

            temp = temp.Replace("#COLUMN_LIST", columnData);

            return temp;



        }
        /// <summary>
        /// データクラス生成
        /// </summary>
        /// <param name="tif"></param>
        /// <param name="dataClassTempPath"></param>
        /// <param name="proprtyTempPath"></param>
        /// <param name="nameSpace"></param>
        /// <returns></returns>
        public String EditDataClass(TableInfo tif, String dataClassTempPath, String proprtyTempPath, String nameSpace)
        {
            FileUtil fileUtil = new FileUtil();

            //データクラステンプレート読み込み
            String tempBuff = fileUtil.ReadTextAll(dataClassTempPath, Encoding.UTF8);

            String propertyTempBuff = fileUtil.ReadTextAll(proprtyTempPath, Encoding.UTF8);


            string head = tempBuff;

            head = head.Replace("{#CLASS_LOGICAL_NAME}", tif.LogicalName);
            head = head.Replace("{#DTO_CLASS_NAME}", tif.PhysicalName);
            head = head.Replace("{#NAMESPACE}", nameSpace);


            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo fif in tif.FifList)
            {

                //Classのプロパティ名作成
                CommonUtil commonUtil = new CommonUtil();
                String logicalName = fif.LogicalName;
                String propName = commonUtil.ColNameToProperty(fif.PhysicalName);

                String privateName = propName.Substring(0, 1).ToLower() + propName.Substring(1, propName.Length - 1);


                String property = propertyTempBuff.Replace("{#PROPERTY_LOGICAL_NAME}", logicalName);
                property = property.Replace("{#CS_PROPERTY_NAME}", propName);
                property = property.Replace("{#CS_PRIVATE_NAME}", privateName);

                property = property.Replace("{#CS_PROPERTY_DATA_TYPE}", fif.CsDataType);

                sb.Append(property).Append(SysConst.CRLF);

                String tmp = sb.ToString();
            }
            //カラムデータ転送部分作成した
            String propertyData = sb.ToString();

            head = head.Replace("{#PROPERTY_PART}", propertyData);

            return head;
        }
        public String EditBindDataGrid(TableInfo tif, String bindDataGridTempPath)
        {
            String AddColumn = "            dt.Columns.Add(\"#COLUMN_NAME\")";

            FileUtil fileUtil = new FileUtil();

            //Columns Add コード編集
            StringBuilder sb = new StringBuilder();
            foreach (FieldInfo fif in tif.FifList)
            {
                string buff = AddColumn;
                CommonUtil commonUtil = new CommonUtil();

                String wkbuff = buff.Replace("#COLUMN_NAME", fif.PhysicalName);

                sb.Append(wkbuff).Append(SysConst.CRLF);

            }
            //カラムデータ転送テンプレート読み込み
            String tempBuff = fileUtil.ReadTextAll(bindDataGridTempPath, Encoding.UTF8);

            String temp = tempBuff.Replace("#DGNAME", tif.DataGridName);
            temp = temp.Replace("#ADD_COLUMNS", sb.ToString());

            //ADD_COLUMNS
//            String bindDataGridCode = sb.ToString();

            return temp;

        }
    }
}
