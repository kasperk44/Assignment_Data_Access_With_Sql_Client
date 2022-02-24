USE SuperheroesDb

ALTER TABLE Assistant
ADD SuperheroId int FOREIGN KEY REFERENCES Superhero(SuperheroId);


/*
ALTER TABLE Assistant
ADD SuperheroId int;

ALTER TABLE Assistant
ADD CONSTRAINT FK_SuperheroId
FOREIGN KEY (SuperheroId) REFERENCES Superhero(SuperheroId); */