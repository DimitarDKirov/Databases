<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:urn="http://www.telerikacademy.com/students"
    xmlns:exam="http://www.telerikacademy.com/exams">
  <xsl:template match="/">
    <html>
      <head>
        <style>
            table, tr, th, td {
              border: 1px solid black;
              border-collapse: collapse;
              padding: 5px;
              margin: 15px;
            }

            th {
              text-align: center;
            }
        </style>
      </head>
      <body>
        <h1>7. Write an XSL stylesheet to visualize the students as HTML.</h1>
        You may test tranform at <a href="http://xsltransform.net/">http://xsltransform.net/</a>

        <hr/>
        <xsl:for-each select="urn:students/urn:student">
            <h3>
              <xsl:value-of select="urn:name"/>
            </h3>
          <ul>
            <li>
              <xsl:value-of select="urn:sex"/>,
              <strong>born on: </strong><xsl:value-of select="urn:birthDate"/>
            </li>
            <li>
              <strong>Phone: </strong><xsl:value-of select="urn:phone"/>,
              <strong>e-mail: </strong><xsl:value-of select="urn:email"/>
            </li>
            <li>
              <strong>Specialty: </strong><xsl:value-of select="urn:specialty"/>,
              <strong>course: </strong><xsl:value-of select="urn:course"/>
              <strong>FN: </strong><xsl:value-of select="urn:facultyNumber"/>
            </li>
            <li>
              <strong>Exams:</strong>
              <table>
                <tr>
                  <th>Subject</th>
                  <th>Tutor</th>
                  <th>Score</th>
                </tr>
                <xsl:for-each select="urn:exams/exam:exam">
                  <tr>
                    <td>
                      <xsl:value-of select="exam:name"/>
                    </td>
                    <td>
                      <xsl:value-of select="exam:tutor"/>
                    </td>
                    <td>
                      <xsl:value-of select="exam:score"/>
                    </td>
                  </tr>
                </xsl:for-each>
              </table>
            </li>
          </ul>
        </xsl:for-each>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
