CREATE PROCEDURE DeleteExercisesByID
	@ExerciseID INT
AS
BEGIN
	DELETE FROM [Exercises]
		WHERE ExerciseID = @ExerciseID;
END
