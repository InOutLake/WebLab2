using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class Institute
{
    public Guid InstituteId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
