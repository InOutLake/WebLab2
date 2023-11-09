using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class ExamForm
{
    public int ExamFormId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SemesterSubject> SemesterSubjects { get; set; } = new List<SemesterSubject>();
}
