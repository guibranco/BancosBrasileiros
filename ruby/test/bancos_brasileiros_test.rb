# frozen_string_literal: true

require "minitest/autorun"
require_relative "../lib/bancos_brasileiros"

class BancosBrasileirosTest < Minitest::Test
  def test_version
    refute_nil BancosBrasileiros::VERSION
  end

  def test_all_banks_loads_and_is_cached
    banks = BancosBrasileiros.all_banks
    refute_empty banks
    assert_same banks, BancosBrasileiros.all_banks
    assert banks.frozen?
    assert banks.first.frozen?
  end

  def test_every_bank_has_ispb_and_long_name
    BancosBrasileiros.all_banks.each do |bank|
      assert_match(/\A\d{8}\z/, bank["ISPB"])
      refute_empty bank["LongName"].to_s
    end
  end

  def test_find_bank_by_compe
    bank = BancosBrasileiros.find_bank_by_compe("001")
    assert_equal "00000000", bank["ISPB"]
    assert_equal bank, BancosBrasileiros.find_bank_by_compe(1)
    assert_equal bank, BancosBrasileiros.find_bank_by_compe("1")
    assert_nil BancosBrasileiros.find_bank_by_compe("abc")
  end

  def test_find_bank_by_codigo_compe_alias_kept_for_compatibility
    assert_equal BancosBrasileiros.find_bank_by_compe("001"),
                 BancosBrasileiros.find_bank_by_codigo_compe("001")
  end

  def test_find_bank_by_ispb
    bank = BancosBrasileiros.find_bank_by_ispb("00000000")
    assert_equal "001", bank["COMPE"]
    assert_equal bank, BancosBrasileiros.find_bank_by_ispb(0)
  end

  def test_find_bank_by_document
    bank = BancosBrasileiros.find_bank_by_document("00.000.000/0001-91")
    assert_equal "001", bank["COMPE"]
    assert_equal bank, BancosBrasileiros.find_bank_by_document("00000000000191")
    assert_nil BancosBrasileiros.find_bank_by_document("")
  end

  def test_filters
    rsfn = BancosBrasileiros.find_banks_by_network("RSFN")
    refute_empty rsfn
    assert(rsfn.all? { |b| b["Network"] == "RSFN" })

    multiplo = BancosBrasileiros.find_banks_by_type("Banco Múltiplo")
    refute_empty multiplo
    assert(multiplo.all? { |b| b["Type"] == "Banco Múltiplo" })

    drct = BancosBrasileiros.find_banks_by_pix_type("DRCT")
    refute_empty drct
    assert(drct.all? { |b| b["PixType"] == "DRCT" })
  end

  def test_search
    results = BancosBrasileiros.search("banco do brasil")
    assert(results.any? { |b| b["COMPE"] == "001" })
    assert_empty BancosBrasileiros.search("   ")
  end
end
