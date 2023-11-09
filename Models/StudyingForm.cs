using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class StudyingForm
{
    public int StudyingFormId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
