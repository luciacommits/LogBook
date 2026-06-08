CREATE PROCEDURE GetTopicsByID
	@TopicID INT
AS 
BEGIN
	SELECT TopicID, Theme, Content, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Topics]
	WHERE TopicID = @TopicID;
END
