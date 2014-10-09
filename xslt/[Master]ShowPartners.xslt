<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
	version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:msxml="urn:schemas-microsoft-com:xslt"
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" 
	exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">


<xsl:output method="html" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
	<xsl:variable name="homepage" select="$currentPage/ancestor-or-self::root/Homepage" />
	<xsl:if test="$homepage/linkToPartnersFolder != ''">
		<xsl:variable name="source" select="umbraco.library:GetXmlNodeById($homepage/linkToPartnersFolder)" />
		<xsl:for-each select="$source/partner">
			<xsl:variable name="iconLink" select="naviIcon"/>
			<xsl:variable name="label" select="navigation_label"/>
			<xsl:for-each select="hyperlink/links/link">
				  <xsl:value-of select="$label"/>
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
						  <xsl:value-of select="umbraco.library:NiceUrl(./@link)"/>
						</xsl:attribute>
					  </xsl:otherwise>
					</xsl:choose>
					<xsl:choose>
						<xsl:when test="$iconLink != ''">
							<xsl:variable name="iconFile" select="umbraco.library:GetMedia(string($iconLink), false)"/>
							<img src='{$iconFile/umbracoFile}.ashx?h=24' alt='{$label}'/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="./@title"/>
						</xsl:otherwise>
					</xsl:choose>
				  </xsl:element>
			  </xsl:for-each>
		</xsl:for-each>
	</xsl:if>
</xsl:template>

</xsl:stylesheet>