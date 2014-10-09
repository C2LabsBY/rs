<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
	version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:msxml="urn:schemas-microsoft-com:xslt"
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" 
	exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">


<xsl:output method="xml" omit-xml-declaration="yes"/>

<xsl:param name="currentPage"/>

<xsl:template match="/">
	<xsl:variable name="source" select="$currentPage/ancestor-or-self::root/Navigation[@nodeName='Navigation']" />
	<ul>
		<xsl:for-each select="$source/navigation_item">
			<!--xsl:variable name="item" select="." /-->
			
			<xsl:if test="hyperlink != ''">
				<!-- GET CORRECT LINK INCLUDING URL ALIAS -->
				<xsl:variable name="targetPage" select="umbraco.library:GetXmlNodeById(hyperlink)" />
				<xsl:variable name="correctLink">
					<xsl:choose>
						<!-- If it has an alias assigned, use that -->
						<xsl:when test="normalize-space($targetPage/umbracoUrlAlias)">
							<xsl:value-of select="concat('/', $targetPage/umbracoUrlAlias)" />
						</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="umbraco.library:NiceUrl(hyperlink)" />
						</xsl:otherwise>
					</xsl:choose>
				</xsl:variable>
				<!-- / GET CORRECT LINK INCLUDING URL ALIAS -->
				<li class="child-menu">
					<a href="{$correctLink}"><xsl:value-of select="navigation_label"/></a>
						<xsl:if test="count(navigation_item)">
							<section class="sub-menu">
								<ul>
								<xsl:for-each select="navigation_item">
									<xsl:if test="hyperlink != ''">
										<!-- GET CORRECT LINK INCLUDING URL ALIAS -->
										<xsl:variable name="targetPage2" select="umbraco.library:GetXmlNodeById(hyperlink)" />
										<xsl:variable name="correctLink2">
											<xsl:choose>
												<!-- If it has an alias assigned, use that -->
												<xsl:when test="normalize-space($targetPage2/umbracoUrlAlias)">
													<xsl:value-of select="concat('/', $targetPage2/umbracoUrlAlias)" />
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="umbraco.library:NiceUrl(hyperlink)" />
												</xsl:otherwise>
											</xsl:choose>
										</xsl:variable>
										<!-- / GET CORRECT LINK INCLUDING URL ALIAS -->
										<li>
											<a href="{$correctLink2}"><xsl:value-of select="navigation_label" /></a>
										</li>
									</xsl:if>
								</xsl:for-each>
								</ul>
							</section>
						</xsl:if>
					</li>
			</xsl:if>
		</xsl:for-each>
	</ul>
</xsl:template>

</xsl:stylesheet>