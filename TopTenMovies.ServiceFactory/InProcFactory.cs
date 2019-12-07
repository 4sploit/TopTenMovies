using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace TopTenMovies.ServiceFactory
{
    public static class InProcFactory
    {
        static readonly string BaseAddress = "net.pipe://toptenmovies.wcf/" + Guid.NewGuid();
        static readonly Binding Binding;
        static Dictionary<Type, Tuple<ServiceHost, EndpointAddress>> m_Hosts =
        new Dictionary<Type, Tuple<ServiceHost, EndpointAddress>>();

        static InProcFactory()
        {
            NetNamedPipeBinding binding = new NetNamedPipeBinding();
            binding.TransactionFlow = true;
            Binding = binding;

            AppDomain.CurrentDomain.ProcessExit += delegate
            {
                foreach (Tuple<ServiceHost, EndpointAddress>
                record in m_Hosts.Values)
                {
                    record.Item1.Close();
                }
            };
        }

        public static I CreateInstance<S, I>() where I : class
                                               where S : I
        {
            EndpointAddress address = GetAddress<S, I>();
            return ChannelFactory<I>.CreateChannel(Binding, address);
        }
        static EndpointAddress GetAddress<S, I>() where I : class
                                                  where S : I
        {
            Tuple<ServiceHost, EndpointAddress> record;

            if (m_Hosts.ContainsKey(typeof(S)))
            {
                record = m_Hosts[typeof(S)];
            }
            else
            {
                ServiceHost host = new ServiceHost(typeof(S));
                string address = BaseAddress + Guid.NewGuid();
                record = new Tuple<ServiceHost, EndpointAddress>(
                host, new EndpointAddress(address));
                m_Hosts[typeof(S)] = record;
                host.AddServiceEndpoint(typeof(I), Binding, address);
                host.Open();
            }

            return record.Item2;
        }
        public static void CloseProxy<I>(I instance) where I : class
        {
            ICommunicationObject proxy = instance as ICommunicationObject;
            Debug.Assert(proxy != null);
            proxy.Close();
        }
    }
}
