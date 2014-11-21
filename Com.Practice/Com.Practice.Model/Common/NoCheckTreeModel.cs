using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Model.Common
{
    public class NoCheckTreeModel
    {
        public string id;//节点ID
        public string text;//显示节点文本
        public string state = "closed";//节点状态，'open' 或 'closed'，默认：'open'。如果为'closed'的时候，将不自动展开该节点。
        public TreeAttributes attributes;//被添加到节点的自定义属性。
    }
}
