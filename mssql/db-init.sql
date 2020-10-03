CREATE DATABASE mydb;
GO

USE mydb;
GO

CREATE TABLE users (
    Id int primary key,
    Name nvarchar(450) not null
);
GO

-- CREATE TABLE cache (
--     Id nvarchar(450) primary key,
--     Value varbinary(max) not null,
--     ExpiresAtTime datetimeoffset not null,
--     SlidingExpirationInSeconds bigint,
--     AbsoluteExpiration datetimeoffset
-- );
-- GO
