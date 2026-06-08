CREATE PROCEDURE DeleteQuestionsByID
	@QuestionID INT
AS
BEGIN
	DELETE FROM [Questions]
		WHERE QuestionID = @QuestionID;
END
