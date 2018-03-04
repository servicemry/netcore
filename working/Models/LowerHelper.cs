using System;
namespace working.Models
{
    /// <summary>
    /// 转换小写工具类
    /// </summary>
    public class LowerHelper:Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
