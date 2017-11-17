using Examine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examine.Domain.Events
{
    public class IndustryEvent : IEvent
    {
        /// <summary>
        /// 经营范围
        /// </summary>
        public string jyfw { get; set; }

        /// <summary>
        /// 核发日期
        /// </summary>
        public DateTime hfrq { get; set; }
    }
}
