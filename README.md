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
