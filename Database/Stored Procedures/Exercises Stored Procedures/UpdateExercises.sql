CREATE PROCEDURE UpdateExercises
	@ExerciseID INT,
	@TopicID INT,
	@ExerciseDescription VARCHAR(150),
	@Result VARCHAR(500)
AS
BEGIN
	UPDATE [Exercises]
	SET 
		TopicID = @TopicID,
		ExerciseDescription = @ExerciseDescription,
    Result = @Result
	WHERE
		ExerciseID = @ExerciseID;
END
