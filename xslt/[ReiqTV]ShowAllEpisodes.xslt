<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
	version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:msxml="urn:schemas-microsoft-com:xslt"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt"
	xmlns:scripts="urn:testscripts"
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" 
	exclude-result-prefixes="msxml msxsl umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
	<section class="sidebar-block"><!-- SIDEBAR BLOCK -->
		<ul class="sidebar-key-info">
			<xsl:for-each select="$currentPage/ancestor-or-self::*[@level = ($currentPage/@level - 1)]/ReiqTV">
				<xsl:if test="@id != $currentPage/@id">
					<!-- GET CORRECT LINK INCLUDING URL ALIAS -->
					<xsl:variable name="correctLink">
						<xsl:choose>
							<!-- If it has an alias assigned, use that -->
							<xsl:when test="normalize-space(umbracoUrlAlias)">
								<xsl:value-of select="concat('/', umbracoUrlAlias)" />
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="umbraco.library:NiceUrl(@id)" />
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					<!-- / GET CORRECT LINK INCLUDING URL ALIAS -->
					<li>
						<figure class="key-img"><a href="{$correctLink}">
							<img src="{scripts:getImageUrl(video)}" alt="{@nodeName}" /></a>
						</figure>
						<p class="key-data"><a href="{$correctLink}"><xsl:value-of select="@nodeName"/></a></p>
						<p><xsl:value-of select="description"/></p>
						<p><xsl:value-of select="duration"/>&nbsp;
						<xsl:value-of select="umbraco.library:FormatDateTime(date, 'MMMM d, yyyy')"/></p>
					</li>
				</xsl:if>							
			</xsl:for-each>
		</ul>
	</section><!-- /SIDEBAR BLOCK -->
</xsl:template>

<msxsl:script language="C#" implements-prefix="scripts">
    <![CDATA[
    public string getImageUrl(string youTubeEmbed)
    {
		string url = "http://img.youtube.com/vi/{0}/1.jpg";
		youTubeEmbed = youTubeEmbed.Remove(youTubeEmbed.IndexOf('?'));
		youTubeEmbed = youTubeEmbed.Substring(youTubeEmbed.IndexOf("www.youtube.com/embed") + 22);
        return String.Format(url, youTubeEmbed);
    }
    ]]>
</msxsl:script>
		
</xsl:stylesheet>
