using System;
namespace Com.Practice.Model
{
	/// <summary>
	/// function:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FunctionModel
	{
		public FunctionModel()
		{}
        #region Model
        private int _id;
        private string _function_code;
        private string _function_name;
        private int? _created_by_id;
        private string _created_by_name;
        private DateTime? _created_at;
        private int? _updated_by_id;
        private string _updated_by_name;
        private DateTime? _updated_at;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string function_code
        {
            set { _function_code = value; }
            get { return _function_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string function_name
        {
            set { _function_name = value; }
            get { return _function_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? created_by_id
        {
            set { _created_by_id = value; }
            get { return _created_by_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string created_by_name
        {
            set { _created_by_name = value; }
            get { return _created_by_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? created_at
        {
            set { _created_at = value; }
            get { return _created_at; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? updated_by_id
        {
            set { _updated_by_id = value; }
            get { return _updated_by_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string updated_by_name
        {
            set { _updated_by_name = value; }
            get { return _updated_by_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? updated_at
        {
            set { _updated_at = value; }
            get { return _updated_at; }
        }
        #endregion Model

	}
}

