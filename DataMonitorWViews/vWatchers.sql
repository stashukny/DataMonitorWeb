CREATE VIEW [dbo].[vWatchers]
	AS SELECT w.Name as WatcherName,
	c.Name as ClientName,
	c.DBServer,
	c.[Database],
	s.Name as SourceName,
	s.[Table],
	m.Name as MetricName,
	w.LastValue
FROM Watchers w
	JOIN Clients c
	ON w.ClientId = c.Id
	JOIN Sources s
	ON c.Id = s.ClientId
	JOIN Metrics m
	ON s.Id = m.SourceId