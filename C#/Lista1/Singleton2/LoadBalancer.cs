using System;
using System.Collections.Generic;

namespace Singleton2
{
    public class LoadBalancer
    {
        private static LoadBalancer _instance;
        private readonly List<string> _servers = new List<string>();
        private readonly Random _random = new Random();
        private string _ser ;

        private static readonly object SyncLock = new object();

        protected LoadBalancer()
        {
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer GetLoadBalancer()
        {
            if (_instance == null)
            {
                lock (SyncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new LoadBalancer();
                    }
                }
            }

            return _instance;
        }

        // Simple, but effective random load balancer
        private string Server
        {
            get
            {
                var r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }

        public void Server2()
        {
            _ser = Server;
        }

        public string GetSer()
        {
            return _ser;
        }
    }
}
