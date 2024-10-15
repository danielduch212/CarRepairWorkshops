# CarRepairWorkshops

Working here: https://carrepairworkshops-api-prod-a8cfb0eddjbmbmc8.polandcentral-01.azurewebsites.net/swagger

##Introduction
This project is made using Clean Code pattern and CQRS(mediator). Projects works with Azure services - App Service, SQL Database, BlobStorage and Insights.

This api is created for Car repair workshops. So for many workshops which have their own owners, mechanics and repairs. So we have 3 actors(roles):
- Mechanic
- Owner
- Admin


They are made using Aspnetcore.Identity Package. And this api authorize endpoints by userRole - generally speaking but there are custom polices either.

## Database
[baza danych CarRepairWorkshops.pdf](https://github.com/user-attachments/files/17379577/baza.danych.CarRepairWorkshops.pdf)

There are entities created from Aspnetcore.Identity but there are mine entities maybe more interesting. So we have:
- CarRepairWorkshops - represents workshop created in database using api. Single entity has its properties and it stores logo either. Logo is stored as filename of blob(Azure).
- Cars - cars that single workshop has in its system
- Repairs - single car has its repairs - with their properties like price and date of finalization.
- CarPart and MechanicalService - it is used for single repair - what car parts were used and what services were given.

## Use cases   

![Use cases diagram](https://github.com/user-attachments/assets/19313f5a-3061-49e5-82ba-8c168eb203b8)


## How to run/test the project:

I created 3 users: 
- admin (email: admin@admin.com / password: Password1!)
- owner (email: owner@owner.com / password: Password1!)
- mechanic (email: mechanic@mechanic.com / password: Password1!)

Owner and mechanic are in the same workshop. You can try to create another workshop - using Admin account. And if you want to try another endpoints - look in use cases if its probably possible for given user. 


Logging and authorization: 

Go to this site: [Swagger for Car Repair Workshops API](https://carrepairworkshops-api-prod-a8cfb0eddjbmbmc8.polandcentral-01.azurewebsites.net/swagger/index.html)

and try to log using for example owner account (details up):

![1](https://github.com/user-attachments/assets/46fdd0e6-a373-4150-b81e-8cc63aca2127)

After this request we should get Access token:
![2](https://github.com/user-attachments/assets/ede7b83c-9b33-4513-9fd4-683e8e768dd7)

You must copy this acces token and paste it here:
![3](https://github.com/user-attachments/assets/7af5a179-d9ff-4e7a-a4a9-e67b967a8d88)

After this steps - you are authorized as owner. (I gave this role before to this user by admin)

Now if you have the role owner you can create your workshop: 

![5](https://github.com/user-attachments/assets/d1bab49a-1512-4829-ae60-0044b9a49dd6)

After successful request we can finally assign mechanic to our workshop:
![6](https://github.com/user-attachments/assets/c155b521-254c-46fc-a4df-349f9c4afa9c)


Thanks for reading. For more information and technical details of programme please search code.


