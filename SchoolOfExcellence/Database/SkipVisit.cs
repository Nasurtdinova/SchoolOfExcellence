//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolOfExcellence.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class SkipVisit
    {
        public int Id { get; set; }
        public Nullable<int> IdSchedule { get; set; }
        public Nullable<int> IdStudent { get; set; }
        public bool IsVisited { get; set; }

        public string VisibilityReason => IsVisited ? "Collapsed" : "Visible";
        public string Reason { get; set; }
    
        public virtual Schedule Schedule { get; set; }
        public virtual Student Student { get; set; }
    }
}
