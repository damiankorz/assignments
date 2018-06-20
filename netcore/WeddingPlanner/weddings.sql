SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema weddings
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `weddings` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `weddings` ;

-- -----------------------------------------------------
-- Table `weddings`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `weddings`.`users` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NULL,
  `LastName` VARCHAR(45) NULL,
  `Email` VARCHAR(255) NULL,
  `Password` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `weddings`.`weddings`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `weddings`.`weddings` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `UserID` INT NOT NULL,
  `Groom` VARCHAR(255) NULL,
  `Bride` VARCHAR(255) NULL,
  `Date` DATETIME NULL,
  `Address` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_weddings_users1_idx` (`UserID` ASC),
  CONSTRAINT `fk_weddings_users1`
    FOREIGN KEY (`UserID`)
    REFERENCES `weddings`.`users` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `weddings`.`rsvps`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `weddings`.`rsvps` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `WeddingID` INT NOT NULL,
  `UserID` INT NOT NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_weddings_has_users_users1_idx` (`UserID` ASC),
  INDEX `fk_weddings_has_users_weddings1_idx` (`WeddingID` ASC),
  CONSTRAINT `fk_weddings_has_users_weddings1`
    FOREIGN KEY (`WeddingID`)
    REFERENCES `weddings`.`weddings` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_weddings_has_users_users1`
    FOREIGN KEY (`UserID`)
    REFERENCES `weddings`.`users` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
