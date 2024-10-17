using AppCommon.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using DataClassGen;

/// <summary>
/// 定義ファイル（A5:Mk2）のテーブル定義書を読み、データクラスを生成する
/// 起動書式
/// DataClassGen 1
/// 引数1は、作成物の種類（現在は、データクラスのみ）
/// 2021/07/22
/// 
/// </summary>
namespace DataClassGen
{
    class Program
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //private static readonly String[] MAKE_TYPE = {"DataClass",
        //                                                "tranColumnDataToProperty",
        //                                                "DataGrid",
        //                                                "BindDataGrid"};

        //作成する種別　現在は、データクラスのみ
        private static String makeType;

        //ファイルパス
        private static String dataClassTempPath;
        private static String propertyTempPath;
        private static String dataClassTempFileName;
        private static String propertyTempFileName;
        private static String dataTypeDataFileName;
        //
        private static String nameSpace;
        private static String cfgpath;
        //ヂレクトリ
        private static String inputDir ;
        private static String outputDir;
        private static String templateDir ;
        //ファイル名
        private static String cfgNameListFileName;
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="args">args[0] 作成種別　1:データ転送コード、
        /// 2:データグリッドタグ、
        /// ３：データバインドコード
        /// </param>
        static void Main(string[] args)
        {
            //Console.WriteLine("Usage1:DbTool [生成種別番号]");
            //Console.WriteLine("     1:データクラス");
            //Console.WriteLine("     2:データ転送コード");
            //Console.WriteLine("     3:データグリッドタグ");
            //Console.WriteLine("     4:データバインドコード");

            _logger.Debug("DbTool::Main() start");

            try
            {
                //作成する種別を設定
//                int　mType　= int.Parse(args[0].Trim());
//                makeType = MAKE_TYPE[mType-1];        

                //定義情報取得
                GetConfig();

                FileUtil fileUtil = new FileUtil();

                //ファイルパス作成
                //
                //データクラスコード テンプレートファイルパス
                dataClassTempPath = templateDir + SysConst.DIR_SEPA + dataClassTempFileName;
                propertyTempPath = templateDir + SysConst.DIR_SEPA + propertyTempFileName;

                String cfgFileNameListPath = inputDir + SysConst.DIR_SEPA + cfgNameListFileName;
                //エンティテ定義ファイル名一覧ファイル読み込み
                List<String> fnameList = fileUtil.ReadTextFile(cfgFileNameListPath, Encoding.UTF8);


                foreach (String fname in fnameList)
                {
                    cfgpath = inputDir + SysConst.DIR_SEPA + fname;

                    ExcelUtil util = new ExcelUtil();

                    //                    FileUtil fileUtil = new FileUtil();

                    //データ変換に使用するデータ型リスト初期設定
                    String dataTypeCsvPath = inputDir + SysConst.DIR_SEPA + dataTypeDataFileName;
                    List<String> DataTypelist = fileUtil.ReadTextFile(dataTypeCsvPath, Encoding.UTF8);

                    List<MapData> mapDataLIst = new List<MapData>();

                    foreach (String line in DataTypelist)
                    {
                        MapData mapData = new MapData();
                        String[] data = line.Split(',');
                        mapData.Key = data[0];
                        mapData.Value = data[1];
                        mapDataLIst.Add(mapData);
                    }
                    //データ型MAP初期化
                    util.InitDdataTypeMap(mapDataLIst);

                    //テーブル項目定義書（EXCEL）読み込み
                    TableInfo tif = util.ReadExcel(cfgpath);


                    MkCodeUtil mkCodeUtil = new MkCodeUtil();

                    CommonUtil commonUtil = new CommonUtil();

                    //データクラス作成
//                    if (makeType == MAKE_TYPE[0]){
                        String rsltData = mkCodeUtil.EditDataClass(tif, dataClassTempPath, propertyTempPath,nameSpace);

                        String fpath = outputDir +SysConst.DIR_SEPA+ commonUtil.ColNameToProperty(tif.PhysicalName) + ".cs";

                        fileUtil.WriteTextFile(FileMode.Create, fpath, Encoding.UTF8, rsltData);

                    Console.WriteLine(fpath + "を作成しました。");
                    Console.WriteLine(rsltData);

                    //                    }
                }
            }
            catch (IOException ex)
            {
                _logger.Error(ex.Message);

            }
            catch (AppException ex)
            {
                _logger.Error(ex.Message);

            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);

            }
            Console.WriteLine("処理終了しました。何か入力してください。");
            Console.ReadKey();
        }
        private static void GetConfig()
        {
            //テーブル定義ファイル一覧ファイル　格納フォルダ
            inputDir = ConfigurationManager.AppSettings["INPUT_DIR"];
            //作成テキスト　出力フォルダ
            outputDir = ConfigurationManager.AppSettings["OUTPUT_DIR"];
            //テンプレートファイル　格納フォルダ
            templateDir = ConfigurationManager.AppSettings["TEMPLATE_DIR"];
            //テーブル定義ファイル一覧　ファイル名
            cfgNameListFileName = ConfigurationManager.AppSettings["CFGNAMELIST_FILENAME"];
            //データクラス　　テンプレートファイル名
            dataClassTempFileName = ConfigurationManager.AppSettings["DATACLASS_TEMP_FILENAME"];
            //プロパティ部　　テンプレートファイル名
            propertyTempFileName = ConfigurationManager.AppSettings["PROPERTY_TEMP_FILENAME"];
            //namespace
            nameSpace = ConfigurationManager.AppSettings["NAMESPACE"];
            dataTypeDataFileName = ConfigurationManager.AppSettings["DATA_TYPE_FILENAME"];

            if (inputDir==null)
                throw new AppException("定義情報(inputDir)取得に失敗しました。");
            if　(outputDir == null)
                throw new AppException("定義情報（outputDir）取得に失敗しました。");
            if (templateDir == null)           
                throw new AppException("定義情報（templateDir）取得に失敗しました。");
            if (cfgNameListFileName == null)
                throw new AppException("定義情報（cfgNameListFileName）取得に失敗しました。");
            if (dataClassTempFileName == null)
                throw new AppException("定義情報（dataClassTempFileName）取得に失敗しました。");
            if (propertyTempFileName == null)
                throw new AppException("定義情報（propertyTempFileName）取得に失敗しました。");

        }
    }
}
