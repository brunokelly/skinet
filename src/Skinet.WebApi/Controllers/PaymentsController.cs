using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Skinet.Application.Payments;
using Skinet.Domain.SeedOfWork;

namespace Skinet.WebApi.Controllers
{
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(INotification notification, IPaymentService paymentService) : base(notification)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<IActionResult> CreateOrUpdateIntent(string basketId)
        {
            return Response(await _paymentService.CreateOrUpdatePaymentIntent(basketId));
        }
    }
}
