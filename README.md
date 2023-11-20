# Helmes Customer Manager
### Intro:
Due to the simplicty (and ambitguity) of the task, I have taken it as a chance to self-study and explore new technlogies that I am curious about.
For example, I have decided to play around with BlazorWebAssembely a little bit to get a first impression about it, similary trying out Mapster as a replacement for AutoMapper.

Needless to say, this is not how I would make a decision in a real life scenario, nor this is the quality of code that I would use in a real project (specially on the client side), so instead of focusing on a working and tested solution, I have proritize expressing certain points that maybe more relatable to the position, like:
- General Skills:
   - Writing modular solutions, with imphesis on a clean arch that ensure speareation of concenrs and a touch of a domain centeric approach.
   - Some algorithim and problem solving skills, showen by the usuage of recursion and DFS to flatten the sectors when displaying user selected sectors on edit.
   - The ability to provide documations for the developed solutions.
   - Cabapility of developing simple UIs in a short time, with basic understanding of two-way binding based client side frameworks, and common UI libs like Bootstrap.
   - Eagerness for continues learning and trying out new techologies/patterns
	
- .NET Specific points:
    - Solid knoweldge of EF core showen by utilizing the deffered execution of IQueryable to build complex queries, FluentAPI entity config, working with disconnected entities.
    - Ability to build APIs using .NET Core.
    - Not stuck in 2010's style of C#, trying to stay updated to the new syntax changes (displayed in the usage of primary constructors, Target-typed new expressions, etc...).

### Would have loved to add:
- Dockerizing the solution to eliminate the need for the SDKs if the task evaulators didn't have them locally.
- Filling in the HelmesCustomerManager.Api.http with samples to test the API.   
- Selecting a sector should select all of it's subsectors, and better UI and UX, specially with validations.
- Improve the quality of the UI code, reducing redundancy by building reusable sub compnent for rendering a sector.
- Improved Encapsulation for entities, better usage of nullable ref types and required props, introduce more DTOs.
- Fix the classic routing issue in which when u click on add customer while being already in the page nothing happens

### Solution:
- Running the solution:
  To test the solution, 2 project must be run: the Backend API (HelmesCustomerManager.Api) and the UI (HelmesCustomerManager.UI), both are bulit on .NET 8, with the UI project using Blazor, thus these runtimes/SDKs are required

- Navigating the UI:
  There are 2 pages, one for creating/editing a customer and one for listing all created customer, with a link to navigate to the edit page
  
- Database:
  The solution uses EF Core InMemory DB provider, on the start up of the backend api, a call to DbContent.EnsureCreated() occures, which will suffice for the sake of testing, but if for some reason a SQL db is required by the interviewers, it can be easily auto genreated/scaffolded using code first approach and the same call to  DbContent.EnsureCreated(), that's after including the respect EF DB proivder of course

- Data Seeding:
  a JSON file contaning the Sectors extracted from the intially given task input will populate the Sectors DBSet using EF seeding and HasData();

	
    


  
  


