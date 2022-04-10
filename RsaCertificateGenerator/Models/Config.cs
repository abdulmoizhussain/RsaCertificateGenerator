namespace RsaCertificateGenerator.Models
{
  internal class Config
  {
    public CertParams RSA { get; set; }
    public CertParams ECDsa { get; set; }
  }

  internal class CertParams
  {
    public string DnsName { get; set; }
    public int ValidityInYear { get; set; }
    public string Password { get; set; }
  }
}
