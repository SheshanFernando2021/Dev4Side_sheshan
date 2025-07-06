IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [UserEntity] (
    [UserId] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] nvarchar(max) NULL,
    CONSTRAINT [PK_UserEntity] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [ListEntity] (
    [ListId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_ListEntity] PRIMARY KEY ([ListId]),
    CONSTRAINT [FK_ListEntity_UserEntity_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserEntity] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [TaskEntity] (
    [TaskId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NULL,
    [Status] nvarchar(max) NULL,
    [ListId] int NOT NULL,
    CONSTRAINT [PK_TaskEntity] PRIMARY KEY ([TaskId]),
    CONSTRAINT [FK_TaskEntity_ListEntity_ListId] FOREIGN KEY ([ListId]) REFERENCES [ListEntity] ([ListId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ListEntity_UserId] ON [ListEntity] ([UserId]);
GO

CREATE INDEX [IX_TaskEntity_ListId] ON [TaskEntity] ([ListId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250704191951_InitialMigration', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [ListEntity] DROP CONSTRAINT [FK_ListEntity_UserEntity_UserId];
GO

ALTER TABLE [TaskEntity] DROP CONSTRAINT [FK_TaskEntity_ListEntity_ListId];
GO

ALTER TABLE [UserEntity] DROP CONSTRAINT [PK_UserEntity];
GO

ALTER TABLE [TaskEntity] DROP CONSTRAINT [PK_TaskEntity];
GO

ALTER TABLE [ListEntity] DROP CONSTRAINT [PK_ListEntity];
GO

EXEC sp_rename N'[UserEntity]', N'Users';
GO

EXEC sp_rename N'[TaskEntity]', N'Tasks';
GO

EXEC sp_rename N'[ListEntity]', N'Lists';
GO

EXEC sp_rename N'[Tasks].[IX_TaskEntity_ListId]', N'IX_Tasks_ListId', N'INDEX';
GO

EXEC sp_rename N'[Lists].[IX_ListEntity_UserId]', N'IX_Lists_UserId', N'INDEX';
GO

ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]);
GO

ALTER TABLE [Tasks] ADD CONSTRAINT [PK_Tasks] PRIMARY KEY ([TaskId]);
GO

ALTER TABLE [Lists] ADD CONSTRAINT [PK_Lists] PRIMARY KEY ([ListId]);
GO

ALTER TABLE [Lists] ADD CONSTRAINT [FK_Lists_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE;
GO

ALTER TABLE [Tasks] ADD CONSTRAINT [FK_Tasks_Lists_ListId] FOREIGN KEY ([ListId]) REFERENCES [Lists] ([ListId]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250705200756_InitialCreate', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250705204220_InitialCreate2', N'8.0.0');
GO

COMMIT;
GO

