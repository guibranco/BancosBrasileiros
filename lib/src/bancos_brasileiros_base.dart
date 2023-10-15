import 'dart:convert';
import 'dart:io';
import 'bank_dto.dart'; // Import the BankDTO class you defined earlier.

class BancosData {
  static List<BankDTO> getBancos() {
    File file = File('assets/bancos.json');
    Iterable l = json.decode(file.readAsStringSync());
    List<BankDTO> bancos =
    List<BankDTO>.from(l.map((model) => BankDTO.fromJson(model)));
    return bancos;
  }
}

