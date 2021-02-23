
-- CREATE TABLE bricks
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255),
--   color VARCHAR(255),

--   PRIMARY KEY (id);
-- );

-- CREATE TABLE kits
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255),
--   instructions VARCHAR(255),
--   price DECIMAL(6,2),

--   PRIMARY KEY (id);
-- );

-- TRUNCATE TABLE kits;
-- TRUNCATE TABLE bricks;


CREATE TABLE kitbricks
(
  id INT AUTO_INCREMENT,
  kitId INT,
  brickId INT,

  PRIMARY KEY (id),

  FOREIGN KEY (kitId)
    REFERENCES kits(id)
    ON DELETE CASCADE,

  FOREIGN KEY (brickId)
    REFERENCES bricks(id)
    ON DELETE CASCADE
);
