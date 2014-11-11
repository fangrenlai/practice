using System;
using System.Data;
using System.Collections.Generic;
using Com.Practice.Common;
using Com.Practice.Model;
using Com.Practice.Model.Common;
using Com.Practice.DAL;
using Com.Practice.Common.Json;
using Com.Practice.DAL.Common;
namespace Com.Practice.BLL
{
    /// <summary>
    /// function
    /// </summary>
    public class FunctionBLL
    {

        /// <summary>
        /// 获取特定的数据json串
        /// </summary>
        /// <param name="paginationModel"></param>
        /// <param name="functionQueryModel"></param>
        /// <returns></returns>
        public string GetSpecificDataJsonStr(PaginationModel paginationModel, FunctionQueryModel functionQueryModel)
        {
            string result = null;
            if (null == paginationModel || null == functionQueryModel)
            {
                throw new Exception("查询条件实体类为null");
            }
            else
            {
                if (0 == paginationModel.Page || 0 == paginationModel.Rows)
                {
                    throw new Exception("查询分页参数错误，当前第0页，每页显示0条数据？");
                }
                else
                {
                    int startIndex = (paginationModel.Page - 1) * paginationModel.Rows;

                    string dataSQL = @"SELECT id, function_code,function_name,created_by_id,created_by_name,updated_by_id,updated_by_name,DATE_FORMAT(created_at,'%Y-%m-%d %T') as created_at,DATE_FORMAT(updated_at,'%Y-%m-%d %T') as updated_at FROM p_function ";
                    string conditionSQL = "where 1=1 ";
                    if (0 != functionQueryModel.QueryId)
                    {
                        conditionSQL += string.Format("and id = '{0}' ", functionQueryModel.QueryId);
                    }
                    if (!string.IsNullOrEmpty(functionQueryModel.QueryCode))
                    {
                        conditionSQL += string.Format("and function_code like '%{0}%' ", functionQueryModel.QueryCode);
                    }
                    if (!string.IsNullOrEmpty(functionQueryModel.QueryName))
                    {
                        conditionSQL += string.Format("and function_name like '%{0}%' ", functionQueryModel.QueryName);
                    }
                    if ((!string.IsNullOrEmpty(functionQueryModel.QueryCreateStartTime)) && string.IsNullOrEmpty(functionQueryModel.QueryCreateEndTime))
                    {
                        conditionSQL += string.Format("and DATE_FORMAT(created_at,'%Y-%m-%d %T') >= '{0}' ", functionQueryModel.QueryCreateStartTime);
                    }
                    if (string.IsNullOrEmpty(functionQueryModel.QueryCreateStartTime) && (!string.IsNullOrEmpty(functionQueryModel.QueryCreateEndTime)))
                    {
                        conditionSQL += string.Format("and DATE_FORMAT(created_at,'%Y-%m-%d %T') <= '{0}' ", functionQueryModel.QueryCreateEndTime);
                    }
                    if ((!string.IsNullOrEmpty(functionQueryModel.QueryCreateStartTime)) && (!string.IsNullOrEmpty(functionQueryModel.QueryCreateEndTime)))
                    {
                        conditionSQL += string.Format("and DATE_FORMAT(created_at,'%Y-%m-%d %T') between '{0}' and '{1}' ", functionQueryModel.QueryCreateStartTime, functionQueryModel.QueryCreateEndTime);
                    }
                    string orderSQL = "ORDER BY ID ASC ";
                    if ((!string.IsNullOrEmpty(paginationModel.Sort)) && (!string.IsNullOrEmpty(paginationModel.Order)))
                    {
                        orderSQL = string.Format("ORDER BY {0} {1} ", paginationModel.Sort, paginationModel.Order);
                    }
                    string limitSQL = string.Format("LIMIT {0},{1}", startIndex, paginationModel.Rows);
                    string finalDataSQL = dataSQL + conditionSQL + orderSQL + limitSQL;
                    // string dataSQL = " ORDER BY id ASC LIMIT " + startIndex + "," + paginationModel.Rows;
                    string countSQL = "SELECT count(*) FROM p_function " + conditionSQL;
                    try
                    {
                        CommonMySQLDAL dal = new CommonMySQLDAL();
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

        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="functionModel"></param>
        /// <returns></returns>
        public bool AddFunction(FunctionModel functionModel)
        {
            bool result = false;
            if (null == functionModel) { }
            else
            {
                FunctionDAL functionDAL = null;
                try
                {
                    functionDAL = new FunctionDAL();
                    result = functionDAL.Add(functionModel);
                }
                catch (Exception e) { throw e; }
            }
            return result;
        }


        /// <summary>
        /// 根据id获取一个实体信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns>null/实体信息</returns>
        public FunctionModel GetModelById(int id)
        {
            FunctionModel model = null;
            FunctionDAL functionDAL = null;
            if (0 == id) { }
            else
            {
                try
                {
                    model = new FunctionModel();
                    functionDAL = new FunctionDAL();
                    model = functionDAL.GetModel(id);
                }
                catch (Exception e) { throw e; }
            }
            return model;
        }

        /// <summary>
        /// 更新一个实体信息
        /// </summary>
        /// <param name="newModel"></param>
        /// <returns>bool</returns>
        public bool UpdateFunction(FunctionModel newModel)
        {
            bool result = false;
            if (null == newModel)
            { }
            else
            {
                FunctionDAL functionDAL = null;
                try
                {
                    functionDAL = new FunctionDAL();
                    result = functionDAL.Update(newModel);
                }
                catch (Exception e) { throw e; }
            }
            return result;
        }

        /// <summary>
        /// 删除？条信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteFunctionsByIds(string ids)
        {
            bool result = false;
            if (string.IsNullOrEmpty(ids)) { }
            else
            {
                FunctionDAL functionDAL = null;
                try
                {
                    functionDAL = new FunctionDAL();
                    result = functionDAL.DeleteList(ids);
                }
                catch (Exception e) { throw e; }
            }
            return result;
        }

        //

    }
}

