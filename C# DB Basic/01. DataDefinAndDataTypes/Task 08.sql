-- TASK 8 Create Table Users

CREATE TABLE Users (
	Id BIGINT IDENTITY NOT NULL,
	UserName VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK (ProfilePicture > 900 * 1024),
	LastLoginTime DATETIME NOT NULL,
	IsDeleted BIT
	CONSTRAINT PK_Users PRIMARY KEY (Id)
)

INSERT INTO Users VALUES
('Pesho', '123456', NULL, GETDATE(), 0),
('Ivan', '123456', NULL, GETDATE(), 0),
('Dragan', '123456', NULL, GETDATE(), 0),
('Minka', '123456', NULL, GETDATE(), 0),
('Ginka', '123456', NULL, GETDATE(), 0)

SELECT * FROM Users