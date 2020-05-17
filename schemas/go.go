// This file was generated from JSON Schema using quicktype, do not modify it directly.
// To parse and unparse this JSON data, add this code to your project and do:
//
//    bank, err := UnmarshalBank(bytes)
//    bytes, err = bank.Marshal()

package bancosBrasileiros

import "encoding/json"

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
	Compe          string  `json:"COMPE"`         
	Ispb           string  `json:"ISPB"`          
	Document       string  `json:"Document"`      
	FiscalName     string  `json:"FiscalName"`    
	FantasyName    string  `json:"FantasyName"`   
	URL            *string `json:"Url"`           
	DateRegistered string  `json:"DateRegistered"`
	DateUpdated    *string `json:"DateUpdated"`   
	DateRemoved    *string `json:"DateRemoved"`   
	IsRemoved      bool    `json:"IsRemoved"`     
}
