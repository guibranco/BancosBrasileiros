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

import java.io.Serializable;
import java.util.HashMap;
import java.util.Map;
import javax.annotation.Generated;
import com.fasterxml.jackson.annotation.JsonAnyGetter;
import com.fasterxml.jackson.annotation.JsonAnySetter;
import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonPropertyOrder;
@JsonInclude(JsonInclude.Include.NON_NULL)
@JsonPropertyOrder({
"COMPE",
"ISPB",
"Document",
"LongName",
"ShortName",
"Network",
"Type",
"PixType",
"Charge",
"CreditDocument",
"LegalCheque",
"DetectaFlow",
"SalaryPortability",
"Products",
"Url",
"DateOperationStarted",
"DatePixStarted",
"DateRegistered",
"DateUpdated"
})
@Generated("jsonschema2pojo")
public class Bank implements Serializable
{

@JsonProperty("COMPE")//Compensação de Cheques e Outros Papéis
private String compe;
@JsonProperty("ISPB")//Identificador de Sistema de Pagamento Brasileiro
private String ispb;
@JsonProperty("Document")
private String document;
@JsonProperty("LongName")
private String longName;
@JsonProperty("ShortName")
private String shortName;
@JsonProperty("Network")
private String network;
@JsonProperty("Type")
private Object type;
@JsonProperty("PixType")
private Object pixType;
@JsonProperty("Charge")
private Object charge;
@JsonProperty("CreditDocument")
private Object creditDocument;
@JsonProperty("LegalCheque")
private Object legalCheque;
@JsonProperty("DetectaFlow")
private Object detectaFlow;
@JsonProperty("SalaryPortability")
private Object salaryPortability;
@JsonProperty("Products")
private Object products;
@JsonProperty("Url")
private Object url;
@JsonProperty("DateOperationStarted")
private String dateOperationStarted;
@JsonProperty("DatePixStarted")
private Object datePixStarted;
@JsonProperty("DateRegistered")
private String dateRegistered;
@JsonProperty("DateUpdated")
private String dateUpdated;
@JsonIgnore
private Map<String, Object> additionalProperties = new HashMap<String, Object>();
private final static long serialVersionUID = -2503816616111349162L;

@JsonProperty("COMPE")
public String getCompe() {
return compe;
}

@JsonProperty("COMPE")
public void setCompe(String compe) {
this.compe = compe;
}

public Bank withCompe(String compe) {
this.compe = compe;
return this;
}

@JsonProperty("ISPB")
public String getIspb() {
return ispb;
}

@JsonProperty("ISPB")
public void setIspb(String ispb) {
this.ispb = ispb;
}

public Bank withIspb(String ispb) {
this.ispb = ispb;
return this;
}

@JsonProperty("Document")
public String getDocument() {
return document;
}

@JsonProperty("Document")
public void setDocument(String document) {
this.document = document;
}

public Bank withDocument(String document) {
this.document = document;
return this;
}

@JsonProperty("LongName")
public String getLongName() {
return longName;
}

@JsonProperty("LongName")
public void setLongName(String longName) {
this.longName = longName;
}

public Bank withLongName(String longName) {
this.longName = longName;
return this;
}

@JsonProperty("ShortName")
public String getShortName() {
return shortName;
}

@JsonProperty("ShortName")
public void setShortName(String shortName) {
this.shortName = shortName;
}

public Bank withShortName(String shortName) {
this.shortName = shortName;
return this;
}

@JsonProperty("Network")
public String getNetwork() {
return network;
}

@JsonProperty("Network")
public void setNetwork(String network) {
this.network = network;
}

public Bank withNetwork(String network) {
this.network = network;
return this;
}

@JsonProperty("Type")
public Object getType() {
return type;
}

@JsonProperty("Type")
public void setType(Object type) {
this.type = type;
}

public Bank withType(Object type) {
this.type = type;
return this;
}

@JsonProperty("PixType")
public Object getPixType() {
return pixType;
}

@JsonProperty("PixType")
public void setPixType(Object pixType) {
this.pixType = pixType;
}

public Bank withPixType(Object pixType) {
this.pixType = pixType;
return this;
}

@JsonProperty("Charge")
public Object getCharge() {
return charge;
}

@JsonProperty("Charge")
public void setCharge(Object charge) {
this.charge = charge;
}

public Bank withCharge(Object charge) {
this.charge = charge;
return this;
}

@JsonProperty("CreditDocument")
public Object getCreditDocument() {
return creditDocument;
}

@JsonProperty("CreditDocument")
public void setCreditDocument(Object creditDocument) {
this.creditDocument = creditDocument;
}

public Bank withCreditDocument(Object creditDocument) {
this.creditDocument = creditDocument;
return this;
}

@JsonProperty("LegalCheque")
public Object getLegalCheque() {
return legalCheque;
}

@JsonProperty("LegalCheque")
public void setLegalCheque(Object legalCheque) {
this.legalCheque = legalCheque;
}

public Bank withLegalCheque(Object legalCheque) {
this.legalCheque = legalCheque;
return this;
}

@JsonProperty("DetectaFlow")
public Object getDetectaFlow() {
return detectaFlow;
}

@JsonProperty("DetectaFlow")
public void setDetectaFlow(Object detectaFlow) {
this.detectaFlow = detectaFlow;
}

public Bank withDetectaFlow(Object detectaFlow) {
this.detectaFlow = detectaFlow;
return this;
}

@JsonProperty("SalaryPortability")
public Object getSalaryPortability() {
return salaryPortability;
}

@JsonProperty("SalaryPortability")
public void setSalaryPortability(Object salaryPortability) {
this.salaryPortability = salaryPortability;
}

public Bank withSalaryPortability(Object salaryPortability) {
this.salaryPortability = salaryPortability;
return this;
}

@JsonProperty("Products")
public Object getProducts() {
return products;
}

@JsonProperty("Products")
public void setProducts(Object products) {
this.products = products;
}

public Bank withProducts(Object products) {
this.products = products;
return this;
}

@JsonProperty("Url")
public Object getUrl() {
return url;
}

@JsonProperty("Url")
public void setUrl(Object url) {
this.url = url;
}

public Bank withUrl(Object url) {
this.url = url;
return this;
}

@JsonProperty("DateOperationStarted")
public String getDateOperationStarted() {
return dateOperationStarted;
}

@JsonProperty("DateOperationStarted")
public void setDateOperationStarted(String dateOperationStarted) {
this.dateOperationStarted = dateOperationStarted;
}

public Bank withDateOperationStarted(String dateOperationStarted) {
this.dateOperationStarted = dateOperationStarted;
return this;
}

@JsonProperty("DatePixStarted")
public Object getDatePixStarted() {
return datePixStarted;
}

@JsonProperty("DatePixStarted")
public void setDatePixStarted(Object datePixStarted) {
this.datePixStarted = datePixStarted;
}

public Bank withDatePixStarted(Object datePixStarted) {
this.datePixStarted = datePixStarted;
return this;
}

@JsonProperty("DateRegistered")
public String getDateRegistered() {
return dateRegistered;
}

@JsonProperty("DateRegistered")
public void setDateRegistered(String dateRegistered) {
this.dateRegistered = dateRegistered;
}

public Bank withDateRegistered(String dateRegistered) {
this.dateRegistered = dateRegistered;
return this;
}

@JsonProperty("DateUpdated")
public String getDateUpdated() {
return dateUpdated;
}

@JsonProperty("DateUpdated")
public void setDateUpdated(String dateUpdated) {
this.dateUpdated = dateUpdated;
}

public Bank withDateUpdated(String dateUpdated) {
this.dateUpdated = dateUpdated;
return this;
}

@JsonAnyGetter
public Map<String, Object> getAdditionalProperties() {
return this.additionalProperties;
}

@JsonAnySetter
public void setAdditionalProperty(String name, Object value) {
this.additionalProperties.put(name, value);
}

public Bank withAdditionalProperty(String name, Object value) {
this.additionalProperties.put(name, value);
return this;
}

}