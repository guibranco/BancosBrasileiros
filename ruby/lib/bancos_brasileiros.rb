# frozen_string_literal: true

require "json"
require_relative "bancos_brasileiros/version"

# Brazilian commercial banks list, backed by data/bancos.json.
#
# Every bank is returned as a frozen Hash using the same keys as the JSON
# file ("COMPE", "ISPB", "Document", "LongName", "ShortName", ...).
module BancosBrasileiros
  DATA_PATH = File.expand_path("../../data/bancos.json", __dir__)

  class << self
    # All banks, parsed once and cached.
    def all_banks
      @all_banks ||= load_data
    end

    # Parses data/bancos.json (which starts with a UTF-8 BOM).
    def load_data
      deep_freeze(JSON.parse(File.read(DATA_PATH, mode: "r:bom|utf-8")))
    end

    # Finds a bank by its COMPE code. Accepts "1", "001" or 1.
    def find_bank_by_compe(compe)
      code = compe.to_s.strip.rjust(3, "0")
      all_banks.find { |bank| bank["COMPE"] == code }
    end
    alias find_bank_by_codigo_compe find_bank_by_compe

    # Finds a bank by its ISPB code. Accepts "0", "00000000" or 0.
    def find_bank_by_ispb(ispb)
      code = ispb.to_s.strip.rjust(8, "0")
      all_banks.find { |bank| bank["ISPB"] == code }
    end

    # Finds a bank by its CNPJ, with or without punctuation.
    def find_bank_by_document(document)
      digits = document.to_s.gsub(/\D/, "")
      return nil if digits.empty?

      all_banks.find { |bank| bank["Document"].to_s.gsub(/\D/, "") == digits }
    end

    def find_banks_by_network(network)
      all_banks.select { |bank| bank["Network"] == network }
    end

    def find_banks_by_type(bank_type)
      all_banks.select { |bank| bank["Type"] == bank_type }
    end

    def find_banks_by_pix_type(pix_type)
      all_banks.select { |bank| bank["PixType"] == pix_type }
    end

    # Case-insensitive search on LongName and ShortName.
    def search(term)
      needle = term.to_s.strip.downcase
      return [] if needle.empty?

      all_banks.select do |bank|
        bank["LongName"].to_s.downcase.include?(needle) ||
          bank["ShortName"].to_s.downcase.include?(needle)
      end
    end

    private

    def deep_freeze(value)
      case value
      when Hash then value.each_value { |v| deep_freeze(v) }
      when Array then value.each { |v| deep_freeze(v) }
      end
      value.freeze
    end
  end
end
