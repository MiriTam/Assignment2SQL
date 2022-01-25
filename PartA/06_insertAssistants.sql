INSERT INTO Assistant 
 (Name, SuperheroId)
 VALUES
 ('Robin', (
  SELECT Id FROM Superhero
  WHERE Alias = 'Batman'
 ));

INSERT INTO Assistant
 (Name, SuperheroId)
 VALUES
 ('Miriam', (
  SELECT Id FROM Superhero
  WHERE Alias = 'Wonder Woman'
 ));

INSERT INTO Assistant 
  (Name, SuperheroId)
  VALUES
  ('Anne', (
   SELECT Id FROM Superhero
   WHERE Alias = 'Wonder Woman'
  ));