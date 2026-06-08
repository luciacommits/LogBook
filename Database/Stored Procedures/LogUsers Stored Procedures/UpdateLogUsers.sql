CREATE PROCEDURE UpdateLogUsers
	@UserID INT,
	@Email VARCHAR(100),
	@UserName VARCHAR(50)
AS
BEGIN
	UPDATE [LogUsers]
	SET 
		Email = @Email,
		UserName = @UserName
	WHERE
		UserID = @UserID;
END
