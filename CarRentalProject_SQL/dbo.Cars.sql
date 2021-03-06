CREATE TABLE [dbo].[Cars] (
    [CarId]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NULL,
    [ColorId]      INT           NULL,
    [ModelYear]    INT           NULL,
    [DailyPrice]   FLOAT (53)    NULL,
    [Descriptions] NVARCHAR (25) NULL,
    [Name]         NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);