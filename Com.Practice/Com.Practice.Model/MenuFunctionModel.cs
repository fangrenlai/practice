using System;
namespace Com.Practice.Model
{
	/// <summary>
	/// menu_function:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MenuFunctionModel
	{
		public MenuFunctionModel()
		{}
		#region Model
		private int _id;
		private int _menu_id;
		private int? _function_id;
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
		public int menu_id
		{
			set{ _menu_id=value;}
			get{return _menu_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? function_id
		{
			set{ _function_id=value;}
			get{return _function_id;}
		}
		#endregion Model

	}
}

