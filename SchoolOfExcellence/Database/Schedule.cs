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
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.SkipVisit = new HashSet<SkipVisit>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdTeacherActivity { get; set; }
        public bool IsConducted { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> LessonStartTime { get; set; }
        public Nullable<System.TimeSpan> LessonEndTime { get; set; }
        public Nullable<int> IdCabinet { get; set; }
        public string Reason { get; set; }
        public string VisibilityMark => IsConducted ? "Visibility" : "Collapsed";
        public string VisibilityReason => IsConducted ? "Collapsed" : "Visibility";
        public virtual Cabinet Cabinet { get; set; }
        public virtual TeacherActivity TeacherActivity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkipVisit> SkipVisit { get; set; }
    }
}
