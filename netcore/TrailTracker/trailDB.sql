SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema trailDB
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `trailDB` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `trailDB` ;

-- -----------------------------------------------------
-- Table `trailDB`.`trails`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trailDB`.`trails` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `description` TEXT NULL,
  `length` DOUBLE NULL,
  `elevation` INT NULL,
  `longitude` DOUBLE NULL,
  `latitude` DOUBLE NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trailDB`.`trails`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trailDB`.`trails` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `description` TEXT NULL,
  `length` DOUBLE NULL,
  `elevation` INT NULL,
  `longitude` DOUBLE NULL,
  `latitude` DOUBLE NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `trailDB`.`trails`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trailDB`.`trails` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NULL,
  `description` TEXT NULL,
  `length` DOUBLE NULL,
  `elevation` INT NULL,
  `longitude` DOUBLE NULL,
  `latitude` DOUBLE NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
