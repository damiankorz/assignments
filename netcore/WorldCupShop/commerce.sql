SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema commerce
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `commerce` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `commerce` ;

-- -----------------------------------------------------
-- Table `commerce`.`customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`customers` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `CustomerName` VARCHAR(255) NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `commerce`.`products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`products` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `ProductName` VARCHAR(255) NULL,
  `ImageURL` VARCHAR(255) NULL,
  `ProductDescription` VARCHAR(255) NULL,
  `ProductQuantity` INT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `commerce`.`orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `commerce`.`orders` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `ProductID` INT NOT NULL,
  `CustomerID` INT NOT NULL,
  `OrderQuantity` INT NULL,
  `CreatedAt` DATETIME NULL,
  `UpdatedAt` DATETIME NULL,
  PRIMARY KEY (`ID`, `ProductID`, `CustomerID`),
  INDEX `fk_products_has_customers_customers1_idx` (`CustomerID` ASC),
  INDEX `fk_products_has_customers_products_idx` (`ProductID` ASC),
  CONSTRAINT `fk_products_has_customers_products`
    FOREIGN KEY (`ProductID`)
    REFERENCES `commerce`.`products` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_products_has_customers_customers1`
    FOREIGN KEY (`CustomerID`)
    REFERENCES `commerce`.`customers` (`ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
