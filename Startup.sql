CREATE TABLE libraries (
 id INT NOT NULL AUTO_INCREMENT,
 title VARCHAR(255) NOT NULL,
 PRIMARY KEY(id)
); 

CREATE TABLE books (
  id int NOT NULL AUTO_INCREMENT,
  title VARCHAR(255) NOT NULL,
  pagecount int NOT NULL,
  libraryId int NOT NULL,

  PRIMARY KEY(id),
  FOREIGN KEY (libraryId) 
    REFERENCES libraries(id)
    ON DELETE CASCADE
);

CREATE TABLE authors (
  id int  NOT NULL AUTO_INCREMENT,
  name VARCHAR(255) NOT NULL,
  PRIMARY KEY(id)
);

CREATE TABLE BookAuthors (
  bookId int NOT NULL,
  authorId int NOT NULL,
  PRIMARY KEY(bookId, authorId),
  FOREIGN KEY(bookId)
    REFERENCES books(id)
    ON DELETE CASCADE,

  FOREIGN KEY(authorId)
    REFERENCES authors(id)
    ON DELETE CASCADE
);