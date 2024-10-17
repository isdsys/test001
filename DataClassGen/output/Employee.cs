using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 従業員
/// </summary>
namespace dto
{
    class Employee
    {
		        /// <summary>
        /// 氏名（姓）
        /// </summary>
        private  String  nameSei;

        public  String  NameSei
        {
            set { this.nameSei= value; }
            get { return this.nameSei; }
        }

        /// <summary>
        /// 氏名（名）
        /// </summary>
        private  String  nameMei;

        public  String  NameMei
        {
            set { this.nameMei= value; }
            get { return this.nameMei; }
        }

        /// <summary>
        /// 氏名（副）
        /// </summary>
        private  String  nameSub;

        public  String  NameSub
        {
            set { this.nameSub= value; }
            get { return this.nameSub; }
        }

        /// <summary>
        /// メールアドレス
        /// </summary>
        private  String  email;

        public  String  Email
        {
            set { this.email= value; }
            get { return this.email; }
        }

        /// <summary>
        /// 電話番号
        /// </summary>
        private  String  telno;

        public  String  Telno
        {
            set { this.telno= value; }
            get { return this.telno; }
        }

        /// <summary>
        /// 入社日付
        /// </summary>
        private  DateTime entryDate;

        public  DateTime EntryDate
        {
            set { this.entryDate= value; }
            get { return this.entryDate; }
        }

        /// <summary>
        /// 退職日付
        /// </summary>
        private  DateTime retireDate;

        public  DateTime RetireDate
        {
            set { this.retireDate= value; }
            get { return this.retireDate; }
        }

        /// <summary>
        /// 従業員ID
        /// </summary>
        private  int employeeId;

        public  int EmployeeId
        {
            set { this.employeeId= value; }
            get { return this.employeeId; }
        }

        /// <summary>
        /// 名前（姓）フリガナ
        /// </summary>
        private  String  nameSeiFuri;

        public  String  NameSeiFuri
        {
            set { this.nameSeiFuri= value; }
            get { return this.nameSeiFuri; }
        }

        /// <summary>
        /// 名前（名）フリガナ
        /// </summary>
        private  String  nameMeiFuri;

        public  String  NameMeiFuri
        {
            set { this.nameMeiFuri= value; }
            get { return this.nameMeiFuri; }
        }

        /// <summary>
        /// 携帯TEL
        /// </summary>
        private  String  telnoKeitai;

        public  String  TelnoKeitai
        {
            set { this.telnoKeitai= value; }
            get { return this.telnoKeitai; }
        }

        /// <summary>
        /// 役職
        /// </summary>
        private  int position;

        public  int Position
        {
            set { this.position= value; }
            get { return this.position; }
        }

        /// <summary>
        /// 有効フラグ
        /// </summary>
        private  int active;

        public  int Active
        {
            set { this.active= value; }
            get { return this.active; }
        }


    }
}
