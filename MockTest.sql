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

INSERT INTO Ports (Id, Name, City, Country)
VALUES
  (1, ' Genova', 'Genova', 'Italia'),
  (2, ' Rotterdam', 'Rotterdam', 'Paesi Bassi'),
  (3, ' Shanghai', 'Shanghai', 'Cina'),
  (4, ' Dubai', 'Dubai', 'Emirati Arabi Uniti'),
  (5, ' Singapore', 'Singapore', 'Singapore');


