class BankDTO {
  String? _COMPE;
  String? _ISPB;
  String? _Document;
  String? _LongName;
  String? _ShortName;
  String? _Network;
  String? _Type;
  String? _PixType;
  bool? _Charge;
  bool? _CreditDocument;
  bool? _LegalCheque;
  bool? _DetectaFlow;
  String? _SalaryPortability;
  List<String?>? _Products;
  String? _Url;
  String? _DateOperationStarted;
  String? _DatePixStarted;
  String? _DateRegistered;
  String? _DateUpdated;

  BankDTO(
      this._COMPE,
      this._ISPB,
      this._Document,
      this._LongName,
      this._ShortName,
      this._Network,
      this._Type,
      this._PixType,
      this._Charge,
      this._CreditDocument,
      this._LegalCheque,
      this._DetectaFlow,
      this._SalaryPortability,
      this._Products,
      this._Url,
      this._DateOperationStarted,
      this._DatePixStarted,
      this._DateRegistered,
      this._DateUpdated);

  // Getter methods
  String? get COMPE => _COMPE;

  String? get ISPB => _ISPB;

  String? get Document => _Document;

  String? get LongName => _LongName;

  String? get ShortName => _ShortName;

  String? get Network => _Network;

  String? get Type => _Type;

  String? get PixType => _PixType;

  bool? get Charge => _Charge;

  bool? get CreditDocument => _CreditDocument;

  bool? get LegalCheque => _LegalCheque;

  bool? get DetectaFlow => _DetectaFlow;

  String? get SalaryPortability => _SalaryPortability;

  List<String?>? get Products => _Products;

  String? get Url => _Url;

  String? get DateOperationStarted => _DateOperationStarted;

  String? get DatePixStarted => _DatePixStarted;

  String? get DateRegistered => _DateRegistered;

  String? get DateUpdated => _DateUpdated;

  // Setter methods
  set COMPE(String? value) => _COMPE = value;

  set ISPB(String? value) => _ISPB = value;

  set Document(String? value) => _Document = value;

  set LongName(String? value) => _LongName = value;

  set ShortName(String? value) => _ShortName = value;

  set Network(String? value) => _Network = value;

  set Type(String? value) => _Type = value;

  set PixType(String? value) => _PixType = value;

  set Charge(bool? value) => _Charge = value;

  set CreditDocument(bool? value) => _CreditDocument = value;

  set LegalCheque(bool? value) => _LegalCheque = value;

  set DetectaFlow(bool? value) => _DetectaFlow = value;

  set SalaryPortability(String? value) => _SalaryPortability = value;

  set Products(List<String?>? value) => _Products = value;

  set Url(String? value) => _Url = value;

  set DateOperationStarted(String? value) => _DateOperationStarted = value;

  set DatePixStarted(String? value) => _DatePixStarted = value;

  set DateRegistered(String? value) => _DateRegistered = value;

  set DateUpdated(String? value) => _DateUpdated = value;

  Map<String?, dynamic> toJson() {
    return {
      'COMPE': _COMPE,
      'ISPB': _ISPB,
      'Document': _Document,
      'LongName': _LongName,
      'ShortName': _ShortName,
      'Network': _Network,
      'Type': _Type,
      'PixType': _PixType,
      'Charge': _Charge,
      'CreditDocument': _CreditDocument,
      'LegalCheque': _LegalCheque,
      'DetectaFlow': _DetectaFlow,
      'SalaryPortability': _SalaryPortability,
      'Products': _Products,
      'Url': _Url,
      'DateOperationStarted': _DateOperationStarted,
      'DatePixStarted': _DatePixStarted,
      'DateRegistered': _DateRegistered,
      'DateUpdated': _DateUpdated,
    };
  }

  factory BankDTO.fromJson(Map<String?, dynamic> json) {
    return BankDTO(
      json['COMPE'],
      json['ISPB'],
      json['Document'],
      json['LongName'],
      json['ShortName'],
      json['Network'],
      json['Type'],
      json['PixType'],
      json['Charge'],
      json['CreditDocument'],
      json['LegalCheque'],
      json['DetectaFlow'],
      json['SalaryPortability'],
      List<String?>.from(json['Products'] ?? []),
      json['Url'],
      json['DateOperationStarted'],
      json['DatePixStarted'],
      json['DateRegistered'],
      json['DateUpdated'],
    );
  }

  @override
  String toString() {
    return '{'
        '"COMPE": "$COMPE", '
        '"ISPB": "$ISPB", '
        '"Document": "$Document", '
        '"LongName": "$LongName", '
        '"ShortName": "$ShortName", '
        '"Network": "$Network", '
        '"Type": "$Type", '
        '"PixType": "$PixType", '
        '"Charge": $Charge, '
        '"CreditDocument": $CreditDocument, '
        '"LegalCheque": $LegalCheque, '
        '"DetectaFlow": $DetectaFlow, '
        '"SalaryPortability": "$SalaryPortability", '
        '"Products": ${_listToJson(Products)}, '
        '"Url": "$Url", '
        '"DateOperationStarted": "$DateOperationStarted", '
        '"DatePixStarted": "$DatePixStarted", '
        '"DateRegistered": "$DateRegistered", '
        '"DateUpdated": "$DateUpdated"'
        '}';
  }

  String _listToJson(List<String?>? list) {
    if (list == null) {
      return '';
    }
    return '[${list.map((item) => '"$item"').join(', ')}]';
  }

}
