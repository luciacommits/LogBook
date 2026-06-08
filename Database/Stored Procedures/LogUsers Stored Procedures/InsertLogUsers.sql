CREATE PROCEDURE InsertLogUsers
	@Email VARCHAR(100),
	@Username VARCHAR(50)
AS
BEGIN
	INSERT INTO [LogUsers] (Email, UserName, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate)
	VALUES (@Email, @UserName, ORIGINAL_LOGIN(), GETDATE(), ORIGINAL_LOGIN(), GETDATE());
 END
