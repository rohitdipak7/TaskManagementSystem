CREATE TABLE Tickets (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    Status INT NOT NULL,
    Priority INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    ModifiedDate DATETIME NOT NULL,
    DueDate DATETIME NOT NULL,
    UserID UNIQUEIDENTIFIER NOT NULL
);

CREATE TABLE Documents (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    TicketID UNIQUEIDENTIFIER,
    FileName NVARCHAR(255) NOT NULL,
    FilePath NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (TicketID) REFERENCES Tickets(ID)
);

CREATE TABLE Notes (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    TicketID UNIQUEIDENTIFIER,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    FOREIGN KEY (TicketID) REFERENCES Tickets(ID)
);


INSERT INTO Tickets (ID, Title, Description, Status, Priority, CreatedDate, ModifiedDate, DueDate, UserID)
VALUES 
--(newid(), 'Sample Ticket 1', 'Description 1', 1, 3, '2024-07-26 14:43:19', '2024-07-28 14:43:19', DATEADD(day, 5, GETDATE()), '6f9619ff-8b86-d011-b42d-00cf4fc964ff'),
--(newid(), 'Sample Ticket 2', 'Description 2', 2, 4, '2024-07-26 16:43:19', '2024-07-28 15:43:19', DATEADD(day, 6, GETDATE()), '6f9619ff-8b86-d011-b42d-00cf4fc964ff'),
--(newid(), 'Sample Ticket 3', 'Description 3', 3, 5, '2024-07-26 17:43:19', '2024-07-28 16:43:19', DATEADD(day, 7, GETDATE()), '6f9619ff-8b86-d011-b42d-00cf4fc964ff'),
--(newid(), 'Sample Ticket 4', 'Description 4', 4, 2, '2024-07-26 18:43:19', '2024-07-28 17:43:19', DATEADD(day, 8, GETDATE()), '6f9619ff-8b86-d011-b42d-00cf4fc964ff'),
(newid(), 'Sample Ticket 5', 'Description 5', 5, 1, '2024-07-26 19:43:19', '2024-07-28 18:43:19', DATEADD(day, 9, GETDATE()), '6f9619ff-8b86-d011-b42d-00cf4fc964ff');


select * from Tickets

-- Sample Documents
INSERT INTO Documents (Id, TicketId, FileName, FilePath)
VALUES 
(newid(), '7CD9680F-1106-4A61-9211-05435BD5664F', 'doc1.pdf', '/path/doc1.pdf'),
(newid(), '7CD9680F-1106-4A61-9211-05435BD5664F', 'doc2.pdf', '/path/doc2.pdf'),
(newid(), '4535A6E9-268C-4413-9DD4-14EF4B002F21', 'doc3.pdf', '/path/doc3.pdf'),
(newid(), '4535A6E9-268C-4413-9DD4-14EF4B002F21', 'doc4.pdf', '/path/doc4.pdf'),
(newid(), '332032A5-68F5-4C77-88A3-684CD370DF9D', 'doc5.pdf', '/path/doc5.pdf'),
(newid(), '332032A5-68F5-4C77-88A3-684CD370DF9D', 'doc6.pdf', '/path/doc6.pdf'),
(newid(), '9E0CDCA3-398D-4BA0-B20B-A7E2A61C9B85', 'doc7.pdf', '/path/doc7.pdf'),
(newid(), '9E0CDCA3-398D-4BA0-B20B-A7E2A61C9B85', 'doc8.pdf', '/path/doc8.pdf'),
(newid(), 'ED06B45D-66DD-4FE3-A0DC-B7DEA08DB7AF', 'doc9.pdf', '/path/doc9.pdf'),
(newid(), 'ED06B45D-66DD-4FE3-A0DC-B7DEA08DB7AF', 'doc10.pdf', '/path/doc10.pdf');

-- Sample Notes
INSERT INTO Notes (Id, TicketId, Content, CreatedDate)
VALUES 
(newid(), '7CD9680F-1106-4A61-9211-05435BD5664F', 'Note 1', GETDATE()),
(newid(), '7CD9680F-1106-4A61-9211-05435BD5664F', 'Note 2', GETDATE()),
(newid(), '4535A6E9-268C-4413-9DD4-14EF4B002F21', 'Note 3', GETDATE()),
(newid(), '4535A6E9-268C-4413-9DD4-14EF4B002F21', 'Note 4', GETDATE()),
(newid(), '332032A5-68F5-4C77-88A3-684CD370DF9D', 'Note 5', GETDATE()),
(newid(), '332032A5-68F5-4C77-88A3-684CD370DF9D', 'Note 6', GETDATE()),
(newid(), '9E0CDCA3-398D-4BA0-B20B-A7E2A61C9B85', 'Note 7', GETDATE()),
(newid(), '9E0CDCA3-398D-4BA0-B20B-A7E2A61C9B85', 'Note 8', GETDATE()),
(newid(), 'ED06B45D-66DD-4FE3-A0DC-B7DEA08DB7AF', 'Note 9', GETDATE()),
(newid(), 'ED06B45D-66DD-4FE3-A0DC-B7DEA08DB7AF', 'Note 10', GETDATE());




drop table Users 
CREATE TABLE Users (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    IsManager BIT NOT NULL,
    IsAdmin BIT NOT NULL,
    Role INT NOT NULL,
    ManagerID UNIQUEIDENTIFIER NULL,
    TeamID UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (ManagerID) REFERENCES Users(ID),
    FOREIGN KEY (TeamID) REFERENCES Teams(ID)
);

-- Insert sample users
INSERT INTO Users (ID, Username, Email, PasswordHash,IsManager, IsAdmin,Role, ManagerID, TeamID) VALUES 
(NEWID(), 'user1', 'user1@example.com', 'hashedpassword1',0,0, 0, NULL, (SELECT ID FROM Teams WHERE Name = 'Team A')),
(NEWID(), 'manager1', 'manager1@example.com', 'hashedpassword2',1,0, 1, NULL, (SELECT ID FROM Teams WHERE Name = 'Team B')),
(NEWID(), 'user2', 'user2@example.com', 'hashedpassword3',0,0, 0, (SELECT ID FROM Users WHERE Username = 'manager1'), (SELECT ID FROM Teams WHERE Name = 'Team A')),
(NEWID(), 'admin1', 'admin1@example.com', 'hashedpassword4',1,0, 2, NULL, (SELECT ID FROM Teams WHERE Name = 'Team B')),
(NEWID(), 'user3', 'user3@example.com', 'hashedpassword5',0,0, 0, (SELECT ID FROM Users WHERE Username = 'manager1'), (SELECT ID FROM Teams WHERE Name = 'Team A')),
(NEWID(), 'user4', 'user4@example.com', 'hashedpassword6',0,0, 0, (SELECT ID FROM Users WHERE Username = 'manager1'), (SELECT ID FROM Teams WHERE Name = 'Team B'));

-- Create the Teams table
CREATE TABLE Teams (
    ID UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Insert sample teams
INSERT INTO Teams (ID, Name) VALUES 
(NEWID(), 'Team A'),
(NEWID(), 'Team B');
drop table UserTeams
-- Create the UserTeams table to establish the many-to-many relationship between Users and Teams
CREATE TABLE UserTeams (
    UserID UNIQUEIDENTIFIER NOT NULL,
    TeamID UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (UserID, TeamID),
    FOREIGN KEY (UserID) REFERENCES Users(ID),
    FOREIGN KEY (TeamID) REFERENCES Teams(ID)
);

-- Insert sample user-team associations
INSERT INTO UserTeams (UserID, TeamID) VALUES 
((SELECT ID FROM Users WHERE Username = 'user1'), (SELECT ID FROM Teams WHERE Name = 'Team A')),
((SELECT ID FROM Users WHERE Username = 'user2'), (SELECT ID FROM Teams WHERE Name = 'Team A')),
((SELECT ID FROM Users WHERE Username = 'user3'), (SELECT ID FROM Teams WHERE Name = 'Team B')),
((SELECT ID FROM Users WHERE Username = 'user4'), (SELECT ID FROM Teams WHERE Name = 'Team B')),
((SELECT ID FROM Users WHERE Username = 'manager1'), (SELECT ID FROM Teams WHERE Name = 'Team A')),
((SELECT ID FROM Users WHERE Username = 'admin1'), (SELECT ID FROM Teams WHERE Name = 'Team B'));



select * from Tickets
select * from Documents
select * from Notes
select * from Users
select * from UserTeams

