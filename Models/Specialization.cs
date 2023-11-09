using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class Specialization
{
    public string SpecializationId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
