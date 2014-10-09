<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [ <!ENTITY nbsp "&#x00A0;"> ]>
<xsl:stylesheet 
	version="1.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:msxml="urn:schemas-microsoft-com:xslt" 
	xmlns:umbraco.library="urn:umbraco.library" xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon" xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes" xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath" xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions" xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings" xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets" 
	exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions Exslt.ExsltStrings Exslt.ExsltSets ">

<xsl:output method="html" omit-xml-declaration="yes" />

<xsl:param name="currentPage"/>

<xsl:template match="/">
<xsl:if test="$currentPage/x4Navigation != ''">
	<xsl:variable name="source" select="umbraco.library:GetXmlNodeById($currentPage/x4Navigation)" />
	<section class="front-content-tab-nav-wrap">
		<ul class="nav"><!-- TAB NAV -->
			<xsl:for-each select="$source/navigation_item">
				<li>
					<xsl:attribute name="class">nav-<xsl:value-of select="position()"/></xsl:attribute>
					<a>
						<xsl:if test="position() = 1">
							<xsl:attribute name="class">current</xsl:attribute>
						</xsl:if>
						<xsl:attribute name="href">#fr-<xsl:value-of select="position()"/></xsl:attribute>
						<xsl:value-of select="navigation_label"/>
					</a>
				</li>
			</xsl:for-each>
		</ul>
		<!-- TAB NAV --> 
	</section>
	<section class="content-tab2-outer">
		<!-- CONTENT TAB2 OUTER -->
        <section class="list-wrap">
			<!-- TAB LIST WRAP -->
			<xsl:for-each select="$source/navigation_item">
				<section>
					<xsl:attribute name="id">fr-<xsl:value-of select="position()"/></xsl:attribute>
					<xsl:if test="position() != 1">
						<xsl:attribute name="class">hide</xsl:attribute>
						<xsl:attribute name="style">display: none;</xsl:attribute>
					</xsl:if>
					<section class="tab-inner-data clearfix">
					  <ul class="buying-property">
						  <xsl:for-each select="./navigation_item">
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
								<li> 
									<a href="{$correctLink}"> 
										<span class="icons">
											<!--xsl:attribute name="class">icons step<xsl:value-of select="position()"/></xsl:attribute-->
											<xsl:if test="string(naviIcon) != ''">
												<xsl:variable name="iconFile" select="umbraco.library:GetMedia(string(naviIcon), false)"/>
												<xsl:if test="$iconFile != ''">
													<img src='{$iconFile/umbracoFile}.ashx?w=69&amp;h=69' alt='{navigation_label}'/>
												</xsl:if>
											</xsl:if>
										</span>
										<xsl:value-of select="navigation_label"/> 
									</a> 
								</li>
							</xsl:if>

						</xsl:for-each>
					  </ul>
					</section>
				  </section>
			</xsl:for-each>
		</section>
        <!-- END List Wrap --> 
    </section>
    <!-- /CONTENT TAB2 OUTER -->
    <div class="clear"></div>
</xsl:if>
</xsl:template>

</xsl:stylesheet>