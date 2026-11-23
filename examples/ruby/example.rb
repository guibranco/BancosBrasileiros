# frozen_string_literal: true

# Usage:
#   gem install bancos_brasileiros
#   ruby examples/ruby/example.rb
#
# To run against the code in this repository instead of the published gem:
#   ruby -Iruby/lib examples/ruby/example.rb

require "bancos_brasileiros"

puts "Total banks: #{BancosBrasileiros.all_banks.size}"

itau = BancosBrasileiros.find_bank_by_compe(341)
puts "COMPE 341: #{itau['LongName']} (ISPB #{itau['ISPB']}, CNPJ #{itau['Document']})"

bb = BancosBrasileiros.find_bank_by_document("00.000.000/0001-91")
puts "CNPJ 00.000.000/0001-91: #{bb['ShortName']}"

direct_pix = BancosBrasileiros.find_banks_by_pix_type("DRCT")
puts "Direct PIX participants: #{direct_pix.size}"

puts "Search 'caixa':"
BancosBrasileiros.search("caixa").first(5).each do |bank|
  puts "  #{bank['COMPE'] || '---'} #{bank['LongName']}"
end
