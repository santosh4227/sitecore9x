using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluralSight.Services
{
    public class GuidService
    {
        private readonly Guid ServiceGuid;

        public GuidService()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }

    public class ScopeService
    {
        private readonly Guid ServiceGuid;

        public ScopeService()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }

    public class SingletonService
    {
        private readonly Guid ServiceGuid;

        public SingletonService()
        {
            ServiceGuid = Guid.NewGuid();
        }

        public string GetGuid() => ServiceGuid.ToString();
    }

}
