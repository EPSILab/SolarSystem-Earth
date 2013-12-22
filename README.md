SolarSystem-Earth
=================

Contains all sources for the database access and the webservice.

Webservices are available on:
- Readers (Public): http://www.epsilab.net/Webservices/ReadersServices.svc
- Managers (Private, locked by database login): http://www.epsilab.net/Webservices/ManagersServices.svc

#Important
This project **MUST** be private because it contains some critical informations such as database identification informations.

#HowTo
Clone this repository and open the solution file named "**Earth.sln**".

#License
This project has a **LGPL** license.

#Required
- .NET 4.0
- Visual Studio 2010 or higher
- Entity Framework 4.0

#Layers:
- **Common:** Contains all common elements such as DTOs and Interfaces.
- **DataAccess:** Contains the Entity Model, DAOs and classes to access to the database.
- **ClassMappers:** Transforms DAOs to DTOs and vice-versa.
- **Business:** Contains all the business logic. Link the webservice to the data access.
- **WCF:** The WCF web-service project.
