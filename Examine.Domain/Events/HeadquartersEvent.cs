using Examine.Domain.Model;
using Examine.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Examine.Domain.Events
{
    /// <summary>
    /// 总公司
    /// </summary>
    public class HeadquartersEvent : DomainEvent
    {
        ////申明委托
        //public delegate void ExamineEvent(HeadquartersEvent eventData);
        ////申明事件
        //public event ExamineEvent examineEvent;

        //public HeadquartersEvent()
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();

        //    foreach (var type in assembly.GetTypes())
        //    {
        //        if (typeof(IEventHandler).IsAssignableFrom(type))//判断当前类型是否实现了IEventHandler接口
        //        {
        //            Type handlerInterface = type.GetInterface("IEventHandler`1");//获取该类实现的泛型接口
        //            if (handlerInterface != null)
        //            {
        //                Type eventDataType = handlerInterface.GetGenericArguments()[0]; // 获取泛型接口指定的参数类型

        //                //如果参数类型是FishingEventData，则说明事件源匹配
        //                if (eventDataType.Equals(typeof(HeadquartersEvent)))
        //                {
        //                    //创建实例
        //                    var handler = Activator.CreateInstance(type) as IEventHandler<HeadquartersEvent>;
        //                    //注册事件
        //                    examineEvent += handler.Handle;
        //                }
        //            }
        //        }
        //    }
        //}

        public Headquarters headquarters { get; set; }
    }
}
