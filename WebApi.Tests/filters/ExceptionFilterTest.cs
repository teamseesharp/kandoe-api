using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

using Moq;
using NUnit.Framework;

using Kandoe.Web.Filters;
using System.Web.Http.Controllers;

namespace WebApi.Tests.filters {
    [TestFixture]
    public class ExceptionFilterTest {
        private HttpActionExecutedContext httpActionExecutedContext;

        static object[] ExceptionCases = {
            new object[] { new ArgumentException(), HttpStatusCode.BadRequest },
            new object[] { new NotSupportedException(), HttpStatusCode.MethodNotAllowed },
            new object[] { Utilities.GetSqlException(), HttpStatusCode.Conflict },
            new object[] { new UnauthorizedAccessException(), HttpStatusCode.Unauthorized },
            new object[] { new Exception(), HttpStatusCode.InternalServerError }
        };

        [SetUp]
        public void SetUp() {
            // Not able to mock HttpActionExecutedContext, non-virtual members
            this.httpActionExecutedContext = Utilities.GetActionExecutedContext(new HttpRequestMessage(), new HttpResponseMessage());
        }

        [Test, TestCaseSource("ExceptionCases")]
        public void ShouldRespondWithErrorCodeAfterException(Exception exception, HttpStatusCode code) {
            this.httpActionExecutedContext.Exception = exception;

            ExceptionFilter filter = new ExceptionFilter();
            filter.OnException(this.httpActionExecutedContext);

            Assert.AreEqual(this.httpActionExecutedContext.Response.StatusCode, code);
        }
    }
}
