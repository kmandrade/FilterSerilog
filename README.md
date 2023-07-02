# FilterSerilog

Utilizando aspenas o pacote Serilog.AspNetCore

Verificar sobre esses filtros utilizando SQL Server
.EnableSensitiveDataLogging()
        .EnableDetailedErrors()

        builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
