-- ============================================
-- WARNING: DEV / TEST DATA ONLY
-- Running this script will DELETE all existing data!
-- Do NOT run this in production.
-- All seed user passwords are: Password123
-- ============================================

DELETE FROM Feedbacks;
DELETE FROM Reservations;
DELETE FROM ItemPhotos;
DELETE FROM Items;
DELETE FROM RestaurantTables;
DELETE FROM Menus;
DELETE FROM Users;
GO


DBCC CHECKIDENT ('Feedbacks', RESEED, 0);
DBCC CHECKIDENT ('Reservations', RESEED, 0);
DBCC CHECKIDENT ('ItemPhotos', RESEED, 0);
DBCC CHECKIDENT ('Items', RESEED, 0);
DBCC CHECKIDENT ('RestaurantTables', RESEED, 0);
DBCC CHECKIDENT ('Menus', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);
GO


-- Password for all users: Password123
-- BCrypt hash generated using BCrypt-Net-Next
INSERT INTO Users (FullName, Email, PasswordHash, Phone, Role, IsEmailVerified) 
VALUES 
('Alice Smith', 'alice.smith@email.com', '$2a$11$oJO20V0TfRPU1xP6rbRdv.UfQf6NB39efVx4h2w5EC4WaGBJ3ZfSC', '555-0101', 'Admin', 1),
('Bob Jones', 'bob.jones@email.com', '$2a$11$oJO20V0TfRPU1xP6rbRdv.UfQf6NB39efVx4h2w5EC4WaGBJ3ZfSC', '555-0102', 'Client', 1),
('Charlie Brown', 'charlie.b@email.com', '$2a$11$oJO20V0TfRPU1xP6rbRdv.UfQf6NB39efVx4h2w5EC4WaGBJ3ZfSC', '555-0103', 'Client', 1),
('Diana Prince', 'diana.p@email.com', '$2a$11$oJO20V0TfRPU1xP6rbRdv.UfQf6NB39efVx4h2w5EC4WaGBJ3ZfSC', '555-0104', 'Client', 0),
('Evan Wright', 'evan.w@email.com', '$2a$11$oJO20V0TfRPU1xP6rbRdv.UfQf6NB39efVx4h2w5EC4WaGBJ3ZfSC', '555-0105', 'Client', 1);
GO


INSERT INTO Menus (MenuName, Description, DisplayOrder) 
VALUES 
('Breakfast Menu', 'Morning classics served 7 AM to 11 AM', 1),
('Lunch Menu', 'Light bites, salads, and sandwiches', 2),
('Dinner Menu', 'Steaks, seafood, and hearty pastas', 3),
('Dessert Menu', 'Sweet treats and after-dinner coffee', 4),
('Drinks Menu', 'Cocktails, wines, and soft beverages', 5);
GO


INSERT INTO RestaurantTables (TableNumber, SeatingCapacity, Location, PhotoPath) 
VALUES 
('T-01', 2, 'Window Seat', 'https://images.unsplash.com/photo-1552566626-52f8b828add9?auto=format&fit=crop&w=800&q=80'),
('T-02', 4, 'Main Dining Room', 'https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?auto=format&fit=crop&w=800&q=80'),
('T-03', 4, 'Main Dining Room', 'https://images.unsplash.com/photo-1414235077428-338989a2e8c0?auto=format&fit=crop&w=800&q=80'),
('T-04', 6, 'Outdoor Patio', 'https://images.unsplash.com/photo-1600093463592-8e36ae95ef56?auto=format&fit=crop&w=800&q=80'),
('T-05', 8, 'Private Booth', 'https://images.unsplash.com/photo-1559329007-40df8a9345d8?auto=format&fit=crop&w=800&q=80');
GO


INSERT INTO Items (MenuId, ItemName, Description, Price, Currency, Ingredients, Origin) 
VALUES 
(1, 'Buttermilk Pancakes', 'Three fluffy pancakes with maple syrup', 9.99, '$', 'Flour, milk, eggs, butter, maple syrup', 'Local'),
(2, 'Caesar Salad', 'Crisp romaine with parmesan and croutons', 12.50, '$', 'Romaine lettuce, parmesan, garlic, anchovies', 'Local'),
(3, 'Ribeye Steak', '12oz prime cut with garlic butter', 35.00, '$', 'Beef, garlic, butter, salt, pepper', 'Texas, USA'),
(4, 'Chocolate Lava Cake', 'Warm chocolate cake with a molten center', 8.50, '$', 'Chocolate, flour, eggs, sugar', 'House-made'),
(5, 'Mojito', 'Refreshing rum cocktail with mint and lime', 10.00, '$', 'White rum, mint leaves, lime juice, club soda', 'Cuba');
GO


INSERT INTO ItemPhotos (ItemId, PhotoPath, IsPrimary) 
VALUES 
(1, 'https://images.unsplash.com/photo-1528207776546-365bb710ee93?auto=format&fit=crop&w=800&q=80', 1),
(2, 'https://images.unsplash.com/photo-1550304943-4f24f54ddde9?auto=format&fit=crop&w=800&q=80', 1),
(3, 'https://images.unsplash.com/photo-1600891964092-4316c288032e?auto=format&fit=crop&w=800&q=80', 1),
(4, 'https://images.unsplash.com/photo-1624353365286-3f8d62daad51?auto=format&fit=crop&w=800&q=80', 1),
(5, 'https://images.unsplash.com/photo-1551538827-9c037cb4f32a?auto=format&fit=crop&w=800&q=80', 1);
GO


INSERT INTO Reservations (UserId, TableId, GuestName, GuestEmail, GuestPhone, ReservationDate, NumberOfGuests, Status, Notes) 
VALUES 
(3, 1, 'Charlie Brown', 'charlie.b@email.com', '555-0103', DATEADD(day, 1, GETDATE()), 2, 'Confirmed', 'Anniversary dinner'),
(4, 2, 'Diana Prince', 'diana.p@email.com', '555-0104', DATEADD(day, 2, GETDATE()), 4, 'Pending', 'Needs a high chair'),
(5, 4, 'Evan Wright', 'evan.w@email.com', '555-0105', DATEADD(day, 3, GETDATE()), 6, 'Confirmed', 'Patio seating preferred'),
(NULL, 5, 'Walk-in Guest', 'guest@email.com', '555-9999', DATEADD(hour, 2, GETDATE()), 8, 'Confirmed', 'Walk-in large group'),
(3, 3, 'Charlie Brown', 'charlie.b@email.com', '555-0103', DATEADD(day, 7, GETDATE()), 4, 'Cancelled', 'Had to reschedule');
GO


INSERT INTO Feedbacks (UserId, ReservationId, GuestName, Comment, VisitRating, IsApproved) 
VALUES 
(3, 1, 'Charlie Brown', 'Absolutely loved the pancakes! Great service.', 5, 1),
(4, 2, 'Diana Prince', 'The salad was a bit too salty, but the atmosphere was nice.', 3, 1),
(5, 3, 'Evan Wright', 'Perfect steak. Will definitely be coming back!', 5, 1),
(NULL, NULL, 'Anonymous Reviewer', 'Drinks were a bit overpriced.', 4, 0),
(NULL, 4, 'Walk-in Guest', 'Accommodated our large group wonderfully without a prior booking.', 5, 1);
GO