CREATE TABLE [dbo].[login] (
    [user_id]  INT           IDENTITY (1, 1) NOT NULL,
    [username] NVARCHAR (50) NOT NULL,
    [pwd]      NVARCHAR (50) NOT NULL,
    [isTeacher] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_login] PRIMARY KEY CLUSTERED ([user_id] ASC)
);

