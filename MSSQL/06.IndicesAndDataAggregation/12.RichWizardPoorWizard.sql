SELECT SUM(d.[Difference])
  FROM (SELECT wd.DepositAmount - (SELECT DepositAmount
                                     FROM WizzardDeposits 
									   AS wdn
						            WHERE wdn.id = wd.id + 1) 
									   AS [Difference]
          FROM WizzardDeposits AS wd) 
		    AS d
