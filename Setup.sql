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
--   views int DEFAULT 0,
--   shares int DEFAULT 0,
--   keeps int DEFAULT 1,
--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE
-- );

CREATE TABLE vaults 
(
  id INT AUTO_INCREMENT,
  creatorId VARCHAR(255),
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255),
  isPrivate TINYINT,
  PRIMARY KEY (id),

  FOREIGN KEY (creatorId)
    REFERENCES profiles (id)
    ON DELETE CASCADE
)
