using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Model.Common
{
    /// <summary>
    /// 当前在线用户信息实体类
    /// </summary>
    [Serializable]
    public class OnlineUserInfoModel
    {
        // 当前用户的基本信息
        private UserModel userModel;

        public UserModel UserModel
        {
            get { return userModel; }
            set { userModel = value; }
        }
       
        // 当前用户的权限信息
        // 所拥有的角色
        List<RoleModel> roleList;
        List<RoleMenuModel> roleMenuList;
        List<MenuModel> menuList;

        // 所拥有的菜单


    }
}
