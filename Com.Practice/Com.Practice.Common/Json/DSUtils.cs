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
        public static List<TreeModel> MenuDataSet2TreeModelList(DataSet ds)
        {
            DataTable dt = ds.Tables[0];// 获取DataSet的第一张table，取其他table只须改下标
            List<TreeModel> treeModelList = new List<TreeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                TreeModel treeModel = new TreeModel();
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
    }
}
