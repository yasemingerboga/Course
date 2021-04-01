CREATE TABLE [dbo].[CardPayments] (
    [CardId]          INT           IDENTITY (1, 1) NOT NULL,
    [Number]          NVARCHAR (50) NOT NULL,
    [FullName]        NVARCHAR (50) NOT NULL,
    [Ccv]             NVARCHAR (50) NOT NULL,
    [ExpirationMonth] NVARCHAR (50) NOT NULL,
    [ExpirationYear]  NVARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_CardPayments] PRIMARY KEY ([CardId])
);

