using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examine.Events
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventButs
    {
        /// <summary>
        /// 事件总线对象
        /// </summary>
        private static EventButs _eventBus = null;

        /// <summary>
        /// 领域模型事件句柄字典，用于存储领域模型的句柄
        /// </summary>
        private static Dictionary<Type, List<object>> _dicEventHandler = new Dictionary<Type, List<object>>();

        /// <summary>
        /// 附加领域模型处理句柄时，锁住
        /// </summary>
        private readonly object _syncObject = new object();

        /// <summary>
        /// 单例事件总线
        /// </summary>
        public static EventButs Instance
        {
            get
            {
                return _eventBus ?? (_eventBus = new EventButs());
            }
        }

        private readonly Func<object, object, bool> _eventHandlerEquals = (o1, o2) =>
        {
            return true;
        };

        #region 订阅事件
        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="eventHandler"></param>
        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            //同步锁
            lock (_syncObject)
            {
                //获取领域模型的类型
                var eventType = typeof(TEvent);
                //如果此领域类型在事件总线中已注册过
                if (_dicEventHandler.ContainsKey(eventType))
                {
                    var handlers = _dicEventHandler[eventType];
                    if (handlers != null)
                    {
                        handlers.Add(eventHandler);
                    }
                    else
                    {
                        handlers = new List<object>
                        {
                            eventHandler
                        };
                    }
                }
                else
                {
                    _dicEventHandler.Add(eventType, new List<object> { eventHandler });
                }
            }
        }

        #endregion

        #region 发布事件
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="tEvent"></param>
        /// <param name="callback"></param>
        public void Publish<TEvent>(TEvent tEvent, Action<TEvent, bool, Exception> callback) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_dicEventHandler.ContainsKey(eventType) && _dicEventHandler[eventType] != null &&
                _dicEventHandler[eventType].Count > 0)
            {
                var handlers = _dicEventHandler[eventType];
                try
                {
                    foreach (var handler in handlers)
                    {
                        List<Task> task = new List<Task>();
                        var eventHandler = handler as IEventHandler<TEvent>;
                        task.Add(Task.Factory.StartNew(() => eventHandler.Handle(tEvent)));
                        //Task.WaitAll(task);
                        var tt = Task.Factory.StartNew(() => eventHandler.Handle(tEvent));
                        //Task.
                        //eventHandler.Handle(tEvent);
                        callback(tEvent, true, null);
                    }
                }
                catch (Exception ex)
                {
                    callback(tEvent, false, ex);
                }
            }
            else
            {
                callback(tEvent, false, null);
            }
        }

        #endregion

    }
}