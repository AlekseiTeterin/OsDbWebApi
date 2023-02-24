using Microsoft.EntityFrameworkCore;
using OsDbWebApi.Models.Entity;

namespace OsDbWebApi.Models
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<OperationSystems> EntityOperationSystems { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// получаем файл конфигурации
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();
			// устанавливаем для контекста строку подключения
			// инициализируем саму строку подключения
			optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
		}
	}
}
