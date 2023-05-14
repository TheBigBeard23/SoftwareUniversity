    SELECT TOP(2) wd.DepositGroup
      FROM WizzardDeposits AS wd
  GROUP BY wd.DepositGroup
  ORDER BY MAX(wd.MagicWandSize)
