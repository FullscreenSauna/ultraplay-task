using System;
using System.Collections.Generic;

namespace UltraPlayApi.Models;

public partial class Bet
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Id comming from xml feed
    /// </summary>
    public int ExternalId { get; set; }

    public bool IsLive { get; set; }

    /// <summary>
    /// Connects to the Id of Matches.Matches
    /// </summary>
    public int MatchId { get; set; }

    public virtual Match Match { get; set; } = null!;

    public virtual ICollection<Odd> Odds { get; } = new List<Odd>();
}
