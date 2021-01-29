CREATE TABLE [dbo].[Category] (
    [CategoryId]      SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Description]     NVARCHAR (100) NULL,
    [ProductSKURange] NVARCHAR (10)  NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

