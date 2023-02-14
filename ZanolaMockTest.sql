select @@version

CREATE TABLE Ports
 (
  Id INT PRIMARY KEY,
  Name VARCHAR(50),
  City VARCHAR(50),
  Country VARCHAR(50)
);
select*FROM
ports
;
INSERT INTO Ports (Id, Name, City, Country)
VALUES
  (1, ' Genova', 'Genova', 'Italia'),
  (2, ' Rotterdam', 'Rotterdam', 'Paesi Bassi'),
  (3, ' Shanghai', 'Shanghai', 'Cina'),
  (4, ' Dubai', 'Dubai', 'Emirati Arabi Uniti'),
  (5, ' Singapore', 'Singapore', 'Singapore');


CREATE TABLE Shipments 
(
  Id INT PRIMARY KEY,
  StartPortId INT,
  EndPortId INT,
  StartDate DATE,
  EndDate DATE,
  Kg FLOAT,
  Kind VARCHAR(50) CHECK (Kind IN ('Alimentari', 'Alimentari da congelare', 'Materiali Edili', 'Materiali chimici pericolosi')),
  State VARCHAR(50) CHECK (State IN ('Da spedire', 'Spedita', 'Arrivata', 'Persa')),
  FOREIGN KEY (StartPortId) REFERENCES Ports(Id),
  FOREIGN KEY (EndPortId) REFERENCES Ports(Id)
);
select*FROM
Shipments;
INSERT INTO Shipments (Id, StartPortId, EndPortId, StartDate, EndDate, Kg, Kind, State)
VALUES
  (1, 1, 2, '2022-01-01', '2022-01-07', 1000, 'Alimentari', 'Arrivata'),
  (2, 2, 3, '2022-02-01', '2022-02-07', 2000, 'Materiali Edili', 'Spedita'),
  (3, 3, 4, '2022-03-01', '2022-03-07', 1500, 'Alimentari da congelare', 'Persa'),
  (4, 4, 5, '2022-04-01', '2022-04-07', 500, 'Materiali chimici pericolosi', 'Arrivata'),
  (5, 5, 1, '2022-05-01', '2022-05-07', 100, 'Alimentari', 'Da spedire');

  INSERT INTO Shipments (Id, StartPortId, EndPortId, StartDate, EndDate, Kg, Kind, State)
VALUES
  
  (6, 1, 3, '2019-01-17', '2023-01-07', 300, 'Materiali Edili', 'Da spedire'),
  (7, 2, 5, '2023-02-01', '2023-02-07', 200, 'Alimentari da congelare', 'Da spedire'),
  (8, 3, 1, '2023-03-01', '2023-03-07', 400, 'Materiali chimici pericolosi', 'Da spedire'),
  (9, 4, 2, '2023-04-01', '2023-04-07', 150, 'Alimentari', 'Da spedire'),
  (10, 5, 3, '2023-05-01', '2023-05-07', 50, 'Materiali Edili', 'Da spedire');


/*
Id, porto di partenza e porto di arrivo delle spedizioni in stato "Persa", oppure in stato
"Spedita" e la cui EndDate sia passata rispetto alla data odierna.
*/

SELECT 
  Shipments.Id, 
  Ports1.Name AS StartPort, 
  Ports2.Name AS EndPort
FROM 
  Shipments
  JOIN Ports Ports1 ON Ports1.Id = Shipments.StartPortId
  JOIN Ports Ports2 ON Ports2.Id = Shipments.EndPortId
WHERE 
  (Shipments.State = 'Persa') OR 
  (Shipments.State = 'Spedita' AND Shipments.EndDate < getdate());


select getdate()

/*
Nome del porto di partenza, nome del porto di arrivo, numero di giorni del viaggio, ma solo
per le spedizioni da o verso l'Italia.
*/

SELECT 
  Ports1.Name AS StartPort, 
  Ports2.Name AS EndPort, 
  DATEDIFF(day,Shipments.StartDate, Shipments.EndDate) AS DaysOnJourney
FROM 
  Shipments
  JOIN Ports Ports1 ON Ports1.Id = Shipments.StartPortId
  JOIN Ports Ports2 ON Ports2.Id = Shipments.EndPortId
WHERE 
  (Ports1.Country = 'Italia') OR 
  (Ports2.Country = 'Italia');

/*
Nome città, massimo peso tra tutte le spedizioni in arrivo, ma solo tra quelle di tipo
"Alimentari" o "Alimentari da congelare".
*/

SELECT 
  Ports.City AS City, 
  MAX(Shipments.Kg) AS MaxWeight
FROM 
  Shipments
  JOIN Ports ON Ports.Id = Shipments.EndPortId
WHERE 
  (Shipments.Kind = 'Alimentari') OR 
  (Shipments.Kind = 'Alimentari da congelare')
GROUP BY 
  Ports.City;
/*
Nome del paese e peso totale delle spedizioni (Kg) da quel paese, solo per il 2019
*/


SELECT 
  Ports.Country AS Country, 
  SUM(Shipments.Kg) AS TotalWeight
FROM 
  Shipments
  JOIN Ports ON Ports.Id = Shipments.StartPortId
WHERE 
  YEAR(Shipments.StartDate) = 2019
GROUP BY 
  Ports.Country;

