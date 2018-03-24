INSERT INTO users (first_name, last_name, created_at, updated_at) VALUES('Peter', 'Griffin', NOW(), NOW());
INSERT INTO users (first_name, last_name, created_at, updated_at) VALUES('Brian', 'Griffin', NOW(), NOW());
INSERT INTO users (first_name, last_name, created_at, updated_at) VALUES('Glenn', 'Quagmire', NOW(), NOW());
INSERT INTO users (first_name, last_name, created_at, updated_at) VALUES('Joe', 'Swanson', NOW(), NOW());
INSERT INTO users (first_name, last_name, created_at, updated_at) VALUES('Cleveland', 'Brown', NOW(), NOW());

INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(1, 1, 2, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(2, 1, 3, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(3, 1, 4, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(4, 1, 5, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(5, 2, 1, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(6, 3, 1, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(7, 4, 1, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(8, 5, 1, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(9, 5, 2, NOW(), NOW());
INSERT INTO friends(id, user_id, friend_id, created_at, updated_at) VALUES(10, 5, 3, NOW(), NOW());

SELECT * FROM users;
SELECT * FROM friends;

SELECT CONCAT_WS(' ', users.first_name, users.last_name) AS full_name, CONCAT_WS(' ', users2.first_name, users2.last_name) AS friend_full_name 
FROM users 
LEFT JOIN friends ON users.id = friends.user_id 
LEFT JOIN users AS users2 ON friends.friend_id = users2.id
ORDER BY full_name ASC;





