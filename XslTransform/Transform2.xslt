<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html> 
  <body>
    <h2>TestClass</h2>
    <table border="1">
      <tr bgcolor="#9acd32">
        <th style="text-align:left">Settings1</th>
        <th style="text-align:left">Settings2</th>
        <th style="text-align:left">Settings3</th>
        <th style="text-align:left">SomeString</th>
      </tr>
      <xsl:for-each select="ArrayOfTestClass/TestClass">
        <tr>
          <xsl:for-each select="Settings/string">
            <td>
              <xsl:value-of select="text()"/>
            </td>
          </xsl:for-each>        
          <td>
            <xsl:value-of select="SomeString"/>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </body>
</html>
</xsl:template>
</xsl:stylesheet>

