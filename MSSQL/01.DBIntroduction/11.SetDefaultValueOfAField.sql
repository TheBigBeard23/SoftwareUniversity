
ALTER TABLE [Users]
ADD CONSTRAINT [DF_LastLoginTime]
DEFAULT CURRENT_TIMESTAMP FOR [LastLoginTime]


INSERT INTO [Users]([Username],[Password],[IsDeleted])
VALUES
('Pesho', '12345', 'false')

SELECT * FROM [Users]