import 'dart:convert';
import 'dart:io';

import 'package:bancos_brasileiros/bancos_brasileiros.dart';
import 'package:bancos_brasileiros/src/bank_dto.dart';
import 'package:test/test.dart';

void main() {

  bool areStringListsEqual(List<String?>? list1, List<String?>? list2) {
    if (list1 == null && list2 == null) {
      return true;
    }

    if (list1 == null || list2 == null) {
      return false;
    }

    if (list1.length != list2.length) {
      return false;
    }

    for (int i = 0; i < list1.length; i++) {
      if (list1[i] != list2[i]) {
        return false;
      }
    }

    return true;
  }

  bool areBankDTOsEqual(BankDTO dto1, BankDTO dto2) {
    // Compare each property of the BankDTO objects
    return dto1.COMPE == dto2.COMPE &&
        dto1.ISPB == dto2.ISPB &&
        dto1.Document == dto2.Document &&
        dto1.LongName == dto2.LongName &&
        dto1.ShortName == dto2.ShortName &&
        dto1.Network == dto2.Network &&
        dto1.Type == dto2.Type &&
        dto1.PixType == dto2.PixType &&
        dto1.Charge == dto2.Charge &&
        dto1.CreditDocument == dto2.CreditDocument &&
        dto1.LegalCheque == dto2.LegalCheque &&
        dto1.DetectaFlow == dto2.DetectaFlow &&
        dto1.Pcr == dto2.Pcr &&
        dto1.Pcrp == dto2.Pcrp &&
        dto1.SalaryPortability == dto2.SalaryPortability &&
        areStringListsEqual(dto1.Products, dto2.Products) &&
        dto1.Url == dto2.Url &&
        dto1.DateOperationStarted == dto2.DateOperationStarted &&
        dto1.DatePixStarted == dto2.DatePixStarted &&
        dto1.DateRegistered == dto2.DateRegistered &&
        dto1.DateUpdated == dto2.DateUpdated;
  }

  bool areListsEqual(List<BankDTO> list1, List<BankDTO> list2) {
    // Check if the lengths of the lists are equal
    if (list1.length != list2.length) {
      return false;
    }

    for (int i = 0; i < list1.length; i++) {
      if (!areBankDTOsEqual(list1[i], list2[i])) {
        return false;
      }
    }

    return true;
  }

  group('A group of tests', () {

    test('Bancos Test', () {
      File file = File('assets/bancos.json');
      Iterable l = json.decode(file.readAsStringSync());
      List<BankDTO> bancos =
      List<BankDTO>.from(l.map((model) => BankDTO.fromJson(model)));

      expect(areListsEqual(BancosData.getBancos(), bancos), true);
    });
  });
}
