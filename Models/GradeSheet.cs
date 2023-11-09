using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class GradeSheet
{
    public Guid StudentId { get; set; }

    public Guid GroupId { get; set; }

    public Guid SemesterSubjectId { get; set; }

    public DateTime ExamDate { get; set; }

    public int Score { get; set; }

    public int ScoreIn5 { get; set; }

    public string Letter { get; set; } = null!;

    public virtual SemesterSubject SemesterSubject { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
