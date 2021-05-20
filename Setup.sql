--  CREATE TABLE accounts (
--    id VARCHAR(255) NOT NULL,
--    name VARCHAR(255) NOT NULL,
--    email VARCHAR(255) NOT NULL,
--    picture VARCHAR(255) NOT NULL,
--    PRIMARY KEY (id)
-- );

-- CREATE TABLE recipes (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES accounts (id)
--     ON DELETE CASCADE
-- ); 

-- CREATE TABLE ingredients (
--   id INT NOT NULL AUTO_INCREMENT,
--   recipesId INT NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   quantity VARCHAR (255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (recipesId)
--     REFERENCES recipes (id)
--     ON DELETE CASCADE
-- ); 