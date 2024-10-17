using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClassGen
{
    class ExcelUtil
    {
        const int COL_TABLENAME = 3;
        const int ROW_TABLENAME = 5;
        const int COL_FIELD = 2;
        const int ROW_FIELD = 14;

        Dictionary<String, String> dataTypeMap = new Dictionary<String, String>();
        public void InitDdataTypeMap(List<MapData> mapDataList)
        {
            foreach (MapData data in mapDataList)
            {
                dataTypeMap.Add(data.Key, data.Value);
            }
        }
    
        public TableInfo ReadExcel(String fpath)
        {
            TableInfo tif=null;
            try
            {
                // Excelファイルを作る
                // Excelファイルを開く
                var workbook = new XLWorkbook(fpath);
                    // ワークシートを取得する
                var worksheet = workbook.Worksheet(2);

                //格納領域を生成
                tif = new TableInfo();

                // 位置を指定してセルを取得する
                int col = COL_TABLENAME;
                int row = ROW_TABLENAME;
                tif.LogicalName = (String)worksheet.Cell(row, col).GetString();
                String physicalName = (String)worksheet.Cell(row+1, col).GetString();
                //先頭大文字変換
                tif.PhysicalName = Char.ToUpper(physicalName[0]) + physicalName.Substring(1);

                //データグリッド名
                tif.DataGridName = (String)worksheet.Cell(row - 2, col).GetString();

                col = COL_FIELD;
                int fieldRow = ROW_FIELD;
                for (int i = 0; i < 100;i++)
                {
                    FieldInfo fif = new FieldInfo();
                    fif.LogicalName = (String)worksheet.Cell(fieldRow + i, col).GetString(); ; 
                    if (fif.LogicalName == String.Empty)
                        break;

                    fif.PhysicalName = (String)worksheet.Cell(fieldRow + i, col+1).GetString(); ; 
                    fif.DataType = (String)worksheet.Cell(fieldRow + i, col+2).GetString();


                    String[] items = fif.DataType.Split('(', ')', ',');
                    fif.DataType = items[0].Trim();
                    fif.Length = 0;
                    if ((fif.DataType == "character varying")||
                        (fif.DataType == "nvarchar"))
                        {
                            fif.Length = int.Parse(items[1].Trim());
                    }
                    tif.FifList.Add(fif);

                    //編集タイプ取得
                    fif.EditType = (String)worksheet.Cell(fieldRow + i, col + 5).GetString();

                    //CSデータkt型取得
                    fif.CsDataType = dataTypeMap[fif.DataType];

                    //                var cellA2 = worksheet.Cell(row + i, col); 
                }
            }
            catch(IOException ex)
            {
                String logmsg = string.Format("{0}の読み込みに失敗しました。",fpath);
                throw ;
            }
            return tif;

        }
    }
}
