//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public System.Guid PK { get; set; }
        public string OrderNo { get; set; }
        public System.Guid ProductPK { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public System.Guid UserPK { get; set; }
        public int Status { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual UserData UserData { get; set; }
    }
}
