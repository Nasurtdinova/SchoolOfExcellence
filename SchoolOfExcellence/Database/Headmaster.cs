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
    
    public partial class Headmaster
    {
        public int Id { get; set; }
        public Nullable<int> IdUser { get; set; }
    
        public virtual User User { get; set; }
    }
}
