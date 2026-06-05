# ClickN'Eat

A full-stack food ordering application with a web frontend, and REST API backend.

## Stack

| Layer    | Technology                                                          |
| -------- | ------------------------------------------------------------------- |
| Backend  | ASP.NET Core 9, EF Core 9, SQL Server, BCrypt, JWT                  |
| Frontend | React 19 + TypeScript + Vite, Axios, React Router 7, TanStack Query |
| Tests    | xUnit + Moq + EF InMemory (backend), Playwright (frontend E2E)      |

## Features

- Restaurant browsing with cover images and logos
- Menu items with categories, tags, and multilingual translations
- Cart management and order placement
- Order history with status tracking
- User profile with loyalty points and reward tiers
- Admin panel: manage restaurants, menu items, users, and file uploads
- JWT authentication (register / login)
- i18n: English, French, Spanish, German
- Dark/Light theme toggle
- Seeded restaurants: McDonald's, A&W, Tim Hortons (with full menus and a default admin account)

## Project Structure

```
ClickN'Eat/
├── backend/
│   ├── ClickNEat.Core/       # Models, DTOs, Interfaces, Common (ServiceResult, PagedResult)
│   ├── ClickNEat.API/        # Controllers, Services, Data (EF), Migrations, Program.cs
│   └── ClickNEat.Tests/      # xUnit unit tests (Auth, Orders, Menu, Admin, User)
├── frontend/
│   └── src/
│       ├── features/         # auth, menu, cart, orders, admin, profile
│       └── shared/           # api client, contexts, i18n, types, utils
```

## Running Tests

```bash
# Backend unit tests
cd backend
dotnet test

# Frontend E2E tests (requires the app to be running)
cd frontend
npm run test:e2e
```

## API Endpoints

| Method | Path                   | Auth   | Description                         |
| ------ | ---------------------- | ------ | ----------------------------------- |
| POST   | /api/auth/register     | Public | Create account                      |
| POST   | /api/auth/login        | Public | Get JWT token                       |
| GET    | /api/restaurants       | Public | List restaurants                    |
| GET    | /api/menuitems         | Public | List menu items                     |
| GET    | /api/orders            | User   | Get own orders                      |
| POST   | /api/orders            | User   | Place an order                      |
| GET    | /api/users/me          | User   | Get own profile                     |
| PUT    | /api/users/me          | User   | Update profile                      |
| POST   | /api/uploads           | Admin  | Upload image                        |
| GET    | /api/admin/stats       | Admin  | Platform statistics                 |
| *      | /api/admin/*           | Admin  | Manage users, restaurants, items    |

Rate limiting is applied on `/api/auth/login` and `/api/auth/register` (10 req/min).

## Environment Variables Summary

| Location                          | Key                 | Description              |
| --------------------------------- | ------------------- | ------------------------ |
| `appsettings.Development.json`    | `ConnectionStrings` | SQL Server connection    |
| `appsettings.Development.json`    | `App:BaseUrl`       | Backend base URL         |
| dotnet user-secrets               | `Jwt:Secret`        | JWT signing key          |
| `frontend/.env`                   | `VITE_API_URL`      | Backend URL for frontend |
