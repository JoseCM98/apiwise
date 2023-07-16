using System.ComponentModel.DataAnnotations;

namespace apiwise.Models.Pagos.PagosDto
{
    /// <summary>
    /// 
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Numero del documento
        /// </summary>
        [Required]
        [Display(Name = "Numero del documento secuancial")]
        public string NumRecibo { get; set; }
        /// <summary>
        /// </summary>
        [Required]
        [StringLength(36)]
        public string IdFactura { get; set; }
        /// <summary>
        /// </summary>
        public string IdUsuario { get; set; } = "";
        /// <summary>
        /// EFE para Efectivo, TRA para Transferencia,CHE para Cheque
        /// </summary>
        [Required]
        [StringLength(10)]
        public string FormaPago { get; set; }
        /// <summary>
        /// </summary>
        [Required]
        public decimal ValorTotal { get; set; }
        /// <summary>
        /// </summary>
        [Required]
        public string Observacion { get; set; }
        [Required]
        public List<PaymentDetail> Cuotas { get; set; }
    }
}
