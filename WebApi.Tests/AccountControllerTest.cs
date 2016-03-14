using System;
using System.Net.Http;
using System.Web.Http;
using Kandoe.Business.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace WebApi.Tests
{
    [TestFixture]
    public class AccountControllerTest
    {
        
        [SetUp]
        public void Setup(){
            
        }

        [Test]
        public void ControllerShouldPostNewAccount()
        {
            var account = new Account()
            {
                Email = "TestEmail@email.be",
                Name = "Testje123",
                Picture = "blabla",

            };

            var _accountController = new AccountController(_articleService)
            {
                Configuration = new HttpConfiguration(),
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://localhost/api/articles")
                }
            };

        }
}
