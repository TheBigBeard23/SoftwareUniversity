USE Minions

ALTER TABLE [Minions]
ADD			[TownId]	INT 

ALTER TABLE	   [Minions]
ADD CONSTRAINT [FK_MinionsTownID] FOREIGN KEY (TownId) REFERENCES [Towns]([Id])