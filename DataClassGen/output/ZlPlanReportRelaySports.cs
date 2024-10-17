using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 
/// </summary>
namespace dto
{
    class ZL_PLAN_REPORT_RELAY_SPORTS
    {
		        /// <summary>
        /// 計画報告番号
        /// </summary>
        private  String  planReportNo;

        public  String  PlanReportNo
        {
            set { this.planReportNo= value; }
            get { return this.planReportNo; }
        }

        /// <summary>
        /// 計画報告種別
        /// </summary>
        private  String  type;

        public  String  Type
        {
            set { this.type= value; }
            get { return this.type; }
        }

        /// <summary>
        /// サブタイトル
        /// </summary>
        private  String  subtitle;

        public  String  Subtitle
        {
            set { this.subtitle= value; }
            get { return this.subtitle; }
        }

        /// <summary>
        /// 放送サイズコード
        /// </summary>
        private  String  broadcastSizeCode;

        public  String  BroadcastSizeCode
        {
            set { this.broadcastSizeCode= value; }
            get { return this.broadcastSizeCode; }
        }

        /// <summary>
        /// カメラ台数
        /// </summary>
        private  Decimal cameraCnt;

        public  Decimal CameraCnt
        {
            set { this.cameraCnt= value; }
            get { return this.cameraCnt; }
        }

        /// <summary>
        /// 収録機台数
        /// </summary>
        private  Decimal recordingMachineCnt;

        public  Decimal RecordingMachineCnt
        {
            set { this.recordingMachineCnt= value; }
            get { return this.recordingMachineCnt; }
        }

        /// <summary>
        /// P社員名
        /// </summary>
        private  String  pdEmpName;

        public  String  PdEmpName
        {
            set { this.pdEmpName= value; }
            get { return this.pdEmpName; }
        }

        /// <summary>
        /// 中継場所電話
        /// </summary>
        private  String  relayPlaceTel;

        public  String  RelayPlaceTel
        {
            set { this.relayPlaceTel= value; }
            get { return this.relayPlaceTel; }
        }

        /// <summary>
        /// 中継場所住所
        /// </summary>
        private  String  relayPlaceAddress;

        public  String  RelayPlaceAddress
        {
            set { this.relayPlaceAddress= value; }
            get { return this.relayPlaceAddress; }
        }

        /// <summary>
        /// 放送開始日
        /// </summary>
        private  DateTime broadcastStartDay;

        public  DateTime BroadcastStartDay
        {
            set { this.broadcastStartDay= value; }
            get { return this.broadcastStartDay; }
        }

        /// <summary>
        /// 放送開始時刻
        /// </summary>
        private  String  broadcastStartTime;

        public  String  BroadcastStartTime
        {
            set { this.broadcastStartTime= value; }
            get { return this.broadcastStartTime; }
        }

        /// <summary>
        /// 放送終了日
        /// </summary>
        private  DateTime broadcastEndDay;

        public  DateTime BroadcastEndDay
        {
            set { this.broadcastEndDay= value; }
            get { return this.broadcastEndDay; }
        }

        /// <summary>
        /// 放送終了時刻
        /// </summary>
        private  String  broadcastEndTime;

        public  String  BroadcastEndTime
        {
            set { this.broadcastEndTime= value; }
            get { return this.broadcastEndTime; }
        }

        /// <summary>
        /// 放送メディアコード
        /// </summary>
        private  String  broadcastMediaCode;

        public  String  BroadcastMediaCode
        {
            set { this.broadcastMediaCode= value; }
            get { return this.broadcastMediaCode; }
        }

        /// <summary>
        /// 再放送開始日
        /// </summary>
        private  DateTime rebroadcastStartDay;

        public  DateTime RebroadcastStartDay
        {
            set { this.rebroadcastStartDay= value; }
            get { return this.rebroadcastStartDay; }
        }

        /// <summary>
        /// 再放送開始時刻
        /// </summary>
        private  String  rebroadcastStartTime;

        public  String  RebroadcastStartTime
        {
            set { this.rebroadcastStartTime= value; }
            get { return this.rebroadcastStartTime; }
        }

        /// <summary>
        /// 再放送終了日
        /// </summary>
        private  DateTime rebroadcastEndDay;

        public  DateTime RebroadcastEndDay
        {
            set { this.rebroadcastEndDay= value; }
            get { return this.rebroadcastEndDay; }
        }

        /// <summary>
        /// 再放送終了時刻
        /// </summary>
        private  String  rebroadcastEndTime;

        public  String  RebroadcastEndTime
        {
            set { this.rebroadcastEndTime= value; }
            get { return this.rebroadcastEndTime; }
        }


    }
}
