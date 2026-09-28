# ParcelDesk MVP Technical Audit

**Candidate version:** `v0.1.0-mvp`  
**Status:** Released MVP
**Release date:** September 2026 

---

## 1. Executive Summary

ParcelDesk is a Windows desktop shipment-management application built as a client-server system.

The application consists of:

- a Windows Forms desktop client;
- an ASP.NET Core REST API;
- a service layer containing application and business logic;
- Entity Framework Core for persistence;
- a MySQL relational database.

The first MVP supports the complete operational flow required to manage customers and shipments locally:

1. create and edit customers;
2. create shipments associated with customers;
3. automatically generate AWBs;
4. search and filter shipments;
5. edit shipment information;
6. move shipments through a controlled status workflow;
7. retain shipment status history;
8. inspect all shipments belonging to a customer;
9. view dashboard shipment counts;
10. persist selected desktop UI preferences.

The MVP has been manually tested through an end-to-end flow and builds successfully as a complete solution.

The current version is intended as a functional portfolio MVP, not as a production-ready logistics platform.

---

## 2. MVP Snapshot

At the time of this audit:

- Repository branch: `main`
- .NET SDK used for the audit: `10.0.401`
- API target framework: `.NET 10`
- Desktop target framework: `.NET 10 Windows`
- Desktop technology: Windows Forms
- Backend technology: ASP.NET Core Web API
- ORM: Entity Framework Core
- Database: MySQL 8.4
- EF Core provider: `MySql.EntityFrameworkCore 10.0.9`
- EF Core design package: `Microsoft.EntityFrameworkCore.Design 10.0.9`

The solution contains two application projects:

```text
ParcelDesk.sln
│
├── src/ParcelDesk.Api
└── src/ParcelDesk.WinForms
```

The audited solution builds successfully.

---

## 3. Architecture

ParcelDesk uses a deliberately simple client-server architecture:

```text
┌──────────────────────────────┐
│ ParcelDesk.WinForms          │
│                              │
│ Forms / DataGridViews        │
│ ParcelDeskApiClient          │
└──────────────┬───────────────┘
               │
               │ HTTP + JSON
               ▼
┌──────────────────────────────┐
│ ParcelDesk.Api               │
│                              │
│ Controllers                  │
│ Services                     │
│ DTOs                         │
└──────────────┬───────────────┘
               │
               │ Entity Framework Core
               ▼
┌──────────────────────────────┐
│ ParcelDbContext              │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│ MySQL                        │
│                              │
│ Customers                    │
│ Shipments                    │
│ ShipmentStatusHistories      │
└──────────────────────────────┘
```

The WinForms application does not connect directly to MySQL.

All business operations performed by the desktop application go through the REST API.

This keeps persistence and business rules centralized in the backend instead of duplicating database logic inside the desktop client.

---

## 4. Technology Stack

### Backend

- C#
- .NET 10
- ASP.NET Core Web API
- ASP.NET Core controllers
- Entity Framework Core 10
- MySql.EntityFrameworkCore
- Data Annotations validation
- asynchronous database and HTTP operations

### Desktop

- C#
- .NET 10 for Windows
- Windows Forms
- `HttpClient`
- `System.Net.Http.Json`
- asynchronous UI event handlers
- DataGridView-based administrative UI
- JSON-based local UI preference persistence

### Database

- MySQL 8.4
- EF Core Code First
- EF Core migrations
- relational foreign keys
- unique AWB index

### Development

- Visual Studio Community
- Visual Studio WinForms Designer
- Git
- GitHub
- PowerShell
- .NET CLI

---

## 5. Solution Structure

The backend is organized around:

```text
ParcelDesk.Api
│
├── Controllers
├── Data
│   └── Migrations
├── DTOs
│   ├── Customers
│   ├── Dashboard
│   └── Shipments
├── Models
├── Services
├── Program.cs
└── ParcelDesk.Api.csproj
```

The desktop application is organized around:

```text
ParcelDesk.WinForms
│
├── Api
│   └── ParcelDeskApiClient.cs
├── Models
├── MainForm
├── ShipmentDetailsForm
├── CustomerDetailsForm
├── NewCustomerForm
├── NewShipmentForm
└── Program.cs
```

The MVP intentionally avoids adding unnecessary architectural layers before they are required.

---

## 6. Database Model

### Customer

A customer contains:

| Field | Purpose |
|---|---|
| `Id` | Primary identifier |
| `Name` | Customer name |
| `Phone` | Customer phone number |
| `Email` | Optional email address |
| `Address` | Customer address |

A customer may own multiple shipments.

### Shipment

A shipment contains:

| Field | Purpose |
|---|---|
| `Id` | Primary identifier |
| `Awb` | Generated shipment identifier |
| `CustomerId` | Customer foreign key |
| `SenderAddress` | Shipment origin |
| `DestinationAddress` | Shipment destination |
| `City` | Destination/search city |
| `Weight` | Shipment weight |
| `Status` | Current shipment state |
| `CreatedAtUtc` | Creation timestamp |
| `UpdatedAtUtc` | Last update timestamp |
| `Notes` | Optional shipment notes |

### ShipmentStatusHistory

Each shipment status transition is stored separately:

| Field | Purpose |
|---|---|
| `Id` | History entry identifier |
| `ShipmentId` | Shipment foreign key |
| `Status` | Shipment status at the change |
| `ChangedAtUtc` | UTC timestamp of the change |

This separates:

```text
Shipments.Status
```

which represents the current state, from:

```text
ShipmentStatusHistories
```

which represents the complete status history.

---

## 7. Entity Relationships

The principal relationships are:

```text
Customer
    1
    │
    │
    *
Shipment
    1
    │
    │
    *
ShipmentStatusHistory
```

The database configuration uses restricted deletes.

A customer with existing shipments cannot be removed through the normal customer delete workflow.

Shipment status history is also protected by a restricted relationship to its shipment.

This avoids accidental loss of operational history through cascade deletion.

---

## 8. EF Core Configuration

The following persistence rules are configured explicitly:

### AWB uniqueness

`Shipment.Awb` has a unique database index.

This provides a database-level final guard against duplicate shipment identifiers.

### Weight

Shipment weight is stored with:

```text
decimal(10,2)
```

precision.

### Status storage

`ShipmentStatus` values are represented as strings in the database instead of integer enum values.

Example:

```text
Created
PickedUp
InTransit
Delivered
Cancelled
```

This improves database readability.

### Delete behavior

Both major relationships use:

```text
DeleteBehavior.Restrict
```

to protect related operational data.

---

## 9. EF Core Migrations

The MVP currently contains the following migrations:

```text
20260912153430_InitialCreate
20260914061602_AddShipments
20260915081657_AddShipmentStatusHistory
```

The sequence reflects the incremental development of the persistence model:

```text
Customers
    ↓
Shipments
    ↓
Shipment Status History
```

A current `ParcelDbContextModelSnapshot` is also present.

---

## 10. API Surface

### Health

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/health` | Backend health response |

### Customers

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/customers` | List customers |
| GET | `/api/customers/{id}` | Get one customer |
| POST | `/api/customers` | Create customer |
| PUT | `/api/customers/{id}` | Update customer |
| DELETE | `/api/customers/{id}` | Delete customer if permitted |

### Shipments

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/shipments` | List/filter shipments |
| GET | `/api/shipments/{id}` | Get shipment by ID |
| GET | `/api/shipments/awb/{awb}` | Find shipment by AWB |
| POST | `/api/shipments` | Create shipment |
| PUT | `/api/shipments/{id}` | Edit shipment |
| PATCH | `/api/shipments/{id}/status` | Change shipment status |
| GET | `/api/shipments/{id}/history` | Get status history |

Shipment list filters currently include:

```text
status
customerId
city
search
```

The free-text search checks multiple shipment fields including AWB, city, customer name, addresses and notes.

### Dashboard

| Method | Endpoint | Purpose |
|---|---|---|
| GET | `/api/dashboard/summary` | Return shipment counters by status |

---

## 11. API HTTP Behavior

The API uses meaningful HTTP response codes in the main workflows.

Examples:

```text
200 OK
201 Created
204 No Content
400 Bad Request
404 Not Found
409 Conflict
```

Important examples include:

- creating a shipment with an unknown customer returns `400`;
- requesting a missing shipment/customer returns `404`;
- attempting an illegal shipment status transition returns `409`;
- attempting to delete a customer with shipments returns `409`;
- successful creates return `201 Created`.

ASP.NET Core `[ApiController]` automatic validation is used together with DTO Data Annotations.

---

## 12. DTO Boundary

HTTP request/response DTOs are kept separate from EF Core entities.

Examples include:

```text
CreateCustomerRequest
UpdateCustomerRequest
CustomerResponse

CreateShipmentRequest
UpdateShipmentRequest
UpdateShipmentStatusRequest
ShipmentFilterRequest
ShipmentResponse
ShipmentStatusHistoryResponse
```

This avoids exposing EF entities directly as writable HTTP contracts.

It also prevents fields such as AWB, shipment status and timestamps from being changed through the general shipment update request.

---

## 13. Customer Business Rules

Customer creation and update normalize string values using trimming.

Email is stored as `null` when the supplied value is blank.

Customer deletion has three possible service results:

```text
Deleted
NotFound
HasShipments
```

Before deleting a customer, the service checks whether any shipment references the customer.

If shipments exist, deletion is rejected.

---

## 14. Shipment Creation

Shipment creation requires an existing customer.

The backend, rather than the desktop client, controls:

```text
AWB
initial status
CreatedAtUtc
UpdatedAtUtc
initial status history
```

A newly created shipment begins in:

```text
Created
```

and an initial `ShipmentStatusHistory` entry is created in the same unit of persistence.

---

## 15. AWB Generation

AWBs are generated server-side.

The current format is:

```text
PD-XXXXXXXXXXXXXXXXXXXX
```

where the suffix consists of 20 uppercase hexadecimal characters derived from a GUID.

Example conceptual format:

```text
PD-CB71AFE9963747A89C3D
```

The database also enforces AWB uniqueness with a unique index.

The client never supplies the shipment AWB during creation.

---

## 16. Shipment State Machine

The backend enforces the following status transitions:

```text
Created
├── PickedUp
└── Cancelled

PickedUp
├── InTransit
└── Cancelled

InTransit
├── Delivered
└── Cancelled

Delivered
└── terminal

Cancelled
└── terminal
```

Direct transitions such as:

```text
Created → Delivered
```

are rejected.

The backend is authoritative for these rules.

The desktop UI additionally limits the options displayed to the user, but frontend validation is considered user-experience logic rather than the security/business-rule boundary.

---

## 17. Shipment Status History

Each successful status transition:

1. updates `Shipment.Status`;
2. updates `Shipment.UpdatedAtUtc`;
3. creates a new history entry;
4. saves both changes.

History entries are ordered by `ChangedAtUtc`.

This provides a basic audit trail of shipment lifecycle changes.

---

## 18. Shipment Search and Filtering

The backend builds shipment queries dynamically using `IQueryable`.

Filtering is performed in the database before results are materialized.

Supported filters include:

```text
status
customer
city
free-text search
```

Search spans:

```text
AWB
City
Customer Name
Sender Address
Destination Address
Notes
```

Results are ordered with the newest shipments first.

---

## 19. Dashboard

The dashboard reports:

```text
Total Shipments
Created
Picked Up
In Transit
Delivered
Cancelled
```

The desktop dashboard retrieves these values from:

```text
GET /api/dashboard/summary
```

The values therefore represent backend/database state rather than locally calculated desktop state.

---

## 20. Desktop Application

The primary WinForms application contains three top-level areas:

```text
Dashboard
Shipments
Customers
```

Navigation switches between panels hosted inside the main content area.

The desktop does not perform direct database access.

All application data is retrieved or modified through `ParcelDeskApiClient`.

---

## 21. Shipments UI

The Shipments page currently supports:

- shipment list;
- free-text search;
- status filter;
- Enter-to-refresh;
- manual refresh;
- automatic column sizing;
- manual column resizing;
- persisted grid column widths;
- creation of a new shipment;
- double-click to open shipment details.

Shipment column-width preferences are stored locally under the current Windows user's local application data directory.

They are UI preferences and are not stored in the operational database.

---

## 22. Shipment Details

The Shipment Details form supports:

- AWB display;
- customer display;
- current status display;
- sender address editing;
- destination address editing;
- city editing;
- weight editing;
- notes editing;
- status transition;
- shipment status-history display.

After a successful update, data is reloaded from the backend.

Terminal statuses disable further status transition controls.

---

## 23. Customers UI

The Customers page supports:

- customer listing;
- local free-text search;
- search by name;
- search by phone;
- search by email;
- search by address;
- refresh;
- new customer creation;
- double-click to open Customer Details.

For the current MVP, customer search is performed in the WinForms client after retrieving the customer list.

---

## 24. Customer Details

Customer Details supports editing:

```text
Name
Phone
Email
Address
```

The form also retrieves all shipments associated with that customer.

Customer shipment history is displayed in a DataGridView.

Double-clicking a shipment in Customer Details opens the existing Shipment Details form.

This enables navigation:

```text
Customer
    ↓
Customer shipment list
    ↓
Shipment
    ↓
Shipment status history
```

---

## 25. New Customer Workflow

The New Customer form validates that:

```text
Name
Phone
Address
```

are provided before submission.

Email is optional.

On successful creation, the form returns `DialogResult.OK`, allowing the main customer grid to refresh automatically.

---

## 26. New Shipment Workflow

New Shipment supports:

```text
Customer
Sender Address
Destination Address
City
Weight
Notes
```

The customer is selected from existing customers retrieved from the backend.

The ComboBox displays customer names while retaining the complete `Customer` object.

The selected customer ID is submitted to the API.

The form also provides an `Auto Complete Sender Address` action that copies the selected customer's stored address into the sender-address field.

The sender address remains editable after autofill.

If no customers exist, shipment creation is disabled and the user is prompted to create a customer first.

After successful creation:

- the backend returns the generated AWB;
- the new shipment appears in the shipment list;
- dashboard values are refreshed.

---

## 27. Customer-to-Shipment Workflow

One of the primary end-to-end MVP workflows is:

```text
Create Customer
      ↓
Customer appears in Customers
      ↓
Create Shipment
      ↓
Select existing Customer
      ↓
Optionally autofill sender address
      ↓
Backend generates AWB
      ↓
Shipment begins as Created
      ↓
Shipment appears in Shipments
      ↓
Dashboard counts update
      ↓
Open Shipment Details
      ↓
Change status
      ↓
Status History updates
      ↓
Open Customer Details
      ↓
Shipment appears in customer's shipment history
```

This flow was manually exercised successfully during MVP development.

---

## 28. Validation

Validation exists at two levels.

### Desktop validation

WinForms checks common required fields before sending requests.

Examples:

```text
customer name
customer phone
customer address
sender address
destination address
city
selected customer
```

### API validation

The API remains the authoritative validation boundary.

DTOs use Data Annotations including:

```text
Required
MaxLength
EmailAddress
Range
```

The API therefore remains protected even if desktop validation is bypassed.

---

## 29. Error Handling

The WinForms client catches `HttpRequestException` in the main network workflows and presents user-facing error dialogs.

Backend responses include appropriate non-success status codes for common invalid conditions.

The desktop client uses:

```text
EnsureSuccessStatusCode()
```

for create/update/status-changing operations before attempting to deserialize successful response payloads.

---

## 30. Async Behavior

Database operations use asynchronous EF Core methods such as:

```text
ToListAsync
FirstOrDefaultAsync
AnyAsync
CountAsync
SaveChangesAsync
```

HTTP operations also use asynchronous `HttpClient` methods.

WinForms event handlers await these operations so that network/database operations do not intentionally block the UI thread while waiting for I/O.

---

## 31. Development Configuration

The API retrieves its connection string from configuration using:

```text
ConnectionStrings:ParcelDeskDb
```

Local database credentials are not intended to be stored directly in committed source code.

The development setup uses .NET User Secrets.

A dedicated MySQL application account is used instead of connecting the application as MySQL `root`.

This was an explicit project decision from the persistence setup stage.

---

## 32. Local UI Persistence

Shipment DataGridView column widths are serialized as JSON into the Windows local application-data directory.

Conceptually:

```text
%LOCALAPPDATA%\ParcelDesk\...
```

This allows manual column widths to persist across application restarts without storing workstation-specific preferences in MySQL.

The UI also provides an Auto Size Columns command that recalculates widths based on displayed contents.

---

## 33. MVP Verification

The following functionality has been manually verified during development:

| Feature | Result |
|---|---|
| Solution build | Pass |
| Backend startup | Pass |
| WinForms startup | Pass |
| API → MySQL access | Pass |
| Dashboard loading | Pass |
| Customer listing | Pass |
| Customer search | Pass |
| Customer creation | Pass |
| Customer editing | Pass |
| Customer shipment history | Pass |
| Shipment creation | Pass |
| AWB generation | Pass |
| Shipment listing | Pass |
| Shipment search | Pass |
| Shipment filtering | Pass |
| Shipment editing | Pass |
| Status transition | Pass |
| Invalid status transition rejection | Pass |
| Status history | Pass |
| Customer deletion protection | Pass |
| DataGridView column-width persistence | Pass |
| New Shipment sender-address autofill | Pass |
| Full customer → shipment workflow | Pass |

These are manual MVP checks, not an automated test suite.

---

## 34. Engineering Decisions

### Simple architecture first

The MVP intentionally uses:

```text
WinForms
→ REST API
→ Services
→ EF Core
→ MySQL
```

instead of introducing repository layers, mediator libraries, mapping frameworks or additional abstraction projects before they are required.

### DTOs instead of exposing entities

API DTOs define explicit HTTP contracts.

### Backend-generated AWB

Shipment identity is controlled by the backend rather than trusted from the client.

### Backend-owned status transitions

The desktop UI improves usability, but shipment lifecycle rules remain enforced server-side.

### Restricted deletes

Operational history is favored over destructive cascade behavior.

### Separate status history

Current state and historical state are modeled separately.

### Local UI preference persistence

Workstation-specific DataGridView settings remain outside the business database.

---

## 35. Current MVP Scope and Limitations

The current MVP has intentional limitations.

### No authentication or authorization

The API currently has no user login, roles or permissions.

Any client able to reach the API can call the exposed endpoints.

### No automated tests

The MVP was manually exercised but currently has no unit, integration or end-to-end automated test suite.

### No pagination

Shipment/customer result sets are suitable for small MVP datasets but are not paginated.

### Customer search is client-side

The desktop retrieves customers and then filters the list locally.

For large datasets, this should move to an API/database query.

### Dashboard performs multiple count queries

The current summary implementation performs separate count operations per shipment status.

This is simple and clear for the MVP but could be consolidated for higher-scale workloads.

### Desktop/API configuration

The WinForms client currently uses a local development API address.

A configurable endpoint will be introduced when deployment becomes part of the project scope.

### Status rules appear in both backend and desktop

The backend is authoritative, but the UI duplicates allowed transitions to determine which options to display.

This duplication could be removed in a future API-driven workflow.

### No production deployment configuration

The MVP is currently designed and verified as a local development application.

### No centralized API exception middleware

Error handling is currently performed through controller/service results and WinForms request handling rather than a global API exception strategy.

### No concurrency control

The MVP does not currently use optimistic concurrency tokens for simultaneous edits.

### No AWB collision retry

The generated AWB has a very large practical identifier space and the database enforces uniqueness, but there is currently no explicit retry if an unlikely unique-index collision occurs.

---

## 36. Security Scope

The WinForms client communicates exclusively with the API and does not receive direct database credentials.

Authentication and authorization are intentionally outside the scope of the first MVP and are planned before any production deployment.

---

## 37. Post-MVP Roadmap

Potential future improvements include:

### Quality

- automated unit tests;
- API integration tests;
- WinForms workflow tests where practical;
- centralized validation/error handling;
- structured logging.

### API

- pagination;
- customer-side server search;
- configurable sorting;
- OpenAPI/Swagger documentation;
- global exception handling;
- cancellation tokens.

### Security

- authentication;
- authorization;
- application roles;
- HTTPS deployment configuration.

### Desktop

- configuration file for API URL;
- stronger visual styling;
- additional keyboard shortcuts;
- improved responsive layout;
- loading indicators;
- confirmation dialogs where destructive actions are introduced.

### Shipment features

- richer shipment tracking;
- delivery timestamps;
- additional operational statuses if required;
- address normalization/geocoding;
- reporting/export;
- printing shipment/AWB documents.

### Deployment

- packaged Windows release;
- production database configuration;
- hosted ASP.NET Core backend;
- CI build pipeline;
- GitHub Releases.

---

## 38. MVP Acceptance Criteria

For this project, the MVP is considered functionally complete when a user can:

1. open the desktop application;
2. view operational dashboard counts;
3. create a customer;
4. find and edit that customer;
5. create a shipment for the customer;
6. optionally reuse the customer's address as sender address;
7. receive a generated AWB;
8. find the shipment in the shipment list;
9. search/filter shipments;
10. open shipment details;
11. edit shipment information;
12. progress the shipment through allowed states;
13. inspect the shipment status history;
14. open the customer and see the shipment in their shipment history.

The current audited application satisfies this manual workflow.

---

## 39. Final MVP Assessment

ParcelDesk has reached the first functional MVP milestone.

The project demonstrates a complete desktop-to-database application flow rather than an isolated UI or API prototype:

```text
Windows Forms
      ↓
HTTP / JSON
      ↓
ASP.NET Core Controllers
      ↓
Application Services
      ↓
Entity Framework Core
      ↓
MySQL
```

The MVP demonstrates:

- relational data modeling;
- Code First migrations;
- REST API design;
- DTO-based request/response boundaries;
- asynchronous database and HTTP operations;
- server-side business-rule enforcement;
- state-machine logic;
- status-history persistence;
- desktop API integration;
- dynamic filtering/search;
- customer and shipment management;
- local UI preference persistence;

The application is suitable as a functional MVP and portfolio project.

It should not yet be described as production-ready because authentication, automated testing, deployment configuration, scalability features and additional operational hardening remain future work.

The MVP establishes a stable foundation for future work such as authentication, automated testing, deployment, pagination, richer tracking features and broader operational tooling.
