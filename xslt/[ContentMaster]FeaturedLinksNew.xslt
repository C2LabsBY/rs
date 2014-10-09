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
<xsl:variable name="linksGroupId" select="$currentPage/featuredLinksGroup" /> 
<xsl:template match="/">
	<xsl:if test="$linksGroupId != ''">
		<xsl:variable name="linksFolder" select="umbraco.library:GetXmlNodeById($linksGroupId)" />	

		<section class="sidebar-block"><!-- SIDEBAR BLOCK -->
			
			<xsl:if test="count($linksFolder/FeaturedLink) > 0">
				
				<h2>
					<xsl:if test="$currentPage/feaaturedLinksHeading != ''"><xsl:value-of select="$currentPage/feaaturedLinksHeading" /></xsl:if>			
				</h2>			
					<ul class="sidebar-key-info">
						<xsl:for-each select="$linksFolder/FeaturedLink">
							<xsl:if test="title != ''">
								<xsl:variable name="link">
									<xsl:choose>
										<xsl:when test="hyperlinkExternal != ''"><xsl:value-of select="hyperlinkExternal" /></xsl:when>
										<xsl:otherwise>
											<xsl:choose>
												<xsl:when test="hyperlinkInternal != ''">
													<!-- GET CORRECT LINK INCLUDING URL ALIAS -->
													<xsl:variable name="targetPage" select="umbraco.library:GetXmlNodeById(hyperlinkInternal)" />
													<xsl:choose>
														<!-- If it has an alias assigned, use that -->
														<xsl:when test="normalize-space($targetPage/umbracoUrlAlias)">
															<xsl:value-of select="concat('/', $targetPage/umbracoUrlAlias)" />
														</xsl:when>
														<xsl:otherwise>
															<xsl:value-of select="umbraco.library:NiceUrl(hyperlinkInternal)" />
														</xsl:otherwise>
													</xsl:choose>
													<!-- / GET CORRECT LINK INCLUDING URL ALIAS -->
												</xsl:when>									
												<xsl:otherwise>#</xsl:otherwise>
											</xsl:choose>
										</xsl:otherwise>
									</xsl:choose>
								</xsl:variable>							
								<li>
									<xsl:if test="displayImage != ''">
										<figure class="key-img"><a href="{$link}">
											<img src="{umbraco.library:GetMedia(displayImage, 0)/umbracoFile}.ashx?w=75" alt="{title}" /></a>
										</figure>
									</xsl:if>
									<p class="key-data"><a href="{$link}"><xsl:value-of select="title" /></a></p>
								</li>
							</xsl:if>							
						</xsl:for-each>
					</ul>
			</xsl:if>	
		</section><!-- /SIDEBAR BLOCK -->
	</xsl:if>
</xsl:template>

</xsl:stylesheet>