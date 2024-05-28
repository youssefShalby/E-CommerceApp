


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

string connectionString = builder.Configuration.GetConnectionString("eCommerceDb");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHandlerService, HandlerService>();


builder.Services.AddHttpContextAccessor();

//> Identity Service
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
{
	option.Password.RequiredLength = 10;
	option.User.RequireUniqueEmail = true;

	//> if tries 3 times and fail in 4th will block the account for 5 min
	option.Lockout.MaxFailedAccessAttempts = 5;
	option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

	//> add Entity framework implementation for Identity
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

//> configure the token life time that created by Asp
builder.Services.Configure<DataProtectionTokenProviderOptions>(TokenOptions.DefaultEmailProvider, options =>
{
	options.TokenLifespan = TimeSpan.FromHours(2); // Set token lifespan to 2 hours
});

//> register service authentication
var result = builder.Services.AddAuthentication(option =>
{
	//> make authentication schema by the JWT
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
});

result.AddJwtBearer(option =>
{
	option.SaveToken = true;
	option.RequireHttpsMetadata = false;

	//> create the Key, will call function later
	var theSecretKey = builder.Configuration["JWT:ApiSecretKey"];
	var keyInBytes = Encoding.ASCII.GetBytes(theSecretKey);
	var key = new SymmetricSecurityKey(keyInBytes);

	option.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = false,
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		IssuerSigningKey = key

	};
});


//> authorization service
builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminRole", builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));
	options.AddPolicy("UserRole", builder => builder.RequireClaim(ClaimTypes.Role, "User"));
});


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