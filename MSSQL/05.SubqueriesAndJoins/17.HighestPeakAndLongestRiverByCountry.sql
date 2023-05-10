



SELECT TOP(5) c.CountryName
       ,MAX(p.Elevation) AS HighestPeakElevation
	   ,MAX(r.Length)    AS LongestRiverLength
      FROM MountainsCountries AS mc
FULL JOIN Peaks AS p
       ON mc.MountainId = p.MountainId
FULL JOIN CountriesRivers AS cr
       ON cr.CountryCode = mc.CountryCode
FULL JOIN Rivers AS r
       ON cr.RiverId = r.Id
FULL JOIN Countries AS c
       ON c.CountryCode = mc.CountryCode
 GROUP BY c.CountryName
 ORDER BY HighestPeakElevation DESC,
          LongestRiverLength DESC,
		  c.CountryName