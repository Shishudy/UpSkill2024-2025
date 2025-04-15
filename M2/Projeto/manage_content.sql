USE biblio_XPTO;
GO
-- Add items to database
IF EXISTS (
SELECT *
FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddItemsToDatabase'
)
DROP PROCEDURE dbo.sp_AddItemsToDatabase
GO

CREATE PROCEDURE dbo.sp_AddItemsToDatabase
AS
-- Insert data into the Genre table
INSERT INTO [dbo].[Genre] (genre)
VALUES 
('Fiction'),
('Fantasy'),
('Non-Fiction'),
('Science Fiction');

-- Insert data into the Library table
INSERT INTO [dbo].[Library] (library_location)
VALUES 
('Central Library'),
('East Branch'),
('West Branch');

-- Insert data into the BookImage table
INSERT INTO [dbo].[BookImage] (image_data)
VALUES 
(0xFFD8FFE0),
(0xFFD8FFE1),
(0xFFD8FFE2);

-- Insert data into the Book table
INSERT INTO [dbo].[Book] (pk_ISBN, title, author, release_date, publisher, fk_imageID)
VALUES 
('978-3-16-148410-0', 'The Great Gatsby', 'F. Scott Fitzgerald', '1925-04-10', 'Charles Scribners Sons', 1),
('978-1-4028-9462-6', 'The Hobbit', 'J.R.R. Tolkien', '1937-09-21', 'George Allen & Unwin', 2),
('978-0-452-28423-4', '1984', 'George Orwell', '1949-06-08', 'Secker & Warburg', 3);

-- Insert data into the BookGenre table
INSERT INTO [dbo].[BookGenre] (pk_ISBN, pk_genreID)
VALUES 
('978-3-16-148410-0', 1), -- The Great Gatsby is Fiction
('978-1-4028-9462-6', 2), -- The Hobbit is Fantasy
('978-0-452-28423-4', 4); -- 1984 is Science Fiction

-- Insert data into the BookLibrary table
INSERT INTO [dbo].[BookLibrary] (pk_ISBN, pk_libraryID, quantity)
VALUES 
('978-3-16-148410-0', 1, 5), -- The Great Gatsby in Central Library (5 copies)
('978-1-4028-9462-6', 2, 3), -- The Hobbit in East Branch (3 copies)
('978-0-452-28423-4', 3, 2); -- 1984 in West Branch (2 copies)

-- Insert data into the User table
INSERT INTO [dbo].[User] (name, active)
VALUES 
('Alice Johnson', 1),
('Bob Smith', 0),
('Charlie Brown', 1);

-- Insert data into the Reserve table
INSERT INTO [dbo].[Reserve] (fk_libraryID, reserve_date, return_date)
VALUES 
(1, '2024-11-01', '2024-11-10'),
(1, '2024-11-01', '2024-11-05'),
(1, '2024-11-01', '2024-11-12'),
(2, '2024-11-03', '2024-11-11'),
(1, '2024-11-01', '2024-11-15'),
(1, '2024-11-01', '2024-11-13'),
(1, '2024-11-01', '2024-11-04'),
(2, '2024-11-01', '2024-11-15'),
(2, '2024-11-01', '2024-11-15'),
(2, '2024-11-01', '2024-11-15'),
(2, '2024-11-01', '2024-11-15'),
(2, '2024-11-05', NULL); -- A reservation with no return date

-- Insert data into the ReserveBookUser table
INSERT INTO [dbo].[ReserveBookUser] (pk_reserveID, pk_ISBN, pk_userID)
VALUES 
(1, '978-3-16-148410-0', 1), -- Alice reserves The Great Gatsby
(2, '978-1-4028-9462-6', 1),
(3, '978-3-16-148410-0', 1),
(4, '978-1-4028-9462-6', 1),
(5, '978-0-452-28423-4', 1),
(6, '978-3-16-148410-0', 1),
(7, '978-3-16-148410-0', 1),
(8, '978-3-16-148410-0', 1),
(9, '978-1-4028-9462-6', 2),
(10, '978-1-4028-9462-6', 2),
(11, '978-1-4028-9462-6', 2),
(12, '978-1-4028-9462-6', 2); -- Bob reserves The Hobbit

GO

-- Remove items from database
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_ClearDatabase'
)
DROP PROCEDURE dbo.sp_ClearDatabase
GO
CREATE PROCEDURE dbo.sp_ClearDatabase
AS
	IF OBJECT_ID('dbo.BookLibrary', 'U') IS NOT NULL
		DELETE FROM dbo.BookLibrary;
	
	IF OBJECT_ID('dbo.BookGenre', 'U') IS NOT NULL
		DELETE FROM dbo.BookGenre;
	
	IF OBJECT_ID('dbo.ReserveBookUser', 'U') IS NOT NULL
		DELETE FROM dbo.ReserveBookUser;
	
	IF OBJECT_ID('dbo.Reserve', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT (Reserve, RESEED, 0);
		DELETE FROM dbo.Reserve;
	END

	IF OBJECT_ID('dbo.Library', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT (Library, RESEED, 0);
		DELETE FROM dbo.Library;
	END
	
	IF OBJECT_ID('dbo.Book', 'U') IS NOT NULL
		DELETE FROM dbo.Book;
	
	IF OBJECT_ID('dbo.Genre', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT (Genre, RESEED, 0);
		DELETE FROM dbo.Genre;
	END
	
	IF OBJECT_ID('dbo.BookImage', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT (BookImage, RESEED, 0);
		DELETE FROM dbo.BookImage;
	END
	
	IF OBJECT_ID('dbo.[User]', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT ([User], RESEED, 0);
		DELETE FROM dbo.[User];
	END

	IF OBJECT_ID('dbo.DeadArchive', 'U') IS NOT NULL
	BEGIN
		DBCC CHECKIDENT ([DeadArchive], RESEED, 0);
		DELETE FROM dbo.DeadArchive;
	END
GO

EXECUTE dbo.sp_ClearDatabase;
EXECUTE dbo.sp_AddItemsToDatabase;