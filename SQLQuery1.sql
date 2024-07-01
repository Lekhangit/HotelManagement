create table rooms(
roomid int Identity(1,1) primary key,
roomNo varchar(250) not null unique,
roomType varchar(250) not null,
bed varchar(250) not null,
price bigint not null,
booked varchar(50) default 'NO'

) 
INSERT INTO rooms (roomNo, roomType, bed, price)
VALUES
    ('108', 'Ac', 'Single', 100),
    ('105', 'Non-Ac', 'Double', 150),
    ('106', 'Ac', 'Single', 120),
    ('107', 'Ac', 'Double', 180);

CREATE TABLE customer (
    cid int Identity(1,1) primary key,
    cname varchar(250) not null,
    mobile bigint not null,
    nationality varchar(50) not null,
	dob varchar(50) not null,
	idproof varchar(50) not null,
    gender varchar(250) not null,
    adress varchar(350) not null,
    checkin varchar(250) not null,
    checkout varchar(250) not null, 
    roomid int not null,
    foreign key (roomid) references rooms(roomid)
);



CREATE TABLE account (
    account VARCHAR(250) NOT NULL PRIMARY KEY,
    password VARCHAR(250) NOT NULL
);
INSERT INTO account (account, password) VALUES ('khang', '12345678');
