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
    using System.Linq;

    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.TeacherActivity = new HashSet<TeacherActivity>();
        }
    
        public int Id { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> IdUser { get; set; }
        public int CountSubject => Connection.BdConnection.Schedule.Where(a => a.TeacherActivity.IdTeacher == Id && a.IsSkipped == true).Count();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherActivity> TeacherActivity { get; set; }
        public virtual User User { get; set; }
    }
}
