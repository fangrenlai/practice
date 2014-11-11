using System;
namespace Com.Practice.Model
{
	/// <summary>
	/// role_menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoleMenuModel
	{
		public RoleMenuModel()
		{}
		#region Model
		private int _id;
		private int _role_id;
		private int _menu_id;
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
		public int role_id
		{
			set{ _role_id=value;}
			get{return _role_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int menu_id
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		#endregion Model

	}
}

