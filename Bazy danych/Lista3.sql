drop table if exists rok2004;
create table if not exists rok2004
(	
	miesiac int,
    wynik decimal(10,2)
);
drop table if exists rok2005;
create table if not exists rok2005
(	
	miesiac int,
    wynik decimal(10,2)
);
insert into rok2004 (miesiac, wynik)
values (1,1);
insert into rok2004 (miesiac, wynik)
values (2,0);
insert into rok2004 (miesiac, wynik)
values (3,1);
insert into rok2004 (miesiac, wynik)
values (4,0);
insert into rok2004 (miesiac, wynik)
values (5,1);
insert into rok2004 (miesiac, wynik)
values (6,0);
insert into rok2004 (miesiac, wynik)
values (7,1);
insert into rok2004 (miesiac, wynik)
values (8,0);
insert into rok2004 (miesiac, wynik)
values (9,1);
insert into rok2004 (miesiac, wynik)
values (10,0);
insert into rok2004 (miesiac, wynik)
values (11,1);
insert into rok2004 (miesiac, wynik)
values (12,0);
insert into rok2005 (miesiac, wynik)
values (1,0);
insert into rok2005 (miesiac, wynik)
values (2,1);
insert into rok2005 (miesiac, wynik)
values (3,0);
insert into rok2005 (miesiac, wynik)
values (4,1);
insert into rok2005 (miesiac, wynik)
values (5,0);
insert into rok2005 (miesiac, wynik)
values (6,1);
insert into rok2005 (miesiac, wynik)
values (7,0);
insert into rok2005 (miesiac, wynik)
values (8,1);
insert into rok2005 (miesiac, wynik)
values (9,0);
insert into rok2005 (miesiac, wynik)
values (10,1);
insert into rok2005 (miesiac, wynik)
values (11,0);
insert into rok2005 (miesiac, wynik)
values (12,1);
#zadanie1
USE `sklep2`;
DROP procedure IF EXISTS `GiveMeMax`;

DELIMITER $$
USE `sklep2`$$
CREATE PROCEDURE `GiveMeMax` ()
BEGIN
	declare r int;
    declare wynik decimal(10,2);
    declare i int;
    set i=1;
    create table if not exists MaxEachYear(miesiac int, rok int, wynik decimal(10,2));
    start transaction;
    while i<=12 do
		if(select rok2004.wynik from rok2004 where rok2004.miesiac = i)>(select rok2005.wynik from rok2005 where rok2005.miesiac = i) then
        begin
			set r = 2004;
            set wynik = (select rok2004.wynik from rok2004 where rok2004.miesiac = i);
		end;
        else
        begin
			set r =2005;
            set wynik = (select rok2005.wynik from rok2005 where rok2005.miesiac = i);
		end;
        end if;
        insert into MaxEachYear(miesiac,rok,wynik)
        values (i,r,wynik);
        set i=i+1;
	end while;
    commit;
    select * from MaxEachYear;
    drop table if exists MaxEachYear;
END
$$
DELIMITER ;
call GiveMeMax();
drop table if exists lista;
create table if not exists lista
(
	tabela varchar(40),
    kolumna varchar(30),
    maximum varchar(30)
);
insert into lista (tabela, kolumna)
values("rok2004","miesiac");
insert into lista (tabela, kolumna)
values("rok2004","wynik");
insert into lista (tabela, kolumna)
values("rok2005","miesiac");
insert into lista (tabela, kolumna)
values("rok2005","wynik");
#zadanie2

drop procedure if exists maximum;
delimiter $$
create procedure maximum ()
begin
DECLARE n INT DEFAULT 0;
DECLARE i INT DEFAULT 0;
SELECT COUNT(*) FROM lista INTO n;
SET i=0;
while i < n
do
 
set @tablename = ( (select tabela from lista limit i,1) );
set @columnname = ( (select kolumna from lista limit i,1) );
set @sqltext = concat('UPDATE lista SET maximum = (SELECT MAX(',@columnname,') FROM ', @tablename ,' ) WHERE tabela = "', @tablename ,'" AND kolumna = "', @columnname ,'" ');
 
PREPARE stmt from @sqltext;
execute stmt;
deallocate prepare stmt;
set i = i + 1;
end while;
select * from lista;
end;$$
delimiter ;
call maximum();

#zadanie3
drop procedure daty;
delimiter //
create procedure daty (in pierwsza date, in druga date, out dni int, out godziny int, out sekundy bigint)
begin
select (to_days(pierwsza) - to_days(druga)) into dni;
select (dni * 24) into godziny;
select (godziny * 3600) into sekundy;
end;//
delimiter ;
 
call daty ('2015-11-19','2010-10-10', @out_dni, @out_hours, @out_seconds);
select @out_dni , @out_hours , @out_seconds;

#zadanie4
drop table odległość;
CREATE TABLE IF NOT EXISTS odległość (
m1 varchar (30),
m2 varchar (30),
odl int
);
 
 
insert into odległość values ('Wrocław','Warszawa',400),('Warszawa','Gdańsk',350),('Poznań','Warszawa',250),('Kraków','Wrocław',270),('Kraków','Poznań',350),('Gdańsk','Kraków',500),('A','B',2),('B','C',4),('C','D',7);
select * from odległość;
 
create table if not exists odległość_tr (
m1 varchar (30),
m2 varchar (30),
odl int
);
#drop table odległość_tr;
delete from odległość_tr;
select * from odległość_tr;
select * from odległość;
drop procedure if exists proc;
delimiter $$
create procedure proc ()
begin
DECLARE bef INT DEFAULT 0;
DECLARE nex INT DEFAULT 0;
 
 
delete from odległość_tr;
insert into odległość_tr (select * from odległość group by m1, m2);
 
drop table if exists temp1;
create temporary table temp1
    select t1.m1, t2.m2, (t1.odl + t2.odl) as odl from odległość as t1 join odległość as t2 on t1.m2 = t2.m1 where t1.m1 <> t2.m2 group by m1, m2;
insert into odległość_tr (select * from temp1);
 
 
repeat
select count(*) from (select * from odległość_tr group by m1, m2) as t into bef;
 
drop table if exists temp2;
create temporary table temp2
    select t1.m1, t2.m2, (t1.odl + t2.odl) as odl from temp1  as t1 join odległość as t2 on t1.m2 = t2.m1 where t1.m1 <> t2.m2 group by m1, m2;
insert into odległość_tr (select * from temp2 group by m1, m2);
 
delete from temp1;
insert into temp1 (select * from temp2);
 
select count(*) from (select * from odległość_tr group by m1, m2) as t into nex;
 
 
until bef >= nex
end repeat;
 
drop table if exists temp;
create temporary table tempbattle_detailsbattle_detailsbattle
    select * from odległość_tr;
 
delete from odległość_tr;
insert into odległość_tr (select * from temp group by m1, m2);
select * from odległość_tr;
end;$$
delimiter ;
 
call proc();
 
/* Sprawdzenie czy wszystkie */
 
select count(*) from (select distinct m1 , m2 from
    (
        ( select t1.m1 , t2.m2 from odległość as t1 cross join odległość as t2 )
        union
        ( select t1.m2 , t2.m1 from odległość as t1 cross join odległość as t2 )
    ) as t
    where m1 <> m2
    order by m1 ) as t;