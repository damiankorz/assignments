SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema friends_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `friends_db` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `friends_db` ;

-- -----------------------------------------------------
-- Table `friends_db`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `friends_db`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(255) NOT NULL,
  `last_name` VARCHAR(255) NOT NULL,
  `created_at` DATETIME NOT NULL,
  `updated_at` DATETIME NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `friends_db`.`friends`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `friends_db`.`friends` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `friend_id` INT NOT NULL,
  `created_at` DATETIME NOT NULL,
  `updated_at` DATETIME NOT NULL,
  INDEX `fk_users_has_users_users1_idx` (`friend_id` ASC),
  INDEX `fk_users_has_users_users_idx` (`user_id` ASC),
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_users_has_users_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `friends_db`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_users_has_users_users1`
    FOREIGN KEY (`friend_id`)
    REFERENCES `friends_db`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
