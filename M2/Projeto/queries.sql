USE biblio_XPTO
GO

-- 1
EXEC dbo.sp_UniqueBookQuantity;

-- 2
EXEC dbo.sp_BooksByGenre;

-- 3
EXEC dbo.sp_PopularBooks '2024-11-01', '2024-11-04';

-- 4
EXEC dbo.sp_PopularBooksInLibrary '2024-11-01', '2024-11-04';

-- 5
EXEC dbo.sp_AddBook '1', 'A Game of Thrones', 'George R. R. Martin', '1998-10-1', 'Himself', 1, 2, 3, 2;

-- 6
EXEC dbo.sp_UpdateQuantity 2, '1', 4;

-- 7
EXEC dbo.sp_MoveCopiesBetweenLibraries 1, 2, '1', 2;

-- 8
EXEC dbo.sp_RegisterUser 'Rafael Carvalho';

-- 9
EXEC dbo.sp_SuspendUser 1;

-- 10
EXEC dbo.sp_SetUserActive 1;

-- 11
EXEC dbo.sp_DeleteInactiveUser 2;

-- 1
EXEC dbo.sp_RegisterUser 'Rafael Carvalho';

-- 2
EXEC dbo.sp_ReturnBooksAndDeleteUser 2;

-- 3
EXEC dbo.sp_SearchByThemeOrLibrary 'Central Library', 'Fiction';

-- 4.1 inacabado
EXEC dbo.sp_CheckUserCurrentReservations 1;

-- 4.2 inacabado
EXEC dbo.sp_CheckUserCurrentReservations 1;

-- Outros SP:

-- Adicionar imagens: (adicionar path)
EXEC dbo.sp_AddImage ;

-- Devolver o livro: (ID da reserva)
EXEC dbo.sp_ReturnBook ;
