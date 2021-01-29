CREATE TABLE [dbo].[Product] (
    [ProductId]   UNIQUEIDENTIFIER NOT NULL,
    [SKU]         INT              NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
    [Description] NVARCHAR (150)   NULL,
    [Price]       MONEY            CONSTRAINT [DF_Product_Price] DEFAULT ((0.00)) NOT NULL,
    [CategoryId]  SMALLINT         NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Product_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

