using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Practice.Common.Json
{
    /// <summary>
    /// json相关操作工具类
    /// </summary>
    public class JsonUtils
    {
        // 从一个对象信息生成Json串
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // 从一个Json串生成对象信息
        public static object JsonToObject(string jsonString, object obj)
        {
            return JsonConvert.DeserializeObject(jsonString, obj.GetType());
        }
        // List转换成json字符串
        public static string ListToJson(List<object> list)
        {

            return JsonConvert.SerializeObject(list);
        }
        // json字符串转换成List
        public static T JsonToList<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
