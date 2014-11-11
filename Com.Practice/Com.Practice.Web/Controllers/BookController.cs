using Com.Practice.BLL;
using Com.Practice.Common.Json;
using Com.Practice.DAL.Common;
using Com.Practice.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Com.Practice.Web.Controllers
{
    public class BookController : Controller
    {
        private int page;
        private int rows;
        private int fromNum;
        /// <summary>
        /// 跳转到书籍管理主页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Ajax分页获取书籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBooksByPage()
        {
            try
            {
                // 分页参数
                page = Convert.ToInt32(Request["page"]);
                rows = Convert.ToInt32(Request["rows"]);
                fromNum = (page - 1) * rows;// 记录起始数
                // 根据查询条件拼凑SQL语句
                string countSQL = "select count(*) from p_book where 1=1 ";// 获取记录总条数SQL语句
                string dataSQL = @"select id,name,version,DATE_FORMAT(published_at,'%Y-%m-%d') as published_at,created_by,DATE_FORMAT(created_at,'%Y-%m-%d %T') as created_at,updated_by,DATE_FORMAT(updated_at,'%Y-%m-%d %T') as updated_at from p_book where 1=1 "; // 获取数据SQL语句
                if (null != Request["id"] && "" != Request["id"])
                {
                    string id = Request["id"].ToString();
                    countSQL += string.Format(" and id = '{0}'" , id);
                    dataSQL += string.Format(" and id = '{0}'", id);
                    
                }
                if (null != Request["name"] && "" != Request["name"])
                {
                    string name = Request["name"].ToString();
                    countSQL += string.Format(" and name like '%{0}%'", name);
                    dataSQL += string.Format(" and name like '%{0}%'", name);
                }
                if (null != Request["version"] && "" != Request["version"])
                {
                    string version = Request["version"].ToString();
                    countSQL += string.Format(" and version like '%{0}%'",version);
                    dataSQL += string.Format(" and version like '%{0}%'", version);
                }
                if (null != Request["published_at_start"] && "" != Request["published_at_start"] && null != Request["published_at_end"] && "" != Request["published_at_end"])
                {
                    string published_at_start = Request["published_at_start"].ToString();
                    string published_at_end = Request["published_at_end"].ToString();
                    countSQL += string.Format(" and DATE_FORMAT(published_at,'%Y-%m-%d') between '{0}' and '{1}'", published_at_start, published_at_end);
                    dataSQL += string.Format(" and DATE_FORMAT(published_at,'%Y-%m-%d') between '{0}' and '{1}'", published_at_start, published_at_end);
                }
                // 最后都要加上分页条件
                dataSQL += " limit " + fromNum + "," + rows; // limit 其实记录数，欲查询记录条数
                // 开始查询
                CommonMySQLDAL dal = new CommonMySQLDAL();
                DataSet ds = dal.QueryDataSetBySQL(dataSQL);// 获取数据
                int count = dal.QueryCountBySQL(countSQL);// 获取记录总数
                string dsStr = JsonUtils.ObjectToJson(ds);
                String dataStr = dsStr.Substring(5, dsStr.Length - 5);// json数据后半部
                string totalStr = "{\"total\":" + count + ",\"rows\"";// json数据前半部
                string finalStr = totalStr + dataStr;// json数据拼接
                return Content(finalStr);// 返回json数据
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }
        }

        /// <summary>
        /// 保存书籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult SaveBook()
        {
            BookBLL bookBLL = new BookBLL();
            BookModel book = new BookModel();
            try
            {
                string name = Request["name"].ToString();
                string version = Request["version"].ToString();
                string published_at = Request["published_at"].ToString() + " 00:00:00";
                book.name = name;
                book.version = version;
                book.published_at = Convert.ToDateTime(published_at);//yyyy-MM-dd hh:mm:ss
                book.created_by = 1;
                book.created_at = DateTime.Now;
                book.updated_by = 1;
                book.updated_at = DateTime.Now;
                bookBLL.Add(book);
                return Json(new { result = 1 });
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }

        }

        /// <summary>
        /// 修改书籍信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditBook()
        {
            BookBLL bookBLL = new BookBLL();
            BookModel book = new BookModel();
            try
            {
                int id = Convert.ToInt32(Request["id"].ToString());
                string name = Request["name"].ToString();
                string version = Request["version"].ToString();
                string published_at = Request["published_at"].ToString() + " 00:00:00";
                book = bookBLL.GetModel(id);
                book.name = name;
                book.version = version;
                book.published_at = Convert.ToDateTime(published_at);
                book.updated_at = DateTime.Now;
                bookBLL.Update(book);
                return Json(new { result = 1 });
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }
        }

        /// <summary>
        /// 删除书籍信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult DeleteBooks()
        {
            BookBLL bookBLL = new BookBLL();
            string idlist = Request["ids"].ToString();
            try
            {
                bookBLL.DeleteList(idlist);
                return Json(new { result = 1 });
            }
            catch (Exception e)
            {
                return Json(new { result = -1, msg = e.Message });
            }

        }
    }
}
