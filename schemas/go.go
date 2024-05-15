// This file was generated from JSON Schema using quicktype, do not modify it directly.
// To parse and unparse this JSON data, add this code to your project and do:
//
//    bank, err := UnmarshalBank(bytes)
//    bytes, err = bank.Marshal()

package bancosBrasileiros

import (
	"encoding/json"
	"time"
)

type Bank []BankElement

func UnmarshalBank(data []byte) (Bank, error) {
	var r Bank
	err := json.Unmarshal(data, &r)
	return r, err
}

func (r *Bank) Marshal() ([]byte, error) {
	return json.Marshal(r)
}

type BankElement struct {
	Compe                string    `json:"COMPE"`
	Ispb                 string    `json:"ISPB"`
	Document             string    `json:"Document"`
	LongName             string    `json:"LongName"`
	ShortName            string    `json:"ShortName"`
	Network              string    `json:"Network"`
	Type                 string    `json:"Type"`
	PixType              string    `json:"PixType"`
	Charge               bool      `json:"Charge"`
	CreditDocument       bool      `json:"CreditDocument"`
	LegalCheque          bool      `json:"LegalCheque"`
	DetectaFlow          bool      `json:"DetectaFlow"`
	Pcr                  bool      `json:"Pcr"`
	Pcrp                 bool      `json:"Pcrp"`
	SalaryPortability    string    `json:"SalaryPortability"`
	Products             []string  `json:"Products"`
	URL                  string    `json:"Url"`
	DateOperationStarted string    `json:"DateOperationStarted"`
	DatePixStarted       string    `json:"DatePixStarted"`
	DateRegistered       string    `json:"DateRegistered"`
	DateUpdated          time.Time `json:"DateUpdated"`
}
