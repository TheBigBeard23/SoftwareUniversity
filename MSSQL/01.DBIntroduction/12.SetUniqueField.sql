
ALTER TABLE [Users]
DROP CONSTRAINT [PK_UsersCompositeIdUsername]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_UsersId] PRIMARY KEY (Id)

ALTER TABLE [Users] 
ADD CONSTRAINT [CHK_UsernameLength]
CHECK (LEN([Username]) >= 5)

ALTER TABLE [Users]
DROP CONSTRAINT [CHK_UsernameLength]

ALTER TABLE [Users]
DROP CONSTRAINT [UQ__Users__536C85E4CB31783C]

ALTER TABLE [Users] 
ADD CONSTRAINT [CHK_UsernameLength]
CHECK (LEN([Username]) >= 3)

DELETE FROM [Users] WHERE [Username] = 'Joe';

ALTER TABLE [Users]
ADD CONSTRAINT [UQ_Username]
UNIQUE (Username)

INSERT INTO [Users]([Username],[Password],[IsDeleted])
VALUES
('Joe', '123456', 'false')

INSERT INTO [Users]([Username],[Password],[IsDeleted])
VALUES
('Ivo', '12345', 'false')

SELECT * FROM [Users]