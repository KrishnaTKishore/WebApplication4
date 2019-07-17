CREATE TABLE usrprj (
  id int identity,
  user_id nvarchar(50) NOT NULL,
  prj_id varchar(50) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE,
  FOREIGN KEY (prj_id) REFERENCES project(prj_id) ON DELETE CASCADE
);