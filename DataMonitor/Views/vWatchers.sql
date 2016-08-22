CREATE VIEW [dbo].[vWatchers]
	AS SELECT 
		w.Id,
		w.Name,
		l.Name as LevelName,
		c.Id as ClientId,
		c.Name as ClientName,
		c.DBServer,
		c.[Database],
		s.Id as SourceId,
		s.Name as SourceName,
		s.[Table],
		m.Id as MetricId,
		m.Name as MetricName,
		n.Email,
		w.LastValue,
		t.Name as ThreasholdName,
		t.Percentage
FROM Watchers w
	JOIN Levels l
	ON w.LevelId = l.Id
	JOIN Notifications n
	ON w.NotificationId = n.Id
	JOIN Threasholds t
	ON w.ThreasholdId = t.Id
	LEFT JOIN Clients c
	ON w.ClientId = c.Id
	LEFT JOIN Sources s
	ON w.SourceId = s.Id
	LEFT JOIN Metrics m
	ON w.MetricId = m.Id