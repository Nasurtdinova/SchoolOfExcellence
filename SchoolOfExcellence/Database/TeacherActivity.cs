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
    
    public partial class TeacherActivity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeacherActivity()
        {
            this.Schedule = new HashSet<Schedule>();
            this.StudentActivity = new HashSet<StudentActivity>();
        }
    
        public int Id { get; set; }
        public int IdTeacher { get; set; }
        public int IdActivity { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Activity Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentActivity> StudentActivity { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
