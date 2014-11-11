using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Com.Practice.DBUtility;//Please add references
namespace Com.Practice.DAL
{
	/// <summary>
	/// 数据访问类:user
	/// </summary>
	public partial class UserDAL
	{
		public UserDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "p_user"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from p_user");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Com.Practice.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into p_user(");
			strSql.Append("login_name,nick_name,pwd,e_mail,e_mail_flag,mobile_num,mobile_num_flag,user_status,created_by,created_at,updated_by,updated_at)");
			strSql.Append(" values (");
			strSql.Append("@login_name,@nick_name,@pwd,@e_mail,@e_mail_flag,@mobile_num,@mobile_num_flag,@user_status,@created_by,@created_at,@updated_by,@updated_at)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@login_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@nick_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@pwd", MySqlDbType.VarChar,255),
					new MySqlParameter("@e_mail", MySqlDbType.VarChar,100),
					new MySqlParameter("@e_mail_flag", MySqlDbType.Int32,10),
					new MySqlParameter("@mobile_num", MySqlDbType.VarChar,20),
					new MySqlParameter("@mobile_num_flag", MySqlDbType.Int32,10),
					new MySqlParameter("@user_status", MySqlDbType.Int32,10),
					new MySqlParameter("@created_by", MySqlDbType.Int32,255),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by", MySqlDbType.Int32,255),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime)};
			parameters[0].Value = model.login_name;
			parameters[1].Value = model.nick_name;
			parameters[2].Value = model.pwd;
			parameters[3].Value = model.e_mail;
			parameters[4].Value = model.e_mail_flag;
			parameters[5].Value = model.mobile_num;
			parameters[6].Value = model.mobile_num_flag;
			parameters[7].Value = model.user_status;
			parameters[8].Value = model.created_by;
			parameters[9].Value = model.created_at;
			parameters[10].Value = model.updated_by;
			parameters[11].Value = model.updated_at;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Com.Practice.Model.UserModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update p_user set ");
			strSql.Append("login_name=@login_name,");
			strSql.Append("nick_name=@nick_name,");
			strSql.Append("pwd=@pwd,");
			strSql.Append("e_mail=@e_mail,");
			strSql.Append("e_mail_flag=@e_mail_flag,");
			strSql.Append("mobile_num=@mobile_num,");
			strSql.Append("mobile_num_flag=@mobile_num_flag,");
			strSql.Append("user_status=@user_status,");
			strSql.Append("created_by=@created_by,");
			strSql.Append("created_at=@created_at,");
			strSql.Append("updated_by=@updated_by,");
			strSql.Append("updated_at=@updated_at");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@login_name", MySqlDbType.VarChar,100),
					new MySqlParameter("@nick_name", MySqlDbType.VarChar,255),
					new MySqlParameter("@pwd", MySqlDbType.VarChar,255),
					new MySqlParameter("@e_mail", MySqlDbType.VarChar,100),
					new MySqlParameter("@e_mail_flag", MySqlDbType.Int32,10),
					new MySqlParameter("@mobile_num", MySqlDbType.VarChar,20),
					new MySqlParameter("@mobile_num_flag", MySqlDbType.Int32,10),
					new MySqlParameter("@user_status", MySqlDbType.Int32,10),
					new MySqlParameter("@created_by", MySqlDbType.Int32,255),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by", MySqlDbType.Int32,255),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,255)};
			parameters[0].Value = model.login_name;
			parameters[1].Value = model.nick_name;
			parameters[2].Value = model.pwd;
			parameters[3].Value = model.e_mail;
			parameters[4].Value = model.e_mail_flag;
			parameters[5].Value = model.mobile_num;
			parameters[6].Value = model.mobile_num_flag;
			parameters[7].Value = model.user_status;
			parameters[8].Value = model.created_by;
			parameters[9].Value = model.created_at;
			parameters[10].Value = model.updated_by;
			parameters[11].Value = model.updated_at;
			parameters[12].Value = model.id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from p_user ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from p_user ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public Com.Practice.Model.UserModel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,login_name,nick_name,pwd,e_mail,e_mail_flag,mobile_num,mobile_num_flag,user_status,created_by,created_at,updated_by,updated_at from p_user ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Com.Practice.Model.UserModel model=new Com.Practice.Model.UserModel();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Com.Practice.Model.UserModel DataRowToModel(DataRow row)
		{
			Com.Practice.Model.UserModel model=new Com.Practice.Model.UserModel();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["login_name"]!=null)
				{
					model.login_name=row["login_name"].ToString();
				}
				if(row["nick_name"]!=null)
				{
					model.nick_name=row["nick_name"].ToString();
				}
				if(row["pwd"]!=null)
				{
					model.pwd=row["pwd"].ToString();
				}
				if(row["e_mail"]!=null)
				{
					model.e_mail=row["e_mail"].ToString();
				}
				if(row["e_mail_flag"]!=null && row["e_mail_flag"].ToString()!="")
				{
					model.e_mail_flag=int.Parse(row["e_mail_flag"].ToString());
				}
				if(row["mobile_num"]!=null)
				{
					model.mobile_num=row["mobile_num"].ToString();
				}
				if(row["mobile_num_flag"]!=null && row["mobile_num_flag"].ToString()!="")
				{
					model.mobile_num_flag=int.Parse(row["mobile_num_flag"].ToString());
				}
				if(row["user_status"]!=null && row["user_status"].ToString()!="")
				{
					model.user_status=int.Parse(row["user_status"].ToString());
				}
				if(row["created_by"]!=null && row["created_by"].ToString()!="")
				{
					model.created_by=int.Parse(row["created_by"].ToString());
				}
				if(row["created_at"]!=null && row["created_at"].ToString()!="")
				{
					model.created_at=DateTime.Parse(row["created_at"].ToString());
				}
				if(row["updated_by"]!=null && row["updated_by"].ToString()!="")
				{
					model.updated_by=int.Parse(row["updated_by"].ToString());
				}
				if(row["updated_at"]!=null && row["updated_at"].ToString()!="")
				{
					model.updated_at=DateTime.Parse(row["updated_at"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,login_name,nick_name,pwd,e_mail,e_mail_flag,mobile_num,mobile_num_flag,user_status,created_by,created_at,updated_by,updated_at ");
			strSql.Append(" FROM p_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM p_user ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from p_user T ");
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
			parameters[0].Value = "p_user";
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

        /// <summary>
        /// 得到一个对象实体（重载）
        /// </summary>
        public Com.Practice.Model.UserModel GetModel(string loginName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,login_name,nick_name,pwd,e_mail,e_mail_flag,mobile_num,mobile_num_flag,user_status,created_by,created_at,updated_by,updated_at from p_user ");
            strSql.Append(" where login_name=@login_name");
            MySqlParameter[] parameters = {
					new MySqlParameter("@login_name", MySqlDbType.String)
			};
            parameters[0].Value = loginName;

            Com.Practice.Model.UserModel model = new Com.Practice.Model.UserModel();
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
	}
}

