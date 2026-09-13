# ParcelDesk Decision Log

## 2026-09-12 — Initial backend

- Use .NET 10 LTS.
- Use ASP.NET Core Web API with controllers.
- Keep the initial architecture simple: WinForms -> REST API -> Services -> EF Core -> Database.
- Avoid unnecessary architectural layers until the project requires them.

## 2026-09-12 — Database

- Use MySQL 8.4 because it is already installed in the development environment.
- Use Entity Framework Core with Code First migrations.
- Use the official MySQL Entity Framework Core provider.
- Keep database credentials outside source control using .NET User Secrets during local development.
- Use a dedicated `parceldesk_app` database user instead of the MySQL `root` account.