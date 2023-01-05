# Mvc Blog Project
It's blog web page.
## Development Tools
- MVC 
- Entity Framework Core
- N-tier Architecture
- MS SQL
## How to install
Go to the web.config file and flex the **data source** to your own SQL Server. 
```
  <connectionStrings>
    <add name="Context" connectionString="data source= SQLSERVER; initial catalog=DbMvcCamp; integrated security=true;" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
