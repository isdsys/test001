using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCommon.common
{
    public class FileUtil
    {
        /**
         * バイナリファイル書き込み
         * @param fmode Append 追加,Create 作成,CreateNew　新規作成,　Open 上書き,OpenOrCreate　上書き／新規作成,Truncate　削除＆追加
         * @param fpath
         * @param data
         *
         **/
        public void WriteBinaryFile(FileMode fmode, String fpath, byte[] data)
        {
            try
            {
                using (var fs = new FileStream(fpath, fmode))
                using (var sw = new BinaryWriter(fs))
                {
                    sw.Write(data);
                }

            }
            catch (IOException ex)
            {
                throw;
            }
        }


        /**
         * テキストファイル書き込み
         * @param fmode Append 追加,Create 作成,CreateNew　新規作成,　Open 上書き,OpenOrCreate　上書き／新規作成,Truncate　削除＆追加
         * @param fpath
         * @param encode
         * @param buff
         **/
        public void WriteTextFile(FileMode fmode, String fpath, Encoding encode, String buff)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(fpath, fmode);
                using (StreamWriter writer = new StreamWriter(fs, encode))
                {
                    writer.Write(buff);
                }
            }
            catch (IOException ex)
            {
                throw;
            }

            {
                if (fs != null)
                    fs.Dispose();
            }
        }
        //コメント行マーク
        const String COMMENT_MARK = "#";

        public List<String> ReadTextFile(String fpath, Encoding encode)
        {
            if (fpath.Length < 1)
            {
                throw new　AppException("パラメータ（filepath)が不正です。ファイルパス：" + fpath);
            }
            try
            {

                List<String> rsltList = new List<string>();

                // Read the file and display it line by line.  
                System.IO.StreamReader file = new System.IO.StreamReader(fpath, encode);
                String line;
                int counter = 1;
                while ((line = file.ReadLine()) != null)
                {
                    char[] charsToTrim = { ' ', '\t' };
                    string strline = line.Trim(charsToTrim);
                    counter++;
                    if (line.Length < 1)//空行スキップ
                    {
                        strline = "";
                        continue;
                    }
                    if (strline.StartsWith(COMMENT_MARK))//コメント行スキップ
                    {
                        strline = "";
                        continue;
                    }
                    rsltList.Add(line);
                }
                return rsltList;
            }
            catch (IOException ex)
            {
                String logmsg = string.Format("{0}ファイル読み込みで例外が発生しました。", fpath);
                throw new AppException(logmsg , ex);
            }

        }
        public String ReadTextAll(String fpath, Encoding encode)
        {
            if (fpath.Length < 1)
            {
                throw new AppException("パラメータ（filepath)が不正です。ファイルパス：" + fpath);
            }
            try
            {

                System.IO.StreamReader file = new System.IO.StreamReader(fpath, encode);
                String tempBuff= file.ReadToEnd();
                return tempBuff;
            }
            catch (IOException ex)
            {
                String logmsg = string.Format("{0}ファイル読み込みで例外が発生しました。", fpath);
                throw new AppException(logmsg, ex);
            }



        }

    }
}
