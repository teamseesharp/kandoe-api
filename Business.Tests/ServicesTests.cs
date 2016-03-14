using System;
using Kandoe.Business;
using Kandoe.Data;
using Kandoe.Data.EFDB.Repositories;
using NUnit.Framework;

namespace Business.Tests
{
    [TestFixture]
    public class ServicesTests
    {
       IService<AccountService> accService;
       IRepository<AccountRepository> accRepository;

        [SetUp]
        public void Setup()
        {
            
        }
    }
}
