
    SELECT COUNT(*) AS [Count]
      FROM MountainsCountries AS mc
RIGHT JOIN Countries AS c
        ON mc.CountryCode = c.CountryCode
     WHERE mc.MountainId IS NULL

