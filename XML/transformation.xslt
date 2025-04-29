<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:json="http://json.org">
    <xsl:output method="text"/>

    <xsl:template match="/">
        {
        "prices": [
            <xsl:apply-templates select="//price[value > 200]">
                <xsl:sort select="value" data-type="number" order="ascending"/>
            </xsl:apply-templates>
        ]
        }
    </xsl:template>

    <xsl:template match="price">
        {
        "value": <xsl:value-of select="value"/>,
        <xsl:if test="discount">
        ,"discount": "<xsl:value-of select="discount"/>"
        </xsl:if>
        }<xsl:if test="position()!=last()">,</xsl:if>
    </xsl:template>

</xsl:stylesheet>