CREATE TABLE [dbo].[CarImages] (
    [CarImageId] INT           IDENTITY (1, 1) NOT NULL,
    [CarId]      INT           NOT NULL,
    [ImagePath]  VARCHAR (255) NOT NULL,
    [Date]       DATETIME      NOT NULL default(getdate()),
    PRIMARY KEY CLUSTERED ([CarImageId] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([CarId])
);

