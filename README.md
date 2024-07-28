<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
 
</head>
<body>

<h1>SecureWebUtilsApi</h1>

<p>SecureWebUtilsApi is a Web API project designed to provide utility methods for sanitizing URLs and escaping potentially dangerous inputs. The API helps to prevent XSS (Cross-Site Scripting) and other injection attacks by validating and cleaning user inputs.</p>

<h2>Features</h2>
<ul>
    <li><strong>URL Sanitization</strong>: Validate and sanitize URLs to ensure they are safe and from trusted domains.</li>
    <li><strong>Input Escaping</strong>: Escape HTML and URL inputs to prevent XSS attacks.</li>
    <li><strong>Pattern Matching</strong>: Identify potentially dangerous patterns in inputs.</li>
</ul>

<h2>Endpoints</h2>

<h3>Sanitize URL</h3>
<p><strong>Endpoint</strong>: <code>POST /api/sanitization/sanitize-url</code></p>
<p><strong>Description</strong>: This endpoint validates and sanitizes a given URL, ensuring it is from a trusted domain and free of dangerous patterns.</p>
<p><strong>Request Body</strong>:</p>
<pre><code>{
    "url": "https://www.example.com"
}</code></pre>
<p><strong>Response</strong>:</p>
<pre><code>{
    "SanitizedUrl": "https://www.example.com/",
    "EscapedUrl": "https%3A%2F%2Fwww.example.com%2F"
}</code></pre>

<h3>Escape Input</h3>
<p><strong>Endpoint</strong>: <code>POST /api/sanitization/escape-input</code></p>
<p><strong>Description</strong>: This endpoint escapes a given input to make it safe for HTML embedding, preventing XSS attacks.</p>
<p><strong>Request Body</strong>:</p>
<pre><code>{
    "input": "&lt;script&gt;alert('XSS Attack!')&lt;/script&gt;"
}</code></pre>
<p><strong>Response</strong>:</p>
<pre><code>{
    "EscapedOutput": "&amp;lt;script&amp;gt;alert(&amp;#39;XSS Attack!&amp;#39;)&amp;lt;/script&amp;gt;"
}</code></pre>

<h3>Get Dangerous Patterns</h3>
<p><strong>Endpoint</strong>: <code>GET /api/sanitization/dangerous-patterns</code></p>
<p><strong>Description</strong>: This endpoint returns a list of regular expressions used to identify potentially dangerous patterns in inputs.</p>
<p><strong>Response</strong>:</p>
<pre><code>[
    "&lt;script.*?&gt;.*?&lt;/script.*?&gt;",
    "javascript:",
    "data:",
    "vbscript:",
    "&lt;.*?on\\w+.*?=.*?&gt;",
    "eval\\(",
    "expression\\(",
    "\\b(require|socket|exec|md5|nslookup|gethostbyname)\\b",
    "base64_decode",
    "concat\\(",
    "assert\\(",
    "\\bperl\\b",
    "\\bpython\\b",
    "\\bphp\\b",
    "(dns|jndi).*?//"
]</code></pre>

<h2>Example Data for Testing</h2>

<h3>URL Sanitization</h3>

<h4>Valid URLs</h4>
<pre><code>{
    "url": "https://www.example.com"
}</code></pre>
<pre><code>{
    "url": "ftp://fileserver.com/file.txt"
}</code></pre>

<h4>Invalid URLs</h4>
<pre><code>{
    "url": "invalid-url"
}</code></pre>
<pre><code>{
    "url": "http://untrusted-domain.com/test?param=+A'.concat(70-3).concat(22*4).concat(111).concat(82).concat(97).concat(81)+(require'socket' Socket"
}</code></pre>

<h3>Input Escaping</h3>

<h4>Inputs with Potential XSS</h4>
<pre><code>{
    "input": "&lt;script&gt;alert('XSS Attack!')&lt;/script&gt;"
}</code></pre>
<pre><code>{
    "input": "'+A'.concat(70-3).concat(22*4).concat(111).concat(82).concat(97).concat(81)+(require'socket' Socket"
}</code></pre>

<h4>Inputs with SQL Injection</h4>
<pre><code>{
    "input": "SELECT * FROM users WHERE username = 'admin' --"
}</code></pre>
<pre><code>{
    "input": "DROP TABLE users;"
}</code></pre>

<h2>Installation</h2>
<ol>
    <li>Clone the repository:
        <pre><code>git clone https://github.com/yourusername/SecureWebUtilsApi.git</code></pre>
    </li>
    <li>Navigate to the project directory:
        <pre><code>cd SecureWebUtilsApi</code></pre>
    </li>
    <li>Restore the dependencies:
        <pre><code>dotnet restore</code></pre>
    </li>
    <li>Build the project:
        <pre><code>dotnet build</code></pre>
    </li>
    <li>Run the application:
        <pre><code>dotnet run</code></pre>
    </li>
</ol>
<p>The API will be available at <code>https://localhost:7255</code> by default.</p>

<h2>Usage</h2>
<p>Use tools like Postman, curl, or any HTTP client to test the endpoints as described in the <a href="#endpoints">Endpoints</a> section.</p>

<h2>Contributing</h2>
<p>Contributions are welcome! Please open an issue or submit a pull request for any changes or improvements.</p>

<h2>License</h2>
<p>This project is licensed under the MIT License. See the <a href="LICENSE">LICENSE</a> file for details.</p>

</body>
</html>
