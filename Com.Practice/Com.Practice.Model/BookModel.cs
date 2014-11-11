using System;
namespace Com.Practice.Model
{
	/// <summary>
	/// book:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BookModel
	{
		public BookModel()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _version;
		private DateTime _published_at;
		private int? _created_by;
		private DateTime? _created_at;
		private int? _updated_by;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime published_at
		{
			set{ _published_at=value;}
			get{return _published_at;}
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

