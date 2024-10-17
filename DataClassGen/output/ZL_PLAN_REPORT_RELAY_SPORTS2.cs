using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 計画報告2
/// </summary>
namespace dto
{
    class ZL_PLAN_REPORT_RELAY_SPORTS2
    {
		        /// <summary>
        /// 報告書番号
        /// </summary>
        private  String  planReportNo;

        public  String  PlanReportNo
        {
            set { this.planReportNo= value; }
            get { return this.planReportNo; }
        }

        /// <summary>
        /// 報告書種別
        /// </summary>
        private  String  reportType;

        public  String  ReportType
        {
            set { this.reportType= value; }
            get { return this.reportType; }
        }

        /// <summary>
        /// 副題
        /// </summary>
        private  String  subtitle;

        public  String  Subtitle
        {
            set { this.subtitle= value; }
            get { return this.subtitle; }
        }

        /// <summary>
        /// 放送サイズ
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
        private  Decimal cameraUnit;

        public  Decimal CameraUnit
        {
            set { this.cameraUnit= value; }
            get { return this.cameraUnit; }
        }


    }
}
