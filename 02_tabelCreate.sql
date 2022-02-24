USE SuperheroesDb

CREATE TABLE Superhero (
	[SuperheroId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(255),
	[Alias] nvarchar(255),
	[Origin] nvarchar(255)
	);
CREATE TABLE Assistant (
	[AssistantId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(255)
	);
CREATE TABLE Power (
	[PowerId] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] nvarchar(255),
	[Description] nvarchar(255)
	);
