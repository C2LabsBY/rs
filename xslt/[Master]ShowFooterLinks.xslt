<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [  <!ENTITY nbsp "&#x00A0;">]>
<xsl:stylesheet
	version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxml="urn:schemas-microsoft-com:xslt" 
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" 
	exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">


  <xsl:output method="xml" omit-xml-declaration="yes" />

  <xsl:param name="currentPage"/>
  <xsl:param name="propertyAlias" select="/macro/propertyAlias" />
  
  <xsl:template match="/">
  <xsl:if test="$propertyAlias != ''">
	  <xsl:variable name="source" select="$currentPage/ancestor-or-self::root/Homepage" />
      <xsl:for-each select="$source/* [name() = $propertyAlias and not(@isDoc)]/links/link">
          <xsl:element name="a">
            <xsl:if test="./@newwindow = '1'">
              <xsl:attribute name="target">_blank</xsl:attribute>
            </xsl:if>
            <xsl:choose>
              <xsl:when test="./@type = 'external'">
                <xsl:attribute name="href">
                  <xsl:value-of select="./@link"/>
                </xsl:attribute>
              </xsl:when>
              <xsl:otherwise>
                <xsl:attribute name="href">
					<!-- GET CORRECT LINK INCLUDING URL ALIAS -->
					<xsl:variable name="targetPage" select="umbraco.library:GetXmlNodeById(./@link)" />
					<xsl:choose>
						<!-- If it has an alias assigned, use that -->
						<xsl:when test="normalize-space($targetPage/umbracoUrlAlias)">
							<xsl:value-of select="concat('/', $targetPage/umbracoUrlAlias)" />
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="umbraco.library:NiceUrl(./@link)" />
						</xsl:otherwise>
					</xsl:choose>
					<!-- / GET CORRECT LINK INCLUDING URL ALIAS -->
                </xsl:attribute>
              </xsl:otherwise>
            </xsl:choose>
            <xsl:value-of select="./@title"/>
          </xsl:element>
		  <xsl:if test="position() != last()"> | </xsl:if>
      </xsl:for-each>

    <!-- Live Editing support for related links. -->
    <xsl:value-of select="umbraco.library:Item($currentPage/@id,$propertyAlias,'')" />
  </xsl:if>
  </xsl:template>

</xsl:stylesheet>