// See https://aka.ms/new-console-template for more information
using CertificateManager;
using RsaCertificateGenerator;
using RsaCertificateGenerator.Models;

Console.WriteLine("Reading ./appsettings.json file and generating certificates.");

string appsettings = File.ReadAllText("./appsettings.json");
var config = System.Text.Json.JsonSerializer.Deserialize<Config>(appsettings);

var certGenerator = new CertGenerator();
var rsaCert = certGenerator.CreateRsaCertificate(config.RSA.DnsName, config.RSA.ValidityInYear);
var ecdsaCert = certGenerator.CreateECDsaCertificate(config.ECDsa.DnsName, config.ECDsa.ValidityInYear);

var iec = new ImportExportCertificate();

var rsaCertPfxBytes = iec.ExportSelfSignedCertificatePfx(config.RSA.Password, rsaCert);
File.WriteAllBytes("./rsa_cert.pfx", rsaCertPfxBytes);

var ecdsaCertPfxBytes = iec.ExportSelfSignedCertificatePfx(config.ECDsa.Password, ecdsaCert);
File.WriteAllBytes("./ecdsa_cert.pfx", ecdsaCertPfxBytes);

Console.WriteLine("Certificates have been generated in the program directory.");
