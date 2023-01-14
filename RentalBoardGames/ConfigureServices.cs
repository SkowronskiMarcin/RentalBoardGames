namespace RentalBoardGames;

public class ConfigureServices {
    
    public void ConfigureService(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: "AllowOrigin",
                builder =>{
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }

// in Configure
    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("AllowOrigin ");
    }
}