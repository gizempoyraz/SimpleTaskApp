using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Task : Entity<long>
{
    [ForeignKey("AssignedPersonId")]
    public virtual Person AssignedPerson { get; set; }

    public virtual int? AssignedPersonId { get; set; }

    public virtual string Description { get; set; }

    public virtual DateTime CreationTime { get; set; }

    public virtual TaskState State { get; set; }

    public Task()
    {
        CreationTime = DateTime.Now;
        State = TaskState.Active;
    }
}
}
