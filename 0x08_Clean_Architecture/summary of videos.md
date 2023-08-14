Summary of Videos
=============

Clean architecture, sometimes referred to as onion or hexagonal architecture in the past, is a domain-centric method of grouping dependencies. Here worries about infrastructural dependencies are at their lowest. Instead than being heavily focused on architecture, it concentrates more on domain logic. Its intricate business logic results in a design that is very testable.
There are essentially two approaches to architecture. N-tier architecture and Clean Architecture are these. The Clean Architecture is a domain logic focused, mostly layer independent architecture, whereas the N-tier architecture is an all-in-one, layered approach. However, there are primarily 3 categories of architectural styles. Listed below are each's advantages and disadvantages.
Integrated architecture.
        
+ All in one architecture
    + Easy and stable but hard to test and maintain.
+ Layered Architecture
    + Enforces solid principles and maintainable but dependent layers and logic is scattered
+ Onion architecture
    * Easily testable and maintainable but time-consuming and harder to learn

There are two ways you can implement the clean architecture. The first one is using the provided Ardalis.CleanArchitecture.Template on NuGet package manager. It has already defined examples to get developers familiar with the usage. The other alternative is to create a blank solution and start from scratch populating the solution folder with required projects and folders.
Setting up the project solution folder using the latter method can be achieved by following this instructions.

+	Create a blank solution and inside the solution create folders namely Core, API, infrastructure and UI.
+	Create a new project called application inside the core folder.  And inside the application project create new folder called persistence
+	Inside persistence folder, create folder named Contracts. Inside Contracts Folder create a generic interface with Type T of class as repository with CRUD tasks. Then create repository interfaces that implement the generic interface with their class type.
