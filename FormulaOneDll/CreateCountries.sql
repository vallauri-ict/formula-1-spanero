CREATE TABLE [dbo].[Countries]
(
	[countryCode] [char](2) NOT NULL,
	[countryName] [varchar](100) NOT NULL,
	[flag] [varchar](200) NOT NULL,
	PRIMARY KEY CLUSTERED ([countryCode] ASC)
);
-- 
-- Data
-- 
INSERT INTO [Countries] VALUES ('AU', 'Australia', 'https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Flag_of_Australia.svg/1280px-Flag_of_Australia.svg.png'),
INSERT INTO [Countries] VALUES ('CA', 'Canada', 'https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Flag_of_Canada_%28Pantone%29.svg/1280px-Flag_of_Canada_%28Pantone%29.svg.png'),
INSERT INTO [Countries] VALUES ('CH', 'Switzerland', 'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Switzerland.svg/1024px-Flag_of_Switzerland.svg.png'),
INSERT INTO [Countries] VALUES ('US', 'United States', 'https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/Flag_of_the_United_States.svg/1280px-Flag_of_the_United_States.svg.png'),
INSERT INTO [Countries] VALUES ('BH', 'Bahrain', 'https://upload.wikimedia.org/wikipedia/commons/2/2c/Flag_of_Bahrain.svg'),
INSERT INTO [Countries] VALUES ('AZ', 'Azerbaijan', 'https://upload.wikimedia.org/wikipedia/commons/d/dd/Flag_of_Azerbaijan.svg'),
INSERT INTO [Countries] VALUES ('AT', 'Austria', 'https://upload.wikimedia.org/wikipedia/commons/thumb/4/41/Flag_of_Austria.svg/1200px-Flag_of_Austria.svg.png'),
INSERT INTO [Countries] VALUES ('BE', 'Belgium', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/92/Flag_of_Belgium_%28civil%29.svg/1280px-Flag_of_Belgium_%28civil%29.svg.png'),
INSERT INTO [Countries] VALUES ('HU', 'Hungary', 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c1/Flag_of_Hungary.svg/1280px-Flag_of_Hungary.svg.png'),
INSERT INTO [Countries] VALUES ('SG', 'Singapore', 'https://upload.wikimedia.org/wikipedia/commons/4/48/Flag_of_Singapore.svg'),
INSERT INTO [Countries] VALUES ('BR', 'Brazil', 'https://upload.wikimedia.org/wikipedia/en/thumb/0/05/Flag_of_Brazil.svg/1200px-Flag_of_Brazil.svg.png'),
INSERT INTO [Countries] VALUES ('AE', 'United Arab Emirates', 'https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Flag_of_the_United_Arab_Emirates.svg/1280px-Flag_of_the_United_Arab_Emirates.svg.png'),
INSERT INTO [Countries] VALUES ('DK', 'Denmark', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Flag_of_Denmark.svg/1200px-Flag_of_Denmark.svg.png'),
INSERT INTO [Countries] VALUES ('FI', 'Finland', 'https://upload.wikimedia.org/wikipedia/commons/b/bc/Flag_of_Finland.svg'),
INSERT INTO [Countries] VALUES ('FR', 'France', 'https://upload.wikimedia.org/wikipedia/en/thumb/c/c3/Flag_of_France.svg/1200px-Flag_of_France.svg.png'),
INSERT INTO [Countries] VALUES ('DE', 'Germany', 'https://upload.wikimedia.org/wikipedia/en/thumb/b/ba/Flag_of_Germany.svg/1200px-Flag_of_Germany.svg.png'),
INSERT INTO [Countries] VALUES ('IT', 'Italy', 'https://upload.wikimedia.org/wikipedia/en/thumb/0/03/Flag_of_Italy.svg/1200px-Flag_of_Italy.svg.png'),
INSERT INTO [Countries] VALUES ('MX', 'Mexico', 'https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Flag_of_Mexico.svg/1280px-Flag_of_Mexico.svg.png'),
INSERT INTO [Countries] VALUES ('MC', 'Monaco', 'https://upload.wikimedia.org/wikipedia/commons/e/ea/Flag_of_Monaco.svg'),
INSERT INTO [Countries] VALUES ('NL', 'Netherlands', 'https://upload.wikimedia.org/wikipedia/commons/thumb/2/20/Flag_of_the_Netherlands.svg/1280px-Flag_of_the_Netherlands.svg.png'),
INSERT INTO [Countries] VALUES ('PL', 'Poland', 'https://upload.wikimedia.org/wikipedia/en/1/12/Flag_of_Poland.svg'),
INSERT INTO [Countries] VALUES ('RU', 'Russian Federation', 'https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/Flag_of_Russia.svg/1200px-Flag_of_Russia.svg.png'),
INSERT INTO [Countries] VALUES ('ES', 'Spain', 'https://upload.wikimedia.org/wikipedia/commons/thumb/9/9a/Flag_of_Spain.svg/1024px-Flag_of_Spain.svg.png'),
INSERT INTO [Countries] VALUES ('TH', 'Thailand', 'https://upload.wikimedia.org/wikipedia/commons/a/a9/Flag_of_Thailand.svg'),
INSERT INTO [Countries] VALUES ('GB', 'United Kingdom', 'https://upload.wikimedia.org/wikipedia/commons/a/ae/Flag_of_the_United_Kingdom.svg');