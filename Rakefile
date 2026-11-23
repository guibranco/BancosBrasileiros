# frozen_string_literal: true

require "rake/testtask"

Rake::TestTask.new(:test) do |t|
  t.libs << "ruby/lib"
  t.test_files = FileList["ruby/test/**/*_test.rb"]
end

desc "Build the bancos_brasileiros gem"
task :build do
  sh "gem build bancos_brasileiros.gemspec"
end

task default: :test
