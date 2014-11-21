using Com.Practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Common.Json
{
    public class TreeUtils
    {
        public static string GetUserRoleStr(List<RoleModel> allRoleList, List<RoleModel> userRoleList)
        {

            string result = "[";
            foreach (RoleModel allRoleModel in allRoleList)
            {
                string temp = "";
                if (hasRole(allRoleModel, userRoleList))
                {
                    temp = "{\"id\":\"" + allRoleModel.id + "\",\"checked\":\"checked\",\"text\":\"" + allRoleModel.name + "\",\"state\":\"closed\"},";
                }
                else
                {
                    temp = "{\"id\":\"" + allRoleModel.id + "\",\"checked\":\"\",\"text\":\"" + allRoleModel.name + "\",\"state\":\"closed\"},";
                }
                result += temp;
            }
            result = result.Remove(result.LastIndexOf(","), 1);
            result += "]";
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allRoleModel"></param>
        /// <param name="userRoleList"></param>
        /// <returns></returns>
        private static bool hasRole(RoleModel allRoleModel, List<RoleModel> userRoleList)
        {
            bool result = false;
            if (0 == userRoleList.Count) { }
            else
            {
                foreach (RoleModel userRoleModel in userRoleList)
                {
                    if (allRoleModel.id == userRoleModel.id)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static string GetRoleMenuStr(List<MenuModel> allMenuList, List<MenuModel> menuList)
        {
            string result = "[";
            foreach (MenuModel allMenuModel in allMenuList)
            {
                string temp = "";
                if (hasMenu(allMenuModel, menuList))
                {
                    temp = "{\"id\":\"" + allMenuModel.id + "\",\"checked\":\"checked\",\"text\":\"" + allMenuModel.name + "\",\"state\":\"closed\"},";
                }
                else
                {
                    temp = "{\"id\":\"" + allMenuModel.id + "\",\"checked\":\"\",\"text\":\"" + allMenuModel.name + "\",\"state\":\"closed\"},";
                }
                result += temp;
            }
            result = result.Remove(result.LastIndexOf(","), 1);
            result += "]";
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="allMenuModel"></param>
        /// <param name="menuList"></param>
        /// <returns></returns>
        private static bool hasMenu(MenuModel allMenuModel, List<MenuModel> menuList)
        {
            bool result = false;
            if (0 == menuList.Count) { }
            else
            {
                foreach (MenuModel menuModel in menuList)
                {
                    if (allMenuModel.id == menuModel.id)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        public static string GetMenuFunctionStr(List<FunctionModel> allFunctionModelList, List<FunctionModel> functionModelList)
        {
            string result = "[";
            foreach (FunctionModel allFunctionModel in allFunctionModelList)
            {
                string temp = "";
                if (hasFunction(allFunctionModel, functionModelList))
                {
                    temp = "{\"id\":\"" + allFunctionModel.id + "\",\"checked\":\"checked\",\"text\":\"" + allFunctionModel.name + "\",\"state\":\"closed\"},";
                }
                else
                {
                    temp = "{\"id\":\"" + allFunctionModel.id + "\",\"checked\":\"\",\"text\":\"" + allFunctionModel.name + "\",\"state\":\"closed\"},";
                }
                result += temp;
            }
            result = result.Remove(result.LastIndexOf(","), 1);
            result += "]";
            return result;
        }

        private static bool hasFunction(FunctionModel allFunctionModel, List<FunctionModel> functionModelList)
        {
            bool result = false;
            if (0 == functionModelList.Count) { }
            else
            {
                foreach (FunctionModel functionModel in functionModelList)
                {
                    if (allFunctionModel.id == functionModel.id)
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        //

        //
    }
}
