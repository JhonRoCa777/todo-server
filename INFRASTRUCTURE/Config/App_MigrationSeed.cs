using Microsoft.EntityFrameworkCore;
using INFRASTRUCTURE.Models;
using DOMAIN.Enums;

namespace INFRASTRUCTURE.Config
{
    public static class App_MigrationSeed
    {
        public static WebApplication UseMigrationSeed(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                // MIGRATIONS
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.Migrate();

                // SEEDERS
                // USERS
                if (!db.UserModel.Any())
                {
                    db.UserModel.AddRange(
                        new UserModel { Fullname = "Jhonatan Romero", Email = "jhonatan@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("hola1234"), Role = Role.ADMIN },
                        new UserModel { Fullname = "Stiven Campuzano", Email = "stiven@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("hola1234"), Role = Role.USER },
                        new UserModel { Fullname = "Prueba Prueba", Email = "prueba@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword("hola1234"), Role = Role.USER, Deleted_At = DateTime.Now }
                    );
                    db.SaveChanges();
                }
                // TODOS
                if (!db.TodoModel.Any())
                {
                    var users = db.UserModel.ToList();

                    foreach (var u in users)
                    {
                        db.TodoModel.AddRange(
                            new TodoModel { Description = "Regar las plantas - " + u.Role, UserId = u.Id, Estado = Estado.COMPLETADO },
                            new TodoModel { Description = "Alimentar las mascota - " + u.Role, UserId = u.Id, Estado = Estado.COMPLETADO },
                            new TodoModel { Description = "Enviar documentación - " + u.Role, UserId = u.Id, Estado = Estado.COMPLETADO },
                            new TodoModel { Description = "Realizar prueba - " + u.Role, UserId = u.Id, Estado = Estado.PENDIENTE },
                            new TodoModel { Description = "Sustentar prueba - " + u.Role, UserId = u.Id, Estado = Estado.PENDIENTE },
                            new TodoModel { Description = "Hacer pulls - " + u.Role, UserId = u.Id, Estado = Estado.PENDIENTE, Deleted_At = DateTime.Now }
                        );
                    }
                    db.SaveChanges();
                }
            }

            return app;
        }
    }
}
