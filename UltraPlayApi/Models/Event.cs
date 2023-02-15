using System;
using System.Collections.Generic;

namespace UltraPlayApi.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Id comming from xml feed
    /// </summary>
    public int ExternalId { get; set; }

    public bool IsLive { get; set; }

    /// <summary>
    /// Id comming from xml feed
    /// </summary>
    public int CategoryId { get; set; }

    public virtual ICollection<Match> Matches { get; } = new List<Match>();
}
