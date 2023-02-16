CREATE VIEW vw_AllMatches AS
SELECT m.Name as MatchName,
	   m.StartDate,
	   b.Name as MarketName,
	   o.Name as OddName,
	   o.Value,
	   o.SpecialBetValue,
	   m.ExternalId
FROM Matches m
INNER JOIN Bets b ON b.MatchId = m.Id
INNER JOIN Odds o ON o.BetId = b.Id