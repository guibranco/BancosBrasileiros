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
    #[serde(rename = "LongName")]
    pub long_name: String,
    #[serde(rename = "ShortName")]
    pub short_name: String,
    #[serde(rename = "Network")]
    pub network: Option<String>,
    #[serde(rename = "Type")]
    pub type: Option<String>,
    #[serde(rename = "PixType")]
    pub pix_type: Option<String>,
    #[serde(rename = "Charge")]
    pub charge: bool,
    #[serde(rename = "CreditDocument")]
    pub credit_document: bool,
    #[serde(rename = "LegalCheque")]
    pub legal_cheque: bool,
    #[serde(rename = "DetectaFlow")]
    pub detecta_flow: bool,
    #[serde(rename = "SalaryPortability")]
    pub salary_portability: String,
    #[serde(rename = "Products")]
    pub products: Vec<String>,
    #[serde(rename = "Url")]
    pub url: Option<String>,
    #[serde(rename = "DateOperationStarted")]
    pub date_operation_started: String,
    #[serde(rename = "DatePixStarted")]
    pub date_pix_started: String,
    #[serde(rename = "DateRegistered")]
    pub date_registered: String,
    #[serde(rename = "DateUpdated")]
    pub date_updated: String,
}
