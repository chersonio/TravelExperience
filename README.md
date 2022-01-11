# TravelExperience - Group project for PeopleCert

Project contributors
--------------------------------

1. Stavros Chersoniotakis (Team Coordinator, Back-End Developer, Database Developer)
    chersoniotakis.stavros@gmail.com
2. Nikoleta Panagou (Back-End Developer, Database Developer)
    nikolpanagou@gmail.com
3. Stavroula Parisi (Front-End Developer, Back-End Developer)
    stavroulaprs@gmail.com
    
Business Logic
-------------------------
The main idea of the TravelExperience is that a User could become a Host(owner) and by giving space for rent and may have income from other users or Travelers in our case.

Hosts can sign-in so they can place listings of Accommodations.
The Accommodations that Hosts can create, or users can book, begin from a simple Room to a Hotel.
Hosts can share a good represantation of their lovely place by uploading an image with just a simple click.

Users can sign-in to search and book where to stay all over the world.
They may review their upcoming or past bookings.
They can start browsing in the default page by checking random accommodations around the world or near their location.
The search filters are by address, dates or max guests. 

Each individual Accommodation has Title, Description, Location, Utilities, Dates of availability, Cost per Night 

When a user wants to book an accommodation at free dates, he may choose his private wallet to pay.
A transaction is created keeping the available information
As a last part of the successfull booking there is a confirmation page with a receipt and other booking info.

For the Business:
WebApi returns Read operations for accommodations locations and bookings.
There is an also export a db tool that creates a copy of rows as sql insert statements for enhanced security and back-up. 

Future goals: 
------------------
Experiences= the other half of our goal
Advertisements= Paid Ads could be shown higher and/or more often at search results.
Group booking= One person could book for itself, for other persons, or groups of persons.
Payment solutions= Paypal and E-banking implementation, 
Travel Agency= a middle guy manages accommodations and experiences
Instant Messaging

Technologies:
--------------------
a) The project's DB is based on MSSQL
b) Front-End: HTML/CSS/JAVASCRIPT, JQuery, Bootstrap
c) Back-End: C#, .NET Framework, Entity Framework, REST API: ASP .NET
d) Extra: Google maps api

---------------------------------
For TravelExperience development there was also created a Jira ticketing system so there could be quicker and safer communication and for a better development experience.
https://travelexperience.atlassian.net/jira/software/projects/TX/boards/1
