using CosmosDBPlayground.DatabaseSeeding;

using var databaseSeeder = new DatabaseSeeder();
await databaseSeeder.CreateAndSeedDatabase();
