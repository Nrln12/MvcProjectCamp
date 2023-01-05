# Mvc Blog Project
It's blog web page.
## Development Tools
- MVC 
- Entity Framework Core
- N-tier Architecture
- MS SQL
## Features
- The project has general CRUD operations, also I've added show-case of project as seperate web page, and add my skills' card to it. All these operations are working dynamically(the datas were fetched from database).
## How to install
Go to the web.config file and flex the **data source** to your own SQL Server. Then add migrations and start the project.
```
  <connectionStrings>
    <add name="Context" connectionString="data source= SQLSERVER; initial catalog=DbMvcCamp; integrated security=true;" providerName="System.Data.SqlClient" />
  </connectionStrings>
```
