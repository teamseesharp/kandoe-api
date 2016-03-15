using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

using NUnit.Framework;

using Kandoe.Web.Filters;

namespace WebApi.Tests.Filters {
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
            // Built up from the bottom with an utility method
            this.httpActionExecutedContext = Utilities.GetActionExecutedContext();
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
