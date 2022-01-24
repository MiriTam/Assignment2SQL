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
 ('Wonder Girl', (
  SELECT Id FROM Superhero
  WHERE Alias = 'Wonder Woman'
 ));

INSERT INTO Assistant 
  (Name, SuperheroId)
  VALUES
  ('Amazing Girl', (
   SELECT Id FROM Superhero
   WHERE Alias = 'Wonder Woman'
  ));