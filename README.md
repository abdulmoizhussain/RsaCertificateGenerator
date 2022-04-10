# RsaCertificateGenerator

## NOTE: I would recommend you to use the PowerShell method (method given below) if possible:

### App Details:
Generates .pfx files of RSA & ECDsa certificates.

This project is created especially to be helpful for IdentityServer4.

Amendments will/can be made, as needed.

### How to use this app:
- Download the release.
- Populate the `appsettings.json` file according to your need.
- Then execute the app to generate .pfx files.


### How to utilize the generated certificates in IdentityServer4:

```javascript
private System.Security.Cryptography.X509Certificates.X509Certificate2 GetCertificate()
{
  return new System.Security.Cryptography.X509Certificates.X509Certificate2("./JwtCertificate/rsa_cert.pfx", Configuration["JwtCertificate:Password"]);
}
```

```javascript
services
        .AddIdentityServer()
        // ...
        .AddSigningCredential(GetCertificate());
```


## Powershell Method:

- To generate a certificate, with a validity of 3 years:
- $cert = New-SelfSignedCertificate -Subject "CN=WebApiNetCore" –NotAfter (Get-Date).AddYears(3) -CertStoreLocation cert:\CurrentUser\My -Provider "Microsoft Strong Cryptographic Provider"
- 
- 
- To list all the certificates:
- Get-ChildItem -Path cert:\CurrentUser\My
- 
- To display all the properties of a certificate by Thumbprint:
- Get-ChildItem -Path "Cert:\CurrentUser\My" | Where-Object Thumbprint -eq 2175A76B10F843676951965F52A718F635FFA043 | Select-Object *
-
- To remove a certificate:
- Remove-Item -Path ("cert:\CurrentUser\My\" + $cert.Thumbprint)
- OR
- Remove-Item -Path ("cert:\CurrentUser\My\2175A76B10F843676951965F52A718F635FFA043")
- 
- To load the certificate (by certificate name) into powershell variable ($mycert):
- $mycert = Get-ChildItem -Path cert:\CurrentUser\My | ?{$_.Subject -eq "CN=TodoListDaemonWithCert"}
- 
- To Export the private key, first we need to ask password from user and save that in a "System.Security.SecureString" variable:
- Prompt user to enter password securely:
- $cert_pass = Read-Host "Enter certificate password" -AsSecureString
-
- Now use that variable in the export command:
- Export-PfxCertificate -Cert $cert -Password $cert_pass -FilePath ".\cert.pfx"



### Sources:
- https://damienbod.com/2020/02/10/create-certificates-for-identityserver4-signing-using-net-core/
- https://www.youtube.com/watch?v=gnUM3cB3_co
- https://docs.microsoft.com/en-us/archive/blogs/kaevans/using-powershell-with-certificates
- https://docs.microsoft.com/en-us/powershell/module/pki/new-selfsignedcertificate (New-SelfSignedCertificate Microsoft Docs)
- http://woshub.com/how-to-create-self-signed-certificate-with-powershell (To display all the properties and how to use -NotAfter parameter)
