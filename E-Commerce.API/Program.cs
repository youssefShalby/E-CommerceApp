


using E_Commerce.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Services

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//> load smpt settings from json configuration
var smtpSettings = builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
builder.Services.AddSingleton(smtpSettings);

var stripeSettings = builder.Configuration.GetSection("StripeSettings").Get<StripeSettings>();
builder.Services.AddSingleton(stripeSettings);

builder.Services.AddApplicationService(builder.Configuration);

string connectionString = builder.Configuration.GetConnectionString("eCommerceDb");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();


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