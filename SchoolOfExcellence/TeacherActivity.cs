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
    
    public partial class TeacherActivity
    {
        public int IdTeacher { get; set; }
        public int IdActivity { get; set; }
        public string Name { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}