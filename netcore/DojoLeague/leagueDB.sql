SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema leagueDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `leagueDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `leagueDB` ;

-- -----------------------------------------------------
-- Table `leagueDB`.`dojos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `leagueDB`.`dojos` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `DojoName` VARCHAR(45) NULL,
  `DojoLocation` VARCHAR(45) NULL,
  `DojoDescription` TEXT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `leagueDB`.`ninjas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `leagueDB`.`ninjas` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `DojoID` INT NULL,
  `NinjaName` VARCHAR(45) NULL,
  `NinjaLevel` INT NULL,
  `NinjaDescription` TEXT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` VARCHAR(45) NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_ninjas_dojos1_idx` (`DojoID` ASC),
  CONSTRAINT `fk_ninjas_dojos1`
    FOREIGN KEY (`DojoID`)
    REFERENCES `leagueDB`.`dojos` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `leagueDB`.`dojos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `leagueDB`.`dojos` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `DojoName` VARCHAR(45) NULL,
  `DojoLocation` VARCHAR(45) NULL,
  `DojoDescription` TEXT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `leagueDB`.`ninjas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `leagueDB`.`ninjas` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `DojoID` INT NOT NULL,
  `NinjaName` VARCHAR(45) NULL,
  `NinjaLevel` INT NULL,
  `NinjaDescription` TEXT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` VARCHAR(45) NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_ninjas_dojos1_idx` (`DojoID` ASC),
  CONSTRAINT `fk_ninjas_dojos1`
    FOREIGN KEY (`DojoID`)
    REFERENCES `leagueDB`.`dojos` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
