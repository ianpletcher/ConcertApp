# ConcertAPI

A RESTful API for managing concert and venue data, built with ASP.NET Core and Entity Framework Core. This project was developed primarily as a learning exercise in building REST APIs with C# and .NET, and serves as a demonstration of core backend development concepts including layered architecture, database modeling, and API design.

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core (.NET 10) |
| ORM | Entity Framework Core |
| Database | SQLite |
| API Docs | Swagger / OpenAPI |

---

## Project Structure

```
ConcertAPI/
├── Controllers/        # HTTP request handling and routing
│   └── ConcertController.cs
├── Data/               # EF Core DbContext
│   └── ConcertContext.cs
├── Migrations/         # EF Core auto-generated migration files
├── Models/             # Domain entities
│   ├── Concert.cs
│   └── Venue.cs
├── Services/           # Business logic layer
│   └── ConcertService.cs
└── Program.cs          # App configuration and startup
```

The project follows a three-layer pattern: the **Controller** handles routing and HTTP concerns, the **Service** contains business logic and database operations, and the **Models** define the domain entities. This keeps concerns separated and makes the codebase easier to extend.

---

## Data Models

### Concert
| Field | Type | Notes |
|---|---|---|
| `Id` | int | Primary key |
| `Date` | DateOnly | Date of the concert |
| `Venue` | Venue | Nested venue object |
| `Artist` | string | Headlining artist |
| `Support` | string? | Supporting act (optional) |
| `Festival` | bool? | Whether it is a festival event |
| `TourName` | string? | Associated tour name (optional) |

### Venue
| Field | Type | Notes |
|---|---|---|
| `Id` | int | Primary key |
| `Name` | string | Venue name |
| `City` | string | City |
| `State` | string? | State/province (optional) |
| `Country` | string | Country |
| `ServesAlcohol` | bool? | Optional |
| `AllAges` | bool? | Optional |
| `Type` | VenueType | Enum (see below) |

**VenueType enum:** `Amphitheater`, `Bar`, `Club`, `Standalone`, `Arena`, `Stadium`, `ConcertHall`

> Venues are currently embedded within concerts and are not independently addressable via a dedicated endpoint. Standalone venue endpoints may be added in a future update.

---

## API Endpoints

Base URL (local): `https://localhost:{port}/concert`

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/concert` | Retrieve all concerts |
| `GET` | `/concert/{id}` | Retrieve a concert by ID |
| `POST` | `/concert` | Create a new concert |
| `PUT` | `/concert/{id}` | Update an existing concert |
| `DELETE` | `/concert/{id}` | Delete a concert |

### Example Request Body (POST / PUT)

```json
{
  "date": "1997-12-19",
  "venue": {
    "name": "Hammerstein Ballroom",
    "city": "New York",
    "state": "NY",
    "country": "USA",
    "servesAlcohol": true,
    "allAges": false,
    "type": 0
  },
  "artist": "Radiohead",
  "support": "Teenage Fanclub",
  "festival": false,
  "tourName": "OK Computer Tour"
}
```

---

## Running Locally

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Steps

```bash
# Clone the repository
git clone https://github.com/ianpletcher/ConcertAPI.git
cd ConcertAPI

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```

Once running, navigate to `https://localhost:{port}/swagger` to explore and test the API interactively via Swagger UI.