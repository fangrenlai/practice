using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Com.Practice.DBUtility;//Please add references
namespace Com.Practice.DAL
{
	/// <summary>
	/// 数据访问类:FunctionModel
	/// </summary>
	public partial class FunctionDAL
	{
		public FunctionDAL()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "p_function");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from p_function");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Com.Practice.Model.FunctionModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into p_function(");
            strSql.Append("function_code,function_name,created_by_id,created_by_name,created_at,updated_by_id,updated_by_name,updated_at)");
            strSql.Append(" values (");
            strSql.Append("@function_code,@function_name,@created_by_id,@created_by_name,@created_at,@updated_by_id,@updated_by_name,@updated_at)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@function_code", MySqlDbType.VarChar,22),
					new MySqlParameter("@function_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@created_by_id", MySqlDbType.Int32,11),
					new MySqlParameter("@created_by_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by_id", MySqlDbType.Int32,11),
					new MySqlParameter("@updated_by_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime)};
            parameters[0].Value = model.function_code;
            parameters[1].Value = model.function_name;
            parameters[2].Value = model.created_by_id;
            parameters[3].Value = model.created_by_name;
            parameters[4].Value = model.created_at;
            parameters[5].Value = model.updated_by_id;
            parameters[6].Value = model.updated_by_name;
            parameters[7].Value = model.updated_at;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Com.Practice.Model.FunctionModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update p_function set ");
            strSql.Append("function_code=@function_code,");
            strSql.Append("function_name=@function_name,");
            strSql.Append("created_by_id=@created_by_id,");
            strSql.Append("created_by_name=@created_by_name,");
            strSql.Append("created_at=@created_at,");
            strSql.Append("updated_by_id=@updated_by_id,");
            strSql.Append("updated_by_name=@updated_by_name,");
            strSql.Append("updated_at=@updated_at");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@function_code", MySqlDbType.VarChar,22),
					new MySqlParameter("@function_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@created_by_id", MySqlDbType.Int32,11),
					new MySqlParameter("@created_by_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by_id", MySqlDbType.Int32,11),
					new MySqlParameter("@updated_by_name", MySqlDbType.VarChar,22),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.function_code;
            parameters[1].Value = model.function_name;
            parameters[2].Value = model.created_by_id;
            parameters[3].Value = model.created_by_name;
            parameters[4].Value = model.created_at;
            parameters[5].Value = model.updated_by_id;
            parameters[6].Value = model.updated_by_name;
            parameters[7].Value = model.updated_at;
            parameters[8].Value = model.id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from p_function ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from p_function ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Com.Practice.Model.FunctionModel GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,function_code,function_name,created_by_id,created_by_name,created_at,updated_by_id,updated_by_name,updated_at from p_function ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            Com.Practice.Model.FunctionModel model = new Com.Practice.Model.FunctionModel();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Com.Practice.Model.FunctionModel DataRowToModel(DataRow row)
        {
            Com.Practice.Model.FunctionModel model = new Com.Practice.Model.FunctionModel();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["function_code"] != null)
                {
                    model.function_code = row["function_code"].ToString();
                }
                if (row["function_name"] != null)
                {
                    model.function_name = row["function_name"].ToString();
                }
                if (row["created_by_id"] != null && row["created_by_id"].ToString() != "")
                {
                    model.created_by_id = int.Parse(row["created_by_id"].ToString());
                }
                if (row["created_by_name"] != null)
                {
                    model.created_by_name = row["created_by_name"].ToString();
                }
                if (row["created_at"] != null && row["created_at"].ToString() != "")
                {
                    model.created_at = DateTime.Parse(row["created_at"].ToString());
                }
                if (row["updated_by_id"] != null && row["updated_by_id"].ToString() != "")
                {
                    model.updated_by_id = int.Parse(row["updated_by_id"].ToString());
                }
                if (row["updated_by_name"] != null)
                {
                    model.updated_by_name = row["updated_by_name"].ToString();
                }
                if (row["updated_at"] != null && row["updated_at"].ToString() != "")
                {
                    model.updated_at = DateTime.Parse(row["updated_at"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,function_code,function_name,created_by_id,created_by_name,created_at,updated_by_id,updated_by_name,updated_at ");
            strSql.Append(" FROM p_function ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM p_function ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from p_function T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "p_function";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
	}
}

