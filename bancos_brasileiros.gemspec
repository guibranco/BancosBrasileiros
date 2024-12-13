Gem::Specification.new do |spec|
  spec.name          = "bancos_brasileiros"
  spec.version       = "0.1.0"
  spec.summary       = "A Ruby gem for Brazilian banks information."
  spec.description   = "This gem provides information about Brazilian banks, including codes and other relevant data."
  spec.authors       = ["Elton Santos"]
  spec.email         = ["elton@example.com"]
  spec.files         = Dir["lib/**/*", "data/**/*"]
  spec.homepage      = "https://github.com/eltonsantos/bancos_brasileiros"
  spec.license       = "MIT"
  spec.required_ruby_version = ">= 2.5"
  spec.metadata["homepage_uri"] = spec.homepage
  spec.metadata["source_code_uri"] = spec.homepage
  spec.metadata["changelog_uri"] = "https://github.com/eltonsantos/bancos_brasileiros/CHANGELOG.md"
  spec.metadata["bug_tracker_uri"] = "https://github.com/eltonsantos/bancos_brasileiros/issues"
end
