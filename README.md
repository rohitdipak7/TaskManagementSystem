# Task Management System API

## Introduction
This is the backend API for the Task Management System. It is built using .NET Core and Entity Framework Core, with a relational database (SQL Server/MSSQL/Postgres).

## Features
- Asynchronous API calls
- CRUD operations for Tickets
- Attach documents and add notes to tickets
- Task tracking for employees, managers, and admins
- Reports generation for task completion

## Technologies Used
- .NET Core
- Entity Framework Core
- SQL Server/MSSQL/Postgres
- ASP.NET Core Web API

## Getting Started


### Prerequisites
- .NET Core SDK
- MSSQL
- Postman or any API testing tool
## Database mdf, ldf and backup files are uploaded to the DBbackup folder. Make sure to restore it to get proper connectivity
### API Endpoints

#### Tickets
- GET `/api/tickets` - Get all tickets
- GET `/api/tickets/{id}` - Get ticket by ID
- POST `/api/tickets` - Create a new ticket
- PUT `/api/tickets/{id}` - Update a ticket
- DELETE `/api/tickets/{id}` - Delete a ticket

#### Documents
- GET `/api/tickets/{ticketId}/documents` - Get documents for a ticket
- POST `/api/tickets/{ticketId}/documents` - Attach a document to a ticket
- DELETE `/api/tickets/{ticketId}/documents/{id}` - Delete a document

#### Notes
- GET `/api/tickets/{ticketId}/notes` - Get notes for a ticket
- POST `/api/tickets/{ticketId}/notes` - Add a note to a ticket
- DELETE `/api/tickets/{ticketId}/notes/{id}` - Delete a note

#### Reports
- GET `/api/reports/team-performance` - Get team performance report

Note: I have kept terminology for Task as a Ticket as Task is conflicting with the System.threading.task.
