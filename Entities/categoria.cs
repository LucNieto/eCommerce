//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public categoria()
        {
            this.productoes = new HashSet<producto>();
        }


        public int id_categoria { get; set; }
        [Required(ErrorMessage = "El campo \"nombre de la categor�a\" es requrido")]
        [StringLength(20, MinimumLength = 3)] //m�ximo de caracteres
        [RegularExpression((@"^[A-Z]+[a-zA-Z0-9''-'\s]*$"), ErrorMessage = "El nombre se debe capitalizar, s�lo letras del alfabeto, n�meros permitidos despues de una letra")]// combinaci�n de expresiones regulares
        public string nombre_categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto> productoes { get; set; }
    }
}
