using Models;
using System;
using System.Collections.Generic;
using TicketerApi.Data;

namespace TicketerApi.Services
{
    public class DataServiceFactory
    {
        private Dictionary<Type, IDataService> _availableDataServices = new Dictionary<Type, IDataService>();

        public DataServiceFactory(ApplicationDbContext context)
        {
            _availableDataServices.Add(typeof(User), new UserDataService(context));
            _availableDataServices.Add(typeof(Project), new ProjectDataService(context));
            _availableDataServices.Add(typeof(Ticket), new TicketDataService(context));
        }

        public IDataService GetDataService(Type type)
        {
            return _availableDataServices[type];
        }
    }
}