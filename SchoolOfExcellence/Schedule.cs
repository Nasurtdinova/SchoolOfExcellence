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
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.SkipVisit = new HashSet<SkipVisit>();
        }
    
        public int Id { get; set; }
        public Nullable<int> IdActivity { get; set; }
        public Nullable<int> IdDayOfWeek { get; set; }
        public Nullable<bool> IsSkipped { get; set; }
        public System.TimeSpan LessonStartTime { get; set; }
        public System.TimeSpan LessonEndTime { get; set; }
        public Nullable<int> IdTeacher { get; set; }
        public Nullable<int> IdCabinet { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Cabinet Cabinet { get; set; }
        public virtual DayOfWeek DayOfWeek { get; set; }
        public virtual Teacher Teacher { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkipVisit> SkipVisit { get; set; }
    }
}