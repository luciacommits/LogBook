CREATE PROCEDURE UpdateTopics
	@TopicID INT,
	@Theme VARCHAR(100),
	@Content VARCHAR(500)
AS
BEGIN
	UPDATE [Topics]
	SET 
		Theme = @Theme,
		Content = @Content
	WHERE
		TopicID = @TopicID;
END
