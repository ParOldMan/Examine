using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examine.Domain.Model
{
    /// <summary>
    /// 总公司
    /// </summary>
    public class Headquarters : IEntity
    {
        /// <summary>
        /// 业户账号
        /// </summary>
        public string 业户账号 { get; set; }
        /// <summary>
        /// 业户名称
        /// </summary>
        public string 业户名称 { get; set; }
        /// <summary>
        /// 单位级别
        /// </summary>
        public string 单位级别 { get; set; }
        /// <summary>
        /// 所属地区
        /// </summary>
        public string 所属地区 { get; set; }
        /// <summary>
        /// 上级单位
        /// </summary>
        public string 上级单位 { get; set; }
        /// <summary>
        /// 管理部门
        /// </summary>
        public string 管理部门 { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string 经营范围 { get; set; }
        /// <summary>
        /// 经营许可证号
        /// </summary>
        public string 经营许可证号 { get; set; }
        /// <summary>
        /// 核发日期
        /// </summary>
        public DateTime 核发日期 { get; set; }
    }
}
