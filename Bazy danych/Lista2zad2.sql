CREATE TABLE IF NOT EXISTS `sklep2`.`sklep` (
  `nazwa` VARCHAR(32) NOT NULL COMMENT '',
  `adres` VARCHAR(64) NOT NULL COMMENT '',
  PRIMARY KEY (`nazwa`, `adres`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
CREATE TABLE IF NOT EXISTS `sklep2`.`towar` (
  `nazwa` VARCHAR(32) NOT NULL COMMENT '',
  `producent` VARCHAR(32) NOT NULL COMMENT '',
  PRIMARY KEY (`nazwa`, `producent`)  COMMENT '')
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;
CREATE TABLE IF NOT EXISTS `sklep2`.`sprzedaz` (
  `sklep_nazwa` VARCHAR(32) NOT NULL COMMENT '',
  `sklep_adres` VARCHAR(64) NOT NULL COMMENT '',
  `towar_nazwa` VARCHAR(32) NOT NULL COMMENT '',
  `towar_producent` VARCHAR(32) NOT NULL COMMENT '',
  `cena` FLOAT NULL COMMENT '',
  `data` DATE NULL COMMENT '',
  `ID` INT NOT NULL AUTO_INCREMENT COMMENT '',
  INDEX `fk_sklep_has_towar_towar1_idx` (`towar_nazwa` ASC, `towar_producent` ASC)  COMMENT '',
  INDEX `fk_sklep_has_towar_sklep_idx` (`sklep_nazwa` ASC, `sklep_adres` ASC)  COMMENT '',
  PRIMARY KEY (`ID`)  COMMENT '',
  CONSTRAINT `fk_sklep_has_towar_sklep`
    FOREIGN KEY (`sklep_nazwa` , `sklep_adres`)
    REFERENCES `sklep2`.`sklep` (`nazwa` , `adres`)
    on update cascade,
  CONSTRAINT `fk_sklep_has_towar_towar1`
    FOREIGN KEY (`towar_nazwa` , `towar_producent`)
    REFERENCES `sklep2`.`towar` (`nazwa` , `producent`)
    on update cascade)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8

DELIMITER //
CREATE PROCEDURE insert_not_allowed()
BEGIN
    SELECT 'Insert not allowed';
END//

delimiter ;
DELIMITER //
CREATE PROCEDURE wrong_adress()
BEGIN
    SELECT 'wrong adress';
END//

delimiter ;
DELIMITER //
CREATE PROCEDURE wrong_producent()
BEGIN
    SELECT 'wrong producent';
END//

delimiter ;
USE `sklep2`;

DELIMITER $$

DROP TRIGGER IF EXISTS sklep2.sprzedaz_BEFORE_INSERT$$
USE `sklep2`$$
CREATE DEFINER=`root`@`localhost` TRIGGER `sklep2`.`sprzedaz_BEFORE_INSERT` BEFORE INSERT ON `sprzedaz` FOR EACH ROW
BEGIN
	if (select count(*) from sprzedaz where sklep_nazwa=new.sklep_nazwa AND sklep_adres=new.sklep_adres AND towar_nazwa=new.towar_nazwa and towar_producent=new.towar_producent and cena = new.cena and data = new.data)=1 then
    begin
		SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Error: This row is in this table';
        set @new.sklep_nazwa = null;
        
	end;
    else
		if (new.sklep_nazwa in (select nazwa from sklep))and(new.towar_nazwa in (select nazwa from towar)) then
        begin
			if (new.sklep_adres not in (select adres from sklep where new.sklep_nazwa = nazwa)) then
            begin
				SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'Error: Wrong adres';
                set new.sklep_adres = null;
			end;
            end if;
            if(new.towar_producent not in (select producent from towar where new.towar_nazwa = nazwa)) then
            begin
				SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'Error: Wrong producent';
                set new.towar_producent = null;
			end;
            end if;
		end;
        else
			begin
				if((new.sklep_nazwa not in (select nazwa from sklep))and(new.sklep_adres not in (select adres from sklep where new.sklep_nazwa = nazwa))and(new.towar_nazwa not in (select nazwa from towar))and(new.towar_producent not in (select producent from towar where new.towar_nazwa = nazwa)))then
					begin
						insert into sklep (nazwa, adres)
                        values (new.sklep_nazwa, new.sklep_adres);
                        insert into towar (nazwa, producent)
                        values (new.towar_nazwa, new.towar_producent);
                    end;
                    elseif new.sklep_nazwa not in (select nazwa from sklep) then
					begin
						SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'Error: Wrong shop name';
                        set new.sklep_nazwa = null;
                    end;
                elseif new.towar_nazwa not in (select nazwa from towar) then
					begin
						SIGNAL SQLSTATE '02000' SET MESSAGE_TEXT = 'Error: Wrong item name';
                        set new.towar_nazwa = null;
                    end;
				end if;
            end;
		end if;
	end if;
END$$
DELIMITER ;

USE `sklep2`;

DELIMITER $$

DROP TRIGGER IF EXISTS sklep2.sprzedaz_BEFORE_UPDATE$$
USE `sklep2`$$
CREATE DEFINER = CURRENT_USER TRIGGER `sklep2`.`sprzedaz_BEFORE_UPDATE` BEFORE UPDATE ON `sprzedaz` FOR EACH ROW
BEGIN
	if(new.sklep_nazwa != old.sklep_nazwa) then
		update sklep set nazwa=new.sklep_nazwa where adres = new.sklep_adres;
	end if;
    if(new.sklep_adres != old.sklep_adres) then
		update sklep set adres=new.sklep_adres where nazwa = new.sklep_nazwa;
	end if;
    if(new.towar_nazwa != old.towar_nazwa) then
		update towar set nazwa=new.towar_nazwa where producent = new.towar_producent;
	end if;
    if(new.towar_producent != old.towar_producent) then
		update towar set producent=new.towar_producent where nazwa = new.towar_nazwa;
	end if;
END
$$
DELIMITER ;

USE `sklep2`;

DELIMITER $$

DROP TRIGGER IF EXISTS sklep2.sprzedaz_AFTER_DELETE$$
USE `sklep2`$$
CREATE DEFINER = CURRENT_USER TRIGGER `sklep2`.`sprzedaz_AFTER_DELETE` AFTER DELETE ON `sprzedaz` FOR EACH ROW
BEGIN
	if old.sklep_nazwa not in (select sklep_nazwa from sprzedaz) then
		delete from sklep where nazwa = old.sklep_nazwa;
	end if;
    if old.towar_nazwa not in (select towar_nazwa from sprzedaz) then
		delete from towar where nazwa = old.towar_nazwa;
	end if;
END
$$
DELIMITER ;
#test
insert into sklep (nazwa, adres)
values ('asdfg','asdfgh');
insert into sklep (nazwa, adres)
values ('qwert','qwerty');
insert into sklep (nazwa, adres)
values ('cvbnm','cvbnmm');
insert into sprzedaz (sklep_nazwa,sklep_adres,towar_nazwa,towar_producent,cena,data)
values ('cvbnnm','cvbnnmm','cvbnnm','cvbnnmm',2.5,'2012-08-08');
SET SQL_SAFE_UPDATES = 0;
update sprzedaz set sklep_nazwa ='cabnnnnnm' where sklep_adres like 'cvbnnmm';
delete from sprzedaz where sklep_nazwa ='cabnnnnnm';
select * from sklep;