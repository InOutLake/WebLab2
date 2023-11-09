using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class Teacher
{
    public Guid TeacherId { get; set; }

    public Guid InstituteId { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string JobTitle { get; set; } = null!;

    public string AcademicRank { get; set; } = null!;

    public string FamilyStatus { get; set; } = null!;

    public virtual Institute Institute { get; set; } = null!;

    public virtual ICollection<SemesterSubject> SemesterSubjects { get; set; } = new List<SemesterSubject>();
}
