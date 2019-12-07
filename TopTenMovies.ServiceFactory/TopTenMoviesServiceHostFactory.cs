using System;
using System.Configuration;
using System.ServiceModel;

namespace TopTenMovies.ServiceFactory
{
    public class TopTenMoviesServiceHostFactory : Ninject.Extensions.Wcf.NinjectServiceHostFactory
    {
        private string appUrl;


        public TopTenMoviesServiceHostFactory()
        {
            appUrl = ConfigurationManager.AppSettings["app_url"];
        }

        protected override ServiceHost CreateServiceHost(Type t, Uri[] baseAddresses)
        {
            return new TopTenMoviesServiceHost(t, baseAddresses);
        }

        //public IService GetService<IService>() where IService : TopTenMovies.ServiceContracts.IService
        //{
        //    ChannelFactory<IService> channelFactory = null;

        //    try
        //    {
        //        BasicHttpBinding binding = new BasicHttpBinding();
        //        string endpointUrl = $"{appUrl}/GenreService.svc";
        //        EndpointAddress endpointAddress = new EndpointAddress(endpointUrl);

        //        channelFactory = new ChannelFactory<IService>(binding, endpointAddress);

        //        return channelFactory.CreateChannel();
        //    }
        //    catch (TimeoutException)
        //    {
        //        //Timeout error  
        //        if (channelFactory != null)
        //            channelFactory.Abort();

        //        throw;
        //    }
        //    catch (FaultException)
        //    {
        //        if (channelFactory != null)
        //            channelFactory.Abort();

        //        throw;
        //    }
        //    catch (CommunicationException)
        //    {
        //        //Communication error  
        //        if (channelFactory != null)
        //            channelFactory.Abort();

        //        throw;
        //    }
        //    catch (Exception)
        //    {
        //        if (channelFactory != null)
        //            channelFactory.Abort();

        //        throw;
        //    }
        //}
    }
}
