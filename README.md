# ExpenseGuard

Welcome to ExpenseGuard! This application is designed to help you efficiently manage your expenses, allowing you to track your spending, categorize transactions, and gain insights into your financial habits. This project is being developed as part of the 100-commits challenge.

Unfortunately, due to reasons beyond my control, I was not fully available during this time and could not complete the MVP as planned. On the positive side, I created a basic, nearly functional frontend and backend. This project allowed me to review .NET technologies and learn a lot about React.

In the future, I plan to complete this project and use it as a foundational project to apply concepts learned from courses and tutorials.

### DONE:

- **Expense Tracking**: Easily add, edit, and delete expenses to keep track of your spending.
- **Income Tracking**: Easily add, edit, and delete income to keep track of your budget.
- **Investments Tracking**: Monitoring of investment deposits and company shares.

### TODO:

- **Docker**: Create a Docker file to make it easier to install and run the app.
- **Authorization and Authentication**: Implement authorization and authentication on the frontend (currently working on the backend).

## Journal of Work

- **Day 1**: Initialized backend solution, started writing README, began planning models and functions.
- **Day 2**: Created "in-code" repository for expenses and connected it with the controller using dependency injection (DI).
- **Day 3**: Created CRUD controller and service for expenses.
- **Day 4**: Created "in-code" repository for incomes.
- **Day 5**: Created CRUD controller and service for incomes.
- **Day 6**: Added DTOs for expense controller.
- **Day 7**: Added DTOs for income controller, removed cloning of expenses and incomes.
- **Day 8**: Added category model with repository, implemented GET and DELETE controller and service methods.
- **Day 9**: Implemented CREATE and UPDATE for categories controller and service.
- **Day 10**: Replaced category string in other classes with new Category class.
- **Day 11**: Restructured folder structure.
- **Day 12**: Added GET method for currencies controller, services, and repository.
- **Day 13**: Introduced Money class, integrated it into other classes.
- **Day 14**: Initialized React project.
- **Day 15**: Fixed returning new resource location from POST methods.
- **Day 16**: Added finance repository and model.
- **Day 17**: Added GET and DELETE for finance controller and service.
- **Day 18**: Created DTO mapper static class.
- **Day 19**: Added CREATE and UPDATE for finance controller and service.
- **Day 20**: Updated money in finance on adding incomes and expenses.
- **Day 21**: Added investment deposit repository and model, initialized unit test project.
- **Day 22**: Added GET and DELETE service methods for investment deposit.
- **Day 23**: Added CREATE service method and created controller for investment deposit.
- **Day 24**: Created entity mapper class and introduced it in income and expense services.
- **Day 25**: Continued adding usage of entity mapper, started drawing entities diagram.
- **Day 26**: Completed entities diagram, modified models to mimic relations.
- **Day 27**: Added EF Core in-memory DB context.
- **Day 28**: Created repositories using EF Core.
- **Day 29**: Replaced old repositories with new, started implementing data seeding.
- **Day 30**: Updated new repositories, removed legacy repositories.
- **Day 31**: Renamed repositories, small refactor.
- **Day 32**: Refactored code to remove in-code TODOs, tested controllers, started planning UI.
- **Rest**: Lost track of specific days...

## Technical Goals

- Besides creating functional and attractive software, my goal for this project is to extend my knowledge of backend clean architecture and frontend technologies like React.
- Start with the simplest architecture (single project with directories for services, controllers, models, etc.) and then evolve it into a clean architecture.
- Familiarize myself with best practices and clean code principles.

## Installation

Don't bother installing it yet. It's still a work in progress and not completed.
