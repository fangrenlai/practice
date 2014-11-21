using Com.Practice.Model;
using Com.Practice.Model.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Common.Json
{
    public class DSUtils
    {
        public static List<NoCheckTreeModel> MenuDataSet2TreeModelList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];// 获取DataSet的第一张table，取其他table只须改下标
            List<NoCheckTreeModel> treeModelList = new List<NoCheckTreeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                NoCheckTreeModel treeModel = new NoCheckTreeModel();
                treeModel.id = dr["id"].ToString();
                treeModel.text = dr["name"].ToString();
                treeModel.state = "closed";
                TreeAttributes treeAttr = new TreeAttributes();
                treeAttr.url = dr["path"].ToString();
                treeModel.attributes = treeAttr;
                treeModelList.Add(treeModel);
            }
            return treeModelList;
        }

        public static List<RoleModel> DT2RoleModelList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];// 获取DataSet的第一张table，取其他table只须改下标
            List<RoleModel> roleModelList = new List<RoleModel>();
            foreach (DataRow dr in dt.Rows)
            {
                RoleModel roleModel = new RoleModel();
                roleModel.id = Convert.ToInt32(dr["id"]);
                roleModel.name = dr["name"].ToString();
                roleModelList.Add(roleModel);
            }
            return roleModelList;
        }

        public static List<MenuModel> DT2MenuModelList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];// 获取DataSet的第一张table，取其他table只须改下标
            List<MenuModel> menuModelList = new List<MenuModel>();
            foreach (DataRow dr in dt.Rows)
            {
                MenuModel menuModel = new MenuModel();
                menuModel.id = Convert.ToInt32(dr["id"]);
                menuModel.name = dr["name"].ToString();
                menuModelList.Add(menuModel);
            }
            return menuModelList;
        }

        public static List<FunctionModel> DT2FunctionModelList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];// 获取DataSet的第一张table，取其他table只须改下标
            List<FunctionModel> menuModelList = new List<FunctionModel>();
            foreach (DataRow dr in dt.Rows)
            {
                FunctionModel functionModel = new FunctionModel();
                functionModel.id = Convert.ToInt32(dr["id"]);
                functionModel.name = dr["name"].ToString();
                menuModelList.Add(functionModel);
            }
            return menuModelList;
        }
    }
}
