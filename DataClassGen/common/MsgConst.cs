using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCommon.common
{
    class MsgConst
    {
        public static readonly String ILLEGAL_ARGUMENT = "引数に{0}が必要です。";
        public static readonly String APP_START = "アプリケーション開始";
        public static readonly String APP_NORMAL_END = "正常終了しました。";
        public static readonly String APP_ERROR_END = "異常終了しました。";
        public static readonly String ILLEGAL_NUMBER_OFCOLUMNS="カラム数が不正です。行番号:{0}";
        public static readonly String FILE_NOT_FOUND="ファイルが見つかりません。ファイルパス：{0}";
        public static readonly String ILLEGAL_PARAM="{0}が不正です。{0}:{1}" ;
        //ファイルパスが不正です。ファイルパス：{ファイルパス}

    }
}
