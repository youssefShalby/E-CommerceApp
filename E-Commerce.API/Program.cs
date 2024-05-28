
var builder = WebApplication.CreateBuilder(args);

#region Services

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("eCommerceDb");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRedisService, RedisService>();

//> register service of validation exception response
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
	options.InvalidModelStateResponseFactory = actionContext =>
	{
		//> get errors
		var errors = actionContext.ModelState
			.Where(error => error.Value?.Errors.Count > 0)
			.SelectMany(errs => errs.Value!.Errors)
			.Select(err => err.ErrorMessage)
			.ToArray();

		var erroResponse = new ApiValidationErrorResponse
		{
			Errors = errors
		};

		//> so, not need to check the ModelState in endpoints
		return new BadRequestObjectResult(erroResponse);
	};
});

#endregion

var app = builder.Build();

#region Middlewares

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//> here, the right place of exception handler middleare
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


#endregion