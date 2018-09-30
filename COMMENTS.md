## Comments

# REST API
It is using Swagger UI to facilitate communication with endpoints.

# Contracts Assumption
In this project, the models used between the data layer and the presentation layer are very similar. I still separated these models to emphasis that no models needs to be shared between these layers. 

# Unit Tests Assumption
Ideally the data services are Mocked so it does not call the database. In this case I left the DB connection and was using the Tests to fill database with some data. 