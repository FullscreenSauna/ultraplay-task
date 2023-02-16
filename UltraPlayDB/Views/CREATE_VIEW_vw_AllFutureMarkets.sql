CREATE VIEW vw_AllFutureMarkets AS
SELECT 
    m.Name AS MatchName,
    m.StartDate,
    b.Name AS MarketName,
    o.Name AS OddName,
    COALESCE(MAX(CASE WHEN o.SpecialBetValue IS NOT NULL THEN o.SpecialBetValue ELSE NULL END), MAX(o.Value)) AS Odds
FROM Matches m
INNER JOIN Bets b ON b.MatchId = m.Id
INNER JOIN Odds o ON o.BetId = b.Id
WHERE DATEADD(HH, 24, m.StartDate) <= DATEADD(HH, 24, GETDATE())
AND b.IsLive = 1
AND b.Name IN ('Match Winner', 'Map Advantage', 'Total Maps Played')
GROUP BY m.Name,
         m.StartDate,
         b.Name,
         o.Name