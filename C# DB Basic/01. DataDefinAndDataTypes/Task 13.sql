CREATE TABLE Directors (
	Id INT IDENTITY NOT NULL,
	DirectorName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Directors PRIMARY KEY (Id)
)

CREATE TABLE Genres (
	Id INT IDENTITY NOT NULL,
	GenreName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Genre PRIMARY KEY (Id)
)

CREATE TABLE Categories (
	Id INT IDENTITY NOT NULL,
	CategoryName NVARCHAR(100),
	Notes NVARCHAR(MAX) 
	CONSTRAINT PK_Categories PRIMARY KEY (Id)
)

CREATE TABLE Movies (
	Id INT IDENTITY NOT NULL,
	Title NVARCHAR(50),
	DirectorId INT NOT NULL,
	CopyrightYear DATE,
	Length DECIMAL(15, 2),
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT,
	Notes NVARCHAR(MAX)
	CONSTRAINT PK_Movies PRIMARY KEY (Id)
	CONSTRAINT FK_DirectorId FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
	CONSTRAINT FK_GenreId FOREIGN KEY (GenreId) REFERENCES Genres(Id),
	CONSTRAINT FK_CategoryId FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Directors VALUES
('Ivankata', NULL),
('Stamat', NULL),
('Penka', NULL),
('Ivan', NULL),
('Pesho', NULL)

INSERT INTO Genres VALUES
('Drama', NULL),
('Comic', NULL),
('Crime', NULL),
('Erotic', NULL),
('Fantasy', NULL)

INSERT INTO Categories VALUES
('Ede', NULL),
('da', NULL),
('of', NULL),
('Sex', NULL),
('nosex', NULL)

INSERT INTO Movies (Title, DirectorId, GenreId, CategoryId ) VALUES
('Hulk', 1, 2, 3),
('The Flash', 2, 3, 4),
('Batman', 3, 4, 5),
('Superman', 4, 5, 1),
('Na maikati', 5, 1, 2)