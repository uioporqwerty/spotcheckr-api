# Spotcheckr API
[![codecov](https://codecov.io/gh/uioporqwerty/spotcheckr-api/branch/develop/graph/badge.svg?token=Q2J254YS0G)](https://codecov.io/gh/uioporqwerty/spotcheckr-api)
Repository for the Spotcheckr GraphQL API.

## Getting Started
1. `git clone https://github.com/uioporqwerty/spotcheckr-api.git`
2. Install MS-SQL server for local development. MS-SQL server is supported. Docker can be used to setup an instance of MS-SQL server.
3. Create user `spotcheckr-dev` with password `spotcheckr`. Ensure this user is db-owner for the `Spotcheckr-Core` database. These settings match what is in `appsettings.development.json`.
4. Run `Spotcheckr.API`.
5. Going to `/graphql` endpoint will open up `Banana Cake Pop` instance for you to explore the schema and issue calls. First run will also seed the database with test data.

## Testing
`Spotcheckr.API.Tests.Common` is a shared project to be usedacross the `Spotcheckr.API.IntegrationTests`, `Spotcheckr.API.UnitTests`, and `Spotcheckr.API.SnapshotTests`. The common project has a `ServiceFixture` used to initialize the `ServiceCollection` IoC for the CUT in `Spotcheckr.API`. Each test class must be annotated with a `[Collection("Service collection")]` attribute and inherit from `BsaeTest`. This allows test classes to share a single IoC instance.
See [here](https://xunit.net/docs/shared-context) for more about Collection Fixtures and Shared Context. Each test project must also have a `ServiceCollection` class to facilitate Collection Fixtures.

## CI/CD
The project has continuous integration using Github actions. The configuration can be found in `.github/workflows/ci.yml`. The project also support continuous deployment to an instance of Azure App Service.

## Architectural Overview
The Spotcheckr API is a GraphQL API with the HotChocolate library. EntityFramework is used as the ORM. `Spotcheckr.Domain` are the domain classes used to configure EntityFramework. It is preferred to keep the domain classes annotation free and to instead use the `Spotcheckr.Data` project's `SpotcheckrCoreContext` class to configure the database schema. `Spotcheckr.Data` also has a `DatabaseInitializer` class to seed the database with test data if it does not already exist. `Spotcheckr.Models` are the  data transfer objects returned by the service layer; the service layer will take in these objects and return them and will also work with Domain models when working with the database. We use `AutoMapper` to map between the domain to DTOs but **never** from the DTOs to the domain.

Querying and mutating with the database is done using the Unit of Work and Repository patterns. The repositories exist in `Spotcheckr.Data`. Each of these repositories should return Domain entities only.

The service layer exists in the `Spotcheckr.API` project under the `Services` folder.GraphQL types are configured in the `Types` folder. We prefer to configure types and avoid annotation of the `Spotcheckr.Models` entities. The `Spotcheckr.Models` entities may contain doc strings to annotate the schema, however. Queries, mutations, and subscriptions have their own respective folders. For each, we extend as necessary to avoid large classes.

For naming conventions we prefer `Create`, `Delete`, `Update`, `Get` prefixes for all queries and mutations.
