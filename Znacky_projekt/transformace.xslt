<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:output method="text" encoding="UTF-8" indent="yes"/>

    <xsl:template match="/">
{
  "klinika": {
    "nazev": "<xsl:value-of select="klinika/nazev"/>",
    "adresa": {
      "ulice": "<xsl:value-of select="klinika/adresa/ulice"/>",
      "mesto": "<xsl:value-of select="klinika/adresa/mesto"/>",
      "psc": "<xsl:value-of select="klinika/adresa/psc"/>",
      "stat": "<xsl:value-of select="klinika/adresa/stat"/>"
    },
    "kontakt": {
      "telefon": "<xsl:value-of select="klinika/kontakt/telefon"/>",
      "email": "<xsl:value-of select="klinika/kontakt/email"/>",
      "web": "<xsl:value-of select="klinika/kontakt/web"/>"
    },
    "sluzby": [
      <xsl:for-each select="klinika/sluzby/sluzba">
        {
          "nazev": "<xsl:value-of select="nazevSluzby"/>",
          "popis": "<xsl:value-of select="popisSluzby"/>",
          "cena": "<xsl:value-of select="cena"/>",
          "dobaTrvani": "<xsl:value-of select="dobaTrvani"/>",
          "specializace": "<xsl:value-of select="specializace"/>"
        }<xsl:if test="position() != last()">,</xsl:if>
      </xsl:for-each>
    ],
    "lekari": [
      <xsl:for-each select="klinika/lekari/lekar">
        <xsl:sort select="prijmeni" order="ascending"/>
        {
          "jmeno": "<xsl:value-of select="jmeno"/>",
          "prijmeni": "<xsl:value-of select="prijmeni"/>",
          "specializace": "<xsl:value-of select="specializace"/>",
          "email": "<xsl:value-of select="email"/>",
          "telefon": "<xsl:value-of select="telefon"/>"
        }<xsl:if test="position() != last()">,</xsl:if>
      </xsl:for-each>
    ],
    "novinky": [
      <xsl:for-each select="klinika/novinky/novinka">
        <xsl:choose>
          <xsl:when test="starts-with(titulek, 'Nová')">
            {
              "typ": "důležitá",
              "titulek": "<xsl:value-of select="titulek"/>",
              "obsah": "<xsl:value-of select="obsah"/>",
              "datum": "<xsl:value-of select="datum"/>"
            }
          </xsl:when>
          <xsl:otherwise>
            {
              "typ": "běžná",
              "titulek": "<xsl:value-of select="titulek"/>",
              "obsah": "<xsl:value-of select="obsah"/>",
              "datum": "<xsl:value-of select="datum"/>"
            }
          </xsl:otherwise>
        </xsl:choose>
        <xsl:if test="position() != last()">,</xsl:if>
      </xsl:for-each>
    ]
  }
}
    </xsl:template>

</xsl:stylesheet>
