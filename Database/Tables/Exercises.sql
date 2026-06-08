CREATE TABLE Exercises(
	ExerciseID INT IDENTITY(1,1) PRIMARY KEY,
	TopicID INT NOT NULL,
	ExerciseDescription VARCHAR(150),
	Result VARCHAR(500),
	CreateUser VARCHAR(50) CONSTRAINT DF_Exercise_CreateUser DEFAULT ORIGINAL_LOGIN(),
    CreateDate DATETIME CONSTRAINT DF_Exercise_CreateDate DEFAULT GETDATE(),
    LastUpdateUser VARCHAR(50) NULL,
    LastUpdateDate DATETIME NULL,
	CONSTRAINT FK_Exercise_Topic FOREIGN KEY (TopicID)
		REFERENCES Topic(TopicID)
);
