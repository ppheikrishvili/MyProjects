using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using OutlookReplayBySender.Model.ViewModel;

namespace OutlookReplayBySender.Common
{
    public class DIStory
    {
        ConcurrentDictionary<string, dynamic> _repositories;

        private Type GetSubClassType(Type baseT) =>
            Assembly.GetAssembly(baseT)?.GetTypes().FirstOrDefault(t =>
                typeof(BaseViewModel).IsAssignableFrom(t) && baseT == t &&
                t.IsClass && t.BaseType != null && !t.IsInterface && !t.IsAbstract
            );

        public BaseViewModel CreateClass<T>() where T : BaseViewModel
        {
            Type repositoryType = GetSubClassType(typeof(T));
            if (repositoryType == null) return (BaseViewModel)Activator.CreateInstance(typeof(BaseViewModel));
            return (BaseViewModel)Activator.CreateInstance(repositoryType);
        }

        public BaseViewModel Repository<T>() where T : BaseViewModel
        {
            if (_repositories == null) _repositories = new ConcurrentDictionary<string, dynamic>();
            return _repositories.GetOrAdd(typeof(T).Name, _ => CreateClass<T>());
        }

        public void Add<T>(T obj) where T : BaseViewModel
        {
            if (_repositories == null) _repositories = new ConcurrentDictionary<string, dynamic>();
            _repositories.GetOrAdd(typeof(T).Name, _ => obj);
        }

    }
}
