# frozen_string_literal: true

require_relative "ruby/lib/bancos_brasileiros_data/version"

Gem::Specification.new do |spec|
  spec.name = "bancos_brasileiros_data"
  spec.version = BancosBrasileiros::VERSION
  spec.authors = ["Guilherme Branco Stracini", "Elton Santos"]
  spec.email = ["opensource@straccini.com"]

  spec.summary = "🇧🇷 🏦 📋 Brazilian commercial banks list"
  spec.description = "Brazilian commercial banks list (COMPE, ISPB, CNPJ, PIX and more), " \
                     "updated daily from official sources."
  spec.homepage = "https://github.com/guibranco/BancosBrasileiros"
  spec.license = "Unlicense"
  spec.required_ruby_version = ">= 2.6.0"

  spec.metadata = {
    "homepage_uri" => spec.homepage,
    "source_code_uri" => "https://github.com/guibranco/BancosBrasileiros",
    "changelog_uri" => "https://github.com/guibranco/BancosBrasileiros/blob/main/CHANGELOG.md",
    "bug_tracker_uri" => "https://github.com/guibranco/BancosBrasileiros/issues",
    "rubygems_mfa_required" => "true"
  }

  spec.files = Dir[
    "ruby/lib/**/*.rb",
    "data/bancos.json",
    "README.md",
    "LICENSE"
  ]
  spec.require_paths = ["ruby/lib"]
end
