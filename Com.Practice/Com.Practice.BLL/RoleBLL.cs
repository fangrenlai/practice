using System;
using System.Data;
using System.Collections.Generic;
using Com.Practice.Common;
using Com.Practice.Model;
using Com.Practice.Model.Common;
using Com.Practice.DAL.Common;
using Com.Practice.Common.Json;
namespace Com.Practice.BLL
{
    /// <summary>
    /// role
    /// </summary>
    public partial class RoleBLL
    {
        private readonly Com.Practice.DAL.RoleDAL dal = new Com.Practice.DAL.RoleDAL();
        public RoleBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Com.Practice.Model.RoleModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Com.Practice.Model.RoleModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Com.Practice.Model.RoleModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Com.Practice.Model.RoleModel GetModelByCache(int id)
        {

            string CacheKey = "roleModel-" + id;
            object objModel = Com.Practice.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Com.Practice.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Com.Practice.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Com.Practice.Model.RoleModel)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Com.Practice.Model.RoleModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Com.Practice.Model.RoleModel> DataTableToList(DataTable dt)
        {
            List<Com.Practice.Model.RoleModel> modelList = new List<Com.Practice.Model.RoleModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Com.Practice.Model.RoleModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod

        public string GetSpecificDataJsonStr(PaginationModel paginationModel, string queryName)
        {
            string result = "";
            if (null == paginationModel || 0 == paginationModel.Page || 0 == paginationModel.Rows)
            {
                throw new Exception("查询参数错误");
            }
            else
            {
                int startIndex = (paginationModel.Page - 1) * paginationModel.Rows;
                string dataSQL = @"SELECT id,name,created_by,created_by_name,updated_by,updated_by_name,DATE_FORMAT(created_at,'%Y-%m-%d %T') as created_at,DATE_FORMAT(updated_at,'%Y-%m-%d %T') as updated_at FROM p_role ";
                string conditionSQL = "where 1=1 ";
                if (!string.IsNullOrEmpty(queryName))
                {
                    conditionSQL += string.Format("and name like '%{0}%' ", queryName);
                }
                string orderSQL = "ORDER BY ID ASC ";
                string limitSQL = string.Format("LIMIT {0},{1}", startIndex, paginationModel.Rows);

                string finalDataSQL = dataSQL + conditionSQL + orderSQL + limitSQL;
                string countSQL = "SELECT count(*) FROM p_role " + conditionSQL;
                CommonMySQLDAL dal = null;
                try
                {
                    dal = new CommonMySQLDAL();
                    DataSet ds = dal.QueryDataSetBySQL(finalDataSQL);// 获取数据
                    int count = dal.QueryCountBySQL(countSQL);// 获取记录总数
                    string dsStr = JsonUtils.ObjectToJson(ds);
                    String dataStr = dsStr.Substring(5, dsStr.Length - 5);// json数据后半部
                    string totalStr = "{\"total\":" + count + ",\"rows\"";// json数据前半部
                    result = totalStr + dataStr;// json数据拼接
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }
    }
}

