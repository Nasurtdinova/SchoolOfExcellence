//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolOfExcellence
{
    using System;
    using System.Collections.Generic;
    
    public partial class SkipVisit
    {
        public int Id { get; set; }
        public Nullable<int> IdSchedule { get; set; }
        public Nullable<int> IdStudent { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Schedule Schedule { get; set; }
        public virtual Student Student { get; set; }
    }
}
