# Nomis

Nomis is a crypto protocol based on a mathematical prediction and AI model enabling protocol users with a favorable on-chain credit score to borrow crypto with a fair collateral and APR on a case-by-case basis. On the other hand, Nomis is an open-source protocol that helps web3 developers both to build new on-chain solutions and use cases, and to balance already existing high-TVL protocols.

# Development

## Add new PosgreSQL database migrations

1. Open the window: `Package Manager Console` (`View`->`Other Windows`->`Package Manager Console`);
1. Select as the default project the project in which the data access database context is located, through which we want to add a new migration;
1. 1. Execute command with appropriate context.
- For example, adding new `Initial` migration for `ApplicationDbContext` database context:
```
add-migration Initial -o Persistence/Migrations/ -context ApplicationDbContext
```

or

```
dotnet ef migrations add "initial" -o Persistence/Migrations/ --context ApplicationDbContext
```