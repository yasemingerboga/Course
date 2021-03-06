CREATE TABLE [dbo].[Users] (
    [UserId]       INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (25) NULL,
    [LastName]     NVARCHAR (25) NULL,
    [Email]        NVARCHAR (25) NULL,
    [UserPassword] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);