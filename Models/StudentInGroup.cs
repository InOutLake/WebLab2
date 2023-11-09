using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class StudentInGroup
{
    public Guid StudentId { get; set; }

    public Guid GroupId { get; set; }

    public int PaymentFormId { get; set; }

    public virtual Group Group { get; set; } = null!;

    public virtual PaymentForm PaymentForm { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
