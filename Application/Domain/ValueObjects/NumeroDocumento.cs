namespace ClientesDapper.Application.Domain.ValueObjects
{
    public class NumeroDocumento
    {
        private string numero { get; set; }

        private NumeroDocumento(string numero)
        {
            this.numero = numero;
        }

        public NumeroDocumento IsNumeroDocumento(TipoDocumento tipoDocumento, string numero)
        {
            // controlar la longitud de DNI
            if (tipoDocumento == TipoDocumento.DNI && numero.Length > 8)
            {
                throw new ArgumentException("El número de documento no es un DNI VALIDO");
            }

            // controlar la longitud de CUIL
            if (tipoDocumento == TipoDocumento.CUIL && numero.Length > 11)
            {
                throw new ArgumentException("El número de documento no es un CUIL VALIDO");
            }

            // controlar que sean solo numeros
            if (!numero.All(char.IsDigit))
            {
                throw new ArgumentException("El número de documento debe contener solo dígitos.");
            }

            return new NumeroDocumento(numero);
        }
    }
}
