CREATE PROCEDURE GetQuestionsByID
	@QuestionID INT
AS 
BEGIN
	SELECT QuestionID, TopicID, QuestionStatement, QuestionDate, AnswerDate, Answer, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Questions]
	WHERE QuestionID = @QuestionID;
END
