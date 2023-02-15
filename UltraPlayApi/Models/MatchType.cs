using System;
using System.Collections.Generic;

namespace UltraPlayApi.Models;

public partial class MatchType
{
    public int Id { get; set; }

    /// <summary>
    /// Prematch/Live
    /// </summary>
    public string Type { get; set; } = null!;

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
