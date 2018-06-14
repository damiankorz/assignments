SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema bankDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bankDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `bankDB` ;

-- -----------------------------------------------------
-- Table `bankDB`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankDB`.`users` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(45) NULL,
  `LastName` VARCHAR(45) NULL,
  `Email` VARCHAR(255) NULL,
  `Password` VARCHAR(255) NULL,
  `Balance` DOUBLE NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bankDB`.`transactions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankDB`.`transactions` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `UserID` INT NOT NULL,
  `Amount` DOUBLE NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`),
  INDEX `fk_transactions_users_idx` (`UserID` ASC),
  CONSTRAINT `fk_transactions_users`
    FOREIGN KEY (`UserID`)
    REFERENCES `bankDB`.`users` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
