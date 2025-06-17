## How to Run

Follow these steps to get the project running locally:

### 1. Clone the repository

```bash
git clone https://github.com/Thabang-n/amsAPI.git
cd amsAPI
2. Configure your database connection in the .env file
"ConnectionStrings": {
  "DefaultConnection": ""
}
3. Apply EF Core migrations
dotnet ef database update --project Repository --startup-project API
4. Run the API
dotnet run --project API
Open Swagger
https://localhost:5001/swagger


#### This repository contains the full source code for the AMS (Asset Management System) API, developed with ASP.NET Core.

Available Endpoints
The API includes the following endpoints:

POST /asset – Create a new asset with dynamic attributes.

GET /locations – Retrieve all available asset locations.

GET /brands – Retrieve all available asset brands.

GET /categories – Retrieve all asset categories.

GET /features – Retrieve available asset feature types (e.g., RAM, screen size).
