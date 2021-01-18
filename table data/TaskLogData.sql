USE [LimbaBackOfficeDB]
GO

/****** Object:  Table [TaskLog]  ******/

INSERT INTO TaskLog 
	(WorkSpaceUserId, [Name], Category, StartDateTime, EndDateTime, Note)
VALUES
	-- Monday
	(1, 'string3', 1, '11-30-2020 15:30', '11-30-2020 17:00', 'string3-note'),
	(1, 'string1', 1, '11-30-2020 08:00', '11-30-2020 12:00', 'string1-note'),
	(1, 'string2', 1, '11-30-2020 13:00', '11-30-2020 15:30', 'string2-note'),
	-- Tuesday					  					  
	(1, 'string4', 1, '12-01-2020 08:00', '12-01-2020 12:00', 'string4-note'),
	(1, 'string5', 1, '12-01-2020 13:00', '12-01-2020 15:30', 'string5-note'),
	(1, 'string6', 1, '12-01-2020 15:30', '12-01-2020 17:00', 'string6-note'),
	-- Wednesday				  					  
	(1, 'string7', 1, '12-02-2020 08:00', '12-02-2020 12:00', 'string7-note'),
	(1, 'string8', 1, '12-02-2020 13:00', '12-02-2020 15:30', 'string8-note'),
	(1, 'string9', 1, '12-02-2020 15:30', '12-02-2020 17:00', 'string9-note'),
	-- Thursday
	(1, 'string10', 1, '12-03-2020 08:00', '12-03-2020 12:00', 'string10-note'),
	(1, 'string12', 1, '12-03-2020 13:00', '12-03-2020 15:30', 'string12-note'),
	(1, 'string12', 1, '12-03-2020 15:30', '12-03-2020 17:00', 'string12-note'),
	-- Friday					   					   
	(1, 'string13', 1, '12-04-2020 08:00', '12-04-2020 12:00', 'string13-note'),
	(1, 'string14', 1, '12-04-2020 13:00', '12-04-2020 15:30', 'string14-note'),
	(1, 'string15', 1, '12-04-2020 15:30', '12-04-2020 17:00', 'string15-note');
GO

/****** End:  Table [TaskLog]  ******/
