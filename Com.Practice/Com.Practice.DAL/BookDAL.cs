using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Com.Practice.DBUtility;//Please add references
namespace Com.Practice.DAL
{
	/// <summary>
	/// 数据访问类:book
	/// </summary>
	public partial class BookDAL
	{
		public BookDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("id", "p_book"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from p_book");
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
		public bool Add(Com.Practice.Model.BookModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into p_book(");
			strSql.Append("name,version,published_at,created_by,created_at,updated_by,updated_at)");
			strSql.Append(" values (");
			strSql.Append("@name,@version,@published_at,@created_by,@created_at,@updated_by,@updated_at)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@version", MySqlDbType.VarChar,255),
					new MySqlParameter("@published_at", MySqlDbType.Date),
					new MySqlParameter("@created_by", MySqlDbType.Int32,11),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by", MySqlDbType.Int32,11),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.version;
			parameters[2].Value = model.published_at;
			parameters[3].Value = model.created_by;
			parameters[4].Value = model.created_at;
			parameters[5].Value = model.updated_by;
			parameters[6].Value = model.updated_at;

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
		public bool Update(Com.Practice.Model.BookModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update p_book set ");
			strSql.Append("name=@name,");
			strSql.Append("version=@version,");
			strSql.Append("published_at=@published_at,");
			strSql.Append("created_by=@created_by,");
			strSql.Append("created_at=@created_at,");
			strSql.Append("updated_by=@updated_by,");
			strSql.Append("updated_at=@updated_at");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@version", MySqlDbType.VarChar,255),
					new MySqlParameter("@published_at", MySqlDbType.Date),
					new MySqlParameter("@created_by", MySqlDbType.Int32,11),
					new MySqlParameter("@created_at", MySqlDbType.DateTime),
					new MySqlParameter("@updated_by", MySqlDbType.Int32,11),
					new MySqlParameter("@updated_at", MySqlDbType.DateTime),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.version;
			parameters[2].Value = model.published_at;
			parameters[3].Value = model.created_by;
			parameters[4].Value = model.created_at;
			parameters[5].Value = model.updated_by;
			parameters[6].Value = model.updated_at;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from p_book ");
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
			strSql.Append("delete from p_book ");
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
		public Com.Practice.Model.BookModel GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,name,version,published_at,created_by,created_at,updated_by,updated_at from p_book ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			Com.Practice.Model.BookModel model=new Com.Practice.Model.BookModel();
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
		public Com.Practice.Model.BookModel DataRowToModel(DataRow row)
		{
			Com.Practice.Model.BookModel model=new Com.Practice.Model.BookModel();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["version"]!=null)
				{
					model.version=row["version"].ToString();
				}
				if(row["published_at"]!=null && row["published_at"].ToString()!="")
				{
					model.published_at=DateTime.Parse(row["published_at"].ToString());
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
			strSql.Append("select id,name,version,published_at,created_by,created_at,updated_by,updated_at ");
			strSql.Append(" FROM p_book ");
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
			strSql.Append("select count(1) FROM p_book ");
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
			strSql.Append(")AS Row, T.*  from p_book T ");
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
			parameters[0].Value = "p_book";
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

