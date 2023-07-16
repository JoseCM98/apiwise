using System.ComponentModel.DataAnnotations;

namespace apiwise.Models.Pagos.PagosDto
{
    /// <summary>
    /// 
    /// </summary>
    public class PaymentDetail
    {
        [StringLength(36)]
        [Required]
        public string IdCuota { get; set; }
        [Required]
        public decimal ValorAbono { get; set; }
        /// <summary>
        /// Nombre de propietatio del documento de CHEQUE/TRANSFERENCIA
        /// </summary>
        [StringLength(100)]
        public string Propietario { get; set; }
        /// <summary>
        /// Codigo del banco si es CHEQUE/TRANSFERENCIA
        /// </summary>
        [StringLength(20)]
        public string IdBanco { get; set; }
        /// <summary>
        /// Numero de cuenta del Propietario CHEQUE/TRANSFERENCIA
        /// </summary>
        [StringLength(20)]
        public string NumCuenta { get; set; }
        /// <summary>
        /// Numero de CHEQUE
        /// </summary>
        [StringLength(10)]
        public string NumCheque { get; set; } = "0";
        /// <summary>
        /// Fecha del documento CHEQUE en formato Anio-Mes-Dia 2022-04-25
        /// </summary>
        public DateTime Fechadoc { get; set; } = DateTime.Now;
    }
}
