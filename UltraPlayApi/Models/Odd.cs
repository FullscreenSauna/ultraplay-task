using System;
using System.Collections.Generic;

namespace UltraPlayApi.Models;

public partial class Odd
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Id comming from xml feed
    /// </summary>
    public int ExternalId { get; set; }

    public decimal Value { get; set; }

    public decimal? SpecialBetValue { get; set; }

    /// <summary>
    /// Connects to the Id of Bets.Bets
    /// </summary>
    public int BetId { get; set; }

    public virtual Bet Bet { get; set; } = null!;
}
