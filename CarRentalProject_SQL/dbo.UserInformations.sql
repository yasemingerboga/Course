CREATE TABLE [dbo].[UserInformations] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [UserId]           INT           NOT NULL,
    [UserCreditCardId] INT           NOT NULL,
    [FirstName]        VARCHAR (50)  NOT NULL,
    [LastName]         VARCHAR (50)  NOT NULL,
    [Email]            VARCHAR (50)  NOT NULL,
    [FindeksPoint]     VARCHAR (50)  DEFAULT ((0)) NULL,
    [ImagePath]        VARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    FOREIGN KEY ([UserCreditCardId]) REFERENCES [dbo].[CreditCards] ([Id])
);

