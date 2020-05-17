// To parse the JSON, install Klaxon and do:
//
//   val bank = Bank.fromJson(jsonString)

package br.com.stracini.guilherme.bancosbrasileiros

import com.beust.klaxon.*

private val klaxon = Klaxon()

class Bank(elements: Collection<BankElement>) : ArrayList<BankElement>(elements) {
    public fun toJson() = klaxon.toJsonString(this)

    companion object {
        public fun fromJson(json: String) = Bank(klaxon.parseArray<BankElement>(json)!!)
    }
}

data class BankElement (
    @Json(name = "COMPE")
    val compe: String,

    @Json(name = "ISPB")
    val ispb: String,

    @Json(name = "Document")
    val document: String,

    @Json(name = "FiscalName")
    val fiscalName: String,

    @Json(name = "FantasyName")
    val fantasyName: String,

    @Json(name = "Url")
    val url: String? = null,

    @Json(name = "DateRegistered")
    val dateRegistered: String,

    @Json(name = "DateUpdated")
    val dateUpdated: String? = null,

    @Json(name = "DateRemoved")
    val dateRemoved: String? = null,

    @Json(name = "IsRemoved")
    val isRemoved: Boolean
)
