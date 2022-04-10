# RsaCertificateGenerator

Generates .pfx files of RSA & ECDsa certificates.

This project is created especially to be helpful for IdentityServer4.

Amendments will/can be made, as needed.


Helpful sources:
- https://damienbod.com/2020/02/10/create-certificates-for-identityserver4-signing-using-net-core/
- https://www.youtube.com/watch?v=gnUM3cB3_co
- https://docs.microsoft.com/en-us/archive/blogs/kaevans/using-powershell-with-certificates


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
