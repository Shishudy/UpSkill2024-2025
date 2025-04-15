USE biblio_XPTO;
GO

-- Info: Adds a new library
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddLibrary'
)
DROP PROCEDURE dbo.sp_AddLibrary
GO
CREATE PROCEDURE dbo.sp_AddLibrary
	@libraryLocation NVARCHAR(50)
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [Library] WHERE library_location = @libraryLocation) != 0)
			THROW 50000, 'Library already in database.', 1;
		INSERT INTO [Library] (library_location) VALUES (@libraryLocation);
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding new library.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Adds a new genre
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddGenre'
)
DROP PROCEDURE dbo.sp_AddGenre
GO
CREATE PROCEDURE dbo.sp_AddGenre
	@genre NVARCHAR(50)
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [Genre] WHERE genre = @genre) != 0)
			THROW 50000, 'Genre already in database.', 1;
		INSERT INTO [Genre] (genre) VALUES (@genre);
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding new genre.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Registers a new user - for simplicity, the only information stored about the user is the name.
-- There can't be 2 registries with the same name.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_RegisterUser'
)
DROP PROCEDURE dbo.sp_RegisterUser;
GO
CREATE PROCEDURE dbo.sp_RegisterUser @user_name NVARCHAR(50)
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE [name] = @user_name) != 0)
			THROW 50000, 'User already registered.', 1;
		INSERT INTO [User]([name], active) VALUES (@user_name, 1);
		IF (@local_trancount = 1)
		BEGIN
		  COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding new user.';
		IF (@local_trancount = 1)
		BEGIN
		  ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Adds a new image
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddImage'
)
DROP PROCEDURE dbo.sp_AddImage;
GO
CREATE PROCEDURE dbo.sp_AddImage @image_path NVARCHAR(MAX)
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		DECLARE @command NVARCHAR(MAX);
		SET @command = 'INSERT INTO [BookImage](image_data) VALUES (SELECT BulkColumn FROM Openrowset (Bulk ' + @image_path + ', 
		Single_Blob) AS VARBINARY(MAX))';
		EXEC sp_executesql @command;
		IF (@local_trancount = 1)
		BEGIN
		  COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding new image.';
		IF (@local_trancount = 1)
		BEGIN
		  ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Update quantity of copies of a book
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_UpdateQuantity'
)
DROP PROCEDURE dbo.sp_UpdateQuantity
GO
CREATE PROCEDURE dbo.sp_UpdateQuantity
	@libraryID INT, @ISBN NVARCHAR(50), @quantity_to_add INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [BookLibrary] WHERE pk_isbn = @ISBN AND pk_libraryID = @libraryID) = 0)
			THROW 50000, 'Selected library does not have this book registered yet. Use sp_AddBookToLibrary if 
			the book exists or sp_AddBook to add a new book.', 1;
		UPDATE [BookLibrary]
		SET quantity = (SELECT quantity FROM BookLibrary WHERE pk_libraryID = @libraryID AND pk_ISBN = @ISBN) + @quantity_to_add
		WHERE [BookLibrary].pk_libraryID = @libraryID AND [BookLibrary].pk_ISBN = @ISBN;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error updating number of copies in the given library.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Adds a new book
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddBook'
)
DROP PROCEDURE dbo.sp_AddBook;
GO
CREATE PROCEDURE dbo.sp_AddBook @ISBN NVARCHAR(50), @title NVARCHAR(50), @author NVARCHAR(50), @release_date DATE, @publisher NVARCHAR(50), @imageID INT, @genreID INT, @libraryID INT, @quantity INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [Book] WHERE pk_isbn = @ISBN) = 0)
			THROW 50000, 'Book already in database. Use sp_AddBookToLibrary to add it to the desired library.', 1;
		IF (@release_date > CAST(GETDATE() AS date))
			THROW 50000, 'Invalid date.', 1;
		IF ((SELECT COUNT(*) FROM [BookImage] WHERE pk_imageID = @imageID) = 0)
			THROW 50000, 'Invalid image.', 1;
		IF ((SELECT COUNT(*) FROM [Genre] WHERE pk_genreID = @genreID) = 0)
			THROW 50000, 'Invalid genre.', 1;
		IF ((SELECT COUNT(*) FROM [Library] WHERE pk_libraryID = @libraryID) = 0)
			THROW 50000, 'Invalid library.', 1;
		IF ((@quantity < 1))
			THROW 50000, 'Invalid quantity. Need at least 1 copy to add to database.', 1;
		INSERT INTO [Book](pk_ISBN, title, author, release_date, publisher, fk_imageID) VALUES (@ISBN, @title, @author, @release_date, @publisher, @imageID);
		INSERT INTO [BookGenre](pk_ISBN, pk_genreID) VALUES (@ISBN, @genreID);
		INSERT INTO [BookLibrary](pk_libraryID, pk_ISBN, quantity) VALUES (@libraryID, @ISBN, @quantity);
		IF (@local_trancount = 1)
		BEGIN
		  COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding new book.';
		IF (@local_trancount = 1)
		BEGIN
		  ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Adds an already existing book to a library
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_AddBookToLibrary'
)
DROP PROCEDURE dbo.sp_AddBookToLibrary
GO
CREATE PROCEDURE dbo.sp_AddBookToLibrary
	@libraryID INT, @ISBN NVARCHAR(50), @quantity INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF (SELECT COUNT(*) FROM [BookLibrary] WHERE pk_isbn = @ISBN AND pk_libraryID = @libraryID) != 0
			THROW 50000, 'Book already in library. If you wish to update the quantity, use sp_UpdateQuantity', 1;
		INSERT INTO [BookLibrary] (pk_ISBN, pk_libraryID, quantity) VALUES (@libraryID, @ISBN, @quantity);
		IF (@local_trancount = 1)
		BEGIN
		  COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error adding book to library.';
		IF (@local_trancount = 1)
		BEGIN
		  ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Transfer copies from one library to another.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_MoveCopiesBetweenLibraries'
)
DROP PROCEDURE dbo.sp_MoveCopiesBetweenLibraries
GO
CREATE PROCEDURE dbo.sp_MoveCopiesBetweenLibraries
	@libraryFrom INT, @libraryTo INT, @ISBN NVARCHAR(50), @copies_to_move INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF (@copies_to_move < 1)
			THROW 50000, 'Invalid book quantity.', 1;
		IF ((SELECT COUNT(*) FROM [Book] WHERE pk_ISBN = @ISBN) = 0)
			THROW 50000, 'Book not in database.', 1;
		IF ((SELECT COUNT(*) FROM [BookLibrary] WHERE pk_isbn = @ISBN AND pk_libraryID = @libraryFrom) = 0)
			THROW 50000, 'Source library does not have that book registered.', 1;
		IF ((SELECT COUNT(*) FROM [BookLibrary] WHERE pk_isbn = @ISBN AND pk_libraryID = @libraryTo) = 0)
			INSERT INTO [BookLibrary](pk_libraryID, pk_ISBN, quantity) VALUES (@libraryTo, @ISBN, 0);
		IF (@copies_to_move < (SELECT quantity FROM [BookLibrary] WHERE pk_libraryID = @libraryFrom AND pk_ISBN = @ISBN))
		BEGIN
			EXEC dbo.sp_UpdateQuantity @libraryTo, @ISBN, @copies_to_move;
			DECLARE @newQuantity INT;
			SET @newQuantity = 0 - @copies_to_move;
			EXEC dbo.sp_UpdateQuantity @libraryFrom, @ISBN, @copies_to_move;
		END
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error transfering books between libraries.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Creates reservation ID and sets reservation date.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_CreateReservationID'
)
DROP PROCEDURE dbo.sp_CreateReservationID
GO
CREATE PROCEDURE dbo.sp_CreateReservationID
	@libraryID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [Library] WHERE pk_libraryID = @libraryID) = 0)
			THROW 50000, 'Library does not exist.', 1;
		INSERT INTO [Reserve](fk_libraryID, reserve_date, return_date) VALUES (@libraryID, CAST(GETDATE() AS date), null);
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error creating reservation ID.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Creates reservation. Adds a row on a table connecting the reservation ID, the book and the user.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_CreateReservation'
)
DROP PROCEDURE dbo.sp_CreateReservation
GO

CREATE PROCEDURE dbo.sp_CreateReservation
	@ISBN NVARCHAR(50), @userID INT, @libraryID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User not registered.', 1;
		IF ((SELECT COUNT(*) FROM [BookLibrary] WHERE pk_ISBN = @ISBN AND pk_libraryID = @libraryID) = 0)
			THROW 50000, 'Book not in library.', 1;
		IF ((SELECT quantity FROM [BookLibrary] WHERE pk_ISBN = @ISBN AND pk_libraryID = @libraryID) < 2)
			THROW 50000, 'Not enough copies available to create reservation.', 1;
		IF ((SELECT COUNT(*) FROM [ReserveBookUser] INNER JOIN [Reserve] ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID WHERE [ReserveBookUser].pk_userID = 2 AND [Reserve].return_date IS NULL) = 4)
			THROW 50000, 'User already has 4 books reserved.', 1;
		IF ((SELECT active FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User has been suspended and can no longer make book reservations.', 1;
		EXECUTE dbo.sp_CreateReservationID @libraryID;
		DECLARE @reserveID INT;
		SET @reserveID = IDENT_CURRENT('dbo.Reserve');
		INSERT INTO [ReserveBookUser](pk_reserveID, pk_ISBN, pk_userID) VALUES (@reserveID, @ISBN, @userID);
		UPDATE [BookLibrary] 
		SET quantity = ((SELECT quantity FROM [BookLibrary] WHERE pk_libraryID = @libraryID AND pk_ISBN = @ISBN) - 1) 
		WHERE pk_libraryID = @libraryID AND pk_ISBN = @ISBN;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error creating reservation.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Finishes reservation by setting the return_date and updating the quantity of available copies in the library.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_ReturnBook'
)
DROP PROCEDURE dbo.sp_ReturnBook
GO
CREATE PROCEDURE dbo.sp_ReturnBook
	@reserveID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [ReserveBookUser] WHERE pk_reserveID = @reserveID) = 0)
			THROW 50000, 'Invalid reserveID.', 1;
		IF ((SELECT return_date FROM [Reserve] WHERE pk_reserveID = @reserveID) IS NOT NULL)
			THROW 50000, 'The reservation has been previously closed.', 1;
		UPDATE [Reserve] SET return_date = CAST(GETDATE() AS date) WHERE pk_reserveID = @reserveID;
		DECLARE @libraryID INT;
		DECLARE @ISBN NVARCHAR(50);
		SET @libraryID = (SELECT fk_libraryID FROM [Reserve] WHERE pk_reserveID = @reserveID);
		SET @ISBN = (SELECT pk_ISBN FROM [ReserveBookUser] WHERE pk_reserveID = @reserveID);
		UPDATE [BookLibrary] 
		SET quantity = ((SELECT quantity FROM [BookLibrary] WHERE pk_libraryID = @libraryID AND pk_ISBN = @ISBN) + 1)
		WHERE pk_libraryID = @libraryID AND pk_ISBN = @ISBN;
		DECLARE @userID INT;
		SET @userID = (SELECT pk_userID FROM [ReserveBookUser] WHERE pk_reserveID = @reserveID);
		EXEC dbo.sp_CheckUserReservations @userID;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error finishing reservation.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Counts the number of unique books.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_UniqueBookQuantity'
)
DROP PROCEDURE dbo.sp_UniqueBookQuantity
GO

CREATE PROCEDURE dbo.sp_UniqueBookQuantity
AS
	BEGIN TRY
		SELECT COUNT(pk_ISBN) AS 'Total obras' FROM [Book];
	END TRY
	BEGIN CATCH
		THROW 50000, 'Error displaying unique books.', 1;
	END CATCH
GO

-- Info: Display number of books per genre.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_BooksByGenre'
)
DROP PROCEDURE dbo.sp_BooksByGenre
GO
CREATE PROCEDURE dbo.sp_BooksByGenre
AS
	BEGIN TRY
		SELECT genre AS 'Genero', COUNT(pk_ISBN) AS 'Livros'
		FROM Genre
		INNER JOIN BookGenre ON [Genre].pk_genreID = [BookGenre].pk_genreID
		GROUP BY genre
		HAVING COUNT(pk_ISBN) > 0;
	END TRY
	BEGIN CATCH
		THROW 50000, 'Error displaying books by genre.', 1;
	END CATCH
GO

-- Info: Display the 10 most reserved books between the given dates.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_PopularBooks'
)
DROP PROCEDURE dbo.sp_PopularBooks
GO
CREATE PROCEDURE dbo.sp_PopularBooks
	@startDate DATE, @endDate DATE
AS
	BEGIN TRY
		SELECT TOP 10 title AS 'Titulo', COUNT(title) AS 'Requisicoes' FROM [Book] 
		INNER JOIN [ReserveBookUser] ON [Book].pk_ISBN = [ReserveBookUser].pk_ISBN 
		INNER JOIN [Reserve] ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID 
		WHERE ([Reserve].reserve_date >= @startDate AND [Reserve].reserve_date <= @endDate)
		GROUP BY title
		ORDER BY COUNT(title) desc;
	END TRY
	BEGIN CATCH
		THROW 50000, 'Error displaying the 10 most popular books in the selected dates.', 1;
	END CATCH
GO

-- Info: Display the list of libraries, sorted by descending number of reservations made in a given time interval.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_PopularBooksInLibrary'
)
DROP PROCEDURE dbo.sp_PopularBooksInLibrary
GO
CREATE PROCEDURE dbo.sp_PopularBooksInLibrary
	@startDate DATE, @endDate DATE
AS
	BEGIN TRY
		SELECT library_location AS 'Biblioteca', COUNT(pk_reserveID) AS 'Livros Requisitados'
		FROM [Reserve]
		INNER JOIN [Library] ON [Reserve].fk_libraryID = [Library].pk_libraryID
		WHERE reserve_date >= @startDate AND reserve_date <= @endDate
		GROUP BY library_location
		ORDER BY COUNT(library_location) desc;
	END TRY
	BEGIN CATCH
		THROW
	END CATCH
GO

-- Info: Deletes user and saves their reservation history in the dead archive.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_DeleteUser'
)
DROP PROCEDURE dbo.sp_DeleteUser
GO
CREATE PROCEDURE dbo.sp_DeleteUser
	@userID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User is not registered.', 1;
		INSERT INTO [DeadArchive] ([user_name], library_location, ISBN, reserve_date, return_date) SELECT [name], library_location, pk_ISBN, reserve_date, return_date FROM [User] INNER JOIN [ReserveBookUser] ON [User].pk_userID = [ReserveBookUser].pk_userID INNER JOIN [Reserve] ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID INNER JOIN [Library] ON [Reserve].fk_libraryID = [Library].pk_libraryID WHERE [User].pk_userID = @userID;
		DELETE FROM [ReserveBookUser] WHERE pk_userID = @userID;
		DELETE FROM [Reserve] WHERE pk_reserveID NOT IN (SELECT DISTINCT pk_reserveID FROM [ReserveBookUser]);
		DELETE FROM [User] WHERE pk_userID = @userID;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error deleting user.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Assumes the user is returning every book they had reserved and not returned and deletes their profile.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_ReturnBooksAndDeleteUser'
)
DROP PROCEDURE dbo.sp_ReturnBooksAndDeleteUser
GO
CREATE PROCEDURE dbo.sp_ReturnBooksAndDeleteUser
	@userID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User is not registered.', 1;
		WHILE ((SELECT COUNT(*) FROM [ReserveBookUser] INNER JOIN [Reserve] ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID WHERE pk_userID = @userID AND return_date IS NULL) != 0)
		BEGIN
			DECLARE @reserveID INT;
			SET @reserveID = (SELECT TOP 1 [ReserveBookUser].pk_reserveID 
			FROM [ReserveBookUser] 
			INNER JOIN [Reserve] 
			ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID 
			WHERE pk_userID = @userID AND return_date IS NULL);
			EXEC dbo.sp_ReturnBook @reserveID;
		END
		EXEC dbo.sp_DeleteUser @userID;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Delete user after being inactive for 1 year.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_DeleteInactiveUser'
)
DROP PROCEDURE dbo.sp_DeleteInactiveUser
GO

CREATE PROCEDURE dbo.sp_DeleteInactiveUser
	@userID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User is not registered.', 1;
		IF ((SELECT COUNT(*) FROM [ReserveBookUser] 
		INNER JOIN [Reserve] 
		ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID 
		WHERE [ReserveBookUser].pk_userID = @userID AND [Reserve].return_date IS NULL) != 0)
			THROW 50000, 'User has an active reservation.', 1;
		IF ((SELECT COUNT(*) FROM [ReserveBookUser] 
		INNER JOIN [Reserve] 
		ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID 
		WHERE [ReserveBookUser].pk_userID = @userID AND DATEDIFF(DAY, return_date, CAST(GETDATE() AS date)) < 365) = 0)
			EXEC dbo.sp_DeleteUser @userID;
		ELSE
			PRINT 'This user is not inactive (has returned a book in the last year).';
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error deleting inactive user.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: In order to clear the user's past registry and set it as active, the user's profile is deleted and registered again.
-- This assumes that when the user requests the reactivation of his profile, he also returns any books he still had in his possession.
-- I decided to do it this way so it would clear the user's history so they wouldn't have any overdue returns in their new history.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_SetUserActive'
)
DROP PROCEDURE dbo.sp_SetUserActive
GO

CREATE PROCEDURE dbo.sp_SetUserActive
	@userID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User not registered.', 1;
		DECLARE @user_name NVARCHAR(50);
		SET @user_name = (SELECT [name] FROM [User] WHERE pk_userID = @userID);
		EXEC dbo.sp_ReturnBooksAndDeleteUser @userID;
		EXEC dbo.sp_RegisterUser @user_name;
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error setting user as active.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Checks the user's reservations to check if any of them were past the return limit of 15 days. If user has 3 or more late returns, they are suspended.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_SuspendUser'
)
DROP PROCEDURE dbo.sp_SuspendUser
GO

CREATE PROCEDURE dbo.sp_SuspendUser
	@userID INT
AS
	DECLARE @local_trancount INT = 0;
	IF (@@TRANCOUNT = 0)
	BEGIN
		BEGIN TRANSACTION;
		SET @local_trancount = 1;
	END
	BEGIN TRY
		IF ((SELECT COUNT(*) FROM [User] WHERE pk_userID = @userID) = 0)
			THROW 50000, 'User not registered.', 1;
		IF ((SELECT COUNT(*) FROM [ReserveBookUser] 
		INNER JOIN [Reserve] 
		ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID 
		WHERE pk_userID = @userID AND DATEDIFF(DAY, reserve_date, return_date) > 15 OR (DATEDIFF(DAY, reserve_date, CAST(GETDATE() AS date)) > 15 AND return_date IS NULL)) >= 3)
		BEGIN
			UPDATE [User] SET active = 0 WHERE pk_userID = @userID;
		END
		IF (@local_trancount = 1)
		BEGIN
			COMMIT TRANSACTION;
		END
	END TRY
	BEGIN CATCH
		PRINT 'Error suspending user.';
		IF (@local_trancount = 1)
		BEGIN
			ROLLBACK TRANSACTION;
		END
		;THROW
	END CATCH
GO

-- Info: Searches books by theme or library.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_SearchByThemeOrLibrary'
)
DROP PROCEDURE dbo.sp_SearchByThemeOrLibrary
GO
CREATE PROCEDURE dbo.sp_SearchByThemeOrLibrary
	@library NVARCHAR(50) = NULL, @genre NVARCHAR(50) = NULL
AS
	BEGIN TRY
		SELECT DISTINCT 
			title AS 'Titulo',
			author AS 'Autor',
			genre AS 'Genero',
			library_location AS 'Biblioteca'
		FROM [Book]
		INNER JOIN [BookLibrary] ON [Book].pk_ISBN = [BookLibrary].pk_ISBN
		INNER JOIN [Library] ON [BookLibrary].pk_libraryID = [Library].pk_libraryID
		INNER JOIN [BookGenre] ON [Book].pk_ISBN = [BookGenre].pk_ISBN
		INNER JOIN [Genre] ON [BookGenre].pk_genreID = [Genre].pk_genreID
		WHERE quantity > 0 AND (@library IS NULL OR library_location = @library) AND (@genre IS NULL OR genre = @genre);
	END TRY
	BEGIN CATCH
		THROW 50000, 'Error displaying books by genre/library.', 1;
	END CATCH
GO

-- Info: Displays the user's history.
IF EXISTS (
SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
	AND SPECIFIC_NAME = N'sp_CheckUserCurrentReservations'
)
DROP PROCEDURE dbo.sp_CheckUserCurrentReservations
GO
CREATE PROCEDURE dbo.sp_CheckUserCurrentReservations
	@userID INT
AS
	BEGIN TRY
		SELECT title AS 'Titulo', reserve_date AS 'Data de Reserva', library_location AS 'Biblioteca' FROM [Book] INNER JOIN [ReserveBookUser] ON [Book].pk_ISBN = [ReserveBookUser].pk_ISBN INNER JOIN [Reserve] ON [ReserveBookUser].pk_reserveID = [Reserve].pk_reserveID INNER JOIN [Library] on [Reserve].fk_libraryID = [Library].pk_libraryID INNER JOIN [User] ON [ReserveBookUser].pk_userID = [User].pk_userID WHERE [ReserveBookUser].pk_userID = @userID;
	END TRY
	BEGIN CATCH
		THROW 50000, 'Error displaying the user history.', 1;
	END CATCH
GO