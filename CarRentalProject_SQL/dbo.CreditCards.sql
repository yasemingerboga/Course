CREATE TABLE [dbo].[CreditCards]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UserId] INT NOT NULL,
	[NameOnTheCard] VARCHAR(50) NOT NULL, 
    [CreditCardNumber] VARCHAR(50) NOT NULL, 
    [Cvc] VARCHAR(50) NOT NULL, 
    [ExpirationMonth] VARCHAR(50) NOT NULL, 
    [ExpirationYear] VARCHAR(50) NOT NULL,
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
)
