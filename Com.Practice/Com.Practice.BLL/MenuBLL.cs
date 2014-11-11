using System;
using System.Data;
using System.Collections.Generic;
using Com.Practice.Common;
using Com.Practice.Model;
using Com.Practice.DAL.Common;
using Com.Practice.Common.Json;
namespace Com.Practice.BLL
{
    /// <summary>
    /// menu
    /// </summary>
    public partial class MenuBLL
    {
        public string GetMenuTreeJsonStr(string menuId)
        {
            string result = "";
            string sql = "SELECT * FROM p_menu WHERE parent_id = '{0}' order by sort_level asc";// 添加个排序字段
            string menuSQL = "";
            if (string.IsNullOrEmpty(menuId))
            {
                menuSQL = string.Format(sql, 0);// 获取全部的一级菜单信息
            }
            else
            {
                menuSQL = string.Format(sql, menuId);
            }
            CommonMySQLDAL commonDAL = null;
            try
            {
                commonDAL = new CommonMySQLDAL();
                DataSet ds = commonDAL.QueryDataSetBySQL(menuSQL);
                if (null == ds)
                {
                    throw new Exception("没有找到数据啊");
                }
                else {
                    result = JsonUtils.ObjectToJson(DSUtils.MenuDataSet2TreeModelList(ds));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}

