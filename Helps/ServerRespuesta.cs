namespace apiwise.Helps
{
    public class ServerRespuesta
    {
        /// <summary>
        /// true, false estado de ejecucion
        /// </summary>
        public bool Success { get; set; } = true;
        /// <summary>
        /// mensaje del estado del proceso
        /// </summary>
        public string Message { get; set; } = "OK";
        /// <summary>
        /// 
        /// </summary>
        public object? ResponsesObject { get; set; } = null;
    }
}
