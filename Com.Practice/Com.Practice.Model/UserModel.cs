using System;
namespace Com.Practice.Model
{
	/// <summary>
	/// user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserModel
	{
		public UserModel()
		{}
		#region Model
		private int _id;
		private string _login_name;
		private string _nick_name;
		private string _pwd;
		private string _e_mail;
		private int? _e_mail_flag=0;
		private string _mobile_num;
		private int? _mobile_num_flag=0;
		private int _user_status=0;
		private int? _created_by=1;
		private DateTime? _created_at;
		private int? _updated_by=1;
		private DateTime? _updated_at;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string login_name
		{
			set{ _login_name=value;}
			get{return _login_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nick_name
		{
			set{ _nick_name=value;}
			get{return _nick_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string e_mail
		{
			set{ _e_mail=value;}
			get{return _e_mail;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? e_mail_flag
		{
			set{ _e_mail_flag=value;}
			get{return _e_mail_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile_num
		{
			set{ _mobile_num=value;}
			get{return _mobile_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? mobile_num_flag
		{
			set{ _mobile_num_flag=value;}
			get{return _mobile_num_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_status
		{
			set{ _user_status=value;}
			get{return _user_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? created_by
		{
			set{ _created_by=value;}
			get{return _created_by;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? created_at
		{
			set{ _created_at=value;}
			get{return _created_at;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? updated_by
		{
			set{ _updated_by=value;}
			get{return _updated_by;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updated_at
		{
			set{ _updated_at=value;}
			get{return _updated_at;}
		}
		#endregion Model

	}
}

