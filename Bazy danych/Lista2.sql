#drop table produkt;
#drop table klient;
use sklep;
#drop table sprzedaz;
create table if not exists Produkt
(
ProduktNumer varchar(4),
ProduktNazwa varchar(32) not null,
Cena float not null,
Dostepnosc bit not null,
primary key (ProduktNumer) 
);
create table if not exists Klient
(
KlientId  int auto_increment,
Nazwa varchar(32) not null,
Miasto varchar(32),
Typ enum('Indywidualny' , 'Firma') not null
,primary key (KlientId)
);
create table if not exists Sprzedaz
(
Id int auto_increment,
KlientId int,
ProduktNumer varchar(4),
Ilosc int not null check(Ilosc >0),
Cena float not null,
Data_sprzedazy timestamp default current_timestamp,
primary key (Id),
foreign key (KlientId) references klient(KlientId),
foreign key (ProduktNumer) references produkt(ProduktNumer)
);

insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A308','Pierniki', 4.50, b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A309','Wafle czekoladowe', 3.50 ,b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A310','Wafle waniliowe', 3.50 , b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A311', 'Baton MarcoPolo', 1.75 , b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A312', 'Baton droga mleczna', 0.99,b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A313', 'Kokosanki', 2.50, b'1' );
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A314' , 'Korsarze', 1.40, b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A315', 'Lizak', 0.75 , b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A316', 'Czekolada', 2.25, b'1');
insert into produkt (ProduktNumer, ProduktNazwa, Cena, Dostepnosc)
values ('A317', 'Gumisie', 3.99 , b'1');

insert into klient (Nazwa, Miasto, Typ)
values ('Kowalski', 'Olsztyn', 'Indywidualny');
insert into klient (Nazwa, Miasto, Typ)
values ('Nowak24', 'Olsztyn', 'Firma');
insert into klient (Nazwa, Miasto, Typ)
values ('Play', 'Warszawa', 'Firma');
insert into klient (Nazwa, Typ)
values ('Brzęczyszczykiewicz', 'Indywidualny');
insert into klient (Nazwa, Miasto, Typ)
values ('Sobolewski', 'Gdańsk', 'Indywidualny');
insert into klient (Nazwa, Miasto, Typ)
values ('Brzozowski', 'Wrocław', 'Firma');
insert into klient (Nazwa, Miasto, Typ)
values ('Sempopol', 'Poznań', 'Firma');
insert into klient (Nazwa, Miasto, Typ)
values ('Staniszewski', 'Barczewo', 'Indywidualny');
insert into klient (Nazwa, Miasto, Typ)
values ('Pekum', 'Sopot', 'Firma');
insert into klient (Nazwa, Miasto, Typ)
values ('Pieńkoski', 'Ostrołęka', 'Indywidualny');
drop procedure tranzakcje;
DELIMITER $$
create procedure tranzakcje()
begin
	declare ID int;
    declare PRONUMER varchar(4);
    declare ILE int;
    declare PRICE int;
    declare PRICEALL int;
    declare i int;
    set i=1;
    start transaction;
    while i<=1000 do
		set ID = (select KlientId from klient order by Rand() Limit 1);
        set PRONUMER = (select ProduktNumer from produkt order by Rand() Limit 1);
        set ILE = tu trzeba randoma wpisać np od 1-100
        set PRICE = (select Cena from produkt where ProduktNumer = PRONUMER);
        set PRICEALL = ILE * PRICE;
        insert into sprzedaz(KlientId,ProduktNumer,Ilosc,Cena)
        values (ID,PRONUMER,ILE,PRICEALL);
        set i=i+1;
	end while;
    commit;
end$$
delimiter ;
#drop procedure tranzakcje;
call tranzakcje();
select * from sprzedaz;
#drop table sprzedaz;
#select * from klient;