
  SELECT
          r.Country
	     ,ISNULL(r.PeakName, '(no highest peak)') AS [Highest Peak Name]
	     ,ISNULL(r.Elevation, 0) AS [Highest Peak Elevation]
	     ,ISNULL(r.MountainRange, '(no mountain)') AS Mountain
    FROM
          (SELECT  c.CountryName AS Country
                  ,p.PeakName
        	      ,MAX(p.Elevation) AS Elevation
        	      ,m.MountainRange
        	      ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS Rank
             FROM Countries AS c
        LEFT JOIN MountainsCountries AS mc
               ON c.CountryCode = mc.CountryCode
        LEFT JOIN Peaks AS p
               ON mc.MountainId = p.MountainId
        LEFT JOIN Mountains AS m
               ON p.MountainId = m.Id
         GROUP BY c.CountryName,
                  p.PeakName,
                  m.MountainRange) AS r
   WHERE r.Rank = 1
ORDER BY r.Country, [Highest Peak Name]
