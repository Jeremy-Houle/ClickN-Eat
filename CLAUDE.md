# ClickN'Eat — Project Instructions

## Stack
- **Backend**: ASP.NET Core 9, EF Core 9, SQL Server, BCrypt, JWT
- **Frontend**: React 18 + TypeScript + Vite, Axios, React Router, React Query

## Architecture

### Backend
```
backend/ClickNEat.Core/
  Models/        — DB entities (User, MenuItem, Order, Restaurant, etc.)
  DTOs/          — Input/output contracts (AuthDto, OrderDto, etc.)
  Interfaces/    — IAuthService, IOrderService, etc.
  Common/        — ServiceResult<T>, PagedResult<T>

backend/ClickNEat.API/
  Controllers/   — Thin controllers, extend BaseApiController
  Services/      — All business logic (AuthService, OrderService, etc.)
  Data/          — AppDbContext, Seed/, Migrations/
  Extensions/    — ServiceExtensions (AddApplicationServices)
  Program.cs     — JWT, CORS, rate limiting, services registration

backend/ClickNEat.Tests/  — xUnit + Moq + EF InMemory
```

### Frontend
```
frontend/src/
  features/      — Feature-based modules (auth, menu, cart, orders, admin, profile)
    <feature>/
      api/       — Axios calls
      pages/     — Page components
      components/
      context/   (if needed)
  shared/
    api/         — client.ts (Axios instance)
    components/  — Navbar, ErrorBoundary
    context/     — AuthContext, LanguageContext, ThemeContext, ToastContext
    i18n/        — fr.json, en.json, es.json, de.json
    types/       — index.ts
    utils/       — apiError.ts, estimate.ts, tiers.ts
```

## Key Patterns

### ServiceResult<T>
All services return `ServiceResult<T>` — never throw. Controllers use `FromResult<T>()` from `BaseApiController`.
```csharp
return ServiceResult<T>.Ok(data);
return ServiceResult<T>.NotFound();
return ServiceResult<T>.Fail("errors.xxx.yyy");   // always use i18n error codes
return ServiceResult<T>.Unauthorized("errors.xxx.yyy");
return ServiceResult<T>.Conflict("errors.xxx.yyy");
```

### i18n Error Codes
Backend returns error codes like `"errors.auth.emailTaken"` — NEVER hardcoded French strings.
Frontend translates with `translateApiError(data, t, fallback)` from `shared/utils/apiError.ts`.
All error keys are in the `errors.*` section of each i18n file.

### BaseApiController
```csharp
protected int CurrentUserId  // extracts userId from JWT claims
protected IActionResult FromResult<T>(ServiceResult<T> result)  // maps to HTTP response
```

### PagedResult<T>
Used for all paginated endpoints. `{ items, total, page, pageSize }`.

## Config
- `appsettings.json` — empty placeholders (ConnectionString, Jwt:Secret, App:BaseUrl)
- `appsettings.Development.json` — gitignored, contains local SQL Server connection string
- JWT secret → stored in `dotnet user-secrets` (never committed)
- Frontend env → `frontend/.env` (gitignored), `VITE_API_URL=http://localhost:5294`

## Security Rules (never bypass)
- All service inputs validated server-side
- JWT verified on every protected endpoint via `[Authorize]`
- Admin endpoints use `[Authorize(Roles = "Admin")]`
- File uploads validated by magic bytes (not just extension)
- IDOR checks: users can only access their own data
- Rate limiting on `/auth/login` and `/auth/register`

## Running Locally
```bash
# Backend
cd backend/ClickNEat.API
dotnet run

# Frontend
cd frontend
npm run dev
```
Backend runs on `http://localhost:5294`, frontend on `http://localhost:5173`.
