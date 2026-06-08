CREATE PROCEDURE GetLogUsersByID
	@UserID INT
AS 
BEGIN
	SELECT UserID, Email, UserName, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [LogUsers]
	WHERE UserID = @UserID;
END
