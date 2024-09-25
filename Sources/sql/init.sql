/*******************************************************************************************************************************************
 * boardshelfd database init script
 * 
 * Description:  initialization of the database	
 *	- create main tables
 *  - insert tests datas
 *
 * Create date	: 20/09/2024
 * Author 		: DE LA FUENTE Axel					   
 *******************************************************************************************************************************************/

SET NOCOUNT ON;

GO

DROP DATABASE IF EXISTS;
CREATE DATABASE BSD;

GO

DROP TABLE IF EXISTS APP_USER_COLLECTION;
DROP TABLE IF EXISTS APP_USER_RELATION;
DROP TABLE IF EXISTS APP_USER;

GO

CREATE TABLE APP_USER
(
	USR_ID INT IDENTITY(1,1) PRIMARY KEY,
	USR_NAME varchar(64) NOT NULL,
	USR_PWD varchar(max) NOT NULL,
	USR_EMAIL varchar(max)
);

GO

CREATE TABLE APP_USER_RELATION(
	URL_ID INT IDENTITY(1,1) PRIMARY KEY,
	USR_ID_FOLLOWING INT NOT NULL,
	USR_ID_FOLLOWED INT NOT NULL,
	FOREIGN KEY (USR_ID_FOLLOWING) REFERENCES APP_USER(USR_ID),
	FOREIGN KEY (USR_ID_FOLLOWED) REFERENCES APP_USER(USR_ID)
);

GO

CREATE TABLE APP_USER_COLLECTION(
	UCL_ID INT IDENTITY(1,1) PRIMARY KEY,
	USR_ID INT NOT NULL,
	BRG_ID INT NOT NULL,
	FOREIGN KEY (USR_ID) REFERENCES APP_USER(USR_ID)
);

GO

INSERT INTO BSD.dbo.APP_USER VALUES ('SomeGuy', '123', 'someguy@mail.com');
INSERT INTO BSD.dbo.APP_USER VALUES ('HisFriend', '321', 'hisfriend@mail.com');

INSERT INTO BSD.dbo.APP_USER_RELATION VALUES (1, 2);

INSERT INTO BSD.dbo.APP_USER_COLLECTION VALUES (1, 123);

GO
