-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   email VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );


-- CREATE TABLE keeps
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255),
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) DEFAULT "",
--   img VARCHAR(255) NOT NULL,
--   views INT,
--   shares INT,
--   keeps INT,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

-- CREATE TABLE vaults 
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255),
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255),
--   isPrivate TINYINT,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

-- TRUNCATE TABLE vaults;

-- CREATE TABLE vaultkeeps
-- (
--   id INT AUTO_INCREMENT,
--   creatorId VARCHAR(255),
--   vaultId INT,
--   keepId INT,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorID)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (vaultId)
--     REFERENCES vaults (id)
--     ON DELETE CASCADE,

--   FOREIGN KEY (keepId)
--     REFERENCES keeps (id)
--     ON DELETE CASCADE
-- );

-- TRUNCATE TABLE vaultkeeps;

-- DROP TABLE vaultkeeps;
-- DROP TABLE keeps;
-- DROP TABLE vaults;
