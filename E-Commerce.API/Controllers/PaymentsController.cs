

using Stripe;

namespace E_Commerce.API.Controllers;



[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
	private readonly IPaymentService _paymentService;
    private readonly string _webHooks;
    private readonly StripeSettings _stripeSettings;
    private readonly ILogger<PaymentsController> _logger;
    public PaymentsController(IPaymentService paymentService, StripeSettings stripeSettings, ILogger<PaymentsController> logger)
    {
        _paymentService = paymentService;
        _stripeSettings = stripeSettings;
        _webHooks = _stripeSettings.webHooksSecret;
        _logger = logger;
    }

    [HttpPost("{basketId}")]
    public async Task<ActionResult> CreateOrUpdatePaymentIntent(string basketId)
    {
        var result = await _paymentService.CreateOrUpdatePaymentIntentAsync(basketId);
        if(result is null)
        {
            return BadRequest("cannot create or update the payment intent right now..!!");
        }
        return StatusCode(201, result);
    }

    [HttpPost("webhook")]
    public async Task<ActionResult> StripeWebHook()
    {
        //> read the request body and convert it into string
        var json = await new StreamReader(Request.Body).ReadToEndAsync();

        //> get stripe signature from the request header
        var stripeSignature = Request.Headers["Stripe-Signature"];

        var stripeEvent = EventUtility.ConstructEvent(json, stripeSignature, _webHooks);

        PaymentIntent intent;
        Order order;

        switch(stripeEvent.Type)
        {
			case "payment_intent.succeeded":

				//> Extracts the PaymentIntent object from the event data
				intent = (PaymentIntent)stripeEvent.Data.Object;

                //> update the order with payment status
				order = await _paymentService.UpdateOrderWhenPaymentSuccessAsync(intent.Id);
				break;

			case "payment_intent.payment_failed":
				intent = (PaymentIntent)stripeEvent.Data.Object;
				order = await _paymentService.UpdateOrderWhenPaymentFailAsync(intent.Id);
				break;
		}

        return NoContent();
    }
}
