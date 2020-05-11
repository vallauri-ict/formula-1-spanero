CREATE TABLE [dbo].[Scores]
(
	[id] [int] NOT NULL,
	[score] [int] NOT NULL,
	[details] [varchar](254) NOT NULL,
	CONSTRAINT [PK_Scores] PRIMARY KEY CLUSTERED ([id] ASC)
);

INSERT INTO [dbo].[Scores]
(
    id,
	score,
	details
)
VALUES
(0, 1, 'Fastest Lap bonus'),
(1, 25, '1st Place'),
(2, 18, '2nd Place'),
(3, 15, '3td Place'),
(4, 12, '4th Place'),
(5, 10, '5th Place'),
(6, 8, '6th Place'),
(7, 6, '7th Place'),
(8, 4, '8th Place'),
(9, 2, '9th Place'),
(10, 1, '10th Place'),
(11, 0, '11th Place'),
(12, 0, '12th Place'),
(13, 0, '13th Place'),
(14, 0, '14th Place'),
(15, 0, '15th Place'),
(16, 0, '16th Place'),
(17, 0, '17th Place'),
(18, 0, '18th Place'),
(19, 0, '19th Place'),
(20, 0, '20th Place');