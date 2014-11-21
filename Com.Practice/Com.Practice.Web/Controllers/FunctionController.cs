using Com.Practice.BLL;
using Com.Practice.Common.Json;
using Com.Practice.Model;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    /// <summary>
    /// 功能表控制器
    /// 方仁来
    /// 2014年11月5日14:31:39
    /// </summary>
    public class FunctionController : Controller
    {

        /// <summary>
        /// 跳转到功能表维护主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取满足特定条件的功能信息列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetSpecificFunctionsByPage()
        {
            int page = 0;
            int rows = 0;
            FunctionBLL functionBLL = null;
            string sort = "";
            string order = "";
            PaginationModel paginationModel = null;
            FunctionQueryModel functionQueryModel = null;
            string query_id = "";
            string query_name = "";
            string query_created_at_start = "";
            string query_created_at_end = "";
            try
            {
                // page=1&rows=10&sort=UserName&order=desc
                page = null == Request["page"] ? 0 : Convert.ToInt32(Request["page"].ToString());// 当前第？页
                rows = null == Request["rows"] ? 0 : Convert.ToInt32(Request["rows"].ToString());// 每页显示？条数据
                sort = null == Request["sort"] ? "" : Request["sort"].ToString();
                order = null == Request["order"] ? "" : Request["order"].ToString();
                // 接收查询条件
                query_id = null == Request["query_id"] ? "" : Request["query_id"].ToString();
                //query_id = null == Request["query_id"] ? 0 : Convert.ToInt32(Request["query_id"].ToString());
                query_name = null == Request["query_name"] ? "" : Request["query_name"].ToString();
                query_created_at_start = null == Request["query_created_at_start"] ? "" : Request["query_created_at_start"].ToString();
                query_created_at_end = null == Request["query_created_at_end"] ? "" : Request["query_created_at_end"].ToString();
                paginationModel = new PaginationModel(page, rows, sort, order);
                functionQueryModel = new FunctionQueryModel();
                if (string.IsNullOrEmpty(query_id))
                {
                    functionQueryModel.QueryId = 0;
                }
                else
                {
                    functionQueryModel.QueryId = Convert.ToInt32(query_id);
                }

                functionQueryModel.QueryName = query_name;
                functionQueryModel.QueryCreateStartTime = query_created_at_start;
                functionQueryModel.QueryCreateEndTime = query_created_at_end;

                functionBLL = new FunctionBLL();
                string pageDataStr = functionBLL.GetSpecificDataJsonStr(paginationModel, functionQueryModel);
                return Content(pageDataStr);
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="functionModel"></param>
        /// <returns></returns>
        public ActionResult AddFunction()
        {
            string functionName = null == Request["name"] ? "" : Request["name"].ToString();
            if (string.IsNullOrEmpty(functionName))
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：表单数据不符合要求" });
            }
            else
            {
                OnlineUserInfoModel onlineUserInfoModel = null;
                string onlineUserInfoString = null == Session["CURRENT_ONLINE_USER_INFO"] ? "" : Session["CURRENT_ONLINE_USER_INFO"].ToString();
                if (string.IsNullOrEmpty(onlineUserInfoString))
                {
                    return Json(new { result = -1, msg = "出错了，错误代码/信息为：Session值过期了，需要重新登录" });
                }
                else
                {
                    onlineUserInfoModel = new OnlineUserInfoModel();
                    onlineUserInfoModel = (OnlineUserInfoModel)JsonUtils.JsonToObject(onlineUserInfoString, onlineUserInfoModel);
                    FunctionModel addModel = new FunctionModel();
                    addModel.name = functionName;
                    addModel.created_at = DateTime.Now;
                    addModel.created_by = onlineUserInfoModel.UserModel.id;
                    addModel.created_by_name = onlineUserInfoModel.UserModel.login_name;
                    addModel.updated_at = DateTime.Now;
                    addModel.updated_by = onlineUserInfoModel.UserModel.id;
                    addModel.updated_by_name = onlineUserInfoModel.UserModel.login_name;
                    FunctionBLL functionBLL = null;
                    try
                    {
                        functionBLL = new FunctionBLL();
                        bool addResult = functionBLL.AddFunction(addModel);
                        if (addResult)
                        {
                            return Json(new { result = 1, msg = "添加信息成功" });
                        }
                        else
                        {
                            return Json(new { result = -1, msg = "出错了，错误代码/信息为：数据库交互出错" });
                        }
                    }
                    catch (Exception e)
                    {
                        return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message });
                    }
                }
            }
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="functionModel"></param>
        /// <returns></returns>
        public ActionResult UpdateFunction()
        {
            string idStr = null == Request["id"] ? "" : Request["id"].ToString();
            int id = 0;
            if (!string.IsNullOrEmpty(idStr))
            {
                id = Convert.ToInt32(idStr);
            }
            string functionName = null == Request["name"] ? "" : Request["name"].ToString();
            if (string.IsNullOrEmpty(functionName) || (0 == id))
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：表单数据不符合要求" });
            }
            else
            {
                OnlineUserInfoModel onlineUserInfoModel = null;
                string onlineUserInfoString = null == Session["CURRENT_ONLINE_USER_INFO"] ? "" : Session["CURRENT_ONLINE_USER_INFO"].ToString();
                if (string.IsNullOrEmpty(onlineUserInfoString))
                {
                    return Json(new { result = -1, msg = "出错了，错误代码/信息为：Session值过期了，需要重新登录" });
                }
                else
                {
                    onlineUserInfoModel = new OnlineUserInfoModel();
                    onlineUserInfoModel = (OnlineUserInfoModel)JsonUtils.JsonToObject(onlineUserInfoString, onlineUserInfoModel);
                    FunctionBLL functionBLL = null;
                    try
                    {
                        functionBLL = new FunctionBLL();
                        FunctionModel oldModel = new FunctionModel();
                        oldModel = functionBLL.GetModelById(id);
                        if (null == oldModel)
                        {
                            return Json(new { result = -1, msg = "出错了，错误代码/信息为：原记录已经不存在了" });
                        }
                        else
                        {
                            FunctionModel updateModel = new FunctionModel();
                            updateModel.id = id;
                            updateModel.name = functionName;
                            updateModel.updated_at = DateTime.Now;
                            updateModel.updated_by = onlineUserInfoModel.UserModel.id;
                            updateModel.updated_by_name = onlineUserInfoModel.UserModel.login_name;
                            // 没有改动的部分要用老数据填充
                            updateModel.created_at = oldModel.created_at;
                            updateModel.created_by = oldModel.created_by;
                            updateModel.created_by_name = oldModel.created_by_name;
                            bool addResult = functionBLL.UpdateFunction(updateModel);
                            if (addResult)
                            {
                                return Json(new { result = 1, msg = "修改信息成功" });
                            }
                            else
                            {
                                return Json(new { result = -1, msg = "出错了，错误代码/信息为：数据库交互出错" });
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message });
                    }
                }
            }
        }

        /// <summary>
        /// 删除?条记录
        /// </summary>
        /// <param name="functionModel"></param>
        /// <returns></returns>
        public ActionResult DeleteFunctions()
        {
            string ids = null == Request["ids"] ? "" : Request["ids"].ToString();
            if (string.IsNullOrEmpty(ids))
            {
                return Json(new { result = -1, msg = "出错了，错误代码/信息为：提交的数据不符合要求" });
            }
            else
            {
                FunctionBLL functionBLL = null;
                try
                {
                    functionBLL = new FunctionBLL();
                    bool delResult = false;
                    delResult = functionBLL.DeleteFunctionsByIds(ids);
                    if (delResult)
                    {
                        return Json(new { result = 1, msg = "删除成功" });
                    }
                    else
                    {
                        return Json(new { result = -1, msg = "出错了，错误代码/信息为：数据库交互出错" });
                    }
                }
                catch (Exception e)
                {
                    return Json(new { result = -1, msg = "出错了，错误代码/信息为：" + e.Message });
                }
            }
        }

    }
}
