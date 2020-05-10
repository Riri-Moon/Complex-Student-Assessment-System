
CREATE TABLE [dbo].[Student] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Meno]                 NVARCHAR (30) NOT NULL,
    [Priezvisko]           NVARCHAR (35) NOT NULL,
    [Email]                NVARCHAR (55) NOT NULL,
    [Email_UCM]            NVARCHAR (55) NULL,
    [ISIC]                 NVARCHAR (25) NULL,
    [Rocnik]               INT           NULL,
    [Forma]                NVARCHAR (7)  NOT NULL,
    [ID_Kruzok]            NVARCHAR (3)  NULL,
    [Stud_program]         NVARCHAR (10) NOT NULL,
    [ID_stud_skupina]      INT           NOT NULL,
    [IdGroupForAttendance] NVARCHAR (3)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[User] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [Meno]            NVARCHAR (30)  NULL,
    [Heslo]           NVARCHAR (128) NULL,
    [Email]           NVARCHAR (50)  NULL,
    [ApiKey]          NVARCHAR (80)  NULL,
    [Signature]       NVARCHAR (300) NULL,
    [AGrade]          FLOAT (53)     NULL,
    [BGrade]          FLOAT (53)     NULL,
    [CGrade]          FLOAT (53)     NULL,
    [DGrade]          FLOAT (53)     NULL,
    [EGrade]          FLOAT (53)     NULL,
    [FxGrade]         FLOAT (53)     NULL,
    [PointsForActLec] INT            NULL,
    [PointsForActSem] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[EmailTemplate] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [EmailSubject]      NVARCHAR (100)  NOT NULL,
    [EmailContent]      NVARCHAR (1000) NOT NULL,
    [IdUser]            INT             NOT NULL,
    [EmailTemplateName] NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Table_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[ActivityTemplate] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [ActivityName] NVARCHAR (25) NOT NULL,
    [MaxPoints]    FLOAT (53)    DEFAULT ((0)) NOT NULL,
    [IdUser]       INT           NOT NULL,
    [FirstRem]     INT           NULL,
    [SecondRem]    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Activity_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[FinalGrade] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [IdStudent]          INT          NOT NULL,
    [MaxPts]             FLOAT (53)   DEFAULT ((0)) NULL,
    [GotPoints]          FLOAT (53)   DEFAULT ((0)) NULL,
    [MissedLectures]     INT          DEFAULT ((0)) NULL,
    [MissedSeminars]     INT          DEFAULT ((0)) NULL,
    [Grade]              NVARCHAR (2) DEFAULT ('Fx') NULL,
    [IdSkupina]          INT          NOT NULL,
    [ActivityLectPoints] FLOAT (53)   DEFAULT ((0)) NOT NULL,
    [ActivitySemPoints]  FLOAT (53)   DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FinalGrade_ToStudent] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Student] ([Id])
);


CREATE TABLE [dbo].[StudentSkupina] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Nazov]   NVARCHAR (20) NOT NULL,
    [Forma]   NVARCHAR (7)  NOT NULL,
    [Id_User] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StudentSkupina_User] FOREIGN KEY ([Id_User]) REFERENCES [dbo].[User] ([Id]),
    CHECK ([Forma]='Externá' OR [Forma]='Denná')
);


CREATE TABLE [dbo].[TaskTemplate] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [TaskName]           NVARCHAR (50) NOT NULL,
    [MaxPts]             FLOAT (53)    NOT NULL,
    [IdActivityTemplate] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TaskTemplate_ToActivityTemplate] FOREIGN KEY ([IdActivityTemplate]) REFERENCES [dbo].[ActivityTemplate] ([Id])
);




CREATE TABLE [dbo].[TotalAttendance] (
    [Id]                  INT IDENTITY (1, 1) NOT NULL,
    [IdStudent]           INT NOT NULL,
    [TotalPresentLecture] INT DEFAULT ((0)) NOT NULL,
    [TotalAbsentLecture]  INT DEFAULT ((0)) NOT NULL,
    [TotalExcusedLecture] INT DEFAULT ((0)) NOT NULL,
    [TotalLecture]        INT DEFAULT ((0)) NOT NULL,
    [TotalSeminar]        INT DEFAULT ((0)) NOT NULL,
    [TotalAbsentSeminar]  INT DEFAULT ((0)) NOT NULL,
    [TotalPresentSeminar] INT DEFAULT ((0)) NOT NULL,
    [TotalExcusedSeminar] INT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TotalAttendance_ToStudent] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Student] ([Id])
);



CREATE TABLE [dbo].[Attachments] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [FilePath]        VARCHAR (200) NOT NULL,
    [FileName]        SQL_VARIANT   NOT NULL,
    [IdUser]          INT           NOT NULL,
    [IdEmailTemplate] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Attachments_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Attachments_ToEmailTemplate] FOREIGN KEY ([IdEmailTemplate]) REFERENCES [dbo].[EmailTemplate] ([Id])
);



CREATE TABLE [dbo].[AttendanceStud] (
    [Date]         DATE           NOT NULL,
    [Status]       NVARCHAR (15)  NULL,
    [IDSkupina]    INT            NOT NULL,
    [Type]         NVARCHAR (10)  NOT NULL,
    [IDStudent]    INT            NOT NULL,
    [IdAttendance] INT            IDENTITY (1, 1) NOT NULL,
    [IsReplacable] BIT            NOT NULL,
    [IdGroup]      NVARCHAR (3)   NOT NULL,
    [Comment]      NVARCHAR (150) NULL,
    CONSTRAINT [PK_AttendanceStud] PRIMARY KEY CLUSTERED ([IdAttendance] ASC),
    CONSTRAINT [FK_AttendanceStud_ToStudent] FOREIGN KEY ([IDStudent]) REFERENCES [dbo].[Student] ([Id]),
    CONSTRAINT [FK_AttendanceStud_ToSkupina] FOREIGN KEY ([IDSkupina]) REFERENCES [dbo].[StudentSkupina] ([Id]),
    CONSTRAINT [Status_Check] CHECK ([Status]='Prítomný' OR [Status]='Neprítomný' OR [Status]='Ospravedlnené' OR [Status]='Zrušené' OR [Status]='Nahradené')
);

CREATE TABLE [dbo].[Activity] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [ActivityName]       NVARCHAR (50)  NOT NULL,
    [IdStudent]          INT            NOT NULL,
    [IdUser]             INT            NOT NULL,
    [IdSkupina]          INT            NOT NULL,
    [Deadline]           DATETIME       NOT NULL,
    [MaxPoints]          FLOAT (53)     NOT NULL,
    [EmailSendingActive] BIT            NOT NULL,
    [Hodnotenie]         FLOAT (53)     DEFAULT ((0)) NOT NULL,
    [Hodnotene]          BIT            DEFAULT ((0)) NULL,
    [IdFirstRem]         INT            NULL,
    [IdSecRem]           INT            NULL,
    [SendFirst]          BIT            NULL,
    [SendSecond]         BIT            NULL,
    [Comment]            NVARCHAR (350) DEFAULT ('') NULL,
    [SendMe]             BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Activity_ToSkupina] FOREIGN KEY ([IdSkupina]) REFERENCES [dbo].[StudentSkupina] ([Id]),
    CONSTRAINT [FK_Activity_ToStudent] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Student] ([Id]),
    CONSTRAINT [FK_Activit_ToUser] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([Id])
);









CREATE TABLE [dbo].[Task] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [TaskName]   NVARCHAR (50)  NOT NULL,
    [IdActivity] INT            NOT NULL,
    [Points]     FLOAT (53)     NOT NULL,
    [IdStudent]  INT            NOT NULL,
    [Comment]    NVARCHAR (250) DEFAULT ('') NOT NULL,
    [Hodnotenie] FLOAT (53)     DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Task_ToActivity] FOREIGN KEY ([IdActivity]) REFERENCES [dbo].[Activity] ([Id]),
    CONSTRAINT [FK_Task_ToStudent] FOREIGN KEY ([IdStudent]) REFERENCES [dbo].[Student] ([Id])
);





