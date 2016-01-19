//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CGPTruck.UWP.Entities.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mission()
        {
            this.Attachments = new HashSet<Attachment>();
            this.Failures = new HashSet<Failure>();
            this.Steps = new HashSet<Step>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Start_Date { get; set; }
        public int Vehicule_Id { get; set; }
        public int Driver_Id { get; set; }
        public int Pickup_Place_Id { get; set; }
        public int Delivery_Place_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attachment> Attachments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Failure> Failures { get; set; }
        public virtual Place DeliveryPlace { get; set; }
        public virtual User Driver { get; set; }
        public virtual Place PickupPlace { get; set; }
        public virtual Vehicule Vehicule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Step> Steps { get; set; }
    }
}
