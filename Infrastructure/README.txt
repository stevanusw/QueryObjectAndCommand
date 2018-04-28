1.Example of scaffold command (https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet):
SET MODE=MIGRATION
D:\Projects\Visual Studio 2017\Projects\2018\QueryObjectAndCommand\Infrastructure>dotnet ef dbcontext scaffold "Server=(localdb)\projectsv13;Database=School;Trusted_Connection=True" Microsoft.EntityFrameworkCore.SqlServer --output-dir ../Core/Models/School --context SchoolDbContext --startup-project ../ConsoleApp1 --verbose
SET MODE=
