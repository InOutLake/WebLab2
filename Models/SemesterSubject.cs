using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class SemesterSubject
{
    public Guid SemesterSubjectId { get; set; }

    public Guid LecturerId { get; set; }

    public Guid GroupId { get; set; }

    public string SubjectId { get; set; } = null!;

    public int SemesterNumber { get; set; }

    public int HoursPerWeek { get; set; }

    public int ExamFormId { get; set; }

    public virtual ExamForm ExamForm { get; set; } = null!;

    public virtual ICollection<GradeSheet> GradeSheets { get; set; } = new List<GradeSheet>();

    public virtual Group Group { get; set; } = null!;

    public virtual Teacher Lecturer { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
