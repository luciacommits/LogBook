CREATE PROCEDURE DeleteLogSessionsByID
	@SessionID INT
AS
BEGIN
	DELETE FROM [LogSessions]
		WHERE SessionID = @SessionID;
END
