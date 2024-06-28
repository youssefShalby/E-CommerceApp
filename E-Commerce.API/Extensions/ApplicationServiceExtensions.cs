	
namespace E_Commerce.API.Extensions;

public static class ApplicationServiceExtensions
{
	public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
	{

		#region Option Pattern

		//> load smpt settings from json configuration
		var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
		services.AddSingleton(smtpSettings);

		var stripeSettings = configuration.GetSection("StripeSettings").Get<StripeSettings>();
		services.AddSingleton(stripeSettings);

		#endregion

		#region Connetion Strings and HttpContextAccessor

		string connectionString = configuration.GetConnectionString("eCommerceDb");
		services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

		services.AddHttpContextAccessor();

		#endregion

		#region Dependency Injection

		services.AddScoped<IProductRepo, ProductRepo>();
		services.AddScoped<IProductService, ProductService>();
		services.AddScoped<IRedisService, RedisService>();
		services.AddScoped<IBasketService, BasketService>();
		services.AddScoped<IEmailService, EmailService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IRoleService, RoleService>();
		services.AddScoped<ITokenService, TokenService>();
		services.AddScoped<IHandlerService, HandlerService>();
		services.AddScoped<IOrderService, OrderService>();
		services.AddScoped<IOrderRepo, OrderRepo>();
		services.AddScoped<IDeliveryMethodRepo, DeliveryMethodRepo>();
		services.AddScoped<ICategoryRepo, CategoryRepo>();
		services.AddScoped<IImageRepo, ImageRepo>();
		services.AddScoped<IBrandRepo, BrandRepo>();
		services.AddScoped<IConfigHelper, ConfigHelper>();
		services.AddScoped<IBrandService, BrandService>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<IDeliveryMethodService, DeliveryMethodService>();
		services.AddScoped<IOrderItemRepo, OrderItemRepo>();
		services.AddScoped<IPaymentService, PaymentService>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ICacheHelper, CacheHelper>();

		#endregion

		#region Authentication & Authorization Services

		//> Identity Service
		services.AddIdentity<ApplicationUser, IdentityRole>(option =>
		{
			option.Password.RequiredLength = 10;
			option.User.RequireUniqueEmail = true;

			//> if tries 3 times and fail in 4th will block the account for 5 min
			option.Lockout.MaxFailedAccessAttempts = 5;
			option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

			//> add Entity framework implementation for Identity
		}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

		//> configure the token life time that created by Asp
		services.Configure<DataProtectionTokenProviderOptions>(TokenOptions.DefaultEmailProvider, options =>
		{
			options.TokenLifespan = TimeSpan.FromHours(2); // Set token lifespan to 2 hours
		});

		//> register service authentication
		var result = services.AddAuthentication(option =>
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
			var theSecretKey = configuration["JWT:TokenKey"];
			var keyInBytes = Encoding.ASCII.GetBytes(theSecretKey);
			var key = new SymmetricSecurityKey(keyInBytes);

			option.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidIssuer = configuration["JWT:Issuer"],
				IssuerSigningKey = key

			};
		});


		//> authorization service
		services.AddAuthorization(options =>
		{
			options.AddPolicy("SuperAdmin", builder => builder.RequireClaim(ClaimTypes.Role, "SuperAdmin"));
			options.AddPolicy("Admin", builder => builder.RequireClaim(ClaimTypes.Role, "Admin", "SuperAdmin"));
			options.AddPolicy("User", builder => builder.RequireClaim(ClaimTypes.Role, "User", "Admin", "SuperAdmin"));
		});

		#endregion

		#region Swagger

		services.AddSwaggerGen(setup =>
		{
			// Include 'SecurityScheme' to use JWT Authentication
			var jwtSecurityScheme = new OpenApiSecurityScheme
			{
				BearerFormat = "JWT",
				Name = "JWT Authentication",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
				Scheme = JwtBearerDefaults.AuthenticationScheme,
				Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

				Reference = new OpenApiReference
				{
					Id = JwtBearerDefaults.AuthenticationScheme,
					Type = ReferenceType.SecurityScheme
				}
			};

			setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

			setup.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{ jwtSecurityScheme, Array.Empty<string>() }
			});

		});

		#endregion

		#region Validation Exception Response Service

		//> register service of validation exception response
		services.Configure<ApiBehaviorOptions>(options =>
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



		return services;

	}
}
