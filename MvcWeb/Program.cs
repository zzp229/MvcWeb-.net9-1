
namespace MvcWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #region 配置swagger服务
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen(options =>
                {
                    #region 
                    string basePath = AppContext.BaseDirectory;
                    string xmlPath = Path.Combine(basePath, "MvcWeb.xml");  // 项目名称.xml
                    options.IncludeXmlComments(xmlPath);    // 加上这个才会在swagger中增加注释
                    #endregion

                    #region 多版本

                    #endregion

                });
            }
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            #region 使用Swagger中间件
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #endregion

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
