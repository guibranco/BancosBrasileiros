// Converter.java

// To use this code, add the following Maven dependency to your project:
//
//
//     com.fasterxml.jackson.core : jackson-databind : 2.9.0
//
// Import this package:
//
//     import br.com.stracini.guilherme.bancosbrasileiros.Converter;
//
// Then you can deserialize a JSON string with
//
//     Bank[] data = Converter.fromJsonString(jsonString);

package br.com.stracini.guilherme.bancosbrasileiros;

import java.util.*;
import java.io.IOException;
import com.fasterxml.jackson.databind.*;
import com.fasterxml.jackson.core.JsonProcessingException;

public class Converter {
    // Serialize/deserialize helpers

    public static Bank[] fromJsonString(String json) throws IOException {
        return getObjectReader().readValue(json);
    }

    public static String toJsonString(Bank[] obj) throws JsonProcessingException {
        return getObjectWriter().writeValueAsString(obj);
    }

    private static ObjectReader reader;
    private static ObjectWriter writer;

    private static void instantiateMapper() {
        ObjectMapper mapper = new ObjectMapper();
        reader = mapper.readerFor(Bank[].class);
        writer = mapper.writerFor(Bank[].class);
    }

    private static ObjectReader getObjectReader() {
        if (reader == null) instantiateMapper();
        return reader;
    }

    private static ObjectWriter getObjectWriter() {
        if (writer == null) instantiateMapper();
        return writer;
    }
}

// Bank.java

package br.com.stracini.guilherme.bancosbrasileiros;

import java.util.*;
import com.fasterxml.jackson.annotation.*;

public class Bank {
    private String compe;
    private String ispb;
    private String document;
    private String longName;
    private String shortName;
    private String network;
    private String type;
    private String pixType;
    private String url;
    private String dateOperationStarted;
    private String datePixStarted;
    private String dateRegistered;
    private String dateUpdated;

    @JsonProperty("COMPE")
    public String getCompe() { return compe; }
    @JsonProperty("COMPE")
    public void setCompe(String value) { this.compe = value; }

    @JsonProperty("ISPB")
    public String getIspb() { return ispb; }
    @JsonProperty("ISPB")
    public void setIspb(String value) { this.ispb = value; }

    @JsonProperty("Document")
    public String getDocument() { return document; }
    @JsonProperty("Document")
    public void setDocument(String value) { this.document = value; }

    @JsonProperty("LongName")
    public String getLongName() { return longName; }
    @JsonProperty("LongName")
    public void setLongName(String value) { this.longName = value; }

    @JsonProperty("ShortName")
    public String getShortName() { return shortName; }
    @JsonProperty("ShortName")
    public void setShortName(String value) { this.shortName = value; }

    @JsonProperty("Network")
    public String getNetwork() { return network; }
    @JsonProperty("Network")
    public void setNetwork(String value) { this.network = value; }

    @JsonProperty("Type")
    public String getType() { return type; }
    @JsonProperty("Type")
    public void setType(String value) { this.type = value; }

    @JsonProperty("PixType")
    public String getPixType() { return pixType; }
    @JsonProperty("PixType")
    public void setPixType(String value) { this.pixType = value; }

    @JsonProperty("Url")
    public String getURL() { return url; }
    @JsonProperty("Url")
    public void setURL(String value) { this.url = value; }

    @JsonProperty("DateOperationStarted")
    public String getDateOperationStarted() { return dateOperationStarted; }
    @JsonProperty("DateOperationStarted")
    public void setDateOperationStarted(String value) { this.dateOperationStarted = value; }

    @JsonProperty("DatePixStarted")
    public String getDatePixStarted() { return datePixStarted; }
    @JsonProperty("DatePixStarted")
    public void setDatePixStarted(String value) { this.datePixStarted = value; }

    @JsonProperty("DateRegistered")
    public String getDateRegistered() { return dateRegistered; }
    @JsonProperty("DateRegistered")
    public void setDateRegistered(String value) { this.dateRegistered = value; }

    @JsonProperty("DateUpdated")
    public String getDateUpdated() { return dateUpdated; }
    @JsonProperty("DateUpdated")
    public void setDateUpdated(String value) { this.dateUpdated = value; }
}
