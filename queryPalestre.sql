select @@VERSION

create TABLE ABBONAMENTI
(
    Id int identity primary key,
    data_inizio date not null,
    data_fine date not null,
    prezzo decimal(18,2) not null,
    CONSTRAINT data_fine  check (data_fine >= data_inizio),
    CONSTRAINT prezzo check (prezzo >= 0),
    client_id INT  not null
);
 alter table ABBONAMENTI
 ADD FOREIGN KEY (ID) REFERENCES CLIENTI(ID);
 
--ok
select* FROM
 ABBONAMENTI
--------------------------------------------------
 CREATE TABLE BADGES
 (
     Id INT PRIMARY KEY,
     Attivo bit not null,
     Abbonamento_id int not null foreign key references ABBONAMENTI(Id),
    
 )


 select * FROM  
 BADGES
 --OK
 ----------------------------------------

 CREATE TABLE CLIENTI
 (
     ID INT PRIMARY KEY,
     NOME VARCHAR (max) not null,
     COGNOME VARCHAR (max) not null,
     NASCITA date not null,
     PESO FLOAT,
     LIVELLO VARCHAR,
     consegnato_cert_Med bit not null,
     coach_id INT NOT NULL
     ,
 )
 alter table CLIENTI
ADD FOREIGN KEY (coach_id) REFERENCES COACHES(id);
 alter table CLIENTI
ADD FOREIGN KEY (coach_id) REFERENCES COACHES(id);

 SELECT* FROM 
 CLIENTI
------------------------------------------------------------
CREATE TABLE 
SCHEDE
(
     ID INT PRIMARY KEY,
     data_inizio date not NULL,
     data_fine date  NULL,
     frequenza int NOT null,
     cliente_id int not null,
     coach_id int not null

)

select *from
SCHEDE


;
-------------------------------------------
create TABLE
COACHES
(
    id int primary KEY,
    nome varchar not null,
    cognome varchar not null,
    data_assunzione date not null,
    data_FineRapp date  null,
)

select *from 
COACHES
----------------------------------------------------
create table 
SESSIONE
(
    id int primary key,
    posizione int not null,
    durata int not null,
    pausa int,
    esercizio_id int not null,
    scheda_id int not null,
    allenamento_id int,
    
)

---------------------------------------------
create table
ALLENAMENTI 
(
    id int primary key,
    Data date not null,
    cliente_id int not null

)
select* from
ALLENAMENTI
------------------------------------------------
create table
ESERCIZI 
(
    ID INT PRIMARY KEY,
    CODE char not null,
    nome varchar not null,
    descrizione varchar not null,
    tipo_quantita varchar not null,
    unita_misura varchar not null
)
select *from
ESERCIZI 
---------------------------------
CREATE TABLE
IMMAGINI_ESERCIZI
(
    id int primary key,
    esercizio_id int not null,
    immagine_id int not null,
    posizione int not null
)
select* from
IMMAGINI_ESERCIZI
-----------------------------
create table 
IMMAGINE
(
    ID int primary key,
    contenuto varbinary not null
)
select*from 
IMMAGINE