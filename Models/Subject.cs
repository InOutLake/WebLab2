using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class Subject
{
    public string SubjectId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<SemesterSubject> SemesterSubjects { get; set; } = new List<SemesterSubject>();
}
