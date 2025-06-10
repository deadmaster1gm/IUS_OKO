using IUS_OKO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IUS_OKO
{
    public sealed class ApplicationContext : DbContext //создание объекта, позволяющего работать с базой данных
    {
        public DbSet<ParameterOKO> ParameterOKO { get; set; } = null!;//создание объекта, позволяющего создать таблицу с одноименным названием в базе данных
        public ApplicationContext() : base() //вызов объекта для удаления и создания базы данных на сервере
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //переопределение метода OnConfiguring и передача в него объекта класса DbContextOptionsBuilder позволяющего задать параметры подключение к той или иной СУБД
        {
            var config = new ConfigurationBuilder() //настройка строки подключения из json файла
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

            optionsBuilder.UseNpgsql(config.GetConnectionString("ConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //добавление сущности ParameterVCS в модель без использования конструкции DbSet
        {
        }
    }
}