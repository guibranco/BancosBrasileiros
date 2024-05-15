class BankDTO {
  String _COMPE;
  String _ISPB;
  String _Document;
  String _LongName;
  String _ShortName;
  String _Network;
  String _Type;
  String _PixType;
  bool _Charge;
  bool _CreditDocument;
  bool _LegalCheque;
  bool _DetectaFlow;
  bool _Pcr;
  bool _Pcrp;

  String _SalaryPortability;
  List<String> _Products;
  String _Url;
  String _DateOperationStarted;
  String _DatePixStarted;
  String _DateRegistered;
  String _DateUpdated;

  BankDTO({
    String COMPE,
    String ISPB,
    String Document,
    String LongName,
    String ShortName,
    String Network,
    String Type,
    String PixType,
    bool Charge,
    bool CreditDocument,
    bool LegalCheque,
    bool DetectaFlow,
    bool Pcr,
    bool Pcrp,
    String SalaryPortability,
    List<String> Products,
    String Url,
    String DateOperationStarted,
    String DatePixStarted,
    String DateRegistered,
    String DateUpdated,
  }) {
    _COMPE = COMPE;
    _ISPB = ISPB;
    _Document = Document;
    _LongName = LongName;
    _ShortName = ShortName;
    _Network = Network;
    _Type = Type;
    _PixType = PixType;
    _Charge = Charge;
    _CreditDocument = CreditDocument;
    _LegalCheque = LegalCheque;
    _DetectaFlow = DetectaFlow;
    _Pcr = Pcr;
    _Pcrp = Pcrp;
    _SalaryPortability = SalaryPortability;
    _Products = Products;
    _Url = Url;
    _DateOperationStarted = DateOperationStarted;
    _DatePixStarted = DatePixStarted;
    _DateRegistered = DateRegistered;
    _DateUpdated = DateUpdated;
  }

  // Getter methods
  String get COMPE => _COMPE;
  String get ISPB => _ISPB;
  String get Document => _Document;
  String get LongName => _LongName;
  String get ShortName => _ShortName;
  String get Network => _Network;
  String get Type => _Type;
  String get PixType => _PixType;
  bool get Charge => _Charge;
  bool get CreditDocument => _CreditDocument;
  bool get LegalCheque => _LegalCheque;
  bool get DetectaFlow => _DetectaFlow;
  bool get Pcr => _Pcr;
  bool get Pcrp => _Pcrp;
  String get SalaryPortability => _SalaryPortability;
  List<String> get Products => _Products;
  String get Url => _Url;
  String get DateOperationStarted => _DateOperationStarted;
  String get DatePixStarted => _DatePixStarted;
  String get DateRegistered => _DateRegistered;
  String get DateUpdated => _DateUpdated;

  // Setter methods
  set COMPE(String value) => _COMPE = value;
  set ISPB(String value) => _ISPB = value;
  set Document(String value) => _Document = value;
  set LongName(String value) => _LongName = value;
  set ShortName(String value) => _ShortName = value;
  set Network(String value) => _Network = value;
  set Type(String value) => _Type = value;
  set PixType(String value) => _PixType = value;
  set Charge(bool value) => _Charge = value;
  set CreditDocument(bool value) => _CreditDocument = value;
  set LegalCheque(bool value) => _LegalCheque = value;
  set DetectaFlow(bool value) => _DetectaFlow = value;
  set Pcr(bool value) => _Pcr = value;
  set Pcrp(bool value) => _Pcrp = value;
  set SalaryPortability(String value) => _SalaryPortability = value;
  set Products(List<String> value) => _Products = value;
  set Url(String value) => _Url = value;
  set DateOperationStarted(String value) => _DateOperationStarted = value;
  set DatePixStarted(String value) => _DatePixStarted = value;
  set DateRegistered(String value) => _DateRegistered = value;
  set DateUpdated(String value) => _DateUpdated = value;

  Map<String, dynamic> toJson() {
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
      'Pcr': _Pcr,
      'Pcrp': _Pcrp,
      'SalaryPortability': _SalaryPortability,
      'Products': _Products,
      'Url': _Url,
      'DateOperationStarted': _DateOperationStarted,
      'DatePixStarted': _DatePixStarted,
      'DateRegistered': _DateRegistered,
      'DateUpdated': _DateUpdated,
    };
  }

  factory BankDTO.fromJson(Map<String, dynamic> json) {
    return BankDTO(
      COMPE: json['COMPE'],
      ISPB: json['ISPB'],
      Document: json['Document'],
      LongName: json['LongName'],
      ShortName: json['ShortName'],
      Network: json['Network'],
      Type: json['Type'],
      PixType: json['PixType'],
      Charge: json['Charge'],
      CreditDocument: json['CreditDocument'],
      LegalCheque: json['LegalCheque'],
      DetectaFlow: json['DetectaFlow'],
      Pcr: json['Pcr'],
      Pcrp: json['Pcrp'],
      SalaryPortability: json['SalaryPortability'],
      Products: List<String>.from(json['Products']),
      Url: json['Url'],
      DateOperationStarted: json['DateOperationStarted'],
      DatePixStarted: json['DatePixStarted'],
      DateRegistered: json['DateRegistered'],
      DateUpdated: json['DateUpdated'],
    );
  }
}
