// Example code that deserializes and serializes the model.
// extern crate serde;
// #[macro_use]
// extern crate serde_derive;
// extern crate serde_json;
//
// use generated_module::[object Object];
//
// fn main() {
//     let json = r#"{"answer": 42}"#;
//     let model: [object Object] = serde_json::from_str(&json).unwrap();
// }

extern crate serde_json;

pub type Bank = Vec<BankElement>;

#[derive(Serialize, Deserialize)]
pub struct BankElement {
    #[serde(rename = "COMPE")]
    pub compe: String,
    #[serde(rename = "ISPB")]
    pub ispb: String,
    #[serde(rename = "Document")]
    pub document: String,
    #[serde(rename = "FiscalName")]
    pub fiscal_name: String,
    #[serde(rename = "FantasyName")]
    pub fantasy_name: String,
    #[serde(rename = "Url")]
    pub url: Option<String>,
    #[serde(rename = "DateRegistered")]
    pub date_registered: String,
    #[serde(rename = "DateUpdated")]
    pub date_updated: Option<String>,
    #[serde(rename = "DateRemoved")]
    pub date_removed: Option<String>,
    #[serde(rename = "IsRemoved")]
    pub is_removed: bool,
}
