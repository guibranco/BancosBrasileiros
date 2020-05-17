
CREATE TABLE Banks (
    COMPE CHAR(3) NOT NULL PRIMARY KEY,
    ISPB CHAR(8) NOT NULL,
    Document CHAR(18) NOT NULL,
    FiscalName VARCHAR(255) NOT NULL,
    FantasyName VARCHAR(255) NOT NULL,
    Url VARCHAR(255) NULL,
    DateRegistered DATETIME NOT NULL,
    DateUpdated DATETIME NULL,
    DateRemoved DATETIME NULL,
    IsRemoved BIT NOT NULL DEFAULT "0");