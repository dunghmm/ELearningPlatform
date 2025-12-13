# ELearningPlatform

A simple ASP.NET Core Web API project for an e-learning platform.

---

## Prerequisites

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (Docker Compose included)  
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) (for local development if needed)  

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/dunghmm/ELearningPlatform.git
cd ELearningPlatform
````

### 2. Setup environment variables

The project uses a `.env` file to store sensitive information like database credentials and SMTP email settings.

1. Copy the template:

```bash
cp .env.example .env
```

2. Edit `.env` and fill in your secrets:

```env
# Database
SA_PASSWORD=YourStrongPassword123!

# Email
SMTP_SERVER=smtp.gmail.com
SMTP_PORT=587
SMTP_SENDER_NAME=Elearing-Platform
SMTP_SENDER_EMAIL=your-email@example.com
SMTP_USERNAME=your-email@example.com
SMTP_PASSWORD=your-email-app-password
```

**Notes:**

* `SA_PASSWORD` is the SQL Server system administrator password. It must contain at least 8 characters, including uppercase, lowercase letters, numbers, and symbols.
* Email settings are used to send registration notification (for now).
* `.env` is **not committed** to Git to keep your secrets safe.
* Docker Compose automatically reads `.env` for values and injects them into your containers via the `docker-compose.override.yml` file.

### 3. Run the application with Docker Compose

```bash
docker compose up --build -d
```

The following services will be started:

* `db` → SQL Server 2022
* `elearningplatform` → ASP.NET Core Web API
* `mssql-tools` → Utility container for database initialization

### 4. Access Swagger

* HTTP: [http://localhost:8080/swagger](http://localhost:8080/swagger)
* HTTPS: [https://localhost:8081/swagger](https://localhost:8081/swagger)


### 5. Stop and remove containers

```bash
docker compose down
```

> This will stop containers but preserve database volumes. Use `docker compose down -v` instead if you want to reset the database. Keep in mind that changing `SA_PASSWORD` in `.env` requires you to reset the database.


### 6. Notes for developers

* Local development uses `docker-compose.override.yml` to mount secrets and enable live reload.
* Never commit `.env` or local secrets.
* Use `.env.example` as the template when adding new secrets.

---

## Connecting to the container's database using SSMS

1. Open SQL Server Management Studio (SSMS).

2. Connect to the database server using the following details:
   - **Server name**: `localhost,1433`
   - **Authentication**: SQL Server Authentication
   - **Login**: Enter username `sa` and password from your `.env` file.

---

### References

* [Docker Compose Documentation](https://docs.docker.com/compose/)
* [ASP.NET Core Docker Support](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker)
