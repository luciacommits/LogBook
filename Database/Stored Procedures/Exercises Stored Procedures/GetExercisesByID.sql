CREATE PROCEDURE GetExercisesByID
	@ExerciseID INT
AS 
BEGIN
	SELECT ExerciseID, TopicID, ExerciseDescription, Result, CreateUser, CreateDate, LastUpdateUser, LastUpdateDate
	FROM [Exercises]
	WHERE ExerciseID = @ExerciseID;
END
