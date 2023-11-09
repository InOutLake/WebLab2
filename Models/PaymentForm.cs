using System;
using System.Collections.Generic;

namespace Weblab2.Models;

public partial class PaymentForm
{
    public int PaymentFormId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StudentInGroup> StudentInGroups { get; set; } = new List<StudentInGroup>();
}
