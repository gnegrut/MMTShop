CREATE TABLE [dbo].[FeaturedProductRange] (
    [Id]              SMALLINT     IDENTITY (1, 1) NOT NULL,
    [ProductSkuRange] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_FeaturedProductRange] PRIMARY KEY CLUSTERED ([Id] ASC)
);

