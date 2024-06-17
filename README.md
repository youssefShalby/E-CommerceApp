# E-CommerceApp
E-Commerce Backend project using dotnet web Api technology

## Installation
the repo is public as you show, so can clone or download it and go ahead

## How use our project
once you cloned or downloaded the Api project you can deploy and use it to build the frontend layer

## We have 4 cases or 4 roles in the System
### 1. Unauthorized user
the Unauthorized user can show products of the system and can search for sepcific product,  
also can show the Brands and Categories and search for specific category or specific brand and show products of them.  
can also show the avaliable delievery methods for shipment process  

### 2. Authenticated user
**The authenticated user have role named 'User' role, once the user have this role the user can make the following process...**    

- Show the all products of the system, and can search for specicfic one   
- Access categories and brands and products of them   
- can add products to the Basket  
- Can create order by the products of the basket  
- Can update the order in the pending state only  
- can finish payment process by using stripe payment  

   

**on another hand, the use can also do the following process...**  
- Add product for sale  
- update created product and can also delete the created product    
- can update the Information of Account like [password, UserName, DisplayName, Address]    

### 3. Authenticated Admin user
**The Authenticated Admin user can make special process on the system, those special processes the normal use can't do it, the Admin can do all process that mentioned in the 'User' role because the 'Admin' role designed to have premission of the 'User' role, the allowed process for the Admin like follow**   

- access all products of the system    
- can delete, update and delete any product on the system     
- can access all categories and can create, update and delete category    
- can access all Brands and can createm update and delete any brand    
- can access all orders of the system and controle them
- can show information about the system form the Admin dashboard   
- can create, update and delete Delivery method for shipment process   

### 4. Authenticated SuperAdmin user
**The Authenticated SuperAdmin user have a all permissions of the system, can do all processes that mentioned above for the 'User' and 'Admin' and additionaly can make any user as admin and can Add Role for the System and also can remove and update any role, and finally will add some features for the SuperAdmin later**

### Some another features
**Exception handler Middleware**  
-- This middleware designed to fetch any unhandled exception in the system

**Limit Requests Middleare**  
-- This middleware designed to limit requests that sending to the server to prevent the DosAttack

**Pagination**  
-- we added pagination when get models like products and categories to Reducing the data carried by the Request and speed up the request

**Sort**   
-- the user can sort the showen models products and categories by more options. can sort by date, name or price

**Filtering**   
-- we added filter to search about models right products, categories and brands

### What we used in the project
1. N-Tier Architecture for project structure
2. unit of work
3. Repository Pattern
4. Dependency Injection
5. stripe pyament
6. JWT
7. dotnet Identity for security
8. Authentication and Authorization Based Roles
9. Entity Framework Core to Interact with Sql Server Database
10. Fluent API validation for Domain Models
11. Data Annotation Validation for DTOs
12. mailkit to send emails
13. custom mappers
14. Redis for caching
15. custom middlewares (exception, limitrequest)
16. global usings
17. option pattern
18. user-secrets to use manage senstive data



