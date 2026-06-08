CREATE PROCEDURE InsertExercises
	@TopicID INT,
	@ExerciseDescription VARCHAR(150),
	@Result VARCHAR(500)
AS
BEGIN
	INSERT INTO [Exercises] (TopicID, ExerciseDescription, Result, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate)
	VALUES (@TopicID, @ExerciseDescription, @Result, ORIGINAL_LOGIN(), GETDATE(), ORIGINAL_LOGIN(), GETDATE());
 END
