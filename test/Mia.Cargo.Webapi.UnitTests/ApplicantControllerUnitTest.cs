using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Mia.Cargo.Webapi.Controllers;
using Mia.Services.PartyService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Mia.Cargo.Webapi.UnitTests
{
    public class ApplicantControllerUnitTest : IDisposable
    {
        private readonly Mock<HttpContext> _mockHttpContext;
        private readonly Mock<IApplicantService> _mockService;
        private readonly string _mockUserId = "mockUserId";
        private readonly Mock<IServiceResult> _mockServiceResult;

        public ApplicantControllerUnitTest()
        {
            var claimPrincipalStub =
                new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimsIdentity.DefaultNameClaimType, _mockUserId) }));

            _mockHttpContext = new Mock<HttpContext>();
            _mockHttpContext.Setup(m => m.User).Returns(claimPrincipalStub);
            _mockService = new Mock<IApplicantService>();
            _mockServiceResult = new Mock<IServiceResult>();
        }

        [Fact]
        public void DeleteWithNormalGuidApplicantServiceShouldbeCalledWithUsername()
        {
            // Arrange
            _mockServiceResult.SetupProperty(r => r.Sucess, true);
            _mockService.Setup(s => s.Delete(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mockServiceResult.Object));

            var controller = new ApplicantsController(_mockService.Object)
            {
                ControllerContext = new ControllerContext { HttpContext = _mockHttpContext.Object }
            };

            Guid applicantId = Guid.NewGuid();

            // Act
            controller.Delete(applicantId).GetAwaiter().GetResult();

            // Assert
            _mockService.Verify(s => s.Delete(_mockUserId, applicantId), Times.Once);
        }

        [Fact]
        public void DeleteApplicantWithDefaultGuidShouldbeBadRequest()
        {
            // Arrange
            _mockService.Setup(s => s.Delete(It.IsAny<string>(), It.IsAny<Guid>()))
                .Returns(Task.FromResult(_mockServiceResult.Object));

            var controller = new ApplicantsController(_mockService.Object)
            {
                ControllerContext = new ControllerContext { HttpContext = _mockHttpContext.Object }
            };

            // Act
            var resultWithDefaultGuid = controller.Delete(default(Guid)).Result;
            var resultWithEmptyGuid = controller.Delete(Guid.Empty).Result;

            // Assert
            Assert.IsType<BadRequestResult>(resultWithDefaultGuid);
            Assert.IsType<BadRequestResult>(resultWithEmptyGuid);
        }

        public void Dispose()
        {

        }
    }
}
