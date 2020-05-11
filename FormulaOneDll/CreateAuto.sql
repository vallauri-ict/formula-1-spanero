CREATE TABLE [dbo].[Auto] (
[nTelaio] varchar(10) NOT NULL,
[marca] varchar(100) NOT NULL,
[cilindrata] INT NOT NULL,
[ali] varchar(100) NOT NULL,
PRIMARY KEY ([nTelaio])
);

INSERT INTO [Auto] VALUES ('123', 'fiat',1300,'gasolio');
INSERT INTO [Auto] VALUES ('1234', 'alfa',2000,'benzina');
INSERT INTO [Auto] VALUES ('12345', 'porsche',3000,'benzina');