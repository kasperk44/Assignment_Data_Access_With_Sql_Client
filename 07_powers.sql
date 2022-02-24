USE SuperheroesDb

INSERT INTO Power
(Name, Description)
VALUES('Web shooter', 'Shoots webs');

INSERT INTO Power
(Name, Description)
VALUES('Fly', 'He can fly');

INSERT INTO Power
(Name, Description)
VALUES('Laser eyes', 'He can shoot lasers from his eyes');

INSERT INTO Power
(Name, Description)
VALUES('Sticky', 'He can stick to walls');

INSERT INTO SuperheroPower
(SuperheroId, PowerId)
VALUES(1, 1);

INSERT INTO SuperheroPower
(SuperheroId, PowerId)
VALUES(1, 4);

INSERT INTO SuperheroPower
(SuperheroId, PowerId)
VALUES(2, 2);

INSERT INTO SuperheroPower
(SuperheroId, PowerId)
VALUES(3, 3);

INSERT INTO SuperheroPower
(SuperheroId, PowerId)
VALUES(3, 2);