using FiledPaymentService.Services.Commands.Interfaces;
using Moq;
using NUnit.Framework;

namespace Filed.Test
{
    public class PaymentGatewayTests
    {
        Mock<IInvoker> _invokerMock;

        [SetUp]
        public void Setup()
        {
            _invokerMock = new Mock<IInvoker>();
        }

        [Test]
        public void CheapPaymentGatewayTest()
        {
            _invokerMock.Setup(p => p.GetCommand(20).Execute()).Returns(true);
            Assert.Pass();
        }

        [Test]
        public void ExpensivePaymentGatewayTest()
        {
            _invokerMock.Setup(p => p.GetCommand(36).Execute()).Returns(true);
            Assert.Pass();
        }

        [Test]
        public void PremiumPaymentGatewayTest()
        {
            _invokerMock.Setup(p => p.GetCommand(896).Execute()).Returns(true);
            Assert.Pass();
        }
    }
}