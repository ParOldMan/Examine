using Examine.Domain.Events;
using Examine.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examine.Events.handlers
{
    /// <summary>
    /// 行业审核
    /// </summary>
    public class ExamineEventHandler : IEventHandler<HeadquartersEvent>,IEventHandler<StationEvent>
    {
        public Headquarters headquarters { get; set; }

        /// <summary>
        /// 处理总公司审核事件
        /// </summary>
        public void Handle(HeadquartersEvent evt)
        {
            if (evt != null)
            {
                //做相应处理
                headquarters = new Headquarters();

                headquarters.业户名称 = evt.headquarters.业户名称;
                headquarters.核发日期 = evt.headquarters.核发日期;
                headquarters.经营范围 = evt.headquarters.经营范围;
            }
        }

        /// <summary>
        /// 处理客运站审核事件
        /// </summary>
        /// <param name="evt"></param>
        public void Handle(StationEvent evt)
        {
            if (evt != null)
            {
                //做相应处理

            }
        }
    }
}
