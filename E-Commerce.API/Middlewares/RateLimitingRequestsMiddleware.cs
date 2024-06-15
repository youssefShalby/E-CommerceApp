namespace E_Commerce.API.Middlewares;

public class RateLimitingRequestsMiddleware
{
	private readonly RequestDelegate _next;
	private readonly Queue<DateTime> _requestsTime = new Queue<DateTime>(6);
    private readonly TimeSpan _limitTime = TimeSpan.FromMinutes(10);
	private readonly int _maximumTriesNumber = 5;

	public RateLimitingRequestsMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
    {
        var currentRequestTime = DateTime.Now;
		while (_requestsTime.Count > 0 && currentRequestTime - _requestsTime.Peek() > _limitTime)
		{
			_requestsTime.Dequeue();
		}

		//> add the current request to the queue
		_requestsTime.Enqueue(currentRequestTime);

        if(_requestsTime.Count > _maximumTriesNumber)
        {
            context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
            await context.Response.WriteAsync("Too Many Requests..!!");
            return;
        }

        await _next.Invoke(context);
    }
}
