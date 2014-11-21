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
    /// user
    /// </summary>
    public class UserBLL
    {
        private readonly Com.Practice.DAL.UserDAL dal = new Com.Practice.DAL.UserDAL();
        public UserBLL()
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
        public bool Add(Com.Practice.Model.UserModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Com.Practice.Model.UserModel model)
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
        public Com.Practice.Model.UserModel GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体（重载）
        /// </summary>
        public Com.Practice.Model.UserModel GetModel(string loginName)
        {

            return dal.GetModel(loginName);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Com.Practice.Model.UserModel GetModelByCache(int id)
        {

            string CacheKey = "userModel-" + id;
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
            return (Com.Practice.Model.UserModel)objModel;
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
        public List<Com.Practice.Model.UserModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Com.Practice.Model.UserModel> DataTableToList(DataTable dt)
        {
            List<Com.Practice.Model.UserModel> modelList = new List<Com.Practice.Model.UserModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Com.Practice.Model.UserModel model;
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
        public string GetUsersByPage(PaginationModel paginationModel, UserQueryModel queryModel)
        {
            string result = "";
            if (null == paginationModel || null == queryModel)
            {
                throw new Exception("查询条件实体类为null");
            }
            else if (0 == paginationModel.Page || 0 == paginationModel.Rows)
            {
                throw new Exception("查询分页参数错误，当前第0页，每页显示0条数据？");
            }
            else
            {
                int startIndex = (paginationModel.Page - 1) * paginationModel.Rows;
                string dataSQL = @"SELECT id,login_name AS loginName,nick_name AS nickName,pwd,e_mail AS email,CASE e_mail_flag WHEN 1 THEN '有效' ELSE '无效' END AS emailStatus ,mobile_num AS mobilePhone,CASE mobile_num_flag WHEN 1 THEN '有效' ELSE '无效' END AS mobilePhoneStatus, CASE user_status WHEN 1 THEN '有效' ELSE '无效' END AS userStatus,created_by_name AS createName,updated_by_name AS updateName FROM p_user ";
                string conditionSQL = "where 1=1 ";
                if (!string.IsNullOrEmpty(queryModel.QueryLoginName))
                {
                    conditionSQL += string.Format("and login_name like '%{0}%' ", queryModel.QueryLoginName);
                }
                if (!string.IsNullOrEmpty(queryModel.NickName))
                {
                    conditionSQL += string.Format("and nick_name like '%{0}%' ", queryModel.NickName);
                }
                string orderSQL = "ORDER BY ID ASC ";
                if ((!string.IsNullOrEmpty(paginationModel.Sort)) && (!string.IsNullOrEmpty(paginationModel.Order)))
                {
                    orderSQL = string.Format("ORDER BY {0} {1} ", paginationModel.Sort, paginationModel.Order);
                }
                string limitSQL = string.Format("LIMIT {0},{1}", startIndex, paginationModel.Rows);
                string finalDataSQL = dataSQL + conditionSQL + orderSQL + limitSQL;
                // string dataSQL = " ORDER BY id ASC LIMIT " + startIndex + "," + paginationModel.Rows;
                string countSQL = "SELECT count(*) FROM p_user " + conditionSQL;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="paramId">节点id</param>
        /// <returns></returns>
        public string GetNodeInfo(int userId, int paramId)
        {
            string result = "";
            if (0 == userId)
            { }
            else
            {
                CommonMySQLDAL dal = new CommonMySQLDAL();
                if (0 == paramId)// 获取角色信息
                {
                    string allRoleSQL = @"SELECT r.id,r.name FROM p_role r";
                    string userRoleSQL = @"SELECT r.id,r.name FROM p_role r,p_user_role ur WHERE ur.role_id = r.id AND ur.user_id = '{0}'";
                    userRoleSQL = string.Format(userRoleSQL, userId);
                    DataSet allRoleDT = dal.QueryDataSetBySQL(allRoleSQL);
                    DataSet userRoleDT = dal.QueryDataSetBySQL(userRoleSQL);
                    List<RoleModel> allRoleList = DSUtils.DT2RoleModelList(allRoleDT);
                    List<RoleModel> userRoleList = DSUtils.DT2RoleModelList(userRoleDT);
                    result = TreeUtils.GetUserRoleStr(allRoleList, userRoleList);
                }
                else if (0 < paramId && 99 >= paramId)// 获取菜单信息，paramId为角色id
                {
                    string allFirstMenuSQL = @"SELECT m.id,m.name FROM p_menu m,p_role_menu rm WHERE m.parent_id='0' AND m.id = rm.menu_id AND rm.role_id ='{0}'";
                    allFirstMenuSQL = string.Format(allFirstMenuSQL, paramId);
                    string firstMenuSQL = @"SELECT m.id,m.name FROM p_menu m,p_user_role_menu urm WHERE m.id = urm.menu_id AND m.parent_id='0' AND urm.user_id = '{0}' AND  urm.role_id='{1}'";
                    firstMenuSQL = string.Format(firstMenuSQL, userId, paramId);
                    DataSet allFirstMenuDT = dal.QueryDataSetBySQL(allFirstMenuSQL);
                    DataSet firstMenuDT = dal.QueryDataSetBySQL(firstMenuSQL);
                    List<MenuModel> allFirstMenuList = DSUtils.DT2MenuModelList(allFirstMenuDT);
                    List<MenuModel> firstMenuList = DSUtils.DT2MenuModelList(firstMenuDT);
                    result = TreeUtils.GetRoleMenuStr(allFirstMenuList, firstMenuList);
                }
                else if (100 <= paramId && 999 >= paramId)// 获取二级菜单信息，paramId为一级菜单id
                {
                    string allSecondMenuSQL = @"SELECT  m.id,m.name FROM p_menu m WHERE m.parent_id ='{0}'";
                    allSecondMenuSQL = string.Format(allSecondMenuSQL, paramId);
                    string secondMenuSQL = @"SELECT m.id,m.name FROM p_menu m,p_user_role_menu urm WHERE m.id = urm.menu_id AND m.parent_id='{0}' AND urm.user_id = '{1}'";
                    secondMenuSQL = string.Format(secondMenuSQL, paramId, userId);
                    DataSet allSecondMenuDT = dal.QueryDataSetBySQL(allSecondMenuSQL);
                    DataSet secondMenuDT = dal.QueryDataSetBySQL(secondMenuSQL);
                    List<MenuModel> allSecondMenuList = DSUtils.DT2MenuModelList(allSecondMenuDT);
                    List<MenuModel> secondMenuList = DSUtils.DT2MenuModelList(secondMenuDT);
                    result = TreeUtils.GetRoleMenuStr(allSecondMenuList, secondMenuList);
                }
                else if (1000 <= paramId && 9999 >= paramId)// 获取功能信息，paramId为二级菜单id
                {
                    string allMenuFunctionSQL = "SELECT f.id,f.name FROM p_function f,p_menu_function mf WHERE mf.function_id = f.id AND  mf.menu_id='{0}'";
                    allMenuFunctionSQL = string.Format(allMenuFunctionSQL, paramId);
                    string menuFunctionSQL = @"SELECT f.id,f.name FROM p_function f,p_user_role_menu_function urmf WHERE urmf.function_id = f.id AND urmf.menu_id='{0}' AND urmf.user_id='{1}'";
                    menuFunctionSQL = string.Format(menuFunctionSQL, paramId, userId);
                    DataSet allMenuFunctionDT = dal.QueryDataSetBySQL(allMenuFunctionSQL);
                    DataSet menuFunctionDT = dal.QueryDataSetBySQL(menuFunctionSQL);
                    List<FunctionModel> allFirstMenuList = DSUtils.DT2FunctionModelList(allMenuFunctionDT);
                    List<FunctionModel> firstMenuList = DSUtils.DT2FunctionModelList(menuFunctionDT);
                    result = TreeUtils.GetMenuFunctionStr(allFirstMenuList, firstMenuList);
                }
                else
                {
                    result = "";
                }
                // 用户id，正常的
                // 角色id，1-99
                // 一级菜单id，100-999
                // 二级菜单id，1000-9999
                // 功能id,10000-99999
            }
            return result;
        }
        //
        public string GetUserRoles(int userId, int id)
        {
            string result = "";
            if (0 == id)
            {
                string allRolesSQL = @"SELECT r.id,r.name FROM p_role r";
                string userRolesSQL = @"SELECT r.id,r.name FROM p_role r, p_user_role ur WHERE ur.role_id = r.id AND ur.user_id = '{0}'";
                userRolesSQL = string.Format(userRolesSQL, userId);
                CommonMySQLDAL dal = new CommonMySQLDAL();
                DataSet allRolesDT = dal.QueryDataSetBySQL(allRolesSQL);
                DataSet userRolesDT = dal.QueryDataSetBySQL(userRolesSQL);
                List<RoleModel> allRolesList = DSUtils.DT2RoleModelList(allRolesDT);
                List<RoleModel> userRolesList = DSUtils.DT2RoleModelList(userRolesDT);
                result = TreeUtils.GetUserRoleStr(allRolesList, userRolesList);
            }
            else // 后面的节点不展示信息
            {
                result = "";
            }
            return result;
        }

        //
        public bool MergeUserRoles(int userId, string ids)
        {
            bool result = false;
            string deleteSQL = "DELETE FROM p_user_role ur WHERE ur.user_id = '{0}'";
            deleteSQL = string.Format(deleteSQL,userId);
            if (string.IsNullOrEmpty(ids)) 
            {
                // 删除userid在p_user_role当中的数据
                
            } else 
            {
                // 删除userid在p_user_role当中的数据
                // 在p_user_role添加新数据
            }
            return result;
        }



        #endregion  ExtensionMethod







        
    }
}

