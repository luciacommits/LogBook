CREATE TABLE LogSessions(
	SessionID INT IDENTITY(1,1) PRIMARY KEY,
	TopicID INT NOT NULL,
	SessionDate DATETIME DEFAULT GETDATE(),
	DurationMinutes INT,
	SessionDescription VARCHAR (500),
	CreateUser VARCHAR(50) CONSTRAINT DF_LogSession_CreateUser DEFAULT ORIGINAL_LOGIN(),
    CreateDate DATETIME CONSTRAINT DF_LogSession_CreateDate DEFAULT GETDATE(),
    LastUpdateUser VARCHAR(50) NULL,
    LastUpdateDate DATETIME NULL,
	CONSTRAINT FK_Session_Topic FOREIGN KEY (TopicID)
		REFERENCES Topic(TopicID)
);
