CREATE PROCEDURE GetLogSessionsByID
	@SessionID INT
AS 
BEGIN
	SELECT SessionID, TopicID, SessionDate, DurationMinutes, SessionDescription, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [LogSessions]
	WHERE SessionID = @SessionID;
END
