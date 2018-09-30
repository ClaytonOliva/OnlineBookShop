# OnlineBookShop

The solution is split into the following projects
* **OnlineBookShop** : This layer has an implementation of the Dependency Inversion Principle so that application builds a loosely coupled application. It communicates to internal layer via interfaces.
* **OnlineBookShop.Bootstrapper** : Initialise the IOC containers.
* **OnlineBookShop.Contracts** : It holds all application domain objects.
* **OnlineBookShop.Data** : The layer is intended to create an Abstraction layer between the Domain entities layer and Business Logic layer of an application.
* **OnlineBookShop.Service** : The layer holds interfaces which are used to communicate between the UI layer and repository layer. It holds business logic for an entity. 
* **OnlineBookShop.Test** : Unit test for the application.