using System;
using System.Collections;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http.Filters;

using NUnit.Framework;

using Kandoe.Web.Filters;

namespace Kandoe.Web.Tests.Filters {
    [TestFixture]
    public class ExceptionFilterTests {
        private HttpActionExecutedContext httpActionExecutedContext;

        public static IEnumerable ExceptionCases {
            get {
                yield return new TestCaseData(new ArgumentException(), HttpStatusCode.BadRequest);
                yield return new TestCaseData(new DbUpdateException(), HttpStatusCode.Conflict);
                yield return new TestCaseData(new NotSupportedException(), HttpStatusCode.MethodNotAllowed);
                yield return new TestCaseData(Utilities.GetSqlException(), HttpStatusCode.Conflict);
                yield return new TestCaseData(new UnauthorizedAccessException(), HttpStatusCode.Unauthorized);
                yield return new TestCaseData(new Exception(), HttpStatusCode.InternalServerError);
            }
        }

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
