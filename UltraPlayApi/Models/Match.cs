using System;
using System.Collections.Generic;

namespace UltraPlayApi.Models;

public partial class Match
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ExternalId { get; set; }

    /// <summary>
    /// Id comming from xml feed
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Connects to the Id of Matches.MatchTypes
    /// </summary>
    public int MatchTypeId { get; set; }

    /// <summary>
    /// Connects to the Id of Events.Events
    /// </summary>
    public int EventId { get; set; }

    public virtual ICollection<Bet> Bets { get; } = new List<Bet>();

    public virtual Event Event { get; set; } = null!;

    public virtual MatchType MatchType { get; set; } = null!;
}
