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

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            this.SkipVisit = new HashSet<SkipVisit>();
            this.StudentActivity = new HashSet<StudentActivity>();
        }
    
        public int Id { get; set; }
        public string FullName { get; set; }
        public Nullable<int> IdGrade { get; set; }
        public int CountActivity => DataAccess.GetStudentsActivities().Where(a => a.IdStudent == Id && a.IsActive == true).Count();
        public bool IsVisited { get; set; }
        public string Reason { get; set; }
        public string VisibilityReason => IsVisited ? "Collapsed" : "Visible";
        public virtual Grade Grade { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkipVisit> SkipVisit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentActivity> StudentActivity { get; set; }
    }
}
