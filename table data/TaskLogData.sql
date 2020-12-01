USE [LimbaBackOfficeDB]
GO

/****** Object:  Table [TaskLog]  ******/

INSERT INTO TaskLog 
	(WorkSpaceUserId, [Name], Category, StartDateTime, EndDateTime, Note)
VALUES
	-- Monday
	(1, 'string1', 1, '11-23-2020 13:30', '11-23-2020 13:30', 'string1-note'),
	(1, 'string2', 1, '11-23-2020 13:30', '11-23-2020 13:30', 'string2-note'),
	(1, 'string3', 1, '11-23-2020 13:30', '11-23-2020 13:30', 'string3-note'),
	-- Tuesday					  					  
	(1, 'string4', 1, '11-24-2020 13:30', '11-23-2020 13:30', 'string4-note'),
	(1, 'string5', 1, '11-24-2020 13:30', '11-23-2020 13:30', 'string5-note'),
	(1, 'string6', 1, '11-24-2020 13:30', '11-23-2020 13:30', 'string6-note'),
	-- Wednesday				  					  
	(1, 'string7', 1, '11-25-2020 13:30', '11-23-2020 13:30', 'string7-note'),
	(1, 'string8', 1, '11-25-2020 13:30', '11-23-2020 13:30', 'string8-note'),
	(1, 'string9', 1, '11-25-2020 13:30', '11-23-2020 13:30', 'string9-note'),
	-- Thursday
	(1, 'string10', 1, '11-26-2020 13:30', '11-23-2020 13:30', 'string10-note'),
	(1, 'string11', 1, '11-26-2020 13:30', '11-23-2020 13:30', 'string11-note'),
	(1, 'string12', 1, '11-26-2020 13:30', '11-23-2020 13:30', 'string12-note'),
	-- Friday					   					   
	(1, 'string13', 1, '11-27-2020 13:30', '11-23-2020 13:30', 'string13-note'),
	(1, 'string14', 1, '11-27-2020 13:30', '11-23-2020 13:30', 'string14-note'),
	(1, 'string15', 1, '11-27-2020 13:30', '11-23-2020 13:30', 'string15-note');
GO

/****** End:  Table [TaskLog]  ******/
