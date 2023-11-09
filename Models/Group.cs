using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class Group
{
    public Guid GroupId { get; set; }

    public Guid InstituteId { get; set; }

    public string Name { get; set; } = null!;

    public int YearOfAdmission { get; set; }

    public int StudyingDuration { get; set; }

    public int StudyingFormId { get; set; }

    public string SpecializationId { get; set; } = null!;

    public virtual Institute Institute { get; set; } = null!;

    public virtual ICollection<SemesterSubject> SemesterSubjects { get; set; } = new List<SemesterSubject>();

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual ICollection<StudentInGroup> StudentInGroups { get; set; } = new List<StudentInGroup>();

    public virtual StudyingForm StudyingForm { get; set; } = null!;
}
