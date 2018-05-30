SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema QuotingDojo
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `QuotingDojo` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `QuotingDojo` ;

-- -----------------------------------------------------
-- Table `QuotingDojo`.`quotes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `QuotingDojo`.`quotes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `quote` TEXT NULL,
  `name` VARCHAR(255) NULL,
  `created_at` DATETIME NULL,
  `updated_at` DATETIME NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
